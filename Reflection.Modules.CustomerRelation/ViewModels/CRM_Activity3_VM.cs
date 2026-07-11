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
using Reflection.BusinessEntity.CustomerRelation;
using Reflection.Presentation.Core.VirtualDesktops;
using System.Reflection;
using GalaSoft.MvvmLight.Ioc;
using Reflection.Presentation.Common;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class CRM_Activity3_VM:WorkspaceViewModel<TSK_T001_C>
    {
    
        #region Variable Declaration     
        string Currency;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }

        WebServiceRepository<TSK_T001_C> repository = new WebServiceRepository<TSK_T001_C>();
        WebServiceRepository<MultipleContext_TSK_T001_C> repository_MC = new WebServiceRepository<MultipleContext_TSK_T001_C>();
        WebServiceRepository<MultipleContext_TSK_T001_C> repository_MCTemp = new WebServiceRepository<MultipleContext_TSK_T001_C>();
        ObjectSerializationService obj = new ObjectSerializationService();



        private MultipleContext_TSK_T001_C _MC = new MultipleContext_TSK_T001_C();
        public MultipleContext_TSK_T001_C MC
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

        private MultipleContext_TSK_T001_C _MCTemp = new MultipleContext_TSK_T001_C();
        public MultipleContext_TSK_T001_C MCTemp
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

        private TSK_T001_C _MasterEntity;
        public TSK_T001_C MasterEntity
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

        private List<TSK_T001_C_BackFlip> _FlipGridData;
        // Flip DataGrid Data Source
        public List<TSK_T001_C_BackFlip> FlipGridData
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
        public GalaSoft.MvvmLight.Command.RelayCommand cmdRefreshData { get; private set; }
        #endregion Relay Commands Declaration
        #region ICollection for Popup Control

        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value;
                RaisePropertyChanged("FlipDataGridCollection");
            }
        }



        #endregion
        #region Constructor
        /// <summary>
        /// Constructor for ViewModel
        /// </summary>
        /// <param name="NA"></param>
        public CRM_Activity3_VM() : base()
        {
            CursorControl.SetBusyState();
            IsDocumentViewerShow = false;

            MasterEntity = new TSK_T001_C();

            NotificationDataCollection = new List<NotificationData>();
            FlipGridData = new List<TSK_T001_C_BackFlip>();
            FrmDate = System.DateTime.Now;
            ToDate = System.DateTime.Now;
            MC = new MultipleContext_TSK_T001_C();
            MCTemp = new MultipleContext_TSK_T001_C();

            LoadInitialData();
            CommandViewDocument = new RelayCommand<object>(items => { if (items == null) { return; } ViewDocument(items); });
            cmdRefreshData = new GalaSoft.MvvmLight.Command.RelayCommand(() => { RefreshData(); });
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public CRM_Activity3_VM(string ts_code) : base()
        {
            CursorControl.SetBusyState();
            IsDocumentViewerShow = false;
            this.ts_code_vm = ts_code;
            MasterEntity = new TSK_T001_C();

            NotificationDataCollection = new List<NotificationData>();
            FlipGridData = new List<TSK_T001_C_BackFlip>();
            FrmDate = System.DateTime.Now;
            ToDate = System.DateTime.Now;
            MC = new MultipleContext_TSK_T001_C();
            MCTemp = new MultipleContext_TSK_T001_C();

            LoadInitialData();
            CommandViewDocument = new RelayCommand<object>(items => { if (items == null) { return; } ViewDocument(items); });
            cmdRefreshData = new GalaSoft.MvvmLight.Command.RelayCommand(() => { RefreshData(); });
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private async void RefreshData()
        {
            CursorControl.SetBusyState();
            try
            {

                string Request = "LoadInitialDataActivity" + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + AppSessionState.EmpId + "!@" + Convert.ToDateTime(FrmDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ToDate).ToString("MM/dd/yyyy");
                MC = await repository_MC.GetDataWithReturnDomainObjectASynchronus<MultipleContext_TSK_T001_C>(MC, Request, "CRMActivity", "CRM", "LoadInitialData", 0, "");

                FlipGridData = MC.BackFlipEntity.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);
                FlipDataGridCollection.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            try
            {
                if (msg.Notification == "Load Activity BackFlip Record")
                {
                    List<TSK_T001_C_BackFlip> Temp = (List<TSK_T001_C_BackFlip>)msg.Sender;
                    if(Temp.Count>0)
                    {
                        var itemToRemove = FlipGridData.Where(r => r.doc_no == Temp[0].doc_no).FirstOrDefault();
                        FlipGridData.Remove(itemToRemove);
                        FlipGridData.Insert(0, Temp[0]);
                        FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                        FlipDataGridCollection.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        #endregion
        #region Abstract Command Actions
        private IEnumerable<T> MakeMeEnumerable<T>(T Entity)
        {
            yield return Entity;
        }


        #endregion

        #region User Defined Functions

        private async void LoadInitialData()
        {
            CursorControl.SetBusyState();
            DefaultValues();

            string Request = "LoadInitialDataActivity" + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + AppSessionState.EmpId + "!@" + Convert.ToDateTime(FrmDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ToDate).ToString("MM/dd/yyyy");
            MC =  await repository_MC.GetDataWithReturnDomainObjectASynchronus<MultipleContext_TSK_T001_C>(MC, Request, "CRMActivity", "CRM", "LoadInitialData", 0, "");

            FlipGridData = MC.BackFlipEntity.ToList();
            FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
            FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);
            FlipDataGridCollection.Refresh();


        }
        private void DefaultValues()
        {
            try
            {
                MasterEntity.ts_code = ts_code_vm;
                if (MasterEntity.act_action == "Log" && MasterEntity.action_type == "Meeting")
                {
                    MasterEntity.doc_type = "LM";
                    MasterEntity.doc_cat = "LM";
                }

                else if (MasterEntity.act_action == "Schedule" && MasterEntity.action_type == "Meeting")
                {
                    MasterEntity.doc_type = "SM";
                    MasterEntity.doc_cat = "SM";
                }

                if (MasterEntity.act_action == "Log" && MasterEntity.action_type == "Call")
                {
                    MasterEntity.doc_type = "LC";
                    MasterEntity.doc_cat = "LC";
                }

                else if (MasterEntity.act_action == "Schedule" && MasterEntity.action_type == "Call")
                {
                    MasterEntity.doc_type = "SC";
                    MasterEntity.doc_cat = "SC";
                }


                MasterEntity.add_by = AppSessionState.UserID;
                MasterEntity.editby = AppSessionState.UserID;
                MasterEntity.client = AppSessionState.client;
                MasterEntity.comp_code = AppSessionState.comp_code;
                MasterEntity.location_Id = AppSessionState.location_Id;
                MasterEntity.so_code = AppSessionState.so_code;
                MasterEntity.sg_code = AppSessionState.sg_code;
                MasterEntity.doc_date = System.DateTime.Now;
                MasterEntity.start_date = System.DateTime.Now;
                MasterEntity.edit_date = System.DateTime.Now;
                MasterEntity.active = true;
                MasterEntity.owner = AppSessionState.EmpId;
                MasterEntity.EmpName = AppSessionState.EmpName;

            }
            catch (Exception ex)
            {
                
            }
        }
        private void ViewDocument(object InputValue)
        {
            try
            {
                TSK_T001_C_BackFlip POPUPEntityObject = null;
                if (InputValue != null && ((IEnumerable)InputValue).Cast<TSK_T001_C_BackFlip>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<TSK_T001_C_BackFlip>().ToList()[0];
                }

                AppSessionState.ViewTitle = "";
                AppSessionState.ViewTitle = "Activity";
                AppSessionState.TransValue = POPUPEntityObject.doc_no;
                AppSessionState.TransValueType = POPUPEntityObject.doc_no;
                AppSessionState.TransParameter = "NO";
                AppSessionState.ViewOtherRecordAllowed = false;
                AppSessionState.TransactionCode = "";

                string userAuth = "Reflection.Modules.CustomerRelation.Views.CRM_NewActivity"; // this one is path option
                string path1 = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.CustomerRelation.dll");
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
            var data = obj as TSK_T001_C_BackFlip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_FlipGrid))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.lead_title != null && data.lead_title.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||                          
                           (data.ref_doc_no != null && data.ref_doc_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.parent_activity != null && data.parent_activity.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.start_date != null && data.start_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.end_date != null && data.end_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.project_name != null && data.project_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.project_location != null && data.project_location.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.project_type != null && data.project_type.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.parent_activity != null && data.parent_activity.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.action_type != null && data.action_type.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.act_action != null && data.act_action.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.party_name != null && data.party_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.contact_person != null && data.contact_person.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.project_location != null && data.project_location.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.person_number != null && data.person_number.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.EmailId != null && data.EmailId.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.place != null && data.place.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.Click != null && data.Click.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.activity_type != null && data.activity_type.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.owner != null && data.owner.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.architect_name != null && data.architect_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.pay_expected_date != null && data.pay_expected_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.act_desc != null && data.act_desc.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.active != null && data.active.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.so_name != null && data.so_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.sg_name != null && data.sg_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.address_name != null && data.address_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));

                }
                return true;
            }
            return false;
        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }
        protected override void OnRefreshCommand(InquiryActionResult<TSK_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<TSK_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<TSK_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<TSK_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<TSK_T001_C> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnSaveAction(InquiryActionResult<TSK_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnCreateAction(InquiryActionResult<TSK_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnRemoveAction(InquiryActionResult<TSK_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDiscardAction(InquiryActionResult<TSK_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnPrintAction(InquiryActionResult<TSK_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFlipAction(InquiryActionResult<TSK_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnHelpAction(InquiryActionResult<TSK_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFevoriteAction(InquiryActionResult<TSK_T001_C> result)
        {
            throw new NotImplementedException();
        }

        

        #endregion
    }
}
