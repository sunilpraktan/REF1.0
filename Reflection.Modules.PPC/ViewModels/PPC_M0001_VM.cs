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
using Reflection.BusinessEntity.Production;
using Reflection.BusinessEntity;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using System.Windows.Controls;
using System.Windows;
using Reflection.Presentation.Services.Convertors;

namespace Reflection.Modules.PPC.ViewModels
{
    public class PPC_M0001_VM : WorkspaceViewModel<PPC_M001>
    {
        bool isNewRecord = true;
        WebServiceRepository<PPC_M001> repository = new WebServiceRepository<PPC_M001>();
        WebServiceRepository<MultipleContext_PPC_M001> repository_MC = new WebServiceRepository<MultipleContext_PPC_M001>();
        WebServiceRepository<MultipleContext_PPC_M001> repository_MCTemp = new WebServiceRepository<MultipleContext_PPC_M001>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(PPC_M0001_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _ASWCTypeCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASWCTypeCode
        {
            get { return _ASWCTypeCode; }
            set
            {
                if (_ASWCTypeCode != value)
                {
                    _ASWCTypeCode = value; RaisePropertyChanged("ASWCTypeCode");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASWCSubTypeCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASWCSubTypeCode
        {
            get { return _ASWCSubTypeCode; }
            set
            {
                if (_ASWCSubTypeCode != value)
                {
                    _ASWCSubTypeCode = value; RaisePropertyChanged("ASWCSubTypeCode");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASWCCategory { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASWCCategory
        {
            get { return _ASWCCategory; }
            set
            {
                if (_ASWCCategory != value)
                {
                    _ASWCCategory = value; RaisePropertyChanged("ASWCCategory");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASLocation { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASLocation
        {
            get { return _ASLocation; }
            set
            {
                if (_ASLocation != value)
                {
                    _ASLocation = value; RaisePropertyChanged("ASLocation");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASPlace { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPlace
        {
            get { return _ASPlace; }
            set
            {
                if (_ASPlace != value)
                {
                    _ASPlace = value; RaisePropertyChanged("ASPlace");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASControlKey { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASControlKey
        {
            get { return _ASControlKey; }
            set
            {
                if (_ASControlKey != value)
                {
                    _ASControlKey = value; RaisePropertyChanged("ASControlKey");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASGroup { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASGroup
        {
            get { return _ASGroup; }
            set
            {
                if (_ASGroup != value)
                {
                    _ASGroup = value; RaisePropertyChanged("ASGroup");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASMake { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASMake
        {
            get { return _ASMake; }
            set
            {
                if (_ASMake != value)
                {
                    _ASMake = value; RaisePropertyChanged("ASMake");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASEmployee { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASEmployee
        {
            get { return _ASEmployee; }
            set
            {
                if (_ASEmployee != value)
                {
                    _ASEmployee = value; RaisePropertyChanged("ASEmployee");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASParty { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASParty
        {
            get { return _ASParty; }
            set
            {
                if (_ASParty != value)
                {
                    _ASParty = value; RaisePropertyChanged("ASParty");
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

        private AutoSuggestTextViewModel<dynamic> _ASCapacity { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCapacity
        {
            get { return _ASCapacity; }
            set
            {
                if (_ASCapacity != value)
                {
                    _ASCapacity = value; RaisePropertyChanged("ASCapacity");
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
                    //if (SourceName == "entry_no")
                    //{ ASDefault = ASDatagridItem; }
                }
            }
        }

        #endregion

        #region Declarations

        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        private MultipleContext_PPC_M001 _MC;
        public MultipleContext_PPC_M001 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_PPC_M001 _MCTemp;
        public MultipleContext_PPC_M001 MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private MultipleContext_PPC_M001 _MCTemp1;
        public MultipleContext_PPC_M001 MCTemp1
        {
            get { return _MCTemp1; }
            set { _MCTemp1 = value; RaisePropertyChanged("MCTemp1"); }
        }

        private PPC_M001 _MasterEntity;
        public PPC_M001 MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }

        private List<PPC_M001_D_P> _place;
        public List<PPC_M001_D_P> place
        {
            get { return _place; }
            set
            {
                if (_place != value)
                {
                    _place = value;
                    RaisePropertyChanged("place");
                }
            }
        }

        private List<PPC_M001_BackFlip> _FlipGridData;
        public List<PPC_M001_BackFlip> FlipGridData
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

        private ICollectionView _dataCollection;
        public ICollectionView DataCollection
        {
            get { return _dataCollection; }
            set { _dataCollection = value; RaisePropertyChanged("DataCollection"); }
        }

        private ICollectionView _dataCollection2;
        public ICollectionView DataCollection2
        {
            get { return _dataCollection2; }
            set { _dataCollection2 = value; RaisePropertyChanged("DataCollection2"); }
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
        public RelayCommand<object> CmdAddWCTypeCode { get; private set; }
        public RelayCommand<object> CmdAddWCSubTypeCode { get; private set; }
        public RelayCommand<object> CmdAddWCCategory { get; private set; }
        public RelayCommand<object> CmdAddPlace { get; private set; }
        public RelayCommand<object> CmdAddControlKey { get; private set; }
        public RelayCommand<object> CmdAddGroup { get; private set; }
        public RelayCommand<object> CmdAddCapacity { get; private set; }
        public RelayCommand<object> CmdAddMake { get; private set; }
        public RelayCommand<object> CmdAddEmployee { get; private set; }
        public RelayCommand<object> CmdAddParty { get; private set; }
        public RelayCommand<object> CmdAddUnit { get; private set; }
        public RelayCommand<object> CmdAddLocation { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        #endregion

        #region Event Handler

        #endregion

        #region Constructor
        public PPC_M0001_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new PPC_M001();
            MC = new MultipleContext_PPC_M001();
            MCTemp = new MultipleContext_PPC_M001();
            MCTemp1 = new MultipleContext_PPC_M001();

            LoadInitialData();
        }
        public PPC_M0001_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new PPC_M001();
            MC = new MultipleContext_PPC_M001();
            MCTemp = new MultipleContext_PPC_M001();
            MCTemp1 = new MultipleContext_PPC_M001();

            LoadInitialData();
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PPC_M001>(MC, Request, "WorkCenter", "Production", "LoadInitialData", 0, "");

                #region Command Initialisation
                CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
                CmdAddWCTypeCode = new RelayCommand<object>(items => { if (items == null) { return; } InsertWCTypeCode(items); });
                CmdAddWCSubTypeCode = new RelayCommand<object>(items => { if (items == null) { return; } InsertWCSubTypeCode(items); });
                CmdAddWCCategory = new RelayCommand<object>(items => { if (items == null) { return; } InsertWCCategory(items); });
                CmdAddPlace = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlace(items); });
                CmdAddControlKey = new RelayCommand<object>(items => { if (items == null) { return; } InsertControlKey(items); });
                CmdAddGroup = new RelayCommand<object>(items => { if (items == null) { return; } InsertGroup(items); });
                CmdAddCapacity = new RelayCommand<object>(items => { if (items == null) { return; } InsertCapacity(items); });
                CmdAddMake = new RelayCommand<object>(items => { if (items == null) { return; } InsertMake(items); });
                CmdAddEmployee = new RelayCommand<object>(items => { if (items == null) { return; } InsertEmployee(items); });
                CmdAddParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertParty(items); });
                CmdAddUnit = new RelayCommand<object>(items => { if (items == null) { return; } InsertUnit(items); });
                CmdAddLocation = new RelayCommand<object>(items => { if (items == null) { return; } InsertLocation(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                #endregion

                FlipGridData = MC.BackFlipEntity;
                DataCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataCollection.Filter = new Predicate<object>(Filter);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003_P)x).location_Id ?? "");
                TheFilter = (o, prefix) => (((ADM_M003_P)o).location_Id ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M003_P)o).LoctnNm ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASLocation = new AutoSuggestTextViewModel<dynamic>(MC.Location, TheFilter, SuggestedValue, "location_Id", true);
                ASLocation.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PPC_M001_D_P)x).place ?? "");
                TheFilter = (o, prefix) => (((PPC_M001_D_P)o).place ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((PPC_M001_D_P)o).place_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASPlace = new AutoSuggestTextViewModel<dynamic>(MC.WCPlace, TheFilter, SuggestedValue, "place", false);
                ASPlace.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PPC_M001_A_P)x).wc_tp_code ?? "");
                TheFilter = (o, prefix) => (((PPC_M001_A_P)o).wc_tp_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASWCTypeCode = new AutoSuggestTextViewModel<dynamic>(MC.WCType, TheFilter, SuggestedValue, "wc_tp_code", false);
                ASWCTypeCode.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PPC_M001_B_P)x).wc_stp_code ?? "");
                TheFilter = (o, prefix) => (((PPC_M001_B_P)o).wc_stp_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASWCSubTypeCode = new AutoSuggestTextViewModel<dynamic>(MC.WCSubType, TheFilter, SuggestedValue, "wc_stp_code", false);
                ASWCSubTypeCode.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PPC_M001_C_P)x).wc_cat ?? "");
                TheFilter = (o, prefix) => (((PPC_M001_C_P)o).wc_cat ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((PPC_M001_C_P)o).wc_cat_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASWCCategory = new AutoSuggestTextViewModel<dynamic>(MC.WCCategory, TheFilter, SuggestedValue, "wc_cat", false);
                ASWCCategory.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PPC_M001_E_P)x).cap_code ?? "");
                TheFilter = (o, prefix) => (((PPC_M001_E_P)o).cap_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASCapacity = new AutoSuggestTextViewModel<dynamic>(MC.WCCapacity, TheFilter, SuggestedValue, "cap_code", false);
                ASCapacity.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PPC_M001_F_P)x).control_key ?? "");
                TheFilter = (o, prefix) => (((PPC_M001_F_P)o).control_key ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((PPC_M001_F_P)o).control_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASControlKey = new AutoSuggestTextViewModel<dynamic>(MC.WCControlKey, TheFilter, SuggestedValue, "control_key", false);
                ASControlKey.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PPC_M001_G_P)x).gr_code ?? "");
                TheFilter = (o, prefix) => (((PPC_M001_G_P)o).gr_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((PPC_M001_G_P)o).gr_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASGroup = new AutoSuggestTextViewModel<dynamic>(MC.WCGroup, TheFilter, SuggestedValue, "gr_code", false);
                ASGroup.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M032_P)x).MakeCode.ToString() ?? "");
                TheFilter = (o, prefix) => (((ADM_M032_P)o).MakeCode.ToString() ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASMake = new AutoSuggestTextViewModel<dynamic>(MC.Make, TheFilter, SuggestedValue, "MakeCode", false);
                ASMake.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpName ?? "");
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M024_P)o).EmpName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASEmployee = new AutoSuggestTextViewModel<dynamic>(MC.Employee, TheFilter, SuggestedValue, "EmpName", false);
                ASEmployee.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId ?? "");
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyId ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M028_P)o).PartyNm ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASParty = new AutoSuggestTextViewModel<dynamic>(MC.Party, TheFilter, SuggestedValue, "PartyId", false);
                ASParty.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M038_B_P)o).unit_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASUnit = new AutoSuggestTextViewModel<dynamic>(MC.Unit, TheFilter, SuggestedValue, "EmpName", false);
                ASUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

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

            MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;

            place = (from o in MC.WCPlace
                     where o.location_Id == AppSessionState.OBJ_LOCATION.location_id
                     select o).ToList();

            SuggestedValue = new ValueConverter(x => x == null ? "" : ((PPC_M001_D_P)x).place ?? "");
            TheFilter = (o, prefix) => (((PPC_M001_D_P)o).place ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((PPC_M001_D_P)o).place_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
            ASPlace = new AutoSuggestTextViewModel<dynamic>(place, TheFilter, SuggestedValue, "place", false);
            ASPlace.AutoSuggestVM.IsEmptyValueAllowed = true;
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.start_dt = DateTime.Now;
            MasterEntity.active = true;
            //MasterEntity.doc_cat = "FR";
            //MasterEntity.doc_type = "FR";
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            PPC_M001_BackFlip ParameterEntityObject = new PPC_M001_BackFlip();

            try
            {
                if (((IEnumerable)ParameterObject).Cast<PPC_M001_BackFlip>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<PPC_M001_BackFlip>().ToList()[0];
                    Request = "LoadDocumentByDocumentNumber" + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + ParameterEntityObject.wc_code;
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PPC_M001>(MCTemp, Request, "WorkCenter", "Production", "LoadDocumentByDocumentNumber", 0, "");

                    if (MCTemp.MasterData.Count > 0)
                    {
                        MasterEntity = MCTemp.MasterData[0];
                    }
                    //SetBusinessEntitiesAfterLoad("Save", "");
                }
                isNewRecord = false;
                SelectedTabControlIndex = 0;
                var msg = new NotificationMessage("PPC_M0001_VM");
                Messenger.Default.Send<NotificationMessage>(msg);
                SetPopupSuggestionDataAfterLoad();
                MasterEntity.ts_code = ts_code_vm;
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
        private void InsertWCTypeCode(object InputValue)
        {
            string Request = "";
            PPC_M001_A_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.WCType.Where(x => x.wc_tp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<PPC_M001_A_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<PPC_M001_A_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.wc_tp_code = POPUPEntityObject.wc_tp_code;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertWCSubTypeCode(object InputValue)
        {
            string Request = "";
            PPC_M001_B_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.WCSubType.Where(x => x.wc_stp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<PPC_M001_B_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<PPC_M001_B_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.wc_stp_code = POPUPEntityObject.wc_stp_code;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertWCCategory(object InputValue)
        {
            string Request = "";
            PPC_M001_C_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.WCCategory.Where(x => x.wc_cat.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<PPC_M001_C_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<PPC_M001_C_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.wc_cat = POPUPEntityObject.wc_cat;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertLocation(object InputValue)
        {
            string Request = "";
            ADM_M003_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Location.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M003_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.location_Id = POPUPEntityObject.location_Id;

                    place = (from o in MC.WCPlace
                             where o.location_Id == MasterEntity.location_Id
                             select o).ToList();

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((PPC_M001_D_P)x).place ?? "");
                    TheFilter = (o, prefix) => (((PPC_M001_D_P)o).place ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((PPC_M001_D_P)o).place_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                    ASPlace = new AutoSuggestTextViewModel<dynamic>(place, TheFilter, SuggestedValue, "place", false);
                    ASPlace.AutoSuggestVM.IsEmptyValueAllowed = true;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertPlace(object InputValue)
        {
            string Request = "";
            PPC_M001_D_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.WCPlace.Where(x => x.place.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<PPC_M001_D_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<PPC_M001_D_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.place = POPUPEntityObject.place;
            }
        }
        private void InsertControlKey(object InputValue)
        {
            string Request = "";
            PPC_M001_F_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.WCControlKey.Where(x => x.control_key.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<PPC_M001_F_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<PPC_M001_F_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.control_key = POPUPEntityObject.control_key;
            }
        }
        private void InsertGroup(object InputValue)
        {
            string Request = "";
            PPC_M001_G_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.WCGroup.Where(x => x.gr_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<PPC_M001_G_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<PPC_M001_G_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.gr_code = POPUPEntityObject.gr_code;
            }
        }
        private void InsertCapacity(object InputValue)
        {
            string Request = "";
            PPC_M001_E_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.WCCapacity.Where(x => x.cap_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<PPC_M001_E_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<PPC_M001_E_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.cap_code = POPUPEntityObject.cap_code;
            }
        }
        private void InsertMake(object InputValue)
        {
            string Request = "";
            ADM_M032_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Make.Where(x => x.MakeCode.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M032_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M032_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.make_id = POPUPEntityObject.MakeCode;
            }
        }
        private void InsertEmployee(object InputValue)
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
                        { POPUPEntityObject = MC.Employee.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M024_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.EmpId = POPUPEntityObject.EmpId;
            }
        }
        private void InsertParty(object InputValue)
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
                        { POPUPEntityObject = MC.Party.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M028_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.PartyId = POPUPEntityObject.PartyId;
            }
        }
        private void InsertUnit(object InputValue)
        {
            string Request = "";
            ADM_M038_B_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Unit.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.unit_code = POPUPEntityObject.unit_code;
            }
        }
        private bool Validation()
        {
            if (MasterEntity.wc_code == null || MasterEntity.wc_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Work Center Code...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.location_Id == null || MasterEntity.location_Id == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Work Center Location...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.place == null || MasterEntity.place == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Work Center Place...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.machinecode == null || MasterEntity.machinecode == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter the Display Code...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.machinedesc == null || MasterEntity.machinedesc == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter the Discription...");
                showMessageService.ShowMessage();
                return false;
            }

            return true;
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                MasterEntity.ts_code = ts_code_vm;
                if (MasterEntity.XmlDataDocument_PPC_M001_Flip != null && isNewRecord == true && ParameterOption1 == "Save")
                {
                    MC.BackFlipEntity = (List<PPC_M001_BackFlip>)obj.XMLToObject(MasterEntity.XmlDataDocument_PPC_M001_Flip, MC.BackFlipEntity);
                    FlipGridData.Add(MC.BackFlipEntity[0]);
                    DataCollection.Refresh();
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
            ASWCTypeCode.AutoSuggestVM.Suggestion = MC.WCType.Find(x => x.wc_tp_code == MasterEntity.wc_tp_code);
            ASWCSubTypeCode.AutoSuggestVM.Suggestion = MC.WCSubType.Find(x => x.wc_stp_code == MasterEntity.wc_stp_code);
            ASWCCategory.AutoSuggestVM.Suggestion = MC.WCCategory.Find(x => x.wc_cat == MasterEntity.wc_cat);
            ASCapacity.AutoSuggestVM.Suggestion = MC.WCCapacity.Find(x => x.cap_code == MasterEntity.cap_code);
            ASControlKey.AutoSuggestVM.Suggestion = MC.WCControlKey.Find(x => x.control_key == MasterEntity.control_key);
            ASLocation.AutoSuggestVM.Suggestion = MC.Location.Find(x => x.location_Id == MasterEntity.location_Id);
            ASPlace.AutoSuggestVM.Suggestion = MC.WCPlace.Find(x => x.place == MasterEntity.place);
            ASGroup.AutoSuggestVM.Suggestion = MC.WCGroup.Find(x => x.gr_code == MasterEntity.gr_code);
            ASMake.AutoSuggestVM.Suggestion = MC.Make.Find(x => x.MakeCode == MasterEntity.make_id);
            ASEmployee.AutoSuggestVM.Suggestion = MC.Employee.Find(x => x.EmpId == MasterEntity.EmpId);
            ASParty.AutoSuggestVM.Suggestion = MC.Party.Find(x => x.PartyId == MasterEntity.PartyId);
            ASUnit.AutoSuggestVM.Suggestion = MC.Unit.Find(x => x.unit_code == MasterEntity.unit_code);

        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                    AppSessionState.ViewOtherRecordAllowed = true;
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
        #endregion        

        #region Abstract Command Actions
        protected override void OnSaveAction(InquiryActionResult<PPC_M001> result)
        {
            try
            {
                MasterEntity.editby = AppSessionState.UserID;
                this.MasterEntity.EndEdit();
                if (Validation() == true)
                {
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<PPC_M001>(MasterEntity, "WorkCenter", "Production");
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<PPC_M001>(MasterEntity, "WorkCenter", "Production");
                    }

                    if (MasterEntity.wc_code != null && isNewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    if (MasterEntity.wc_code != null && isNewRecord == false)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Updated Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");
                    isNewRecord = false;
                    var msg = new NotificationMessage("PPC_M0001_VM");
                    Messenger.Default.Send<NotificationMessage>(msg);
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
        protected override void OnRefreshCommand(InquiryActionResult<PPC_M001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<PPC_M001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<PPC_M001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<PPC_M001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<PPC_M001> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<PPC_M001> result)
        {
            isNewRecord = true;
            MasterEntity = new PPC_M001();

            DefaultValues();
            var msg = new NotificationMessage("PPC_M0001_VM");
            Messenger.Default.Send<NotificationMessage>(msg);
        }
        protected override void OnRemoveAction(InquiryActionResult<PPC_M001> result)
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
        protected override void OnDiscardAction(InquiryActionResult<PPC_M001> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<PPC_M001> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<PPC_M001> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<PPC_M001> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<PPC_M001> result)
        {

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
            if (_dataCollection != null)
            {
                _dataCollection.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as PPC_M001_BackFlip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.wc_code != null && data.wc_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.wc_tp_code != null && data.wc_tp_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.wc_stp_code != null && data.wc_stp_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.wc_cat != null && data.wc_cat.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.cap_code != null && data.cap_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.control_key != null && data.control_key.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.place != null && data.place.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.start_dt != null && data.start_dt.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.machinedesc != null && data.machinedesc.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.gr_code != null && data.gr_code.ToString().ToLower().Contains(_filterString.ToLower())
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
