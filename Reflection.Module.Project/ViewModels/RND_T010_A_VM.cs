using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using System.Collections.ObjectModel;
using Reflection.BusinessEntity.ProjectManagement;
using System.Collections.Specialized;
using System.Windows.Data;
using Reflection.BusinessEntity;

namespace Reflection.Modules.Project.ViewModels
{
    public class RND_T010_A_VM : WorkspaceViewModel<RND_T010> 
    {
        bool isNewRecord = true;
        WebServiceRepository<RND_T010> repository = new WebServiceRepository<RND_T010>();
        WebServiceRepository<MultipleContext_RND_T010> repository_MC = new WebServiceRepository<MultipleContext_RND_T010>();
        WebServiceRepository<MultipleContext_RND_T010> repository_MCTemp = new WebServiceRepository<MultipleContext_RND_T010>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region Declarations
        
        private MultipleContext_RND_T010 _MC;
        public MultipleContext_RND_T010 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_RND_T010 _MCTemp;
        public MultipleContext_RND_T010 MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private MultipleContext_RND_T010 _MCTemp1;
        public MultipleContext_RND_T010 MCTemp1
        {
            get { return _MCTemp1; }
            set { _MCTemp1 = value; RaisePropertyChanged("MCTemp1"); }
        }

        private RND_T010 _MasterEntity;
        public RND_T010 MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }

        private RND_T010 _MasterEntity1;
        public RND_T010 MasterEntity1
        {
            get
            { return _MasterEntity1; }
            set
            {
                _MasterEntity1 = value;
                RaisePropertyChanged("MasterEntity1");
            }
        }
        
        private ObservableCollection<RND_T010_A> _AdminEntity;
        public ObservableCollection<RND_T010_A> AdminEntity
        {
            get { return _AdminEntity; }
            set
            {
                if (_AdminEntity != value)
                {
                    _AdminEntity = value;
                    AdminEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForAdmin);
                    RaisePropertyChanged("AdminEntity");
                }
            }
        }

        private ObservableCollection<RND_T010_A2> _AdminEntity2;
        public ObservableCollection<RND_T010_A2> AdminEntity2
        {
            get { return _AdminEntity2; }
            set
            {
                if (_AdminEntity2 != value)
                {
                    _AdminEntity2 = value;
                    AdminEntity2.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForAdmin);
                    RaisePropertyChanged("AdminEntity2");
                }
            }
        }

        private void AdminEntity_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private RND_T010 _SyncEntity;
        public RND_T010 SyncEntity
        {
            get { return _SyncEntity; }
            set
            {
                if (_SyncEntity != value)
                {
                    _SyncEntity = value;
                    RaisePropertyChanged("SyncEntity");
                }
            }
        }       

        private int _dgSelectedIndexAdmin;
        public int dgSelectedIndexAdmin
        {
            get
            { return _dgSelectedIndexAdmin; }
            set
            {
                if (_dgSelectedIndexAdmin != value)
                {
                    _dgSelectedIndexAdmin = value;
                    RaisePropertyChanged("dgSelectedIndexAdmin");
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

        private ICollectionView _AdminEntityFilter;
        public ICollectionView AdminEntityFilter
        {
            get { return _AdminEntityFilter; }
            set { _AdminEntityFilter = value; RaisePropertyChanged("AdminEntityFilter"); }
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

        #region Relay Commands Declaratio
        
        public RelayCommand<object> CmdDeleteDataGridRowDetail { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand cmdLoadInsertTestBedRecord { get; private set; }

        #endregion

        #region Event Handler
        void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (AdminEntity.Count > dgSelectedIndexAdmin && dgSelectedIndexAdmin >= 0)
            {
                this.ErrorExist = false; /* ParameterEntity[dgSelectedIndexParaCode].HasErrors;*/
            }
        }
        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false; /*MasterEntity.HasErrors;*/
            if (AdminEntity.Count > dgSelectedIndexAdmin && dgSelectedIndexAdmin >= 0)
            {
                this.ErrorExist = false;/*ParameterEntity[dgSelectedIndexItem].HasErrors;*/
            }
        }
        private void CollectionChangedNotifyForAdmin(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (RND_T010_A item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (RND_T010_A item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (RND_T010_A item in e.NewItems)
                    {
                        item.active = true;
                        item.location_Id = AppSessionState.location_Id;
                        item.comp_code = AppSessionState.comp_code;
                        item.add_by = AppSessionState.UserID;
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
        #endregion

        #region Constructor
        public RND_T010_A_VM() : base()
        {

            MasterEntity = new RND_T010();
            MasterEntity1 = new RND_T010();
            AdminEntity = new ObservableCollection<RND_T010_A>();
            AdminEntity2 = new ObservableCollection<RND_T010_A2>();
            SyncEntity = new RND_T010();
            MC = new MultipleContext_RND_T010();
            MCTemp = new MultipleContext_RND_T010();
            MCTemp1 = new MultipleContext_RND_T010();

            cmdLoadInsertTestBedRecord = new GalaSoft.MvvmLight.Command.RelayCommand(() => { LoadInsertTestBedRecord(); });
            CmdDeleteDataGridRowDetail = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRowDetail(items); });            

            LoadInitialData();
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString();
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_RND_T010>(MC, Request, "DAS_Controls", "PM", "LoadInitialData", 0, "");

                AdminEntity = MC.AdminEntity;
                Copy(AdminEntity, AdminEntity2);

                AdminEntityFilter = CollectionViewSource.GetDefaultView(MC.AdminEntity);
                AdminEntityFilter.Filter = new Predicate<object>(Filter);                
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
        private void Copy(ObservableCollection<RND_T010_A> AdminEntity, ObservableCollection<RND_T010_A2> AdminEntity2)
        {
            foreach (RND_T010_A propA in AdminEntity)
            {
                RND_T010_A2 propB = new RND_T010_A2("");
                propB.active = propA.active;
                propB.ip_address = propA.ip_address;
                propB.last_migration = propA.last_migration;
                propB.max_id = propA.max_id;
                propB.tb_name = propA.tb_name;
                propB.tb_code = propA.tb_code;
                propB.user_id = propA.user_id;
                AdminEntity2.Add(propB);
            }
        }
        
        private void LoadInsertTestBedRecord()
        {
            try
            {
                if (Validation() == true)
                {
                    string Request = "LoadTBsConnection" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString();
                  
                    MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_RND_T010>(MC, Request, "DAS_Controls_Synch", "PM", "LoadInitialData", 0, "");

                    StartSynchronisation();                   
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
        private void DeleteDataGridRowDetail(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (AdminEntity.Count > i && AdminEntity[dgSelectedIndexAdmin].id == 0)
                {
                    AdminEntity.RemoveAt(i);
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
                if (MasterEntity.XmlDataDocument_RND_T010_A != null )
                {
                    AdminEntity.Clear();
                    AdminEntity = (ObservableCollection<RND_T010_A>)obj.XMLToObject(MasterEntity.XmlDataDocument_RND_T010_A, MC.AdminEntity);                   
                  
                }
                else
                {
                    AdminEntity = new ObservableCollection<RND_T010_A>();
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
        private bool Validation()
        {
            return true;
        }
        
        #endregion

        #region Abstract Command Actions
        protected override void OnSaveAction(InquiryActionResult<RND_T010> result)
        {
            try
            {
                MasterEntity.XmlDataDocument_RND_T010_A = obj.ObjectToXML(AdminEntity);                
                this.MasterEntity.EndEdit();
                
                if (Validation() == true)
                {                    
                    MasterEntity = repository.SaveWithReturnDomainObject<RND_T010>(MasterEntity, "DAS_Controls_InsertAdmin", "PM");                      
                    
                    if (MasterEntity.XmlDataDocument_RND_T010_A != null)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved and Updated Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }                    

                    SetBusinessEntitiesAfterLoad("Save", "");
                    //isNewRecord = false;
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
        protected override void OnRefreshCommand(InquiryActionResult<RND_T010> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<RND_T010> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<RND_T010> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<RND_T010> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<RND_T010> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<RND_T010> result)
        {
            isNewRecord = true;
            MasterEntity = new RND_T010();
            AdminEntity = new ObservableCollection<RND_T010_A>();
            SyncEntity = new RND_T010();           
        }
        protected override void OnRemoveAction(InquiryActionResult<RND_T010> result)
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
        protected override void OnDiscardAction(InquiryActionResult<RND_T010> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<RND_T010> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<RND_T010> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<RND_T010> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<RND_T010> result)
        {

        }

        #endregion

        #region Filters       

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
            if (_AdminEntityFilter != null)
            {
                _AdminEntityFilter.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as RND_T010_A;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.tb_code != null && data.tb_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.tb_name != null && data.tb_name.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.status != null && data.status.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.ip_address != null && data.ip_address.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.db != null && data.db.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.user_id != null && data.user_id.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.password != null && data.password.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.last_migration != null && data.last_migration.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            //data.ip_address != null && data.ip_address.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.table_name != null && data.table_name.ToString().ToLower().Contains(_filterString.ToLower())
                            );
                }
                return true;
            }
            return false;
        }      

        #endregion

        #region Animation

        void StartSynchronisation()
        {
            foreach (RND_T010_A2 TBSync in AdminEntity2)
                TBSync.StartNewSyncData();
        }

        

        #endregion
    }
}
