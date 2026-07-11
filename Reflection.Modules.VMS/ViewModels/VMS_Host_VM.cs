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
using System.Collections.Specialized;
using System.Windows;
using Reflection.Presentation.Controls;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using Reflection.BusinessEntity.VMS;
using System.Reflection;
using Reflection.Presentation.Core.VirtualDesktops;
using GalaSoft.MvvmLight.Ioc;

namespace Reflection.Modules.VMS.ViewModels
{
    public class VMS_Host_VM : UserControl
    {

        #region Variable Declaration     
        string Currency;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        WebServiceRepository<VMS_T001> repository = new WebServiceRepository<VMS_T001>();
        WebServiceRepository<MultipleContext_VMS_T001> repository_MC = new WebServiceRepository<MultipleContext_VMS_T001>();
        WebServiceRepository<MultipleContext_VMS_T001> repository_MCTemp = new WebServiceRepository<MultipleContext_VMS_T001>();
        ObjectSerializationService obj = new ObjectSerializationService();



        private MultipleContext_VMS_T001 _MC = new MultipleContext_VMS_T001();
        public MultipleContext_VMS_T001 MC
        {
            get { return _MC; }
            set
            {
                if (_MC != value)
                {
                    _MC = value;
                }
            }
        }

        private MultipleContext_VMS_T001 _MCTemp = new MultipleContext_VMS_T001();
        public MultipleContext_VMS_T001 MCTemp
        {
            get { return _MCTemp; }
            set
            {
                if (_MCTemp != value)
                {
                    _MCTemp = value;
                }
            }
        }


        private VMS_T001 _MasterEntity;
        public VMS_T001 MasterEntity
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
                    value.BeginEdit();
                }
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
                    //RaisePropertyChanged("DetailEntity_A");
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
                    //DetailEntity_B.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForAddVisitor);
                    //RaisePropertyChanged("DetailEntity_B");
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
                    //DetailEntity_C.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForVehicle);
                    //RaisePropertyChanged("DetailEntity_C");
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
                    //RaisePropertyChanged("DetailEntity_D");
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
                    //RaisePropertyChanged("DetailEntity_E");
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
                    //RaisePropertyChanged("DetailEntity_X");
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
                }
            }
        }

        private ICollectionView _dataGridviewFilter;
        // This DataGridView filter Schedule Lines for selected item. it will show only schedule for selected item.
        public ICollectionView DataGridViewFilter
        {
            get { return _dataGridviewFilter; }
            set { _dataGridviewFilter = value; }
        }

        // Selected Index for Items DataGrid
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

                }
            }
        }

        private int _dgSelectedIndexItemLeadDistbn;
        // Selected Index for Items schedule DataGrid 
        public int dgSelectedIndexItemLeadDistbn
        {
            get
            {
                return _dgSelectedIndexItemLeadDistbn;
            }
            set
            {
                if (_dgSelectedIndexItemLeadDistbn != value)
                {
                    _dgSelectedIndexItemLeadDistbn = value;
                }
            }
        }

        private int _AttachmentCount;
        public int AttachmentCount
        {
            get { return _AttachmentCount; }
            set
            {
                if (_AttachmentCount != value)
                {
                    _AttachmentCount = value;
                }
            }
        }

        private List<VMS_T001_BackFlip> _FlipGridData;
        // Flip DataGrid Data Source
        public List<VMS_T001_BackFlip> FlipGridData
        {
            get { return _FlipGridData; }
            set
            {
                if (_FlipGridData != value)
                {
                    _FlipGridData = value;
                }
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
                }
            }
        }

        private Nullable<System.DateTime> _FrmDate;
        public Nullable<System.DateTime> FrmDate
        {
            get { return _FrmDate; }
            set
            {
                _FrmDate = value;
            }
        }

        private Nullable<System.DateTime> _ToDate;
        public Nullable<System.DateTime> ToDate
        {
            get { return _ToDate; }
            set
            {
                _ToDate = value;
            }
        }

        #endregion
        #region Relay Commands Declaration
        public RelayCommand<object> CommandViewDocument { get; private set; }
        #endregion Relay Commands Declaration
        #region ICollection for Popup Control

        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; }
        }


        #endregion
        #region Constructor
        /// <summary>
        /// Constructor for ViewModel
        /// </summary>
        /// <param name="NA"></param>
        public VMS_Host_VM() : base()
        {
            IsDocumentViewerShow = false;
            MasterEntity = new VMS_T001();
            DetailEntity_A = new ObservableCollection<VMS_T001_A>();
            DetailEntity_B = new ObservableCollection<VMS_T001_B>();
            DetailEntity_C = new ObservableCollection<VMS_T001_C>();
            DetailEntity_D = new ObservableCollection<VMS_T001_D>();
            DetailEntity_E = new ObservableCollection<VMS_T001_E>();
            DetailEntity_X = new ObservableCollection<VMS_M004_A>();
            MC = new MultipleContext_VMS_T001();
            MCTemp = new MultipleContext_VMS_T001();
            
            NotificationDataCollection = new List<NotificationData>();
            FlipGridData = new List<VMS_T001_BackFlip>();
            FrmDate = System.DateTime.Now;
            ToDate = System.DateTime.Now;
            
            LoadInitialData();
            CommandViewDocument = new RelayCommand<object>(items => { if (items == null) { return; } ViewDocument(items); });


        }
        public VMS_Host_VM(string ts_code) : base()
        {
            IsDocumentViewerShow = false;
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

            NotificationDataCollection = new List<NotificationData>();
            FlipGridData = new List<VMS_T001_BackFlip>();
            FrmDate = System.DateTime.Now;
            ToDate = System.DateTime.Now;

            LoadInitialData();
            CommandViewDocument = new RelayCommand<object>(items => { if (items == null) { return; } ViewDocument(items); });


        }
        public VMS_Host_VM(string ts_code, string doc_no) : base()
        {
            IsDocumentViewerShow = false;
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

            NotificationDataCollection = new List<NotificationData>();
            FlipGridData = new List<VMS_T001_BackFlip>();
            FrmDate = System.DateTime.Now;
            ToDate = System.DateTime.Now;

            LoadInitialData();
            CommandViewDocument = new RelayCommand<object>(items => { if (items == null) { return; } ViewDocument(items); });


        }
        #endregion
        #region Abstract Command Actions
        private IEnumerable<T> MakeMeEnumerable<T>(T Entity)
        {
            yield return Entity;
        }


        #endregion

        #region User Defined Functions

        private void LoadInitialData()
        {
            //MasterEntity.doc_cat = "LE";
            //MasterEntity.doc_type = "LE";
            //string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.doc_cat + "!@" + "" + "!@" + "" + "!@" + AppSessionState.EmpId;
            string Request = "LoadInitialData" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code;
            MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_VMS_T001>(MC, Request, "AppointmentByHost", "VMS", "LoadAll", 0, "");

            FlipGridData = MC.BackFlipEntity.ToList();
            FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
            FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);

            DefaultValues();


            //foreach (var item in MC.BackFlipEntity)
            //{
            //    if (item.sch_dt_frm >= System.DateTime.Now.Date)
            //    {
            //        var SystemDocumentObject = (from o in MC.BackFlipEntity where o.sch_dt_frm >= System.DateTime.Now.Date select o).ToList();

            //        FlipGridData = SystemDocumentObject.ToList();
            //        FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
            //        FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);

            //        DefaultValues();

            //    }
            //    else if (item.sch_dt_frm < System.DateTime.Now.Date)
            //    {
            //        var SystemDocumentObject = (from o in MC.BackFlipEntity where o.sch_dt_frm < System.DateTime.Now.Date select o).ToList();

            //        FlipGridData = SystemDocumentObject.ToList();
            //        FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
            //        FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);

            //        DefaultValues();

            //    }

            //}

            //FlipGridData = MC.BackFlipEntity;           


        }
        private void ViewDocument(object InputValue)
        {
            try
            {
                VMS_T001_BackFlip POPUPEntityObject = null;
                if (InputValue != null && ((IEnumerable)InputValue).Cast<VMS_T001_BackFlip>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<VMS_T001_BackFlip>().ToList()[0];
                }


                AppSessionState.ViewTitle = "Appointment By Host";
                AppSessionState.TransValue = POPUPEntityObject.app_id;
                AppSessionState.TransValueType = POPUPEntityObject.app_id;
                AppSessionState.TransParameter = "NO";
                AppSessionState.ViewOtherRecordAllowed = false;

                string userAuth = "Reflection.Modules.VMS.Views.AppointmentByHost"; // this one is path option
                string path1 = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.VMS.dll");
                Assembly assembly = Assembly.LoadFile(path1);
                Type type = assembly.GetType(userAuth);
                if (type != null)
                {
                    dynamic instance = Activator.CreateInstance(type);
                    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DefaultValues()
        {

            //MasterEntity.doc_cat = "LE";
            //MasterEntity.doc_type = "LE";

            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.edit_by = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.t_status = "Draft";
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;
            //MasterEntity.version = "v1.0";
            //MasterEntity.doc_date = DateTime.Now;
            MasterEntity.app_id= "";

            Currency = AppSessionState.CntryCurncy;

        }

        #endregion

        #region Filters

        private string _filterString_FlipGrid;
        public string FilterString_FlipGrid
        {
            get { return _filterString_FlipGrid; }
            set
            {
                _filterString_FlipGrid = value;
                FilterCollection_FlipGrid();
            }
        }
        private void FilterCollection_FlipGrid()
        {
            if (_FlipDataGridCollection != null)
            {
                _FlipDataGridCollection.Refresh();
            }
        }
        public bool Filter_FlipGrid(object obj)
        {
            var data = obj as VMS_T001_BackFlip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_FlipGrid))
                {
                    return (data.h_ra_define != null && data.h_ra_define.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.app_id != null && data.app_id.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.v_first_nm != null && data.v_first_nm.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.v_last_nm != null && data.v_last_nm.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.v_cat_code != null && data.v_cat_code.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.v_phno1 != null && data.v_phno1.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.v_phno2 != null && data.v_phno2.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.v_email != null && data.v_email.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.vp_code != null && data.vp_code.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.place_code != null && data.place_code.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           //(data.doc_score_name != null && data.doc_score_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           //(data.party_location != null && data.party_location.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           //(data.location_name != null && data.location_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion
    }
}
