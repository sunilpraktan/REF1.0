using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Services;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System.Windows.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.HRMS;
using GalaSoft.MvvmLight.Command;
using System.Collections;
using System.ComponentModel;
using Reflection.Presentation.Services.Convertors;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Specialized;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.HRMS.ViewModels
{
    public class HRM_M015_VM : WorkspaceViewModel<HRM_M015>
    {
        bool isNewRecord = true;
        WebServiceRepository<HRM_M015> repository = new WebServiceRepository<HRM_M015>();
        WebServiceRepository<MultipleContext_HRM_M015> repository_MC = new WebServiceRepository<MultipleContext_HRM_M015>();
        WebServiceRepository<MultipleContext_HRM_M015> repository_MCTemp = new WebServiceRepository<MultipleContext_HRM_M015>();
        ObjectSerializationService obj = new ObjectSerializationService();


        #region AutoSuggest Initialization
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(HRM_M015_VM));
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
                }
            }
        }


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

        private AutoSuggestTextViewModel<dynamic> _ASStatus { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASStatus
        {
            get { return _ASStatus; }
            set
            {
                if (_ASStatus != value)
                {
                    _ASStatus = value; RaisePropertyChanged("ASStatus");
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
        #endregion

        #region Variable Declaration
        private HRM_M015 _MasterEntity;
        public HRM_M015 MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value; RaisePropertyChanged("MasterEntity");
                    RaisePropertyChanged("MasterEntity");
                    value.BeginEdit();
                }
            }
        }
        private ObservableCollection<HRM_M015_A> _DetailEntity;
        public ObservableCollection<HRM_M015_A> DetailEntity
        {
            get { return _DetailEntity; }
            set
            {
                if (_DetailEntity != value)
                {
                    _DetailEntity = value;
                    DetailEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForDetails);
                    RaisePropertyChanged("DetailEntity");
                }
            }
        }
        private List<HRM_M015_BackFlip> _FlipGridData;
        public List<HRM_M015_BackFlip> FlipGridData
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
        private int _dgSelectedIndexDetail;
        public int dgSelectedIndexDetail
        {
            get
            { return _dgSelectedIndexDetail; }
            set
            {
                if (_dgSelectedIndexDetail != value)
                {
                    _dgSelectedIndexDetail = value;
                    RaisePropertyChanged("dgSelectedIndexDetail");
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
        private MultipleContext_HRM_M015 _MC;
        public MultipleContext_HRM_M015 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_HRM_M015 _MCTemp;
        public MultipleContext_HRM_M015 MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private MultipleContext_HRM_M015 _MCTemp1;
        public MultipleContext_HRM_M015 MCTemp1
        {
            get { return _MCTemp1; }
            set { _MCTemp1 = value; RaisePropertyChanged("MCTemp1"); }
        }

        private List<HRM_M015> _SelectedList;
        public List<HRM_M015> SelectedList
        {
            get
            {
                return _SelectedList;
            }
            set
            {
                if (_SelectedList != value)
                {
                    _SelectedList = value;
                    RaisePropertyChanged("SelectedList");
                }
            }
        }
        #endregion

        #region Relay Commands Declaration

        public RelayCommand<object> CmdStatus { get; private set; }
        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }
        #endregion

        #region Event Handler
        private void CollectionChangedNotifyForDetails(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (HRM_M015_A item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (HRM_M015_A item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (HRM_M015_A item in e.NewItems)
                    {
                        item.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        item.client = AppSessionState.client;
                        item.add_by = AppSessionState.UserID;
                        item.editby = AppSessionState.UserID;
                        item.active = true;
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
            if (DetailEntity.Count > dgSelectedIndexDetail && dgSelectedIndexDetail >= 0)
            {
                this.ErrorExist = false;
            }
        }
        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false; /*MasterEntity.HasErrors;*/
            if (DetailEntity.Count > dgSelectedIndexDetail && dgSelectedIndexDetail >= 0)
            {
                this.ErrorExist = false;
            }
        }

        #endregion

        #region Constructor
        public HRM_M015_VM() : base()
        {
            MasterEntity = new HRM_M015();
            DetailEntity = new ObservableCollection<HRM_M015_A>();

            MC = new MultipleContext_HRM_M015();
            MCTemp = new MultipleContext_HRM_M015();
            MCTemp1 = new MultipleContext_HRM_M015();

            CmdStatus = new RelayCommand<object>(items => { if (items == null) { return; } InsertStatus(items); });
            CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });

            LoadInitialData();

        }

        #endregion

        #region User Defined Methods
        private void DefaultValues()
        {
            MasterEntity.active = true;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.add_date = System.DateTime.Now;
            MasterEntity.edit_date = System.DateTime.Now;
        }
        private bool Validation()
        {
            if (MasterEntity.ter_id == null || MasterEntity.ter_id == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter The Terminal ID...");
                showMessageService.ShowMessage();
                return false;
            }

            return true;
        }
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + MasterEntity.ter_id + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_HRM_M015>(MC, Request, "TerminalMaster", "HRMS", "LoadInitialData", 0, "");



                FlipGridData = MC.BackFlipEntity;
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                #region AutoSuggest Initalization
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_name ?? "");
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_status ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M0013)o).t_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASStatus = new AutoSuggestTextViewModel<dynamic>(MC.StatusList, TheFilter, SuggestedValue, "t_name", true);
                ASStatus.AutoSuggestVM.IsEmptyValueAllowed = true;

                DefaultValues();
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

        private void InsertStatus(object InputValue)
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
                            {
                                POPUPEntityObject = MC.StatusList.Where(x => x.t_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
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
                    MasterEntity.t_name = POPUPEntityObject.t_name;
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
            string Request = "";
            HRM_M015_BackFlip ParameterEntityObject = new HRM_M015_BackFlip();

            try
            {
                if (((IEnumerable)ParameterObject).Cast<HRM_M015_BackFlip>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<HRM_M015_BackFlip>().ToList()[0];

                    Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.ter_id + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.client;
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_HRM_M015>(MCTemp, Request, "TerminalMaster", "HRMS", "LoadDocumentByDocumentNumber", 0, "");

                    if (MCTemp.MasterData.Count > 0)
                    {
                        MasterEntity = MCTemp.MasterData[0];
                    }
                    DetailEntity = MCTemp.DetailData;

                    SetBusinessEntitiesAfterLoad("Save", "");

                }
                isNewRecord = false;
                SelectedTabControlIndex = 0;
                var msg = new NotificationMessage("HRM_M015_VM");
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

        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                if (MasterEntity.XmlDataDocument_HRM_M015_A != null)
                {
                    DetailEntity.Clear();
                    MC.DetailData = (ObservableCollection<HRM_M015_A>)obj.XMLToObject(MasterEntity.XmlDataDocument_HRM_M015_A, MC.DetailData);
                    DetailEntity = MC.DetailData;
                }
                else
                {
                    MC.DetailData = new ObservableCollection<HRM_M015_A>();
                }
                if (MasterEntity.XmlDataDocument_HRM_M015_Flip != null && isNewRecord == true && ParameterOption1 == "Save")
                {
                    MC.BackFlipEntity = (List<HRM_M015_BackFlip>)obj.XMLToObject(MasterEntity.XmlDataDocument_HRM_M015_Flip, MC.BackFlipEntity);
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

        #endregion

        #region Abstract Command Actions
        string strReturn = "";
        protected override void OnSaveAction(InquiryActionResult<HRM_M015> result)
        {
            try
            {
                MasterEntity.editby = AppSessionState.UserID;
                MasterEntity.XmlDataDocument_HRM_M015_A = obj.ObjectToXML(DetailEntity);
                this.MasterEntity.EndEdit();
                if (Validation() == true)
                {
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<HRM_M015>(MasterEntity, "TerminalMaster", "HRMS");
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<HRM_M015>(MasterEntity, "TerminalMaster", "HRMS");
                    }

                    if (MasterEntity.ter_id != null && isNewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    if (MasterEntity.ter_id != null && isNewRecord == false)
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
        }
        protected override void OnCreateAction(InquiryActionResult<HRM_M015> result)
        {
            isNewRecord = true;
            MasterEntity = new HRM_M015();
            DetailEntity = new ObservableCollection<HRM_M015_A>();

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<HRM_M015> result)
        {
            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            showMessageService.ButtonSetup = DialogButton.Ok;
            showMessageService.Caption = "Delete Changes";
            showMessageService.Text = String.Format("This record will be Deleted forever", this.Title);
            if (showMessageService.ShowMessage() == DialogResult.Ok)
            {
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<HRM_M015> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<HRM_M015> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<HRM_M015> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<HRM_M015> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<HRM_M015> result)
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<HRM_M015> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<HRM_M015> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<HRM_M015> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<HRM_M015> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<HRM_M015> result)
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
            var data = obj as HRM_M015_BackFlip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.ter_id != null && data.ter_id.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.ter_desc != null && data.ter_desc.ToString().ToLower().Contains(_filterString.ToLower()
                           ) 
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
