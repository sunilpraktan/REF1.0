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
    public class HRM_T001_VM : WorkspaceViewModel<HRM_T001>
    {
        bool isNewRecord = true;
        WebServiceRepository<HRM_T001>repository = new WebServiceRepository<HRM_T001>();
        WebServiceRepository<MultipleContext_HRM_T001> repository_MC = new WebServiceRepository<MultipleContext_HRM_T001>();
        WebServiceRepository<MultipleContext_HRM_T001> repository_MCTemp = new WebServiceRepository<MultipleContext_HRM_T001>();

        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region

        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(HRM_T001_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _ASReasonCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASReasonCode
        {
            get { return _ASReasonCode; }
            set
            {
                if (_ASReasonCode != value)
                {
                    _ASReasonCode = value;
                    RaisePropertyChanged("ASReasonCode");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASSubReasonCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSubReasonCode
        {
            get { return _ASSubReasonCode; }
            set
            {
                if (_ASSubReasonCode != value)
                {
                    _ASSubReasonCode = value;
                    RaisePropertyChanged("ASSubReasonCode");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASDocType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDocType
        {
            get { return _ASDocType; }
            set
            {
                if (_ASDocType != value)
                {
                    _ASDocType = value;
                    RaisePropertyChanged("ASDocType");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASDocCategory { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDocCategory
        {
            get { return _ASDocCategory; }
            set
            {
                if (_ASDocCategory != value)
                {
                    _ASDocCategory = value;
                    RaisePropertyChanged("ASDocCategory");
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
                    _ASStatus = value;
                    RaisePropertyChanged("ASStatus");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASRequestType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASRequestType
        {
            get { return _ASRequestType; }
            set
            {
                if (_ASRequestType != value)
                {
                    _ASRequestType = value;
                    RaisePropertyChanged("ASRequestType");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASSub_RequestType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSub_RequestType
        {
            get { return _ASSub_RequestType; }
            set
            {
                if (_ASSub_RequestType != value)
                {
                    _ASSub_RequestType = value;
                    RaisePropertyChanged("ASSub_RequestType");
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
        private AutoSuggestTextViewModel<dynamic> _ASDayType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDayType
        {
            get { return _ASDayType; }
            set
            {
                if (_ASDayType != value)
                {
                    _ASDayType = value;
                    RaisePropertyChanged("ASDayType");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASObjectType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASObjectType
        {
            get { return _ASObjectType; }
            set
            {
                if (_ASObjectType != value)
                {
                    _ASObjectType = value;
                    RaisePropertyChanged("ASObjectType");
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
                    if (SourceName == "day_code")
                    { ASDefault = ASDayType; }
                }
            }
        }
        #endregion

        #region Declarations   

        private MultipleContext_HRM_T001 _MC;
        public MultipleContext_HRM_T001 MC
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

        private MultipleContext_HRM_T001 _MCTemp;
        public MultipleContext_HRM_T001 MCTemp
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


        private HRM_T001 _MasterEntity;
        public HRM_T001 MasterEntity
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
        private int _dgSelectedIndexAssignToRequest;
        public int dgSelectedIndexAssignToRequest
        {
            get
            { return _dgSelectedIndexAssignToRequest; }
            set
            {
                if (_dgSelectedIndexAssignToRequest != value)
                {
                    _dgSelectedIndexAssignToRequest = value;
                    RaisePropertyChanged("dgSelectedIndexAssignToRequest");
                }
            }
        }
        #endregion

        #region ICollectionView

        private ICollectionView _RequestCollection;
        public ICollectionView RequestCollection
        {
            get { return _RequestCollection; }
            set
            {
                if (_RequestCollection != value)
                {
                    _RequestCollection = value;
                    RaisePropertyChanged("RequestCollection");
                }
            }
        }
        private ObservableCollection<HRM_T001_A> _DetailCollection;
        public ObservableCollection<HRM_T001_A> DetailCollection
        {
            get { return _DetailCollection; }
            set
            {
                if (_DetailCollection != value)
                {
                    _DetailCollection = value;
                    RaisePropertyChanged("DetailCollection");
                }
            }
        }
        private List<HRM_T001_BackFlip> _FlipGridData;
        public List<HRM_T001_BackFlip> FlipGridData
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
        private List<HRM_T001> _SelectedList;
        public List<HRM_T001> SelectedList
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
        private List<HRM_M009_A_P> _temp;
        public List<HRM_M009_A_P> temp
        {
            get { return _temp; }
            set
            {
                if (_temp != value)
                {
                    _temp = value;
                    RaisePropertyChanged("temp");
                }
            }
        }
        private List<HRM_M008_A_P> _temp2;
        public List<HRM_M008_A_P> temp2
        {
            get { return _temp2; }
            set
            {
                if (_temp2 != value)
                {
                    _temp2 = value;
                    RaisePropertyChanged("temp2");
                }
            }
        }
        private List<SYS_M022_P> _temp3;
        public List<SYS_M022_P> temp3
        {
            get { return _temp3; }
            set
            {
                if (_temp3 != value)
                {
                    _temp3 = value;
                    RaisePropertyChanged("temp3");
                }
            }
        }
        #endregion

        #region Relay Commands Declaration

        public RelayCommand<object> CmdReasonCode { get; private set; }
        public RelayCommand<object> CmdSubReasonCode { get; private set; }
        public RelayCommand<object> CmdDocType { get; private set; }
        public RelayCommand<object> CmdDocCategory{ get; private set; }
        public RelayCommand<object> CmdStatus { get; private set; }
        public RelayCommand<object> CmdRequestType { get; private set; }
        public RelayCommand<object> CmdSubRequestType { get; private set; }
        public RelayCommand<object> CmdDayType { get; private set; }
        public RelayCommand<object> CmdObjectType { get; private set; }
        public RelayCommand<object> CmdLoadDocByDocNumber { get; private set; }

        #endregion

        #region  Constructor

        public HRM_T001_VM() : base()
        {
            MasterEntity = new HRM_T001();
            DetailCollection = new ObservableCollection<HRM_T001_A>();

            MC = new MultipleContext_HRM_T001();
            MCTemp = new MultipleContext_HRM_T001();

            CmdReasonCode = new RelayCommand<object>(items => { if (items == null) { return; } Insert_ReasonCode(items); });
            CmdSubReasonCode = new RelayCommand<object>(items => { if (items == null) { return; } Insert_SubReasonCode(items); });
            CmdDocType = new RelayCommand<object>(items => { if (items == null) { return; } Insert_DocType(items); });
            CmdDocCategory = new RelayCommand<object>(items => { if (items == null) { return; } Insert_DocCategory(items); });
            CmdStatus = new RelayCommand<object>(items => { if (items == null) { return; } Insert_Status(items); });
            CmdRequestType = new RelayCommand<object>(items => { if (items == null) { return; } Insert_RequestType(items); });
            CmdSubRequestType = new RelayCommand<object>(items => { if (items == null) { return; } Insert_SubRequestType(items); });
            CmdObjectType = new RelayCommand<object>(items => { if (items == null) { return; } Insert_ObjectType(items); });
            CmdLoadDocByDocNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
            CmdDayType = new RelayCommand<object>(items => { if (items == null) { return; } Insert_DayType(items, false, true, true); });
            LoadinitialData();
        }

        #endregion

        #region User Defined Functions
        private void LoadinitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + MasterEntity.requestid + "!@" + AppSessionState.EmpId + "!@"+ AppSessionState.client + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_HRM_T001>(MC, Request, "Attendence_Request", "HRMS", "LoadInitialData", 0, "");

                DefaultValues();

                FlipGridData = MC.BackFlipEntity;
                RequestCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                RequestCollection.Filter = new Predicate<object>(Filter);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((HRM_M009_P)x).reason_code);
                TheFilter = (o, prefix) => (((HRM_M009_P)o).reason_type ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASReasonCode = new AutoSuggestTextViewModel<dynamic>(MC.ReasonList, TheFilter, SuggestedValue, "reason_code", true);
                ASReasonCode.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M021_P)x).doc_cat);
                TheFilter = (o, prefix) => (((SYS_M021_P)o).cat_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDocCategory = new AutoSuggestTextViewModel<dynamic>(MC.DocCategoryList, TheFilter, SuggestedValue, "doc_cat", true);
                ASDocCategory.AutoSuggestVM.IsEmptyValueAllowed = true;  

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((HRM_M008_P)x).request_type);
                TheFilter = (o, prefix) => (((HRM_M008_P)o).req_type_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASRequestType = new AutoSuggestTextViewModel<dynamic>(MC.RequestTypeList, TheFilter, SuggestedValue, "request_type", true);
                ASRequestType.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_status);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASStatus = new AutoSuggestTextViewModel<dynamic>(MC.StatusList, TheFilter, SuggestedValue, "t_status", true);
                ASStatus.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M034_P)x).obj_type);
                TheFilter = (o, prefix) => (((SYS_M034_P)o).obj_type_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASObjectType = new AutoSuggestTextViewModel<dynamic>(MC.ObjectTypeList, TheFilter, SuggestedValue, "obj_type", true);
                ASObjectType.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M033_P)x).day_code);
                TheFilter = (o, prefix) => (((SYS_M033_P)o).day_type ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.DayTypeList, TheFilter, SuggestedValue, "day_code", "day_code", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M033_P)x).day_code);
                TheFilter = (o, prefix) => (((SYS_M033_P)o).day_type ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDayType = new AutoSuggestTextViewModel<dynamic>(MC.DayTypeList, TheFilter, SuggestedValue, "day_code", "day_code", true);
                ASDayType.AutoSuggestVM.IsEmptyValueAllowed = true;
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
            MasterEntity.doc_date = System.DateTime.Now;
            MasterEntity.EmpId = AppSessionState.UserID;
            MasterEntity.lang_key = AppSessionState.UserID;
        }
        private void Logging()
        {
            //MasterEntity.ts_code = this.ts_code_vm;
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
        private bool Validation()
        {
            if (MasterEntity.requestid == null || MasterEntity.requestid == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter The Request Id");
                showMessageService.ShowMessage();
                return false;
            }

            return true;
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            HRM_T001_BackFlip ParameterEntityObject = new HRM_T001_BackFlip();

            try
            {
                if (((IEnumerable)ParameterObject).Cast<HRM_T001_BackFlip>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<HRM_T001_BackFlip>().ToList()[0];

                    Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.requestid + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_HRM_T001>(MCTemp, Request, "Attendence_Request", "HRMS", "LoadDocumentByDocumentNumber", 0, "");

                    if (MCTemp.RequestList.Count > 0)
                    {
                        MasterEntity = MCTemp.RequestList[0];
                    }
                    DetailCollection = MCTemp.DetailList;

                    SetBusinessEntitiesAfterLoad("Save", "");

                }
                isNewRecord = false;
                SelectedTabControlIndex = 0;
                var msg = new NotificationMessage("HRM_T001_VM");
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
                if (MasterEntity.XmlDataDocument_HRM_T001_A != null)
                {
                    DetailCollection.Clear();
                    MC.DetailList = (ObservableCollection<HRM_T001_A>)obj.XMLToObject(MasterEntity.XmlDataDocument_HRM_T001_A, MC.DetailList);
                    DetailCollection = MC.DetailList;
                }
                else
                {
                    MC.DetailList = new ObservableCollection<HRM_T001_A>();
                }
                if (MasterEntity.XmlDataDocument_HRM_T001_Flip != null && isNewRecord == true && ParameterOption1 == "Save")
                {
                    MC.BackFlipEntity = (List<HRM_T001_BackFlip>)obj.XMLToObject(MasterEntity.XmlDataDocument_HRM_T001_Flip, MC.BackFlipEntity);
                    FlipGridData.Add(MC.BackFlipEntity[0]);
                    RequestCollection.Refresh();
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
        private void Insert_ReasonCode(object InputValue)
        {
            string Request = "";
            HRM_M009_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ReasonList.Where(x => x.reason_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<HRM_M009_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<HRM_M009_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.reason_code = POPUPEntityObject.reason_code;
                    MasterEntity.reason_type = POPUPEntityObject.reason_type;

                    temp = (from o in MC.SubReasonList
                             where o.reason_code == POPUPEntityObject.reason_code
                            select o).ToList();

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((HRM_M009_A_P)x).sub_reason_code ?? "");
                    TheFilter = (o, prefix) => (((HRM_M009_A_P)o).sub_reason_type ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((HRM_M009_A_P)o).sub_reason_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                    ASSubReasonCode = new AutoSuggestTextViewModel<dynamic>(temp, TheFilter, SuggestedValue, "sub_reason_code", true);
                    ASSubReasonCode.AutoSuggestVM.IsEmptyValueAllowed = true;
                    ASSubReasonCode.AutoSuggestVM.IsFreeTextAllowed = true;

                }
                var msg = new NotificationMessage("HRM_T001_VM");
                Messenger.Default.Send<NotificationMessage>(msg);
            }
            catch (Exception ex) { }
        }
        private void Insert_SubReasonCode(object InputValue)
        {
            try
            {
                string Request = "";
                HRM_M009_A_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.SubReasonList.Where(x => x.sub_reason_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<HRM_M009_A_P>().ToList()[0];
                    }

                    if (POPUPEntityObject != null)
                    {
                        MasterEntity.sub_reason_code = POPUPEntityObject.sub_reason_code;
                        MasterEntity.sub_reason_type = POPUPEntityObject.sub_reason_type;
                    }
                }
                catch (Exception ex) { }
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
        private void Insert_RequestType(object InputValue)
        {
            string Request = "";
            HRM_M008_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.RequestTypeList.Where(x => x.request_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<HRM_M008_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<HRM_M008_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.request_type = POPUPEntityObject.request_type;
                    MasterEntity.req_type_desc = POPUPEntityObject.req_type_desc;

                    temp2 = (from o in MC.SubRequestList
                             where o.request_type == POPUPEntityObject.request_type
                             select o).ToList();

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((HRM_M008_A_P)x).sub_req_type ?? "");
                    TheFilter = (o, prefix) => (((HRM_M008_A_P)o).sub_req_desc ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((HRM_M008_A_P)o).sub_req_type ?? "").ToLower().Contains(prefix.ToString().ToLower());
                    ASSub_RequestType = new AutoSuggestTextViewModel<dynamic>(temp2, TheFilter, SuggestedValue, "sub_req_type", true);
                    ASSub_RequestType.AutoSuggestVM.IsEmptyValueAllowed = true;
                    ASSub_RequestType.AutoSuggestVM.IsFreeTextAllowed = true;

                }
                var msg = new NotificationMessage("HRM_T001_VM");
                Messenger.Default.Send<NotificationMessage>(msg);
            }
            catch (Exception ex) { }
        }
        private void Insert_SubRequestType(object InputValue)
        {
            try
            {
                string Request = "";
                HRM_M008_A_P POPUPEntityObject = null;
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
                                POPUPEntityObject = MC.SubRequestList.Where(x => x.sub_req_type.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.sub_req_desc.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }

                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<HRM_M008_A_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.sub_req_type = POPUPEntityObject.sub_req_type;
                    MasterEntity.sub_req_desc = POPUPEntityObject.sub_req_desc;
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
        private void Insert_DocCategory(object InputValue)
        {
            string Request = "";
            SYS_M021_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.DocCategoryList.Where(x => x.doc_cat.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<SYS_M021_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M021_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.doc_cat = POPUPEntityObject.doc_cat;
                    MasterEntity.cat_name = POPUPEntityObject.cat_name;

                    temp3 = (from o in MC.DocTypeList
                             where o.doc_cat == POPUPEntityObject.doc_cat
                            select o).ToList();

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M022_P)x).doc_type ?? "");
                    TheFilter = (o, prefix) => (((SYS_M022_P)o).doc_type ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((SYS_M022_P)o).doc_type_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                    ASDocType = new AutoSuggestTextViewModel<dynamic>(temp3, TheFilter, SuggestedValue, "doc_type", true);
                    ASDocType.AutoSuggestVM.IsEmptyValueAllowed = true;
                    ASDocType.AutoSuggestVM.IsFreeTextAllowed = true;

                }
                var msg = new NotificationMessage("HRM_T001_VM");
                Messenger.Default.Send<NotificationMessage>(msg);
            }
            catch (Exception ex) { }
        }
        private void Insert_DocType(object InputValue)
        {
            try
            {
                string Request = "";
                SYS_M022_P POPUPEntityObject = null;
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
                                POPUPEntityObject = MC.DocTypeList.Where(x => x.doc_type.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.doc_type_name.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }

                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M022_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.doc_type = POPUPEntityObject.doc_type;
                    MasterEntity.doc_type_name = POPUPEntityObject.doc_type_name;
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
        private void Insert_ObjectType(object InputValue)
        {
            try
            {
                string Request = "";
                SYS_M034_P POPUPEntityObject = null;
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
                                POPUPEntityObject = MC.ObjectTypeList.Where(x => x.obj_type.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.obj_type_desc.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];

                            }

                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M034_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.obj_type = POPUPEntityObject.obj_type;
                    MasterEntity.obj_type_desc = POPUPEntityObject.obj_type_desc;
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
        private void Insert_DayType(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                SYS_M033_P POPUPEntityObject = null;
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
                            POPUPEntityObject = MC.DayTypeList.Where(x => x.day_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.day_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M033_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {

                    if (dgSelectedIndexAssignToRequest >= 0 && DetailCollection.Count > dgSelectedIndexAssignToRequest) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {

                        DetailCollection[dgSelectedIndexAssignToRequest].day_code = POPUPEntityObject.day_code;
                        DetailCollection[dgSelectedIndexAssignToRequest].day_type = POPUPEntityObject.day_type;

                        MasterEntity.active = true;
                    }
                    else if (DetailCollection[dgSelectedIndexAssignToRequest].day_code != POPUPEntityObject.day_code)
                    {
                        DetailCollection[dgSelectedIndexAssignToRequest].day_code = POPUPEntityObject.day_code;
                        DetailCollection[dgSelectedIndexAssignToRequest].day_type = POPUPEntityObject.day_type;
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
        protected override void OnCreateAction(InquiryActionResult<HRM_T001> result)
        {
            isNewRecord = true;
            MasterEntity = new HRM_T001();
            DetailCollection = new ObservableCollection<HRM_T001_A>();
            DefaultValues();
        }

        protected override void OnDiscardAction(InquiryActionResult<HRM_T001> result)
        {
           
        }

        protected override void OnDocumentAction()
        {
            
        }

        protected override void OnFevoriteAction(InquiryActionResult<HRM_T001> result)
        {
            
        }

        protected override void OnFlipAction(InquiryActionResult<HRM_T001> result)
        {
            
        }

        protected override void OnHelpAction(InquiryActionResult<HRM_T001> result)
        {
          
        }

        protected override void OnPrintAction(InquiryActionResult<HRM_T001> result)
        {
          
        }

        protected override void OnRemoveAction(InquiryActionResult<HRM_T001> result)
        {
       
        }

        protected override void OnSaveAction(InquiryActionResult<HRM_T001> result)
        {
            try
            {
                Logging();
                this.MasterEntity.EndEdit();
                MasterEntity.XmlDataDocument_HRM_T001_A = obj.ObjectToXML(DetailCollection);
                if (Validation() == true)
                {

                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<HRM_T001>(MasterEntity, "Attendence_Request", "HRMS");

                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<HRM_T001>(MasterEntity, "Attendence_Request", "HRMS");
                    }
                    if (MasterEntity.requestid != null && isNewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    if (MasterEntity.requestid != null && isNewRecord == false)
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
        protected override void OnRefreshCommand(InquiryActionResult<HRM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<HRM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<HRM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<HRM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<HRM_T001> result)
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
            if (_RequestCollection != null)
            {
                _RequestCollection.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as HRM_T001_BackFlip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {

                    return (data.requestid != null && data.requestid.ToString().ToLower().Contains(_filterString.ToLower()) ||
                        data.obj_type != null && data.obj_type.ToString().ToLower().Contains(_filterString.ToLower()) ||
                             data.req_type_desc != null && data.req_type_desc.ToString().ToLower().Contains(_filterString.ToLower())
                            );
                }
                return true;
            }
            return false;
        }

        

        #endregion
    }
}
