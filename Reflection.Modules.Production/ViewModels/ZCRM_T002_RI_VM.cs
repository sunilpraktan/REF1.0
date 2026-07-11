using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Reflection.BusinessEntity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.WebServices.Gateway;
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.Services;
using System.Windows.Data;
using System.Collections;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.Production.ViewModels
{
    public class ZCRM_T002_RI_VM : WorkspaceViewModel<ZCRM_T002>
    {
        #region Variable Declaration And Object .
        bool NewRecord = true;

        WebServiceRepository<ZCRM_T002> repository = new WebServiceRepository<ZCRM_T002>();
        WebServiceRepository<MultipleContext_ZCRM_T002> repository_MC = new WebServiceRepository<MultipleContext_ZCRM_T002>();
        WebServiceRepository<MultipleContext_ZCRM_T002> repository_MCTemp = new WebServiceRepository<MultipleContext_ZCRM_T002>();
        WebServiceRepository<MultipleContext_ZCRM_T002> repository_MCTemp3 = new WebServiceRepository<MultipleContext_ZCRM_T002>();
        WebServiceRepository<MultipleContext_ZCRM_T002> repository_MCTemp2 = new WebServiceRepository<MultipleContext_ZCRM_T002>();
        ObjectSerializationService obj = new ObjectSerializationService();
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        private ZCRM_T002 _MasterEntity;
        public ZCRM_T002 MasterEntity
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

        private ObservableCollection<ZCRM_T002_A> _DefectEntity;
        public ObservableCollection<ZCRM_T002_A> DefectEntity
        {
            get { return _DefectEntity; }
            set
            {
                if (_DefectEntity != value)
                {
                    _DefectEntity = value;
                    RaisePropertyChanged("DefectEntity");
                }
            }
        }

        private ObservableCollection<Ref_Doc_no> _SODetails;
        public ObservableCollection<Ref_Doc_no> SODetails
        {
            get { return _SODetails; }
            set
            {
                if (_SODetails != value)
                {
                    _SODetails = value;
                    RaisePropertyChanged("SODetails");
                }
            }
        }

        private ZCRM_T002 _MasterEntityTemp;
        public ZCRM_T002 MasterEntityTemp
        {
            get
            {
                return _MasterEntityTemp;
            }
            set
            {
                if (_MasterEntityTemp != value)
                {
                    _MasterEntityTemp = value;
                    RaisePropertyChanged("MasterEntityTemp");
                    value.BeginEdit();
                }
            }
        }

        MultipleContext_ZCRM_T002 _MC = new MultipleContext_ZCRM_T002();
        public MultipleContext_ZCRM_T002 MC
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

        MultipleContext_ZCRM_T002 _MCTemp = new MultipleContext_ZCRM_T002();
        public MultipleContext_ZCRM_T002 MCTemp
        {
            get { return _MCTemp; }
            set
            {
                if (_MCTemp != value)
                {
                    _MCTemp = value;

                    RaisePropertyChanged("MC");
                }
            }
        }

        MultipleContext_ZCRM_T002 _MCTemp2 = new MultipleContext_ZCRM_T002();
        public MultipleContext_ZCRM_T002 MCTemp2
        {
            get { return _MCTemp2; }
            set
            {
                if (_MCTemp2 != value)
                {
                    _MCTemp2 = value;

                    RaisePropertyChanged("MCTemp2");
                }
            }
        }

        MultipleContext_ZCRM_T002 _MCTemp3 = new MultipleContext_ZCRM_T002();
        public MultipleContext_ZCRM_T002 MCTemp3
        {
            get { return _MCTemp3; }
            set
            {
                if (_MCTemp3 != value)
                {
                    _MCTemp3 = value;

                    RaisePropertyChanged("MCTemp3");
                }
            }
        }

        private List<ZCRM_T004_RI_Flip> _FlipGridData;
        public List<ZCRM_T004_RI_Flip> FlipGridData
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

        private List<EPR_T001_P> _ItemDataPopup;
        public List<EPR_T001_P> ItemDataPopup
        {
            get { return _ItemDataPopup; }
            set
            {
                if (_ItemDataPopup != value)
                {
                    _ItemDataPopup = value;

                    RaisePropertyChanged("ItemDataPopup");

                }
            }
        }

        private string _LocalVariable;
        public string LocalVariable
        {
            get
            {
                return _LocalVariable;
            }
            set
            {
                if (_LocalVariable != value)
                {

                    _LocalVariable = value;
                    RaisePropertyChanged("LocalVariable");
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

        private int _dgSelectedIndexDefect;
        public int dgSelectedIndexDefect
        {
            get
            {
                return _dgSelectedIndexDefect;
            }
            set
            {
                if (_dgSelectedIndexDefect != value)
                {
                    _dgSelectedIndexDefect = value;
                    RaisePropertyChanged("dgSelectedIndexDefect");
                }
            }
        }

        private string _barcode;
        public string barcode
        {
            get { return _barcode; }
            set
            {
                if (_barcode != value)
                {
                    _barcode = value;
                    RaisePropertyChanged("barcode");
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
        #endregion

        #region AutoSuggest Initialization
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
                    if (SourceName == "parameter")
                    { ASDefault = AS_Parameter; }

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
                    _ASDefault = value; RaisePropertyChanged("ASDefault");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASt_status { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASt_status
        {
            get { return _ASt_status; }
            set
            {
                if (_ASt_status != value)
                {
                    _ASt_status = value; RaisePropertyChanged("ASt_status");
                }
            }
        }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _AS_Machine { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Machine
        {
            get { return _AS_Machine; }
            set
            {
                if (_AS_Machine != value)
                {
                    _AS_Machine = value; RaisePropertyChanged("AS_Machine");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_EMP { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_EMP
        {
            get { return _AS_EMP; }
            set
            {
                if (_AS_EMP != value)
                {
                    _AS_EMP = value; RaisePropertyChanged("AS_EMP");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_Other { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Other
        {
            get { return _AS_Other; }
            set
            {
                if (_AS_Other != value)
                {
                    _AS_Other = value; RaisePropertyChanged("AS_Other");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_Shift { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Shift
        {
            get { return _AS_Shift; }
            set
            {
                if (_AS_Shift != value)
                {
                    _AS_Shift = value; RaisePropertyChanged("AS_Shift");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_Unit { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Unit
        {
            get { return _AS_Unit; }
            set
            {
                if (_AS_Unit != value)
                {
                    _AS_Unit = value; RaisePropertyChanged("AS_Unit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_Parameter { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Parameter
        {
            get { return _AS_Parameter; }
            set
            {
                if (_AS_Parameter != value)
                {
                    _AS_Parameter = value; RaisePropertyChanged("AS_Parameter");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_Defect { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Defect
        {
            get { return _AS_Defect; }
            set
            {
                if (_AS_Defect != value)
                {
                    _AS_Defect = value; RaisePropertyChanged("AS_Defect");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASQcPerson { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASQcPerson
        {
            get { return _ASQcPerson; }
            set
            {
                if (_ASQcPerson != value)
                {
                    _ASQcPerson = value; RaisePropertyChanged("ASQcPerson");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASGrade { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASGrade
        {
            get { return _ASGrade; }
            set
            {
                if (_ASGrade != value)
                {
                    _ASGrade = value; RaisePropertyChanged("ASGrade");
                }
            }
        }

        #endregion

        #region ICollection
        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }

        private ICollectionView _BatchCollection; // Barcode details
        public ICollectionView BatchCollection
        {
            get { return _BatchCollection; }
            set
            {
                _BatchCollection = value;
                RaisePropertyChanged("BatchCollection");
            }
        }

        private ICollectionView _RefDocTypeCollection;
        public ICollectionView RefDocTypeCollection
        {
            get { return _RefDocTypeCollection; }
            set
            {
                _RefDocTypeCollection = value;
                RaisePropertyChanged("RefDocTypeCollection");
            }
        }

        private ICollectionView _ParameterCollection;
        public ICollectionView ParameterCollection
        {
            get { return _ParameterCollection; }
            set
            {
                _ParameterCollection = value;
                RaisePropertyChanged("ParameterCollection");
            }
        }

        private ICollectionView _DefectCollection;
        public ICollectionView DefectCollection
        {
            get { return _DefectCollection; }
            set
            {
                _DefectCollection = value;
                RaisePropertyChanged("DefectCollection");
            }
        }

        private List<COM_T003> _AttachmentCollection;
        public List<COM_T003> AttachmentCollection
        {
            get { return _AttachmentCollection; }
            set
            {
                _AttachmentCollection = value;
                RaisePropertyChanged("_AttachmentCollection");
            }
        }
        #endregion

        #region StringList Variables
        List<string> _strListEmployee;
        public List<string> StringListEmployee
        {
            get { return _strListEmployee; }
            set
            {
                if (_strListEmployee != value)
                {
                    _strListEmployee = value;
                }
            }
        }
        List<string> _strListMachine;
        public List<string> StringListMachine
        {
            get { return _strListMachine; }
            set
            {
                if (_strListMachine != value)
                {
                    _strListMachine = value;
                }
            }
        }
        List<string> _strListDefect;
        public List<string> StringListDefect
        {
            get { return _strListDefect; }
            set
            {
                if (_strListDefect != value)
                {
                    _strListDefect = value;
                }
            }
        }
        List<string> _stringListUOM;
        public List<string> StringListUOM
        {
            get { return _stringListUOM; }
            set
            {
                if (_stringListUOM != value)
                {
                    _stringListUOM = value;
                }
            }
        }
        List<string> _stringListItems;
        public List<string> StringListItems
        {
            get { return _stringListItems; }
            set
            {
                if (_stringListItems != value)
                {
                    _stringListItems = value;
                }
            }
        }
        List<string> _stringListShift;
        public List<string> StringListShift
        {
            get { return _stringListShift; }
            set
            {
                if (_stringListShift != value)
                {
                    _stringListShift = value;
                }
            }
        }

        private List<string> _StringListRefDocType;
        public List<string> StringListRefDocType
        {
            get { return _StringListRefDocType; }
            set
            {
                if (_StringListRefDocType != value)
                {
                    _StringListRefDocType = value;
                }
            }
        }

        private List<string> _StringListParameter;
        public List<string> StringListParameter
        {
            get { return _StringListParameter; }
            set
            {
                if (_StringListParameter != value)
                {
                    _StringListParameter = value;
                }
            }
        }


        #endregion

        #region Relay Commands Declaration
        public GalaSoft.MvvmLight.Command.RelayCommand CommandLoadDocumentFromSource { get; private set; }
        public RelayCommand<object> CommandEmployeeChanged { get; private set; }
        public RelayCommand<object> CMDQCPerson { get; private set; }
        public RelayCommand<object> CommandAddUOM { get; private set; }
        public RelayCommand<object> CommandAddItem { get; private set; }
        public RelayCommand<object> CommandAddShift { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByByDocumentNumber { get; private set; }
        public RelayCommand<object> CmdAddBatchDetails { get; private set; }
        public RelayCommand<object> CMDRefDocType { get; private set; }
        public RelayCommand<object> CMDOtherProblems { get; private set; }
        public RelayCommand<object> CmdParameter { get; private set; }
        public RelayCommand<object> CmdDefect { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand CMDLoadFromFilter { get; private set; }
        public RelayCommand<object> CmdInsert_t_status { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> CmdInsertGrade { get; private set; }
        #endregion

        #region Constructor
        public ZCRM_T002_RI_VM(string ts_code)
            : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntityTemp = new ZCRM_T002();
            MasterEntity = new ZCRM_T002();
            SODetails = new ObservableCollection<Ref_Doc_no>();
            DefectEntity = new ObservableCollection<ZCRM_T002_A>();
            FlipGridData = new List<ZCRM_T004_RI_Flip>();
            MC = new MultipleContext_ZCRM_T002();
            MCTemp = new MultipleContext_ZCRM_T002();
            MCTemp2 = new MultipleContext_ZCRM_T002();
            MCTemp3 = new MultipleContext_ZCRM_T002();
            MasterEntity.ValidateAsync().Wait();
            ZCRM_T002.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);

            LoadInitialData();
            //if (MC.DocTypeInfo.Count > 0)
            //{
            //    if (AppSessionState.TransValue != null && AppSessionState.TransactionCode == MC.DocTypeInfo[0].TranCode)
            //    {
            //        LoadDocumentByDocumentNumber(AppSessionState.TransValue, "DocumentNo");
            //        isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
            //        AppSessionState.TransValue = null;
            //        AppSessionState.TransId = null;
            //        AppSessionState.TransParameter = null;
            //        AppSessionState.ViewOtherRecordAllowed = true;
            //    }
            //}
        }
        public ZCRM_T002_RI_VM(string ts_code,string doc_no)
           : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntityTemp = new ZCRM_T002();
            MasterEntity = new ZCRM_T002();
            SODetails = new ObservableCollection<Ref_Doc_no>();
            DefectEntity = new ObservableCollection<ZCRM_T002_A>();
            FlipGridData = new List<ZCRM_T004_RI_Flip>();
            MC = new MultipleContext_ZCRM_T002();
            MCTemp = new MultipleContext_ZCRM_T002();
            MCTemp2 = new MultipleContext_ZCRM_T002();
            MCTemp3 = new MultipleContext_ZCRM_T002();
            MasterEntity.ValidateAsync().Wait();
            ZCRM_T002.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);

            LoadInitialData();
            
        }


        void ModelUpdated_Master(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            LocalVariable = MasterEntity.machinecode;
            this.ErrorExist = MasterEntity.HasErrors;
        }
        #endregion

        #region Validation
        private bool Validation()
        {
            try
            {
                if (MasterEntity.machinecode == null || MasterEntity.machinecode == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Machine Code Is Required", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.shift == null || MasterEntity.shift == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Shift Is Required", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.ItemCode == null || MasterEntity.ItemCode == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Item Code Is Required", this.Title);
                    showMessageService.ShowMessage();
                    return false;
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

            return true;
        }
        #endregion

        #region User Defined Functions
        private void LoadFromFilterss()
        {
            try
            {
                if (Validation1() == true)
                {
                    string RequestParameter = "LoadFromFilters" + "!@" + MasterEntity.Fromdt.ToString() + "!@" + MasterEntity.Todt.ToString() + "!@" + MasterEntity.machine + "!@" + MasterEntity.item + "!@"+ AppSessionState.comp_code + "!@" +AppSessionState.location_Id +"!@" + MasterEntity.doc_type;
                    MCTemp2 = repository_MCTemp2.GetDataWithReturnDomainObject<MultipleContext_ZCRM_T002>(MCTemp2, RequestParameter, "RandomInspection", "Production", "LoadAll", 0, "");

                    FlipGridData = MCTemp2.DocumentDataFlipGrid.ToList();
                    DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                    DataGridCollection.Filter = new Predicate<object>(Filter);
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
        private bool Validation1()
        {
            if (MasterEntity.Fromdt == null)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select From Date... ");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.Todt == null)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select To Date... ");
                showMessageService.ShowMessage();
                return false;
            }
            return true;
        }
        private void LoadInitialData()
        {
            try
            {
                MasterEntity.Ref_doc_type = "Production Counter Entry";
                MasterEntity.ref_doctp = "PC";
                MasterEntity.doc_cat = "RI";
                MasterEntity.doc_type = "RI";
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ZCRM_T002>(MC, Request, "RandomInspection", "Production", "LoadAll", 0, "");

                #region Command Initialisation 
                CommandEmployeeChanged = new RelayCommand<object>(items => { if (items == null) { return; } InsertEmployee(items); });
                CMDRefDocType = new RelayCommand<object>(items => { if (items == null) { return; } InsertReferenceDocType(items); });
                CommandAddItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItem(cmdPara, true, true, true); });
                CommandAddShift = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertShift(cmdPara, true, true, true); });
                CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                CmdAddBatchDetails = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertBatchDetails(cmdPara); });
                CMDOtherProblems = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertOtherProblems(cmdPara); });
                CmdParameter = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertParameters(cmdPara, true, true, true); });
                CmdDefect = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDefect(cmdPara, true, true, true); });
                CMDQCPerson = new RelayCommand<object>(items => { if (items == null) { return; } InsertQCPerson(items); });
                CMDLoadFromFilter = new GalaSoft.MvvmLight.Command.RelayCommand(() => { LoadFromFilterss(); });
                CmdInsert_t_status = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Insert_t_status(cmdPara); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                CmdInsertGrade = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertGrade(cmdPara); });
                #endregion

                #region AutoSuggest LoadAll

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M013_P)x).machinecode);
                TheFilter = (o, prefix) => (((ZADM_M013_P)o).machinecode ?? "").ToLower().Contains(prefix) || (((ZADM_M013_P)o).machine_id.ToString() ?? "").Contains(prefix);
                AS_Machine = new AutoSuggestTextViewModel<dynamic>(MC.MachineList, TheFilter, SuggestedValue, "machinecode", true);
                AS_Machine.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToLower().Contains(prefix) || (((ADM_M024_P)o).EmpName ?? "").ToString().ToLower().Contains(prefix);
                AS_EMP = new AutoSuggestTextViewModel<dynamic>(MC.EmpList, TheFilter, SuggestedValue, "EmpId", true);
                AS_EMP.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToLower().Contains(prefix) || (((ADM_M024_P)o).EmpName ?? "").ToString().ToLower().Contains(prefix);
                ASQcPerson = new AutoSuggestTextViewModel<dynamic>(MC.EmpList, TheFilter, SuggestedValue, "EmpId", true);
                ASQcPerson.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M016_P)x).dfctcda.ToString());
                TheFilter = (o, prefix) => (((ZADM_M016_P)o).dfctcda.ToString() ?? "").ToLower().Contains(prefix) || (((ZADM_M016_P)o).dfctdsc ?? "").ToString().ToLower().Contains(prefix);
                AS_Other = new AutoSuggestTextViewModel<dynamic>(MC.DefectList, TheFilter, SuggestedValue, "dfctcda", true);
                AS_Other.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M042_P)x).shift.ToString());
                TheFilter = (o, prefix) => (((ADM_M042_P)o).shift ?? "").ToString().ToLower().Contains(prefix);
                AS_Shift = new AutoSuggestTextViewModel<dynamic>(MC.ShiftMaster, TheFilter, SuggestedValue, "shift", true);
                AS_Shift.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code.ToString());
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix);
                AS_Unit = new AutoSuggestTextViewModel<dynamic>(MC.unitList, TheFilter, SuggestedValue, "unit_code", true);
                AS_Unit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ENG_T003_P)x).spec_para_code.ToString());
                TheFilter = (o, prefix) => (((ENG_T003_P)o).spec_para_code ?? "").ToString().ToLower().Contains(prefix) || (((ENG_T003_P)o).parameter ?? "").ToString().ToLower().Contains(prefix);
                AS_Parameter = new AutoSuggestTextViewModel<dynamic>(MC.Parameters, TheFilter, SuggestedValue, "parameters", "spec_para_code", true);
                AS_Parameter.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ENG_T003_P)x).spec_para_code.ToString());
                TheFilter = (o, prefix) => (((ENG_T003_P)o).spec_para_code ?? "").ToString().ToLower().Contains(prefix) || (((ENG_T003_P)o).parameter ?? "").ToString().ToLower().Contains(prefix);
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.Parameters, TheFilter, SuggestedValue, "parameters", "spec_para_code", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M016_P)x).dfctcda.ToString());
                TheFilter = (o, prefix) => (((ZADM_M016_P)o).dfctcda.ToString() ?? "").Contains(prefix) || (((ZADM_M016_P)o).dfctdsc ?? "").ToString().ToLower().Contains(prefix);
                AS_Defect = new AutoSuggestTextViewModel<dynamic>(MC.DefectList, TheFilter, SuggestedValue, "dfctcda", "defect", true);
                AS_Defect.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_display);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASt_status = new AutoSuggestTextViewModel<dynamic>(MC.t_statusList, TheFilter, SuggestedValue, "t_display", true);
                ASt_status.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M030_P)x).parametervalue);
                TheFilter = (o, prefix) => (((ADM_M030_P)o).value_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M030_P)o).parametervalue ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASGrade = new AutoSuggestTextViewModel<dynamic>(MC.GradeList, TheFilter, SuggestedValue, "parametervalue", true);
                ASGrade.AutoSuggestVM.IsEmptyValueAllowed = true;
                #endregion

                FlipGridData = MC.DocumentDataFlipGrid.ToList();
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                var barcode = (from o in MC.BatchDetails where o.doc_type == "PC" select o).ToList();
                BatchCollection = CollectionViewSource.GetDefaultView(barcode);
                BatchCollection.Filter = new Predicate<object>(BatchFilter);

                RefDocTypeCollection = CollectionViewSource.GetDefaultView(MC.RefDocTypeData);
                RefDocTypeCollection.Filter = new Predicate<object>(RefDocFilter);
                StringListRefDocType = MC.RefDocTypeData.Select(X => X.doc_desc_user.ToString()).ToList();

                ParameterCollection = CollectionViewSource.GetDefaultView(MC.Parameters);
                ParameterCollection.Filter = new Predicate<object>(FilterParameter);
                StringListParameter = MC.Parameters.Select(X => X.spec_para_code.ToString()).ToList();

                DefectCollection = CollectionViewSource.GetDefaultView(MC.DefectList);
                DefectCollection.Filter = new Predicate<object>(FilterDefect);
                StringListDefect = MC.DefectList.Select(x => x.dfctcda.ToString()).ToList();

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
        private void InsertDefect(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ZADM_M016_P POPUPEntityObject = null;
            try
            {
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.DefectList.Where(x => x.dfctcda.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ZADM_M016_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M016_P>().ToList()[0];
                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = DefectEntity.Where(x => x.defect == POPUPEntityObject.dfctcda.ToString()).FirstOrDefault();
                    int IndexOfExistValue = DefectEntity.IndexOf(DefectEntity.Where(X => X.defect == POPUPEntityObject.dfctcda.ToString()).FirstOrDefault());
                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && DefectEntity.Count == dgSelectedIndexDefect)
                    {
                        DefectEntity.Add(new ZCRM_T002_A()
                        {
                            id = 0,
                            defect = POPUPEntityObject.dfctcda.ToString(),
                            defectNm = POPUPEntityObject.dfctdsc,
                            active = true,
                            location_Id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            add_by = AppSessionState.UserID,
                            editby = AppSessionState.UserID,
                            t_status = "001"
                        });
                    }
                    else if (dgSelectedIndexDefect >= 0 && DefectEntity.Count > dgSelectedIndexDefect)
                    {
                        if (DefectEntity[dgSelectedIndexDefect].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                        {
                            DefectEntity[dgSelectedIndexDefect].defect = POPUPEntityObject.dfctcda.ToString();
                            DefectEntity[dgSelectedIndexDefect].defectNm = POPUPEntityObject.dfctdsc;
                            DefectEntity[dgSelectedIndexDefect].location_Id = AppSessionState.location_Id;
                            DefectEntity[dgSelectedIndexDefect].comp_code = AppSessionState.comp_code;
                            DefectEntity[dgSelectedIndexDefect].add_by = AppSessionState.UserID;
                            DefectEntity[dgSelectedIndexDefect].editby = AppSessionState.UserID;
                            DefectEntity[dgSelectedIndexDefect].active = true;
                            DefectEntity[dgSelectedIndexDefect].t_status = "001";
                        }
                        else if (DefectEntity[dgSelectedIndexDefect].defect != POPUPEntityObject.dfctcda.ToString())
                        {
                            DefectEntity[dgSelectedIndexDefect].defect = "";
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
        private void InsertOtherProblems(object InputValue)
        {
            string Request = "";
            ZADM_M016_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.DefectList.Where(x => x.dfctcda.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M016_P>().ToList()[0];
                }

                if (POPUPEntityObject != null)
                {
                    MasterEntity.other_problems = POPUPEntityObject.dfctcda.ToString();

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
        private void InsertReferenceDocType(object InputValue)
        {
            string Request = "";
            SYS_M013_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.RefDocTypeData.Where(x => x.doc_desc_user.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M013_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.Ref_doc_type = POPUPEntityObject.doc_desc_user;
                MasterEntity.ref_doctp = POPUPEntityObject.doc_type_user;

                if (MasterEntity.ref_doctp == "CN")
                {

                    var ConvNote = (from o in MC.BatchDetails where o.doc_type == "CN" select o).ToList();
                    BatchCollection = CollectionViewSource.GetDefaultView(ConvNote);
                    BatchCollection.Filter = new Predicate<object>(BatchFilter);

                }
                else
                {
                    var barcode = (from o in MC.BatchDetails where o.doc_type == "PC" select o).ToList();
                    BatchCollection = CollectionViewSource.GetDefaultView(barcode);
                    BatchCollection.Filter = new Predicate<object>(BatchFilter);

                }
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
                        { POPUPEntityObject = MC.EmpList.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                }

                if (POPUPEntityObject != null)
                {
                    MasterEntity.shift_supervisor = POPUPEntityObject.EmpId;
                    MasterEntity.EmpLName = POPUPEntityObject.EmpLName;
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void InsertParameters(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ENG_T003_P POPUPEntityObject = null;
            try
            {
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Parameters.Where(x => x.spec_para_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ENG_T003_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ENG_T003_P>().ToList()[0];
                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = DefectEntity.Where(x => x.parameters == POPUPEntityObject.spec_para_code).FirstOrDefault();
                    int IndexOfExistValue = DefectEntity.IndexOf(DefectEntity.Where(X => X.parameters == POPUPEntityObject.spec_para_code).FirstOrDefault());
                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && DefectEntity.Count == dgSelectedIndexDefect)
                    {
                        DefectEntity.Add(new ZCRM_T002_A()
                        {
                            id = 0,
                            parameters = POPUPEntityObject.spec_para_code,
                            ParameterNm = POPUPEntityObject.parameter,
                            active = true,
                            location_Id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            add_by = AppSessionState.UserID,
                            editby = AppSessionState.UserID,

                            t_status = "001"
                        });
                    }
                    else if (dgSelectedIndexDefect >= 0 && DefectEntity.Count > dgSelectedIndexDefect)
                    {
                        if (DefectEntity[dgSelectedIndexDefect].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                        {
                            DefectEntity[dgSelectedIndexDefect].parameters = POPUPEntityObject.spec_para_code;
                            DefectEntity[dgSelectedIndexDefect].ParameterNm = POPUPEntityObject.parameter;
                            DefectEntity[dgSelectedIndexDefect].location_Id = AppSessionState.location_Id;
                            DefectEntity[dgSelectedIndexDefect].comp_code = AppSessionState.comp_code;
                            DefectEntity[dgSelectedIndexDefect].add_by = AppSessionState.UserID;
                            DefectEntity[dgSelectedIndexDefect].editby = AppSessionState.UserID;
                            DefectEntity[dgSelectedIndexDefect].active = true;
                            DefectEntity[dgSelectedIndexDefect].t_status = "001";
                        }
                        else if (DefectEntity[dgSelectedIndexDefect].parameters != POPUPEntityObject.spec_para_code)
                        {
                            DefectEntity[dgSelectedIndexDefect].parameters = "";
                        }
                    }
                }
                ZCRM_T002_A newObj = new ZCRM_T002_A();
                for (int i = DefectEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = DefectEntity[i].ComparePropertiesTo(newObj);
                    if (DefectEntity[i].ComparePropertiesTo(newObj) == true && DefectEntity.Count > 1)
                    {
                        DefectEntity.RemoveAt(i);
                        if (DefectEntity.Count == 0)
                        {
                            DefectEntity.Add(newObj);
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
        private void InsertUOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                        { POPUPEntityObject = MC.unitList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }

                if (POPUPEntityObject != null)
                {
                    MasterEntity.unit_code = POPUPEntityObject.unit_code;  
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }

        }
        private void InsertItem(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            EPR_T001_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ItemList.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<EPR_T001_P>().ToList()[0];
                }

                if (POPUPEntityObject != null)
                {
                    MasterEntity.unit_code = POPUPEntityObject.Unit_Code;
                    MasterEntity.ItemCode = POPUPEntityObject.ItemCode;
                    MasterEntity.ItemName = POPUPEntityObject.ItemName;
                    MasterEntity.conversion_no = (POPUPEntityObject.conv).ToString();
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void InsertShift(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ECRM_T003_A_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.MachinShiftList.Where(x => x.shift.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ECRM_T003_A_P>().ToList()[0];
                }

                if (POPUPEntityObject != null)
                {
                    MasterEntity.shift = POPUPEntityObject.shift;
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void Insert_t_status(object InputValue)
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
                            { POPUPEntityObject = MC.t_statusList.Where(x => x.t_status.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.t_display.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    MasterEntity.t_display = POPUPEntityObject.t_display;
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
                string ParametersStringValue = "";
                ZCRM_T004_RI_Flip ParameterEntityObject = null;
                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null) // This Block of code read parameter . First for string and Entity Object in else part.
                {
                    if (ParameterObject.GetType() == typeof(string) && ParameterObject != null)
                    {
                        Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + ParameterObject;
                    }   
                }
                else if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<ZCRM_T004_RI_Flip>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ZCRM_T004_RI_Flip>().ToList()[0];
                        Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + ParameterEntityObject.doc_no;
                        NewRecord = false;
                        string RequestParameterData = "LoadDocumentWithReferenceDocumentNumber" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + "RI" + "!@" + "RI" + "!@" + MasterEntity.location_Id;
                    }
                }
                MasterEntity = new ZCRM_T002();
                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<ZCRM_T002>(MCTemp, Request, "RandomInspection", "Production", "LoadDocumentWithReferenceDocumentNumber", 0, "");

                if (MCTemp.MasterEntity.Count > 0)
                {
                    MasterEntity = MCTemp.MasterEntity[0];
                    DefectEntity = MCTemp.DefectEntity;
                    SODetails = MCTemp.SODetails;


                    AttachmentCollection = MCTemp.AttachmentData;
                    if (MCTemp.AttachmentData != null)
                    {
                        AttachmentCollection = MCTemp.AttachmentData;
                    }
                    else
                    {
                        MCTemp.AttachmentData = new List<COM_T003>();
                    }
                }

                SelectedTabControlIndex = 0;
                var msg = new NotificationMessage("ZCRM_T002_RI_VM");
                Messenger.Default.Send<NotificationMessage>(msg);
                DefaultRefDocType();
                MasterEntity.ts_code = ts_code_vm;
                SetBusinessEntitiesAfterLoad(ParametersStringValue, "");
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
        private void InsertBatchDetails(object InputValue)  
        {  
            try
            {
                #region Insert Barcode Details
                string Request = "";
                Ref_Doc_no POPUPEntityObject = null;
                barcode = InputValue.ToString();
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length >= 10)
                    {
                        var InputValueIfExists = MC.BatchDetails.Where(X => X.RefDocNo == Request).FirstOrDefault();//Checking Weather Barcode is Valid or Not By Checking in Business Entity
                        if (InputValueIfExists != null)
                        {
                            try
                            {
                                POPUPEntityObject = MC.BatchDetails.Where(x => (x.RefDocNo ?? "").Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; //If Barcode is Valid Get All the Information in PopupEntityObject
                                if (POPUPEntityObject != null)
                                {
                                    MasterEntity.barcode = POPUPEntityObject.barcode;
                                    MasterEntity.machinecode = POPUPEntityObject.machinecode;
                                    MasterEntity.ItemCode = POPUPEntityObject.ItemCode;
                                    MasterEntity.ItemName = POPUPEntityObject.ItemName;
                                    MasterEntity.unit_code = POPUPEntityObject.unit_code;
                                    MasterEntity.qty = POPUPEntityObject.counter_q;
                                    MasterEntity.shift = POPUPEntityObject.shift;
                                    MasterEntity.prod_dt = POPUPEntityObject.prod_date;
                                    MasterEntity.EmpLName = POPUPEntityObject.EmpName;
                                    MasterEntity.shift_supervisor = POPUPEntityObject.shift_incharge;
                                    MasterEntity.conversion_no = POPUPEntityObject.conversion_no;
                                    MasterEntity.wc_code = POPUPEntityObject.wc_code;
                                    MasterEntity.counter_remark = POPUPEntityObject.counter_remark;
                                    MasterEntity.grade = POPUPEntityObject.grade;

                                    SODetails.Clear();
                                    SODetails.Add(new Ref_Doc_no()
                                    {
                                        sono = POPUPEntityObject.sono,
                                        PartyId = POPUPEntityObject.PartyId,
                                        PartyName = POPUPEntityObject.PartyName,
                                        quantity1 = POPUPEntityObject.quantity1,
                                        ItemCode1 = POPUPEntityObject.ItemCode1,
                                        ItemName1 = POPUPEntityObject.ItemName1,
                                        sodate = POPUPEntityObject.sodate
                                    });
                                }
                            }
                            catch (Exception ex) { }
                        }
                        else
                        {
                            IShowMessageViewService ShowMessage3 = this.GetViewService<IShowMessageViewService>();
                            ShowMessage3.ButtonSetup = DialogButton.OkCancel;
                            ShowMessage3.Caption = "Message";
                            ShowMessage3.Text = String.Format("Entered Barcode is Used.\n Press OK To Re-Sacn Barcode OR Press Cancel To Cancel Re-Scan", this.Title);
                            ShowMessage3.ShowMessage();

                            if (ShowMessage3.ShowMessage() == DialogResult.Ok)
                            {
                                string Request1 = "RescanBarcode" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + Request;
                                MCTemp3 = repository_MCTemp3.GetDataWithReturnDomainObject<MultipleContext_ZCRM_T002>(MCTemp3, Request1, "RandomInspection", "Production", "LoadInitialData", 0, "");

                                if (MCTemp3.RescanBarcode != null)
                                {
                                    if (MCTemp3.RescanBarcode.Count > 0)
                                    {
                                        MasterEntity = MCTemp3.RescanBarcode[0];
                                        SODetails = MCTemp3.SODetails;
                                        DefaultValues();
                                        MasterEntity.t_status = "021";
                                    }
                                    else
                                    {
                                        ShowMessage3.ButtonSetup = DialogButton.OkCancel;
                                        ShowMessage3.Caption = "Message";
                                        ShowMessage3.Text = String.Format("Entered Barcode is Invalid", this.Title);
                                        ShowMessage3.ShowMessage();
                                    }
                                }
                                else
                                {
                                    ShowMessage3.ButtonSetup = DialogButton.OkCancel;
                                    ShowMessage3.Caption = "Message";
                                    ShowMessage3.Text = String.Format("Entered Barcode is Invalid", this.Title);
                                    ShowMessage3.ShowMessage();
                                }
                            }
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<Ref_Doc_no>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<Ref_Doc_no>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.barcode = POPUPEntityObject.barcode;
                    MasterEntity.machinecode = POPUPEntityObject.machinecode;
                    MasterEntity.ItemCode = POPUPEntityObject.ItemCode;
                    MasterEntity.ItemName = POPUPEntityObject.ItemName;
                    MasterEntity.unit_code = POPUPEntityObject.unit_code;
                    MasterEntity.qty = POPUPEntityObject.counter_q;
                    MasterEntity.shift = POPUPEntityObject.shift;
                    MasterEntity.prod_dt = POPUPEntityObject.prod_date;
                    MasterEntity.EmpLName = POPUPEntityObject.EmpName;
                    MasterEntity.shift_supervisor = POPUPEntityObject.shift_incharge;
                    MasterEntity.conversion_no = POPUPEntityObject.conversion_no;
                    MasterEntity.wc_code = POPUPEntityObject.wc_code;
                    MasterEntity.counter_remark = POPUPEntityObject.counter_remark;
                    MasterEntity.grade = POPUPEntityObject.grade;
                    SODetails.Clear();
                    SODetails.Add(new Ref_Doc_no()
                    {
                        sono = POPUPEntityObject.sono,
                        PartyId = POPUPEntityObject.PartyId,
                        PartyName = POPUPEntityObject.PartyName,
                        quantity1 = POPUPEntityObject.quantity1,
                        ItemCode1 = POPUPEntityObject.ItemCode1,
                        ItemName1 = POPUPEntityObject.ItemName1,
                        sodate = POPUPEntityObject.sodate
                    });
                }
            }
            catch (Exception ex) { }
            #endregion
        }
        private void InsertQCPerson(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M024_P POPUPEntityObject = null;
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.EmpList.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M024_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                    }
                }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.qc_person = POPUPEntityObject.EmpId;
                    MasterEntity.QcName = POPUPEntityObject.EmpName;
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
        private void DefaultValues()
        {
            MasterEntity.doc_cat = "RI";
            MasterEntity.doc_type = "RI";
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.t_status = "001";
            MasterEntity.doc_no = "";
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.prod_dt = DateTime.Now;
            MasterEntity.ts_code = ts_code_vm;

        }
        private void DefaultRefDocType()
        {
            MasterEntity.Ref_doc_type = "Production Counter Entry";
            MasterEntity.ref_doctp = "PC";
            var ConvNote = (from o in MC.BatchDetails where o.doc_type == "PC" select o).ToList();
            BatchCollection = CollectionViewSource.GetDefaultView(ConvNote);
            BatchCollection.Filter = new Predicate<object>(BatchFilter);

        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                    isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
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
        private void InsertGrade(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M030_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.GradeList.Where(x => x.value_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.parametervalue.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M030_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.grade = POPUPEntityObject.parametervalue;
                    //MasterEntity.t_display = POPUPEntityObject.t_display;
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
        private void RemoveReferenceDocuments()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(MasterEntity.barcode) == false)
                {
                    MC.BatchDetails.Remove(MC.BatchDetails.Single(s => s.barcode == MasterEntity.barcode));
                }
            }
            catch (Exception ex)
            {
            }

        }
        #endregion

        #region Abstract Method
        protected override void OnSaveAction(InquiryActionResult<ZCRM_T002> result)
        {
            try
            {
                if (Validation() == true)
                {
                    MasterEntity.editby = AppSessionState.UserID;
                    MasterEntity.XmlDataDocument_ZCRM_T002_A = obj.ObjectToXML(DefectEntity);
                    this.MasterEntity.EndEdit();
                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ZCRM_T002>(MasterEntity, "RandomInspection", "Production");
                        RemoveReferenceDocuments();
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ZCRM_T002>(MasterEntity, "RandomInspection", "Production");
                    }
                    var msg = new NotificationMessage("ZCRM_T002_RI_VM");
                    Messenger.Default.Send<NotificationMessage>(msg);
                    SetBusinessEntitiesAfterLoad("Save", "");
                    NewRecord = false;
                    DefaultRefDocType();
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
                MasterEntity.ts_code = ts_code_vm;
                if (MasterEntity.XmlDataDocument_ZCRM_T002_Flip != null && NewRecord == true && ParameterOption1 == "Save")
                {
                    MC.DocumentDataFlipGrid = (List<ZCRM_T004_RI_Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ZCRM_T002_Flip, MC.DocumentDataFlipGrid);
                    FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
                    DataGridCollection.Refresh();
                }
                if (MasterEntity.XmlDataDocument_ZCRM_T002_A != null && NewRecord == true && ParameterOption1 == "Save")
                {
                    MC.DefectEntity = (ObservableCollection<ZCRM_T002_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ZCRM_T002_A, MC.DefectEntity);
                    DefectEntity = MC.DefectEntity;
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }

        protected override void OnCreateAction(InquiryActionResult<ZCRM_T002> result)
        {
            NewRecord = true;
            MasterEntity = new ZCRM_T002();
            DefectEntity = new ObservableCollection<ZCRM_T002_A>();
            MasterEntity.ValidateAsync().Wait();
            DefaultValues();
            DefaultRefDocType();
            SODetails.Clear();
        }

        protected override void OnRemoveAction(InquiryActionResult<ZCRM_T002> result)
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
                    string response = repository.Delete(MasterEntity.doc_no, "RandomInspection", "Production");
                    //FlipGridData.Remove(MasterEntity); Temp
                    MasterEntity = new ZCRM_T002();
                    DefectEntity = new ObservableCollection<ZCRM_T002_A>();
                    NewRecord = true;

                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }

        protected override void OnDiscardAction(InquiryActionResult<ZCRM_T002> result)
        {
            MasterEntity.CancelEdit();
        }

        protected override void OnPrintAction(InquiryActionResult<ZCRM_T002> result)
        {

        }

        protected override void OnFlipAction(InquiryActionResult<ZCRM_T002> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<ZCRM_T002> result)
        {

        }

        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.doc_no))
            {
                //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), DocumentList = MCTemp.AttachmentData, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.comp_code) });
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<ZCRM_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ZCRM_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ZCRM_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ZCRM_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ZCRM_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFevoriteAction(InquiryActionResult<ZCRM_T002> result)
        {

        }
        #endregion

        #region Filter
        #region Filter For Flip Grid
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
            var data = obj as ZCRM_T004_RI_Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_FlipGrid))
                {
                    return

                        (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.shift != null && data.shift.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.EmpLName != null && data.EmpLName.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.posting_date != null && data.posting_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filter string Barcode
        private string _filterString_Barcode;
        public string filterString_Barcode
        {
            get { return _filterString_Barcode; }
            set
            {
                _filterString_Barcode = value;
                RaisePropertyChanged("filterString_Barcode");
                FilterCollectionBarcode();
            }
        }
        private void FilterCollectionBarcode()
        {
            if (_BatchCollection != null)
            {
                _BatchCollection.Refresh();
            }
        }
        public bool BatchFilter(object obj)
        {
            var data = obj as Ref_Doc_no;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Barcode))
                {
                    return (data.RefDocNo != null && data.RefDocNo.ToString().ToLower().Contains(_filterString_Barcode.ToLower())) ||
                        (data.conversion_no != null && data.conversion_no.ToString().ToLower().Contains(_filterString_Barcode.ToLower())) ||
                        (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_Barcode.ToLower())) ||
                        (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_Barcode.ToLower())) ||
                        (data.shift != null && data.shift.ToString().ToLower().Contains(_filterString_Barcode.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter for Ref Doc Type
        private string _filterStringRefdocType;
        public string filterStringRefdocType
        {
            get { return _filterStringRefdocType; }
            set
            {
                _filterStringRefdocType = value;
                RaisePropertyChanged("filterStringRefdocType");
                FilterCollectionRefDocType();
            }
        }
        private void FilterCollectionRefDocType()
        {
            if (_RefDocTypeCollection != null)
            {
                _RefDocTypeCollection.Refresh();
            }
        }
        public bool RefDocFilter(object obj)
        {
            var data = obj as SYS_M013_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringRefdocType))
                {
                    return (data.doc_type_user != null && data.doc_type_user.ToString().ToLower().Contains(_filterStringRefdocType.ToLower())) ||
                        (data.doc_desc_user != null && data.doc_desc_user.ToString().ToLower().Contains(_filterStringRefdocType.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter For Parameter
        private string _filterStringParameter;
        public string filterStringParameter
        {
            get { return _filterStringParameter; }
            set
            {
                _filterStringParameter = value;
                RaisePropertyChanged("filterStringParameter");
                FilterCollectionParameter();
            }
        }
        private void FilterCollectionParameter()
        {
            if (_ParameterCollection != null)
            {
                _ParameterCollection.Refresh();
            }
        }
        public bool FilterParameter(object obj)
        {
            var data = obj as ENG_T003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringParameter))
                {
                    return (data.parameter != null && data.parameter.ToString().ToLower().Contains(_filterStringParameter.ToLower())) ||
                        (data.spec_para_code != null && data.spec_para_code.ToString().ToLower().Contains(_filterStringParameter.ToLower()));
                }
                return true;
            }
            return false;
        }


        #endregion

        #region Filter For Parameter
        private string _FilterStringDefect;
        public string FilterStringDefect
        {
            get { return _FilterStringDefect; }
            set
            {
                _FilterStringDefect = value;
                RaisePropertyChanged("FilterStringDefect");
                FilterDefectCollection();
            }
        }
        private void FilterDefectCollection()
        {
            if (_DefectCollection != null)
            {
                _DefectCollection.Refresh();
            }
        }
        public bool FilterDefect(object obj)
        {
            var data = obj as ZADM_M016_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringDefect))
                {
                    return (data.dfctcda != null && data.dfctcda.ToString().ToLower().Contains(_FilterStringDefect.ToLower())) ||
                        (data.dfctdsc != null && data.dfctdsc.ToString().ToLower().Contains(_FilterStringDefect.ToLower()));
                }
                return true;
            }
            return false;
        }

       

        #endregion

        #endregion

    }
}
