using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.Presentation.ViewModel;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Services;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.HRMS;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using Reflection.Presentation.Services.Convertors;
using System.Collections;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using System.Collections.Specialized;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.HRMS.ViewModels
{
    public class HRM_M016_VM : WorkspaceViewModel<HRM_M016>
    {
        bool isNewRecord = true;
        WebServiceRepository<HRM_M016> repository = new WebServiceRepository<HRM_M016>();
        WebServiceRepository<MultipleContext_HRM_M016> repository_MC = new WebServiceRepository<MultipleContext_HRM_M016>();
        WebServiceRepository<MultipleContext_HRM_M016> repository_MCTemp = new WebServiceRepository<MultipleContext_HRM_M016>();

        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region

        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(HRM_M016_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _ASStatus { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASStatus
        {
            get { return _ASStatus; }
            set
            {
                if (_ASStatus != value)
                {
                    _ASStatus = value;
                    RaisePropertyChanged("ASStatus");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASControlCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASControlCode
        {
            get { return _ASControlCode; }
            set
            {
                if (_ASControlCode != value)
                {
                    _ASControlCode = value;
                    RaisePropertyChanged("ASControlCode");
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
                    _ASDefault = value;
                    RaisePropertyChanged("ASDefault");
                }
            }
        }
        private DataGridCellInfo _cellInfo;
        public DataGridCellInfo CellInfo
        {
            get { return _cellInfo; }
            set
            {
                if (_cellInfo != value)
                {
                    _cellInfo = value;
                    SetAutoTextSource(_cellInfo);
                    RaisePropertyChanged("CellInfo");
                }
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
                    if (SourceName == "control_code")
                    { ASDefault = ASControlCode; }

                }
            }
        }
        #endregion

        #region Declarations   

        private MultipleContext_HRM_M016 _MC;
        public MultipleContext_HRM_M016 MC
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

        private MultipleContext_HRM_M016 _MCTemp;
        public MultipleContext_HRM_M016 MCTemp
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


        private HRM_M016 _MasterEntity;
        public HRM_M016 MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value;
                    RaisePropertyChanged("MasterEntity");
                }
            }
        }
        private int _dgSelectedIndexAssignToEquipment;
        public int dgSelectedIndexAssignToEquipment
        {
            get
            { return _dgSelectedIndexAssignToEquipment; }
            set
            {
                if (_dgSelectedIndexAssignToEquipment != value)
                {
                    _dgSelectedIndexAssignToEquipment = value;
                    RaisePropertyChanged("dgSelectedIndexAssignToEquipment");
                }
            }
        }
        #endregion
        
        #region ICollectionView

        private ICollectionView _EquipmentCollection;
        public ICollectionView EquipmentCollection
        {
            get { return _EquipmentCollection; }
            set
            {
                if (_EquipmentCollection != value)
                {
                    _EquipmentCollection = value;
                    RaisePropertyChanged("EquipmentCollection");
                }
            }
        }
        private ObservableCollection<HRM_M016_A> _ControlCollection;
        public ObservableCollection<HRM_M016_A> ControlCollection
        {
            get { return _ControlCollection; }
            set
            {
                if (_ControlCollection != value)
                {
                    _ControlCollection = value;
                    RaisePropertyChanged("ControlCollection");
                }
            }
        }
        private List<HRM_M016_BackFlip> _FlipGridData;
        public List<HRM_M016_BackFlip> FlipGridData
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
        private List<HRM_M016> _SelectedList;
        public List<HRM_M016> SelectedList
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

        private int _SelectedTabControlIndex;
        public int SelectedTabControlIndex
        {
            get
            {
                return _SelectedTabControlIndex;
            }
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

        #region Relay Commands Declaration

        public RelayCommand<object> CmdStatus { get; private set; }
        public RelayCommand<object> CmdControlCode { get; private set; }
        public RelayCommand<object> CmdLoadDocByDocNumber { get; private set; }

        #endregion

        #region  Constructor

        public HRM_M016_VM() : base()
        {
            MasterEntity = new HRM_M016();
            ControlCollection = new ObservableCollection<HRM_M016_A>();

            MC = new MultipleContext_HRM_M016();
            MCTemp = new MultipleContext_HRM_M016();

            CmdStatus = new RelayCommand<object>(items => { if (items == null) { return; } Insert_Status(items); });
            CmdControlCode = new RelayCommand<object>(items => { if (items == null) { return; } Insert_ControlCode(items, false, true, true); });
            CmdLoadDocByDocNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
            LoadinitialData();
        }

        #endregion

        #region User Defined Functions
        private void LoadinitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_HRM_M016>(MC, Request, "EquipmentMaster", "HRMS", "LoadInitialData", 0, "");

                DefaultValues();

                FlipGridData = MC.BackFlipEntity;
                EquipmentCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                EquipmentCollection.Filter = new Predicate<object>(Filter);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_status);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASStatus = new AutoSuggestTextViewModel<dynamic>(MC.StatusList, TheFilter, SuggestedValue, "t_status", true);
                ASStatus.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M028_P)x).control_code);
                TheFilter = (o, prefix) => (((SYS_M028_P)o).control_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASControlCode = new AutoSuggestTextViewModel<dynamic>(MC.ControlList, TheFilter, SuggestedValue, "control_code", "control_code", true);
                ASControlCode.AutoSuggestVM.IsEmptyValueAllowed = true;
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
            MasterEntity.active = true;
            MasterEntity.lang_key = AppSessionState.UserID;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.add_date = System.DateTime.Now;
            MasterEntity.edit_date = System.DateTime.Now;
        }
        private bool Validation()
        {
            if (MasterEntity.equ_id == null || MasterEntity.equ_id == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Valid Equipment ID");
                showMessageService.ShowMessage();
                return false;
            }
            else
            {
                return true;
            }
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            HRM_M016_BackFlip ParameterEntityObject = new HRM_M016_BackFlip();

            try
            {
                if (((IEnumerable)ParameterObject).Cast<HRM_M016_BackFlip>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<HRM_M016_BackFlip>().ToList()[0];

                    Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.equ_id + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.client;
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_HRM_M016>(MCTemp, Request, "EquipmentMaster", "HRMS", "LoadDocumentByDocumentNumber", 0, "");

                    if (MCTemp.EquipmentList.Count > 0)
                    {
                        MasterEntity = MCTemp.EquipmentList[0];
                    }
                    ControlCollection = MCTemp.ControlDescList;

                    SetBusinessEntitiesAfterLoad("Save", "");

                }
                isNewRecord = false;
                SelectedTabControlIndex = 0;
                var msg = new NotificationMessage("HRM_M016_VM");
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
                if (MasterEntity.XmlDataDocument_HRM_M016_A != null)
                {
                    ControlCollection.Clear();
                    MC.ControlDescList = (ObservableCollection<HRM_M016_A>)obj.XMLToObject(MasterEntity.XmlDataDocument_HRM_M016_A, MC.ControlDescList);
                    ControlCollection = MC.ControlDescList;
                }
                else
                {
                    MC.ControlDescList = new ObservableCollection<HRM_M016_A>();
                }
                if (MasterEntity.XmlDataDocument_HRM_M016_Flip != null && isNewRecord == true && ParameterOption1 == "Save")
                {
                    MC.BackFlipEntity = (List<HRM_M016_BackFlip>)obj.XMLToObject(MasterEntity.XmlDataDocument_HRM_M016_Flip, MC.BackFlipEntity);
                    FlipGridData.Add(MC.BackFlipEntity[0]);
                    EquipmentCollection.Refresh();
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
        private void Insert_Status(object InputValue)
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
                                POPUPEntityObject = MC.StatusList.Where(x => x.t_status.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.t_name.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];

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
                //        showMessageService.ShowMessage();
            }
        }
        private void Insert_ControlCode(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                SYS_M028_P POPUPEntityObject = null;
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
                            POPUPEntityObject = MC.ControlList.Where(x => x.control_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.control_desc.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M028_P>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {

                    if (dgSelectedIndexAssignToEquipment >= 0 && ControlCollection.Count > dgSelectedIndexAssignToEquipment) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {

                        ControlCollection[dgSelectedIndexAssignToEquipment].control_code = POPUPEntityObject.control_code;
                        ControlCollection[dgSelectedIndexAssignToEquipment].control_desc = POPUPEntityObject.control_desc;

                        MasterEntity.active = true;
                    }
                    else if (ControlCollection[dgSelectedIndexAssignToEquipment].control_code != POPUPEntityObject.control_code)
                    {
                        ControlCollection[dgSelectedIndexAssignToEquipment].control_code = POPUPEntityObject.control_code;
                        ControlCollection[dgSelectedIndexAssignToEquipment].control_desc = POPUPEntityObject.control_desc;
                        MasterEntity.active = true;
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

        #region Abstract Command Actions

        protected override void OnCreateAction(InquiryActionResult<HRM_M016> result)
        {
            isNewRecord = true;
            MasterEntity = new HRM_M016();
            ControlCollection = new ObservableCollection<HRM_M016_A>();
            DefaultValues();
        }

        protected override void OnDiscardAction(InquiryActionResult<HRM_M016> result)
        {

        }

        protected override void OnDocumentAction()
        {

        }

        protected override void OnFevoriteAction(InquiryActionResult<HRM_M016> result)
        {

        }

        protected override void OnFlipAction(InquiryActionResult<HRM_M016> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<HRM_M016> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<HRM_M016> result)
        {

        }

        protected override void OnRemoveAction(InquiryActionResult<HRM_M016> result)
        {

        }

        protected override void OnSaveAction(InquiryActionResult<HRM_M016> result)
        {
            try
            {
                MasterEntity.editby = AppSessionState.UserID;
                this.MasterEntity.EndEdit();
                MasterEntity.XmlDataDocument_HRM_M016_A = obj.ObjectToXML(ControlCollection);
                if (Validation() == true)
                {
                    
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<HRM_M016>(MasterEntity, "EquipmentMaster", "HRMS");

                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<HRM_M016>(MasterEntity, "EquipmentMaster", "HRMS");
                    }
                    if (MasterEntity.equ_id != null && isNewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    if (MasterEntity.equ_id != null && isNewRecord == false)
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

        protected override void OnRefreshCommand(InquiryActionResult<HRM_M016> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<HRM_M016> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<HRM_M016> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<HRM_M016> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<HRM_M016> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Filters

        private string _filterString;
        public string FilterString
        {
            get { return _filterString; }
            set
            {
                if (_filterString != value)
                {
                    _filterString = value;
                    RaisePropertyChanged("FilterString");
                    FilterCollection();
                }
            }
        }
        private void FilterCollection()
        {
            if (_EquipmentCollection != null)
            {
                _EquipmentCollection.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as HRM_M016_BackFlip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {

                    return (data.equ_id != null && data.equ_id.ToString().ToLower().Contains(_filterString.ToLower()) ||
                             data.equ_name != null && data.equ_name.ToString().ToLower().Contains(_filterString.ToLower())
                            );
                }
                return true;
            }
            return false;
        }

        

        #endregion
    }
}
