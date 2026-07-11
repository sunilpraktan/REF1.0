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
using Reflection.Presentation.Services;
using System.Collections.ObjectModel;
using Reflection.BusinessEntity.VMS;
using Reflection.BusinessEntity;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using System.Windows.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using System.Windows;
using Reflection.ReportingServices;
using System.Collections.Specialized;
using Reflection.Presentation.Services.Convertors;

namespace Reflection.Modules.VMS.ViewModels
{
    public class VMS_T001_VM : WorkspaceViewModel<VMS_T001>
    {
        bool isNewRecord = true;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        WebServiceRepository<VMS_T001> repository = new WebServiceRepository<VMS_T001>();
        WebServiceRepository<MultipleContext_VMS_T001> repository_MC = new WebServiceRepository<MultipleContext_VMS_T001>();
        WebServiceRepository<MultipleContext_VMS_T001> repository_MCTemp = new WebServiceRepository<MultipleContext_VMS_T001>();
        WebServiceRepository<MultipleContext_VMS_T001> repository_MCTemp1 = new WebServiceRepository<MultipleContext_VMS_T001>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(VMS_T001_VM));
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
        private AutoSuggestTextViewModel<dynamic> _ASDefaultMat { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefaultMat
        {
            get { return _ASDefaultMat; }
            set
            {
                if (_ASDefaultMat != value)
                {
                    _ASDefaultMat = value; RaisePropertyChanged("ASDefaultMat");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASDefaultDoc { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefaultDoc
        {
            get { return _ASDefaultDoc; }
            set
            {
                if (_ASDefaultDoc != value)
                {
                    _ASDefaultDoc = value; RaisePropertyChanged("ASDefaultDoc");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASDefaultHost { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefaultHost
        {
            get { return _ASDefaultHost; }
            set
            {
                if (_ASDefaultHost != value)
                {
                    _ASDefaultHost = value; RaisePropertyChanged("ASDefaultHost");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASDefaultFacility { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefaultFacility
        {
            get { return _ASDefaultFacility; }
            set
            {
                if (_ASDefaultFacility != value)
                {
                    _ASDefaultFacility = value; RaisePropertyChanged("ASDefaultFacility");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASMasterEntity { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASMasterEntity
        {
            get { return _ASMasterEntity; }
            set
            {
                if (_ASMasterEntity != value)
                {
                    _ASMasterEntity = value; RaisePropertyChanged("ASMasterEntity");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASSalutation { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSalutation
        {
            get { return _ASSalutation; }
            set
            {
                if (_ASSalutation != value)
                {
                    _ASSalutation = value; RaisePropertyChanged("ASSalutation");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASVCategory { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASVCategory
        {
            get { return _ASVCategory; }
            set
            {
                if (_ASVCategory != value)
                {
                    _ASVCategory = value; RaisePropertyChanged("ASVCategory");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASVCountry { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASVCountry
        {
            get { return _ASVCountry; }
            set
            {
                if (_ASVCountry != value)
                {
                    _ASVCountry = value; RaisePropertyChanged("ASVCountry");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASVState { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASVState
        {
            get { return _ASVState; }
            set
            {
                if (_ASVState != value)
                {
                    _ASVState = value; RaisePropertyChanged("ASVState");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASVNation { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASVNation
        {
            get { return _ASVNation; }
            set
            {
                if (_ASVNation != value)
                {
                    _ASVNation = value; RaisePropertyChanged("ASVNation");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASVCompany { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASVCompany
        {
            get { return _ASVCompany; }
            set
            {
                if (_ASVCompany != value)
                {
                    _ASVCompany = value; RaisePropertyChanged("ASVCompany");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASVPurpose { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASVPurpose
        {
            get { return _ASVPurpose; }
            set
            {
                if (_ASVPurpose != value)
                {
                    _ASVPurpose = value; RaisePropertyChanged("ASVPurpose");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASGateNo { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASGateNo
        {
            get { return _ASGateNo; }
            set
            {
                if (_ASGateNo != value)
                {
                    _ASGateNo = value; RaisePropertyChanged("ASGateNo");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASMeetingPlace { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASMeetingPlace
        {
            get { return _ASMeetingPlace; }
            set
            {
                if (_ASMeetingPlace != value)
                {
                    _ASMeetingPlace = value; RaisePropertyChanged("ASMeetingPlace");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASMatCat { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASMatCat
        {
            get { return _ASMatCat; }
            set
            {
                if (_ASMatCat != value)
                {
                    _ASMatCat = value; RaisePropertyChanged("ASMatCat");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASMatType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASMatType
        {
            get { return _ASMatType; }
            set
            {
                if (_ASMatType != value)
                {
                    _ASMatType = value; RaisePropertyChanged("ASMatType");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASDocument { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDocument
        {
            get { return _ASDocument; }
            set
            {
                if (_ASDocument != value)
                {
                    _ASDocument = value; RaisePropertyChanged("ASDocument");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASHEmployee { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASHEmployee
        {
            get { return _ASHEmployee; }
            set
            {
                if (_ASHEmployee != value)
                {
                    _ASHEmployee = value; RaisePropertyChanged("ASHEmployee");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASFacility { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASFacility
        {
            get { return _ASFacility; }
            set
            {
                if (_ASFacility != value)
                {
                    _ASFacility = value; RaisePropertyChanged("ASFacility");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASGuestHouse { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASGuestHouse
        {
            get { return _ASGuestHouse; }
            set
            {
                if (_ASGuestHouse != value)
                {
                    _ASGuestHouse = value; RaisePropertyChanged("ASGuestHouse");
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
                    if (SourceName == "MaterialCategory")
                    { ASDefaultMat = ASMatCat; }
                    else if (SourceName == "MaterialType")
                    { ASDefaultMat = ASMatType; }
                    else if (SourceName == "DocumentType")
                    { ASDefaultDoc = ASDocument; }
                    else if (SourceName == "HEmployee")
                    { ASDefaultHost = ASHEmployee; }
                    else if (SourceName == "Facility")
                    { ASDefaultFacility = ASFacility; }                    
                }
            }
        }

        #endregion

        #region Declarations

        private MultipleContext_VMS_T001 _MC;
        public MultipleContext_VMS_T001 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_VMS_T001 _MCTemp;
        public MultipleContext_VMS_T001 MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private MultipleContext_VMS_T001 _MCTemp1;
        public MultipleContext_VMS_T001 MCTemp1
        {
            get { return _MCTemp1; }
            set { _MCTemp1 = value; RaisePropertyChanged("MCTemp1"); }
        }

        private VMS_T001 _MasterEntity;
        public VMS_T001 MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }

        private ObservableCollection<VMS_T001_A> _DetailEntity_A;
        public ObservableCollection<VMS_T001_A> DetailEntity_A
        {
            get { return _DetailEntity_A; }
            set
            {
                if (_DetailEntity_A != value)
                {
                    _DetailEntity_A = value;
                    RaisePropertyChanged("DetailEntity_A");
                }
            }
        }

        private ObservableCollection<VMS_T001_B> _DetailEntity_B;
        public ObservableCollection<VMS_T001_B> DetailEntity_B
        {
            get { return _DetailEntity_B; }
            set
            {
                if (_DetailEntity_B != value)
                {
                    _DetailEntity_B = value;
                    DetailEntity_B.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForAddVisitor);
                    RaisePropertyChanged("DetailEntity_B");
                }
            }
        }

        private ObservableCollection<VMS_T001_C> _DetailEntity_C;
        public ObservableCollection<VMS_T001_C> DetailEntity_C
        {
            get { return _DetailEntity_C; }
            set
            {
                if (_DetailEntity_C != value)
                {
                    _DetailEntity_C = value;
                    DetailEntity_C.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForVehicle);
                    RaisePropertyChanged("DetailEntity_C");
                }
            }
        }

        private ObservableCollection<VMS_T001_D> _DetailEntity_D;
        public ObservableCollection<VMS_T001_D> DetailEntity_D
        {
            get { return _DetailEntity_D; }
            set
            {
                if (_DetailEntity_D != value)
                {
                    _DetailEntity_D = value;
                    RaisePropertyChanged("DetailEntity_D");
                }
            }
        }

        private ObservableCollection<VMS_T001_E> _DetailEntity_E;
        public ObservableCollection<VMS_T001_E> DetailEntity_E
        {
            get { return _DetailEntity_E; }
            set
            {
                if (_DetailEntity_E != value)
                {
                    _DetailEntity_E = value;
                    RaisePropertyChanged("DetailEntity_E");
                }
            }
        }

        private ObservableCollection<VMS_M004_A> _DetailEntity_X;
        public ObservableCollection<VMS_M004_A> DetailEntity_X
        {
            get { return _DetailEntity_X; }
            set
            {
                if (_DetailEntity_X != value)
                {
                    _DetailEntity_X = value;
                    RaisePropertyChanged("DetailEntity_X");
                }
            }
        }

        private List<VMS_T001_BackFlip> _FlipGridData;
        public List<VMS_T001_BackFlip> FlipGridData
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

        public List<VMS_M007_P> _DetailListForPopupMatCat;
        public List<VMS_M007_P> DetailListForPopupMatCat
        {
            get
            {
                return _DetailListForPopupMatCat;
            }
            set
            {
                _DetailListForPopupMatCat = value;
                RaisePropertyChanged("DetailListForPopupMatCat");
            }
        }

        public List<VMS_M008_P> _DetailListForPopupMatType;
        public List<VMS_M008_P> DetailListForPopupMatType
        {
            get
            {
                return _DetailListForPopupMatType;
            }
            set
            {
                _DetailListForPopupMatType = value;
                RaisePropertyChanged("DetailListForPopupMatType");
            }
        }

        public List<VMS_M006_P> _DetailListForPopupDocument;
        public List<VMS_M006_P> DetailListForPopupDocument
        {
            get
            {
                return _DetailListForPopupDocument;
            }
            set
            {
                _DetailListForPopupDocument = value;
                RaisePropertyChanged("DetailListForPopupDocument");
            }
        }

        public List<ADM_M024_P> _DetailListForPopupHEmp;
        public List<ADM_M024_P> DetailListForPopupHEmp
        {
            get
            {
                return _DetailListForPopupHEmp;
            }
            set
            {
                _DetailListForPopupHEmp = value;
                RaisePropertyChanged("DetailListForPopupHEmp");
            }
        }

        public List<VMS_M004_P> _DetailListForPopupFacility;
        public List<VMS_M004_P> DetailListForPopupFacility
        {
            get
            {
                return _DetailListForPopupFacility;
            }
            set
            {
                _DetailListForPopupFacility = value;
                RaisePropertyChanged("DetailListForPopupFacility");
            }
        }
        
        private int _dgSelectedIndexAddVisitor;
        public int dgSelectedIndexAddVisitor
        {
            get
            { return _dgSelectedIndexAddVisitor; }
            set
            {
                if (_dgSelectedIndexAddVisitor != value)
                {
                    _dgSelectedIndexAddVisitor = value;
                    RaisePropertyChanged("dgSelectedIndexAddVisitor");
                }
            }
        }

        private int _dgSelectedIndexMaterial;
        public int dgSelectedIndexMaterial
        {
            get
            { return _dgSelectedIndexMaterial; }
            set
            {
                if (_dgSelectedIndexMaterial != value)
                {
                    _dgSelectedIndexMaterial = value;
                    RaisePropertyChanged("dgSelectedIndexMaterial");
                }
            }
        }

        private int _dgSelectedIndexDocument;
        public int dgSelectedIndexDocument
        {
            get
            { return _dgSelectedIndexDocument; }
            set
            {
                if (_dgSelectedIndexDocument != value)
                {
                    _dgSelectedIndexDocument = value;
                    RaisePropertyChanged("dgSelectedIndexDocument");
                }
            }
        }

        private int _dgSelectedIndexAddHost;
        public int dgSelectedIndexAddHost
        {
            get
            { return _dgSelectedIndexAddHost; }
            set
            {
                if (_dgSelectedIndexAddHost != value)
                {
                    _dgSelectedIndexAddHost = value;
                    RaisePropertyChanged("dgSelectedIndexAddHost");
                }
            }
        }

        private int _dgSelectedIndexFacility;
        public int dgSelectedIndexFacility
        {
            get
            { return _dgSelectedIndexFacility; }
            set
            {
                if (_dgSelectedIndexFacility != value)
                {
                    _dgSelectedIndexFacility = value;
                    RaisePropertyChanged("dgSelectedIndexFacility");
                }
            }
        }

        private int _dgSelectedIndexVehicle;
        public int dgSelectedIndexVehicle
        {
            get
            { return _dgSelectedIndexVehicle; }
            set
            {
                if (_dgSelectedIndexVehicle != value)
                {
                    _dgSelectedIndexVehicle = value;
                    RaisePropertyChanged("dgSelectedIndexVehicle");
                }
            }
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
        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> CmdAddSalutation { get; private set; }       
        public RelayCommand<object> CmdAddVCategory { get; private set; }
        public RelayCommand<object> CmdAddGateNo { get; private set; }
        public RelayCommand<object> CmdAddVCompany { get; private set; }
        public RelayCommand<object> CmdAddVPurpose { get; private set; }
        public RelayCommand<object> CmdAddMeetingPlace { get; private set; }
        public RelayCommand<object> CmdAddVNation { get; private set; }
        public RelayCommand<object> CmdAddVCountry { get; private set; }
        public RelayCommand<object> CmdAddVState { get; private set; }
        public RelayCommand<object> CmdAddMatCat { get; private set; }
        public RelayCommand<object> CmdAddMatType { get; private set; }
        public RelayCommand<object> CmdAddDocument { get; private set; }
        public RelayCommand<object> CmdAddHEmployee { get; private set; }
        public RelayCommand<object> CmdAddFacility { get; private set; }
        public RelayCommand<object> CmdAddGuestHouse { get; private set; }        
        public RelayCommand<object> cmdDeleteDataGridRowMaterial { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowAddVisitor { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowVehicleInfo { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowAddHost { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowDocument { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowFacilityDetail { get; private set; }

        public GalaSoft.MvvmLight.Command.RelayCommand CmdLoadVisitorValidData { get; private set; }

        #endregion

        #region Event Handler
        private void CollectionChangedNotifyForAddVisitor(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (VMS_T001_B item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (VMS_T001_B item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (VMS_T001_B item in e.NewItems)
                    {
                        //item.inst_code = MasterEntity.inst_code;
                        //item.valid_from = MasterEntity.cal_lastdate;
                        //item.valid_to = MasterEntity.due_date;
                        item.active = true;
                        item.add_by = AppSessionState.UserID;
                        item.comp_code = AppSessionState.comp_code;
                        item.location_Id = AppSessionState.location_Id;
                        item.edit_by = AppSessionState.UserID;
                        item.user_source1 = AppSessionState.UserSource1;
                        item.user_source2 = AppSessionState.UserSource2;
                        item.PropertyChanged += EntityViewModelPropertyChanged;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void CollectionChangedNotifyForVehicle(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (VMS_T001_C item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (VMS_T001_C item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (VMS_T001_C item in e.NewItems)
                    {
                        //item.inst_code = MasterEntity.inst_code;
                        //item.valid_from = MasterEntity.cal_lastdate;
                        //item.valid_to = MasterEntity.due_date;
                        item.active = true;
                        item.add_by = AppSessionState.UserID;
                        item.comp_code = AppSessionState.comp_code;
                        item.location_Id = AppSessionState.location_Id;
                        item.edit_by = AppSessionState.UserID;
                        item.user_source1 = AppSessionState.UserSource1;
                        item.user_source2 = AppSessionState.UserSource2;
                        item.PropertyChanged += EntityViewModelPropertyChanged;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (DetailEntity_B.Count > dgSelectedIndexAddVisitor && dgSelectedIndexAddVisitor >= 0)
            {
                this.ErrorExist = false;
            }
            else if (DetailEntity_C.Count > dgSelectedIndexVehicle && dgSelectedIndexVehicle >= 0)
            {
                this.ErrorExist = false;
            }
        }
        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false; /*MasterEntity.HasErrors;*/
            if (DetailEntity_B.Count > dgSelectedIndexAddVisitor && dgSelectedIndexAddVisitor >= 0)
            {
                this.ErrorExist = false;
            }
            else if (DetailEntity_C.Count > dgSelectedIndexVehicle && dgSelectedIndexVehicle >= 0)
            {
                this.ErrorExist = false;
            }
        }

        #endregion

        #region Constructor
        public VMS_T001_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new VMS_T001();
            DetailEntity_A = new ObservableCollection<VMS_T001_A>();
            DetailEntity_B = new ObservableCollection<VMS_T001_B>();            
            DetailEntity_C = new ObservableCollection<VMS_T001_C>();
            DetailEntity_D = new ObservableCollection<VMS_T001_D>();
            DetailEntity_E = new ObservableCollection<VMS_T001_E>();
            DetailEntity_X = new ObservableCollection<VMS_M004_A>();
            MC = new MultipleContext_VMS_T001();
            MCTemp = new MultipleContext_VMS_T001();
            MCTemp1 = new MultipleContext_VMS_T001();

            //ADM_M028_G.ModelEntityUpdated += new EventHandler(ModelUpdated_Detail);

            CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
            CmdAddSalutation = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalutation(items); });
            CmdAddVCategory = new RelayCommand<object>(items => { if (items == null) { return; } InsertVCategory(items); });
            CmdAddVCompany = new RelayCommand<object>(items => { if (items == null) { return; } InsertVCompany(items); });
            CmdAddVPurpose = new RelayCommand<object>(items => { if (items == null) { return; } InsertVPurpose(items); });
            CmdAddGateNo = new RelayCommand<object>(items => { if (items == null) { return; } InsertGateNo(items); });
            CmdAddMeetingPlace = new RelayCommand<object>(items => { if (items == null) { return; } InsertMeetingPlace(items); });
            CmdAddVNation = new RelayCommand<object>(items => { if (items == null) { return; } InsertVNation(items); });
            CmdAddVCountry = new RelayCommand<object>(items => { if (items == null) { return; } InsertVCountry(items); });
            CmdAddVState = new RelayCommand<object>(items => { if (items == null) { return; } InsertVState(items); });           
            CmdAddMatCat = new RelayCommand<object>(items => { if (items == null) { return; } InsertMatCat(items, true, true, true); });
            CmdAddMatType = new RelayCommand<object>(items => { if (items == null) { return; } InsertMatType(items, true, true, true); });
            CmdAddDocument = new RelayCommand<object>(items => { if (items == null) { return; } InsertDocument(items, true, true, true); });
            CmdAddHEmployee = new RelayCommand<object>(items => { if (items == null) { return; } InsertHEmployee(items, true, true, true); });
            CmdAddFacility = new RelayCommand<object>(items => { if (items == null) { return; } InsertFacility(items, true, true, true); });
            CmdAddGuestHouse = new RelayCommand<object>(items => { if (items == null) { return; } InsertGuestHouse(items); });
            cmdDeleteDataGridRowMaterial = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRowDetail_A(items); });
            cmdDeleteDataGridRowAddVisitor = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRowDetail_B(items); });
            cmdDeleteDataGridRowVehicleInfo = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRowDetail_C(items); });
            cmdDeleteDataGridRowAddHost = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRowDetail_D(items); });
            cmdDeleteDataGridRowDocument = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRowDetail_E(items); });
            cmdDeleteDataGridRowFacilityDetail = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRowDetail_X(items); });

            CmdLoadVisitorValidData = new GalaSoft.MvvmLight.Command.RelayCommand(() => { LoadVisitorValidData(); });

            LoadInitialData();
            if (AppSessionState.TransValue != null)
            {
                LoadDocumentByDocumentNumber(AppSessionState.TransValue, "AppointmentID");
                AppSessionState.TransValue = null;
                AppSessionState.TransParameter = null;
                AppSessionState.ViewOtherRecordAllowed = true;
            }
        }
        public VMS_T001_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new VMS_T001();
            DetailEntity_A = new ObservableCollection<VMS_T001_A>();
            DetailEntity_B = new ObservableCollection<VMS_T001_B>();
            DetailEntity_C = new ObservableCollection<VMS_T001_C>();
            DetailEntity_D = new ObservableCollection<VMS_T001_D>();
            DetailEntity_E = new ObservableCollection<VMS_T001_E>();
            DetailEntity_X = new ObservableCollection<VMS_M004_A>();
            MC = new MultipleContext_VMS_T001();
            MCTemp = new MultipleContext_VMS_T001();
            MCTemp1 = new MultipleContext_VMS_T001();

            //ADM_M028_G.ModelEntityUpdated += new EventHandler(ModelUpdated_Detail);

            CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
            CmdAddSalutation = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalutation(items); });
            CmdAddVCategory = new RelayCommand<object>(items => { if (items == null) { return; } InsertVCategory(items); });
            CmdAddVCompany = new RelayCommand<object>(items => { if (items == null) { return; } InsertVCompany(items); });
            CmdAddVPurpose = new RelayCommand<object>(items => { if (items == null) { return; } InsertVPurpose(items); });
            CmdAddGateNo = new RelayCommand<object>(items => { if (items == null) { return; } InsertGateNo(items); });
            CmdAddMeetingPlace = new RelayCommand<object>(items => { if (items == null) { return; } InsertMeetingPlace(items); });
            CmdAddVNation = new RelayCommand<object>(items => { if (items == null) { return; } InsertVNation(items); });
            CmdAddVCountry = new RelayCommand<object>(items => { if (items == null) { return; } InsertVCountry(items); });
            CmdAddVState = new RelayCommand<object>(items => { if (items == null) { return; } InsertVState(items); });
            CmdAddMatCat = new RelayCommand<object>(items => { if (items == null) { return; } InsertMatCat(items, true, true, true); });
            CmdAddMatType = new RelayCommand<object>(items => { if (items == null) { return; } InsertMatType(items, true, true, true); });
            CmdAddDocument = new RelayCommand<object>(items => { if (items == null) { return; } InsertDocument(items, true, true, true); });
            CmdAddHEmployee = new RelayCommand<object>(items => { if (items == null) { return; } InsertHEmployee(items, true, true, true); });
            CmdAddFacility = new RelayCommand<object>(items => { if (items == null) { return; } InsertFacility(items, true, true, true); });
            CmdAddGuestHouse = new RelayCommand<object>(items => { if (items == null) { return; } InsertGuestHouse(items); });
            cmdDeleteDataGridRowMaterial = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRowDetail_A(items); });
            cmdDeleteDataGridRowAddVisitor = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRowDetail_B(items); });
            cmdDeleteDataGridRowVehicleInfo = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRowDetail_C(items); });
            cmdDeleteDataGridRowAddHost = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRowDetail_D(items); });
            cmdDeleteDataGridRowDocument = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRowDetail_E(items); });
            cmdDeleteDataGridRowFacilityDetail = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRowDetail_X(items); });

            CmdLoadVisitorValidData = new GalaSoft.MvvmLight.Command.RelayCommand(() => { LoadVisitorValidData(); });

            LoadInitialData();
            if (AppSessionState.TransValue != null && AppSessionState.TransactionCode == "")
            {
                LoadDocumentByDocumentNumber(AppSessionState.TransValue, "AppointmentID");
                AppSessionState.TransValue = null;
                AppSessionState.TransParameter = null;
                AppSessionState.ViewOtherRecordAllowed = true;
            }
        }
        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.location_Id.ToString() + "!@" + AppSessionState.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_VMS_T001>(MC, Request, "AppointmentByHost", "VMS", "LoadInitialData", 0, "");

                FlipGridData = MC.BackFlipEntity;
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((VMS_M007_P)x).m_cat_code ?? "");
                TheFilter = (o, prefix) => (((VMS_M007_P)o).m_cat_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((VMS_M007_P)o).m_cat_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefaultMat = new AutoSuggestTextViewModel<dynamic>(MC.VMaterialCategory, TheFilter, SuggestedValue, "m_cat_code", "m_cat_code", true);
                ASDefaultMat.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefaultMat.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((VMS_M006_P)x).doc_code ?? "");
                TheFilter = (o, prefix) => (((VMS_M006_P)o).doc_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((VMS_M006_P)o).doc_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefaultDoc = new AutoSuggestTextViewModel<dynamic>(MC.VDocument, TheFilter, SuggestedValue, "doc_code", "doc_code", true);
                ASDefaultDoc.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefaultDoc.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId ?? "");
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M024_P)o).EmpName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefaultHost = new AutoSuggestTextViewModel<dynamic>(MC.HEmployee, TheFilter, SuggestedValue, "emp_id", "EmpId", true);
                ASDefaultHost.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefaultHost.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((VMS_M004_P)x).facility_code ?? "");
                TheFilter = (o, prefix) => (((VMS_M004_P)o).facility_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((VMS_M004_P)o).facility_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefaultFacility = new AutoSuggestTextViewModel<dynamic>(MC.VFacility, TheFilter, SuggestedValue, "facility_code", "facility_code", true);
                ASDefaultFacility.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefaultFacility.AutoSuggestVM.IsFreeTextAllowed = true;

                //Master PopUp
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M050_P)x).sal_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M050_P)o).sal_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M050_P)o).sal_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASSalutation = new AutoSuggestTextViewModel<dynamic>(MC.Salutation, TheFilter, SuggestedValue, "sal_code", true);
                ASSalutation.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((VMS_M001_P)x).v_cat_code ?? "");
                TheFilter = (o, prefix) => (((VMS_M001_P)o).v_cat_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((VMS_M001_P)o).v_cat_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASVCategory = new AutoSuggestTextViewModel<dynamic>(MC.VCategory, TheFilter, SuggestedValue, "v_cat_code", true);
                ASVCategory.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyNm ?? "");
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyId ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M028_P)o).PartyNm ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASVCompany = new AutoSuggestTextViewModel<dynamic>(MC.VCompany, TheFilter, SuggestedValue, "v_party_name", true);
                ASVCompany.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((VMS_M002_P)x).vp_code ?? "");
                TheFilter = (o, prefix) => (((VMS_M002_P)o).vp_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((VMS_M002_P)o).vp_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASVPurpose = new AutoSuggestTextViewModel<dynamic>(MC.VisitPurpose, TheFilter, SuggestedValue, "vp_code", true);
                ASVPurpose.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((HRM_M015_P)x).ter_id ?? "");
                TheFilter = (o, prefix) => (((HRM_M015_P)o).ter_id ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((HRM_M015_P)o).ter_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASGateNo = new AutoSuggestTextViewModel<dynamic>(MC.EntryGateNo, TheFilter, SuggestedValue, "ter_id", true);
                ASGateNo.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((VMS_M003_P)x).place_code ?? "");
                TheFilter = (o, prefix) => (((VMS_M003_P)o).place_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((VMS_M003_P)o).place_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASMeetingPlace = new AutoSuggestTextViewModel<dynamic>(MC.MeetingPlace, TheFilter, SuggestedValue, "place_code", true);
                ASMeetingPlace.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M051_P)x).nation_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M051_P)o).nation_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M051_P)o).nation_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASVNation = new AutoSuggestTextViewModel<dynamic>(MC.Nationality, TheFilter, SuggestedValue, "v_nation", true);
                ASVNation.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M012_P)x).country_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M012_P)o).country_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M012_P)o).CntryName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASVCountry = new AutoSuggestTextViewModel<dynamic>(MC.Country, TheFilter, SuggestedValue, "country_code", true);
                ASVCountry.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M013_P)x).state_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M013_P)o).state_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M013_P)o).StatName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASVState = new AutoSuggestTextViewModel<dynamic>(MC.State, TheFilter, SuggestedValue, "state_code", true);
                ASVState.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((VMS_M005_P)x).gst_house_code ?? "");
                TheFilter = (o, prefix) => (((VMS_M005_P)o).gst_house_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((VMS_M005_P)o).gst_house_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASGuestHouse = new AutoSuggestTextViewModel<dynamic>(MC.GuestHouse, TheFilter, SuggestedValue, "gst_house_code", true);
                ASGuestHouse.AutoSuggestVM.IsEmptyValueAllowed = true;
                
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((VMS_M007_P)x).m_cat_code ?? "");
                TheFilter = (o, prefix) => (((VMS_M007_P)o).m_cat_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((VMS_M007_P)o).m_cat_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASMatCat = new AutoSuggestTextViewModel<dynamic>(MC.VMaterialCategory, TheFilter, SuggestedValue, "m_cat_code", "m_cat_code", true);
                ASMatCat.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((VMS_M008_P)x).m_type_code ?? "");
                TheFilter = (o, prefix) => (((VMS_M008_P)o).m_type_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((VMS_M008_P)o).m_type_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASMatType = new AutoSuggestTextViewModel<dynamic>(MC.VMaterialType, TheFilter, SuggestedValue, "m_type_code", "m_type_code", true);
                ASMatType.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((VMS_M006_P)x).doc_code ?? "");
                TheFilter = (o, prefix) => (((VMS_M006_P)o).doc_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((VMS_M006_P)o).doc_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDocument = new AutoSuggestTextViewModel<dynamic>(MC.VDocument, TheFilter, SuggestedValue, "doc_code", "doc_code", true);
                ASDocument.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId ?? "");
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M024_P)o).EmpName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASHEmployee = new AutoSuggestTextViewModel<dynamic>(MC.HEmployee, TheFilter, SuggestedValue, "emp_id", "EmpId", true);
                ASHEmployee.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((VMS_M004_P)x).facility_code ?? "");
                TheFilter = (o, prefix) => (((VMS_M004_P)o).facility_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((VMS_M004_P)o).facility_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASFacility = new AutoSuggestTextViewModel<dynamic>(MC.VFacility, TheFilter, SuggestedValue, "facility_code", "facility_code", true);
                ASFacility.AutoSuggestVM.IsEmptyValueAllowed = true;

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
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.edit_by = AppSessionState.UserID;
            //MasterEntity.entry_dt = DateTime.Now;
            MasterEntity.active = true;
            //MasterEntity.doc_cat = "FR";
            //MasterEntity.doc_type = "FR";
            MasterEntity.t_status = "Available";
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;
        }

        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";
                VMS_T001_BackFlip ParameterEntityObject = null;

                if (ParameterObject != null)
                {
                    if (ParameterObject.GetType() == typeof(string) && ParameterObject != null) // This Block of code read parameter . First for string and Entity Object in else part.
                    {
                        Request = "LoadDocumentWithDocumentNumber" + "!@" + ParameterObject;
                    }
                    else if (((IEnumerable)ParameterObject).Cast<VMS_T001_BackFlip>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<VMS_T001_BackFlip>().ToList()[0];
                        Request = "LoadDocumentWithDocumentNumber" + "!@" + ParameterEntityObject.app_id;

                    }
                }

                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_VMS_T001>(MCTemp, Request, "AppointmentByHost", "VMS", "LoadDocumentWithDocumentNumber", 0, "");



                if (MCTemp.DetailData_A != null)
                {
                    DetailEntity_A.Clear();
                    MasterEntity = MCTemp.MasterData[0];
                    //PersonEmailId = MCTemp.MasterEntity[0].PersonEmailId;
                    //PartyEmailId = MCTemp.MasterEntity[0].PartyEmailId;
                    DetailEntity_A = MCTemp.DetailData_A;
                }
                else
                {
                    MCTemp.DetailData_A = new ObservableCollection<VMS_T001_A>();
                }

                if (MCTemp.DetailData_B != null)
                {
                    DetailEntity_B.Clear();
                    DetailEntity_B = MCTemp.DetailData_B;
                }
                else
                {
                    MCTemp.DetailData_B = new ObservableCollection<VMS_T001_B>();
                }

                if (MCTemp.DetailData_C != null)
                {
                    DetailEntity_C.Clear();
                    DetailEntity_C = MCTemp.DetailData_C;
                }
                else
                {
                    MCTemp.DetailData_C = new ObservableCollection<VMS_T001_C>();
                }

                if (MCTemp.DetailData_D != null)
                {
                    DetailEntity_D.Clear();
                    DetailEntity_D = MCTemp.DetailData_D;
                }
                else
                {
                    MCTemp.DetailData_D = new ObservableCollection<VMS_T001_D>();
                }

                if (MCTemp.DetailData_E != null)
                {
                    DetailEntity_E.Clear();
                    DetailEntity_E = MCTemp.DetailData_E;
                }
                else
                {
                    MCTemp.DetailData_E = new ObservableCollection<VMS_T001_E>();
                }

                if (MCTemp.DetailData_X != null)
                {
                    DetailEntity_X.Clear();
                    DetailEntity_X = MCTemp.DetailData_X;
                }
                else
                {
                    MCTemp.DetailData_X = new ObservableCollection<VMS_M004_A>();
                }


                //if (MCTemp.Attachment != null)
                //{
                //    AttachmentCollection = MCTemp.Attachment;
                //}
                //else
                //{
                //    MCTemp.Attachment = new List<COM_T003>();
                //}

                SelectedTabControlIndex = 0;
                //AttachmentCount = MCTemp.Attachment.Count;
                SetPopupSuggestionDataAfterLoad();
                isNewRecord = false;

                var msg = new NotificationMessage("VMS_T001_VM");
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
        private void LoadDocumentByDocumentNumber1(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            VMS_T001_BackFlip ParameterEntityObject = new VMS_T001_BackFlip();

            try
            {
                if (((IEnumerable)ParameterObject).Cast<VMS_T001_BackFlip>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<VMS_T001_BackFlip>().ToList()[0];
                    Request = "LoadDocumentByDocumentNumber" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code + "!@" + ParameterEntityObject.app_id;
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_VMS_T001>(MCTemp, Request, "AppointmentByHost", "VMS", "LoadDocumentByDocumentNumber", 0, "");

                    if (MCTemp.MasterData.Count > 0)
                    {
                        MasterEntity = MCTemp.MasterData[0];
                    }
                    DetailEntity_A = MCTemp.DetailData_A;
                    DetailEntity_B = MCTemp.DetailData_B;
                    DetailEntity_C = MCTemp.DetailData_C;
                    DetailEntity_D = MCTemp.DetailData_D;
                    DetailEntity_E = MCTemp.DetailData_E;
                    DetailEntity_X = MCTemp.DetailData_X;

                    SetBusinessEntitiesAfterLoad("Save", "");

                }
                isNewRecord = false;
                SelectedTabControlIndex = 0;
                var msg = new NotificationMessage("VMS_T001_VM");
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
        private void LoadVisitorValidData()
        {
            try
            {
                if (Validation1() == true)
                {
                    var Request = "LoadVisitorValidData" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code + "!@" + MasterEntity.v_email + "!@" + MasterEntity.v_phno1 + "!@" + MasterEntity.v_phno2 ;
                    MCTemp1 = repository_MCTemp1.GetDataWithReturnDomainObject<MultipleContext_VMS_T001>(MCTemp1, Request, "AppointmentByHost", "VMS", "", 0, "");

                    if (MCTemp1.MasterData.Count > 0)
                    {
                        MasterEntity = MCTemp1.MasterData[0];
                    }
                    //PopupInvoiceCollection = CollectionViewSource.GetDefaultView(MCTemp1.Invoice);
                    //PopupInvoiceCollection.Filter = new Predicate<object>(Filter_DetailListPopup);
                    //StringListDetail = MCTemp1.Invoice.Select(x => x.bill_doc).ToList();
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
        private void InsertSalutation(object InputValue)
        {
            string Request = "";
            ADM_M050_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Salutation.Where(x => x.sal_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M050_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M050_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.sal_code = POPUPEntityObject.sal_code;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertVCategory(object InputValue)
        {
            string Request = "";
            VMS_M001_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.VCategory.Where(x => x.v_cat_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<VMS_M001_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<VMS_M001_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.v_cat_code = POPUPEntityObject.v_cat_code;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertVCompany(object InputValue)
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
                        { POPUPEntityObject = MC.VCompany.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M028_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.v_party_id = POPUPEntityObject.PartyId;
                    MasterEntity.v_party_name = POPUPEntityObject.PartyNm;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertVPurpose(object InputValue)
        {
            string Request = "";
            VMS_M002_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.VisitPurpose.Where(x => x.vp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<VMS_M002_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<VMS_M002_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.vp_code = POPUPEntityObject.vp_code;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertGateNo(object InputValue)
        {
            string Request = "";
            HRM_M015_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.EntryGateNo.Where(x => x.ter_id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<HRM_M015_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<HRM_M015_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.ter_id = POPUPEntityObject.ter_id;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertMeetingPlace(object InputValue)
        {
            string Request = "";
            VMS_M003_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.MeetingPlace.Where(x => x.place_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<VMS_M003_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<VMS_M003_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.place_code = POPUPEntityObject.place_code;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertVNation(object InputValue)
        {
            string Request = "";
            ADM_M051_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Nationality.Where(x => x.nation_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M051_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M051_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.v_nation = POPUPEntityObject.nation_code;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertVCountry(object InputValue)
        {
            string Request = "";
            ADM_M012_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Country.Where(x => x.country_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M012_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M012_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.country_code = POPUPEntityObject.country_code;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertVState(object InputValue)
        {
            string Request = "";
            ADM_M013_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.State.Where(x => x.state_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M013_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M013_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.state_code = POPUPEntityObject.state_code;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertMatCat(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            VMS_M007_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.VMaterialCategory.Where(x => x.m_cat_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<VMS_M007_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<VMS_M007_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    //var InputValueIfExists = AccessoryEntity.Where(x => x.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault();
                    var IndexOfExistValue = -1; //AccessoryEntity.IndexOf(AccessoryEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault());

                    if (dgSelectedIndexMaterial >= 0 && DetailEntity_A.Count > dgSelectedIndexMaterial)
                    {
                        if (DetailEntity_A[dgSelectedIndexMaterial].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            DetailEntity_A[dgSelectedIndexMaterial].m_cat_code = POPUPEntityObject.m_cat_code;
                            DetailEntity_A[dgSelectedIndexMaterial].location_Id = AppSessionState.location_Id;
                            DetailEntity_A[dgSelectedIndexMaterial].comp_code = AppSessionState.comp_code;
                            DetailEntity_A[dgSelectedIndexMaterial].add_by = AppSessionState.UserID;
                            DetailEntity_A[dgSelectedIndexMaterial].edit_by = AppSessionState.UserID;
                            DetailEntity_A[dgSelectedIndexMaterial].active = true;
                            DetailEntity_A[dgSelectedIndexMaterial].user_source1 = AppSessionState.UserSource1;
                            DetailEntity_A[dgSelectedIndexMaterial].user_source2 = AppSessionState.UserSource2;
                        }
                        else if (DetailEntity_A[dgSelectedIndexMaterial].m_cat_code != POPUPEntityObject.m_cat_code)
                        {
                            DetailEntity_A[dgSelectedIndexMaterial].m_cat_code = POPUPEntityObject.m_cat_code;
                            DetailEntity_A[dgSelectedIndexMaterial].location_Id = AppSessionState.location_Id;
                            DetailEntity_A[dgSelectedIndexMaterial].comp_code = AppSessionState.comp_code;
                            DetailEntity_A[dgSelectedIndexMaterial].add_by = AppSessionState.UserID;
                            DetailEntity_A[dgSelectedIndexMaterial].edit_by = AppSessionState.UserID;
                            DetailEntity_A[dgSelectedIndexMaterial].user_source1 = AppSessionState.UserSource1;
                            DetailEntity_A[dgSelectedIndexMaterial].user_source2 = AppSessionState.UserSource2;
                            DetailEntity_A[dgSelectedIndexMaterial].active = true;
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void InsertMatType(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            VMS_M008_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.VMaterialType.Where(x => x.m_type_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<VMS_M008_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<VMS_M008_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    //var InputValueIfExists = AccessoryEntity.Where(x => x.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault();
                    var IndexOfExistValue = -1; //AccessoryEntity.IndexOf(AccessoryEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault());

                    if (dgSelectedIndexMaterial >= 0 && DetailEntity_A.Count > dgSelectedIndexMaterial)
                    {
                        if (DetailEntity_A[dgSelectedIndexMaterial].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            DetailEntity_A[dgSelectedIndexMaterial].m_type_code = POPUPEntityObject.m_type_code;
                            //DetailEntity_A[dgSelectedIndexMaterial].location_Id = AppSessionState.location_Id;
                            //DetailEntity_A[dgSelectedIndexMaterial].comp_code = AppSessionState.comp_code;
                            //DetailEntity_A[dgSelectedIndexMaterial].add_by = AppSessionState.UserID;
                            //DetailEntity_A[dgSelectedIndexMaterial].edit_by = AppSessionState.UserID;
                            //DetailEntity_A[dgSelectedIndexMaterial].active = true;
                            //DetailEntity_A[dgSelectedIndexMaterial].user_source1 = AppSessionState.UserSource1;
                            //DetailEntity_A[dgSelectedIndexMaterial].user_source2 = AppSessionState.UserSource2;
                        }
                        else if (DetailEntity_A[dgSelectedIndexMaterial].m_type_code != POPUPEntityObject.m_type_code)
                        {
                            DetailEntity_A[dgSelectedIndexMaterial].m_type_code = POPUPEntityObject.m_type_code;
                            //DetailEntity_A[dgSelectedIndexMaterial].location_Id = AppSessionState.location_Id;
                            //DetailEntity_A[dgSelectedIndexMaterial].comp_code = AppSessionState.comp_code;
                            //DetailEntity_A[dgSelectedIndexMaterial].add_by = AppSessionState.UserID;
                            //DetailEntity_A[dgSelectedIndexMaterial].edit_by = AppSessionState.UserID;
                            //DetailEntity_A[dgSelectedIndexMaterial].user_source1 = AppSessionState.UserSource1;
                            //DetailEntity_A[dgSelectedIndexMaterial].user_source2 = AppSessionState.UserSource2;
                            //DetailEntity_A[dgSelectedIndexMaterial].active = true;
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void InsertDocument(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            VMS_M006_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.VDocument.Where(x => x.doc_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<VMS_M006_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<VMS_M006_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    //var InputValueIfExists = AccessoryEntity.Where(x => x.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault();
                    var IndexOfExistValue = -1; //AccessoryEntity.IndexOf(AccessoryEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault());

                    if (dgSelectedIndexDocument >= 0 && DetailEntity_E.Count > dgSelectedIndexDocument)
                    {
                        if (DetailEntity_E[dgSelectedIndexDocument].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            DetailEntity_E[dgSelectedIndexDocument].doc_code = POPUPEntityObject.doc_code;
                            DetailEntity_E[dgSelectedIndexDocument].location_Id = AppSessionState.location_Id;
                            DetailEntity_E[dgSelectedIndexDocument].comp_code = AppSessionState.comp_code;
                            DetailEntity_E[dgSelectedIndexDocument].add_by = AppSessionState.UserID;
                            DetailEntity_E[dgSelectedIndexDocument].edit_by = AppSessionState.UserID;
                            DetailEntity_E[dgSelectedIndexDocument].active = true;
                            DetailEntity_E[dgSelectedIndexDocument].user_source1 = AppSessionState.UserSource1;
                            DetailEntity_E[dgSelectedIndexDocument].user_source2 = AppSessionState.UserSource2;
                        }
                        else if (DetailEntity_E[dgSelectedIndexDocument].doc_code != POPUPEntityObject.doc_code)
                        {
                            DetailEntity_E[dgSelectedIndexDocument].doc_code = POPUPEntityObject.doc_code;
                            DetailEntity_E[dgSelectedIndexDocument].location_Id = AppSessionState.location_Id;
                            DetailEntity_E[dgSelectedIndexDocument].comp_code = AppSessionState.comp_code;
                            DetailEntity_E[dgSelectedIndexDocument].add_by = AppSessionState.UserID;
                            DetailEntity_E[dgSelectedIndexDocument].edit_by = AppSessionState.UserID;
                            DetailEntity_E[dgSelectedIndexDocument].user_source1 = AppSessionState.UserSource1;
                            DetailEntity_E[dgSelectedIndexDocument].user_source2 = AppSessionState.UserSource2;
                            DetailEntity_E[dgSelectedIndexDocument].active = true;
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void InsertHEmployee(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                        { POPUPEntityObject = MC.HEmployee.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M024_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    //var InputValueIfExists = AccessoryEntity.Where(x => x.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault();
                    var IndexOfExistValue = -1; //AccessoryEntity.IndexOf(AccessoryEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault());

                    if (dgSelectedIndexAddHost >= 0 && DetailEntity_D.Count > dgSelectedIndexAddHost)
                    {
                        if (DetailEntity_D[dgSelectedIndexAddHost].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            DetailEntity_D[dgSelectedIndexAddHost].emp_id = POPUPEntityObject.EmpId;
                            DetailEntity_D[dgSelectedIndexAddHost].first_name = POPUPEntityObject.EmpFName;
                            DetailEntity_D[dgSelectedIndexAddHost].mid_name = POPUPEntityObject.EmpMName;
                            DetailEntity_D[dgSelectedIndexAddHost].last_name = POPUPEntityObject.EmpLName;

                            DetailEntity_D[dgSelectedIndexAddHost].location_Id = AppSessionState.location_Id;
                            DetailEntity_D[dgSelectedIndexAddHost].comp_code = AppSessionState.comp_code;
                            DetailEntity_D[dgSelectedIndexAddHost].add_by = AppSessionState.UserID;
                            DetailEntity_D[dgSelectedIndexAddHost].edit_by = AppSessionState.UserID;
                            DetailEntity_D[dgSelectedIndexAddHost].active = true;
                            DetailEntity_D[dgSelectedIndexAddHost].user_source1 = AppSessionState.UserSource1;
                            DetailEntity_D[dgSelectedIndexAddHost].user_source2 = AppSessionState.UserSource2;
                        }

                        else //if (DetailEntity_D[dgSelectedIndexAddHost].emp_id != POPUPEntityObject.EmpId)   //For Update purpose comment this line because of auto suggest problem.
                        {
                            DetailEntity_D[dgSelectedIndexAddHost].emp_id = POPUPEntityObject.EmpId;
                            DetailEntity_D[dgSelectedIndexAddHost].first_name = POPUPEntityObject.EmpFName;
                            DetailEntity_D[dgSelectedIndexAddHost].mid_name = POPUPEntityObject.EmpMName;
                            DetailEntity_D[dgSelectedIndexAddHost].last_name = POPUPEntityObject.EmpLName;

                            DetailEntity_D[dgSelectedIndexAddHost].location_Id = AppSessionState.location_Id;
                            DetailEntity_D[dgSelectedIndexAddHost].comp_code = AppSessionState.comp_code;
                            DetailEntity_D[dgSelectedIndexAddHost].add_by = AppSessionState.UserID;
                            DetailEntity_D[dgSelectedIndexAddHost].edit_by = AppSessionState.UserID;
                            DetailEntity_D[dgSelectedIndexAddHost].user_source1 = AppSessionState.UserSource1;
                            DetailEntity_D[dgSelectedIndexAddHost].user_source2 = AppSessionState.UserSource2;
                            DetailEntity_D[dgSelectedIndexAddHost].active = true;
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void InsertFacility(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            VMS_M004_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.VFacility.Where(x => x.facility_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<VMS_M004_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<VMS_M004_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    //var InputValueIfExists = AccessoryEntity.Where(x => x.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault();
                    var IndexOfExistValue = -1; //AccessoryEntity.IndexOf(AccessoryEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault());

                    if (dgSelectedIndexFacility >= 0 && DetailEntity_X.Count > dgSelectedIndexFacility)
                    {
                        if (DetailEntity_X[dgSelectedIndexFacility].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            DetailEntity_X[dgSelectedIndexFacility].facility_code = POPUPEntityObject.facility_code;
                            DetailEntity_X[dgSelectedIndexFacility].location_Id = AppSessionState.location_Id;
                            DetailEntity_X[dgSelectedIndexFacility].comp_code = AppSessionState.comp_code;
                            DetailEntity_X[dgSelectedIndexFacility].add_by = AppSessionState.UserID;
                            DetailEntity_X[dgSelectedIndexFacility].edit_by = AppSessionState.UserID;
                            DetailEntity_X[dgSelectedIndexFacility].active = true;
                            DetailEntity_X[dgSelectedIndexFacility].user_source1 = AppSessionState.UserSource1;
                            DetailEntity_X[dgSelectedIndexFacility].user_source2 = AppSessionState.UserSource2;
                        }
                        else if (DetailEntity_X[dgSelectedIndexFacility].facility_code != POPUPEntityObject.facility_code)
                        {
                            DetailEntity_X[dgSelectedIndexFacility].facility_code = POPUPEntityObject.facility_code;
                            DetailEntity_X[dgSelectedIndexFacility].location_Id = AppSessionState.location_Id;
                            DetailEntity_X[dgSelectedIndexFacility].comp_code = AppSessionState.comp_code;
                            DetailEntity_X[dgSelectedIndexFacility].add_by = AppSessionState.UserID;
                            DetailEntity_X[dgSelectedIndexFacility].edit_by = AppSessionState.UserID;
                            DetailEntity_X[dgSelectedIndexFacility].user_source1 = AppSessionState.UserSource1;
                            DetailEntity_X[dgSelectedIndexFacility].user_source2 = AppSessionState.UserSource2;
                            DetailEntity_X[dgSelectedIndexFacility].active = true;
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void InsertGuestHouse(object InputValue)
        {
            string Request = "";
            VMS_M005_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.GuestHouse.Where(x => x.gst_house_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<VMS_M005_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<VMS_M005_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.gst_house_code = POPUPEntityObject.gst_house_code;
                }
            }
            catch (Exception ex) { }
        }
        private bool Validation()
        {
            if (MasterEntity.v_first_nm == null || MasterEntity.v_first_nm == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter The Visitor First Name...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.v_last_nm == null || MasterEntity.v_last_nm == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter The Visitor Last Name...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.v_phno1 == null || MasterEntity.v_phno1 == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter The Visitor Mobile Number...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.v_email == null || MasterEntity.v_email == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter The Visitor Email ID...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.v_cat_code == null || MasterEntity.v_cat_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select The Visitor Category...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.v_party_name == null || MasterEntity.v_party_name == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select The Visitor Company...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.vp_code == null || MasterEntity.vp_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select The Visit Purpose or Meeting Purpose...");
                showMessageService.ShowMessage();
                return false;
            }

            return true;
        }
        private bool Validation1()
        {
            //if (MasterEntity.v_first_nm == null || MasterEntity.v_first_nm == "")
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format("Please Enter The Visitor First Name...");
            //    showMessageService.ShowMessage();
            //    return false;
            //}            

            return true;
        }
        private void DeleteDataGridRowDetail_A(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (DetailEntity_A.Count > i && DetailEntity_A[dgSelectedIndexMaterial].id == 0)
                {
                    DetailEntity_A.RemoveAt(i);
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
        private void DeleteDataGridRowDetail_B(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (DetailEntity_B.Count > i && DetailEntity_B[dgSelectedIndexAddVisitor].id == 0)
                {
                    DetailEntity_B.RemoveAt(i);
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
        private void DeleteDataGridRowDetail_C(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (DetailEntity_C.Count > i && DetailEntity_C[dgSelectedIndexVehicle].id == 0)
                {
                    DetailEntity_C.RemoveAt(i);
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
        private void DeleteDataGridRowDetail_D(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (DetailEntity_D.Count > i && DetailEntity_D[dgSelectedIndexAddHost].id == 0)
                {
                    DetailEntity_D.RemoveAt(i);
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
        private void DeleteDataGridRowDetail_E(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (DetailEntity_E.Count > i && DetailEntity_E[dgSelectedIndexDocument].id == 0)
                {
                    DetailEntity_E.RemoveAt(i);
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
        private void DeleteDataGridRowDetail_X(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (DetailEntity_X.Count > i && DetailEntity_X[dgSelectedIndexFacility].id == 0)
                {
                    DetailEntity_X.RemoveAt(i);
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
                if (MasterEntity.XmlDataDocument_VMS_T001_A != null)
                {
                    DetailEntity_A.Clear();
                    MC.DetailData_A = (ObservableCollection<VMS_T001_A>)obj.XMLToObject(MasterEntity.XmlDataDocument_VMS_T001_A, MC.DetailData_A);
                    DetailEntity_A = MC.DetailData_A;
                }
                else
                {
                    MC.DetailData_A = new ObservableCollection<VMS_T001_A>();
                }

                if (MasterEntity.XmlDataDocument_VMS_T001_B != null)
                {
                    DetailEntity_B.Clear();
                    MC.DetailData_B = (ObservableCollection<VMS_T001_B>)obj.XMLToObject(MasterEntity.XmlDataDocument_VMS_T001_B, MC.DetailData_B);
                    DetailEntity_B = MC.DetailData_B;
                }
                else
                {
                    MC.DetailData_B = new ObservableCollection<VMS_T001_B>();
                }

                if (MasterEntity.XmlDataDocument_VMS_T001_C != null)
                {
                    DetailEntity_C.Clear();
                    MC.DetailData_C = (ObservableCollection<VMS_T001_C>)obj.XMLToObject(MasterEntity.XmlDataDocument_VMS_T001_C, MC.DetailData_C);
                    DetailEntity_C = MC.DetailData_C;
                }
                else
                {
                    MC.DetailData_C = new ObservableCollection<VMS_T001_C>();
                }

                if (MasterEntity.XmlDataDocument_VMS_T001_D != null)
                {
                    DetailEntity_D.Clear();
                    MC.DetailData_D = (ObservableCollection<VMS_T001_D>)obj.XMLToObject(MasterEntity.XmlDataDocument_VMS_T001_D, MC.DetailData_D);
                    DetailEntity_D = MC.DetailData_D;
                }
                else
                {
                    MC.DetailData_D = new ObservableCollection<VMS_T001_D>();
                }

                if (MasterEntity.XmlDataDocument_VMS_T001_E != null)
                {
                    DetailEntity_E.Clear();
                    MC.DetailData_E = (ObservableCollection<VMS_T001_E>)obj.XMLToObject(MasterEntity.XmlDataDocument_VMS_T001_E, MC.DetailData_E);
                    DetailEntity_E = MC.DetailData_E;
                }
                else
                {
                    MC.DetailData_E = new ObservableCollection<VMS_T001_E>();
                }

                if (MasterEntity.XmlDataDocument_VMS_M004_A != null)
                {
                    DetailEntity_X.Clear();
                    MC.DetailData_X = (ObservableCollection<VMS_M004_A>)obj.XMLToObject(MasterEntity.XmlDataDocument_VMS_M004_A, MC.DetailData_X);
                    DetailEntity_X = MC.DetailData_X;
                }
                else
                {
                    MC.DetailData_X = new ObservableCollection<VMS_M004_A>();
                }

                if (MasterEntity.XmlDataDocument_VMS_T001_Flip != null && isNewRecord == true && ParameterOption1 == "Save")
                {
                    MC.BackFlipEntity = (List<VMS_T001_BackFlip>)obj.XMLToObject(MasterEntity.XmlDataDocument_VMS_T001_Flip, MC.BackFlipEntity);
                    FlipGridData.Add(MC.BackFlipEntity[0]);
                    DataGridCollection.Refresh();
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
            ASSalutation.AutoSuggestVM.Suggestion = MC.Salutation.Find(x => x.sal_code == MasterEntity.sal_code);
            ASVCategory.AutoSuggestVM.Suggestion = MC.VCategory.Find(x => x.v_cat_code == MasterEntity.v_cat_code);
            ASVCompany.AutoSuggestVM.Suggestion = MC.VCompany.Find(x => x.PartyNm == MasterEntity.v_party_name);
            ASVPurpose.AutoSuggestVM.Suggestion = MC.VisitPurpose.Find(x => x.vp_code == MasterEntity.vp_code);
            ASMeetingPlace.AutoSuggestVM.Suggestion = MC.MeetingPlace.Find(x => x.place_code == MasterEntity.place_code);
            ASVNation.AutoSuggestVM.Suggestion = MC.Nationality.Find(x => x.nation_code == MasterEntity.v_nation);
            ASVCountry.AutoSuggestVM.Suggestion = MC.Country.Find(x => x.country_code == MasterEntity.country_code);
            ASVState.AutoSuggestVM.Suggestion = MC.State.Find(x => x.state_code == MasterEntity.state_code);
            ASGuestHouse.AutoSuggestVM.Suggestion = MC.GuestHouse.Find(x => x.gst_house_code == MasterEntity.gst_house_code);
            
        }
        #endregion


        #region Abstract Command Actions
        protected override void OnSaveAction(InquiryActionResult<VMS_T001> result)
        {
            try
            {
                MasterEntity.edit_by = AppSessionState.UserID;
                MasterEntity.XmlDataDocument_VMS_T001_A = obj.ObjectToXML(DetailEntity_A);
                MasterEntity.XmlDataDocument_VMS_T001_B = obj.ObjectToXML(DetailEntity_B);
                MasterEntity.XmlDataDocument_VMS_T001_C = obj.ObjectToXML(DetailEntity_C);
                MasterEntity.XmlDataDocument_VMS_T001_D = obj.ObjectToXML(DetailEntity_D);
                MasterEntity.XmlDataDocument_VMS_T001_E = obj.ObjectToXML(DetailEntity_E);
                MasterEntity.XmlDataDocument_VMS_M004_A = obj.ObjectToXML(DetailEntity_X);
                this.MasterEntity.EndEdit();
                if (Validation() == true)
                {
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<VMS_T001>(MasterEntity, "AppointmentByHost", "VMS");
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<VMS_T001>(MasterEntity, "AppointmentByHost", "VMS");
                    }

                    if (MasterEntity.app_id != null && isNewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    if (MasterEntity.app_id != null && isNewRecord == false)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Updated Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");
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
            //if (!string.IsNullOrEmpty(MasterEntity.ItemCode))
            //{            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
            //    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.ItemCode.Replace("/", "--"), DocumentList = MCTemp.Attachment });
            //}
        }
        protected override void OnCreateAction(InquiryActionResult<VMS_T001> result)
        {
            isNewRecord = true;
            MasterEntity = new VMS_T001();
            DetailEntity_A = new ObservableCollection<VMS_T001_A>();
            DetailEntity_B = new ObservableCollection<VMS_T001_B>();
            DetailEntity_C = new ObservableCollection<VMS_T001_C>();
            DetailEntity_D = new ObservableCollection<VMS_T001_D>();
            DetailEntity_E = new ObservableCollection<VMS_T001_E>();
            DetailEntity_X = new ObservableCollection<VMS_M004_A>();

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<VMS_T001> result)
        {
            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            showMessageService.ButtonSetup = DialogButton.Ok;
            showMessageService.Caption = "Delete Changes";
            showMessageService.Text = String.Format("This record will be Deleted forever", this.Title);
            if (showMessageService.ShowMessage() == DialogResult.Ok)
            {
                //string response = repository.Delete(MasterEntity.SrNo, "FormReceivedFrmCustomer", "CRM");  
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<VMS_T001> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<VMS_T001> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<VMS_T001> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<VMS_T001> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<VMS_T001> result)
        {

        }

        protected override void OnRefreshCommand(InquiryActionResult<VMS_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<VMS_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<VMS_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<VMS_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<VMS_T001> result)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region Filters

        #region Filters For DataGrid

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
            var data = obj as VMS_T001_BackFlip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.h_ra_define != null && data.h_ra_define.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.app_id != null && data.app_id.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.v_first_nm != null && data.v_first_nm.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.v_last_nm != null && data.v_last_nm.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.v_cat_code != null && data.v_cat_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.v_phno1 != null && data.v_phno1.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.v_phno2 != null && data.v_phno2.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.v_email != null && data.v_email.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.vp_code != null && data.vp_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.place_code != null && data.place_code.ToString().ToLower().Contains(_filterString.ToLower()) 
                            //data.email_id != null && data.email_id.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            //data.webside != null && data.webside.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            //data.address_type != null && data.address_type.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            //data.address1 != null && data.address1.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            //data.address2 != null && data.address2.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            //data.land_mark != null && data.land_mark.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            //data.city != null && data.city.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            //data.country_code != null && data.country_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            //data.state_code != null && data.state_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            //data.pin != null && data.pin.ToString().ToLower().Contains(_filterString.ToLower())
                            );
                }
                return true;
            }
            return false;
        }

       
        #endregion

        #endregion
    }
}
