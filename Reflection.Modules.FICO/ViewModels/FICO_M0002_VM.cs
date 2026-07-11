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
using Reflection.BusinessEntity;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Reflection.ReportingServices;
using Reflection.BusinessEntity.Admin;

namespace Reflection.Modules.FICO.ViewModels
{
    public class FICO_M0002_VM : WorkspaceViewModel<ACC_M007>
    {
        bool NewRecord = true;

        WebServiceRepository<ACC_M007> repository = new WebServiceRepository<ACC_M007>();
        WebServiceRepository<MC_ACC_M007> repository_MC = new WebServiceRepository<MC_ACC_M007>();
        WebServiceRepository<MC_ACC_M007> repository_MCTemp = new WebServiceRepository<MC_ACC_M007>();

        ObjectSerializationService obj = new ObjectSerializationService();


        #region Declaration        
        private ACC_M007 _MasterEntity;
        public ACC_M007 MasterEntity
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
                }
            }
        }

        private ObservableCollection<ACC_M007_A> _ItemsEntity;
        public ObservableCollection<ACC_M007_A> ItemsEntity
        {
            get { return _ItemsEntity; }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value;
                    ItemsEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForDetails);
                    RaisePropertyChanged("ItemsEntity");
                }
            }
        }

        private MC_ACC_M007 _MC;
        public MC_ACC_M007 MC
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

        private MC_ACC_M007 _MCTemp;
        public MC_ACC_M007 MCTemp
        {
            get { return _MCTemp; }
            set
            {
                if (_MCTemp != value)
                {
                    _MCTemp = value;
                    RaisePropertyChanged("MCTemp");
                }
            }
        }

        private bool _MoveFlag;   //movement type enable disable
        public bool MoveFlag
        {
            get { return _MoveFlag; }
            set { _MoveFlag = value; RaisePropertyChanged("MoveFlag"); }
        }

        private int _dgSelectedIndexDetails;
        public int dgSelectedIndexDetails
        {
            get { return _dgSelectedIndexDetails; }
            set
            {
                if (_dgSelectedIndexDetails != value)
                {
                    _dgSelectedIndexDetails = value;
                    RaisePropertyChanged("dgSelectedIndexDetails");
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
        #endregion
        #region Collection

        private ICollectionView _BACKFLIP_COLLECTION;
        public ICollectionView BACKFLIP_COLLECTION
        {
            get { return _BACKFLIP_COLLECTION; }
            set { _BACKFLIP_COLLECTION = value; RaisePropertyChanged("BACKFLIP_COLLECTION"); }
        }

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
            if (BACKFLIP_COLLECTION != null)
            {
                BACKFLIP_COLLECTION.Refresh();
            }
        }
        public bool FLTR_BACKFLIP(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FLTR_STR_BACKFLIP))
                {
                    return (data.pt_code != null && data.pt_code.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.pt_name != null && data.pt_name.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.short_text != null && data.short_text.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.cat_name != null && data.cat_name.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Collection
        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }

        #endregion

        #region Relay Command Decalration
        public RelayCommand<object> cmdLoadDocument { get; private set; }
        public RelayCommand<object> CmdAddGroup { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowEntity { get; private set; }
        #endregion

        #region Event Handler
        private void CollectionChangedNotifyForDetails(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (ACC_M007_A item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (ACC_M007_A item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (ACC_M007_A item in e.NewItems)
                    {
                        item.active = "1";

                        item.PropertyChanged += EntityViewModelPropertyChanged;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (ItemsEntity.Count > dgSelectedIndexDetails && dgSelectedIndexDetails >= 0)
            {
                this.ErrorExist = false;
            }
        }
        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false; /*MasterEntity.HasErrors;*/
            if (ItemsEntity.Count > dgSelectedIndexDetails && dgSelectedIndexDetails >= 0)
            {
                this.ErrorExist = false;
            }
        }

        #endregion

        #region User Defined Functions
        private void DefaultValues()
        {
            MasterEntity.client = AppSessionState.client;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.session_id = AppSessionState.session_id;
            //MasterEntity.ts_code = ts;
        }
        #endregion

        #region Validation
        private bool Validation()
        {
            if (MasterEntity.pt_name == null || MasterEntity.pt_name == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Payment Term...");
                showMessageService.ShowMessage();
                return false;
            }
            return true;
        }
        #endregion

        #region Constructor 
        public FICO_M0002_VM(string ts) : base()
        {
            MasterEntity = new ACC_M007();
            ItemsEntity = new ObservableCollection<ACC_M007_A>();
            
            MC = new MC_ACC_M007();
            MasterEntity.ValidateAsync().Wait();

            cmdLoadDocument = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocument(cmdPara, "FlipGridReference"); });
            CmdDeleteDataGridRowEntity = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRowEntity(cmdPara); });

            MoveFlag = true;
            LoadInitialData();
        }
        private void LoadInitialData()
        {
            try
            {
                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MC_ACC_M007>(MC, Request, "PaymentTerms", "Administration", "LoadAll", 0, "");

                BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(MC.BACK_FLIP_LIST.ToList());
                BACKFLIP_COLLECTION.Filter = new Predicate<object>(FLTR_BACKFLIP);
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

        #region Relay Command Actions      
        private void LoadDocument(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";
                STD_LIST_BE ParameterEntityObject = null;

                if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList()[0];
                        Request = "LOAD_DOCUMENT" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + ParameterEntityObject.pt_code;
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MC_ACC_M007>(MC, Request, "PaymentTerms", "Administration", "LOAD_DOCUMENT", 0, "");

                        SelectedTabControlIndex = 0;
                        NewRecord = false;
                        MoveFlag = false;

                        if (MCTemp.MasterList.Count > 0)
                        {
                            MasterEntity = MCTemp.MasterList[0];
                        }
                        ItemsEntity = MCTemp.ItemsList;
                    }
                    NewRecord = false;
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
                if (MasterEntity.XDOC_A != null)
                {
                    ItemsEntity.Clear();
                    MC.ItemsList = (ObservableCollection<ACC_M007_A>)obj.XMLToObject(MasterEntity.XDOC_A, MC.ItemsList);
                    ItemsEntity = MC.ItemsList;
                }
                else
                {
                    MC.ItemsList = new ObservableCollection<ACC_M007_A>();
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

        private void DeleteDataGridRowEntity(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemsEntity.Count > i && ItemsEntity[dgSelectedIndexDetails].id == 0)
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

        #endregion

        #region Abstract Methods
        protected override void OnSaveAction(InquiryActionResult<ACC_M007> result)
        {
            try
            {
                MasterEntity.XDOC_A = obj.ObjectToXML(ItemsEntity);
                this.MasterEntity.EndEdit();

                if (Validation() == true)
                {
                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ACC_M007>(MasterEntity, "PaymentTerms", "Administration");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ACC_M007>(MasterEntity, "PaymentTerms", "Administration");
                    }

                    if (MasterEntity.pt_code != null && NewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Saved Successfully");
                        showMessageService.ShowMessage();
                    }
                    if (MasterEntity.pt_code != null && NewRecord == false)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Updated Successfully");
                        showMessageService.ShowMessage();
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    NewRecord = false;
                    MoveFlag = false;
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
        protected override void OnCreateAction(InquiryActionResult<ACC_M007> result)
        {
            NewRecord = true;
            MasterEntity = new ACC_M007();
            ItemsEntity = new ObservableCollection<ACC_M007_A>();
            DefaultValues();
            MoveFlag = true;
        }
        protected override void OnRemoveAction(InquiryActionResult<ACC_M007> result)
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
                string response = repository.Delete(MasterEntity.pt_code, "PaymentTerms", "Administration");

                MasterEntity = new ACC_M007();
                NewRecord = true;
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ACC_M007> result)
        {

        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ACC_M007> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ACC_M007> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ACC_M007> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ACC_M007> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ACC_M007> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ACC_M007> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ACC_M007> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ACC_M007> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ACC_M007> result)
        {
            try
            {

                string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code;


                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MC_ACC_M007>(MC, Request, "PaymentTerms", "Administration", "LoadAll", 0, "");
                object[] objDataSource = new object[3];
                string[] objDataSourceName = new string[3];



                objDataSource[0] = MCTemp.BACK_FLIP_LIST;

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == AppSessionState.OBJ_COMPANY.comp_code).ToList();
                objDataSource[1] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == AppSessionState.OBJ_LOCATION.location_id).ToList();
                objDataSource[2] = Result;



                objDataSourceName[0] = "dsPayment";
                objDataSourceName[1] = "dsCompany";
                objDataSourceName[2] = "dsLocation";


                ReportManager ReportManager = new ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Admin\\PaymentTerms.rdlc", getParametersList(), "");
            }
            catch (Exception ex) { }

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
                RaisePropertyChanged("FilterString_FlipGrid");
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
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_FlipGrid))
                {
                    return

                        (data.pt_code != null && data.p_term_code.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.pt_name != null && data.p_term.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
                }
                return true;
            }
            return false;
        }


        #endregion
    }
}
