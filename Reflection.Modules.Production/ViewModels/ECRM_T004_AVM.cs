using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.VirtualDesktops;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Data;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.Production.ViewModels
{
    public class ECRM_T004_AVM : WorkspaceViewModel<ECRM_T004_A>
    {
        #region AutoSuggest Initialization
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }

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

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _AS_PartyMaster { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_PartyMaster
        {
            get { return _AS_PartyMaster; }
            set
            {
                if (_AS_PartyMaster != value)
                {
                    _AS_PartyMaster = value; RaisePropertyChanged("AS_PartyMaster");
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

        private AutoSuggestTextViewModel<dynamic> _AS_Operator { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Operator
        {
            get { return _AS_Operator; }
            set
            {
                if (_AS_Operator != value)
                {
                    _AS_Operator = value; RaisePropertyChanged("AS_Operator");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_Barcode { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Barcode
        {
            get { return _AS_Barcode; }
            set
            {
                if (_AS_Barcode != value)
                {
                    _AS_Barcode = value; RaisePropertyChanged("AS_Barcode");
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

        private AutoSuggestTextViewModel<dynamic> _ASqcperson { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASqcperson
        {
            get { return _ASqcperson; }
            set
            {
                if (_ASqcperson != value)
                {
                    _ASqcperson = value; RaisePropertyChanged("ASqcperson");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASShift { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASShift
        {
            get { return _ASShift; }
            set
            {
                if (_ASShift != value)
                {
                    _ASShift = value; RaisePropertyChanged("ASShift");
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

        #region Variable Declaration
        bool NewRecord = true;
        WebServiceRepository<ECRM_T004_A> repository = new WebServiceRepository<ECRM_T004_A>();
        WebServiceRepository<MultipleContext_ECRM_T004_A_New> repository_MC = new WebServiceRepository<MultipleContext_ECRM_T004_A_New>();
        WebServiceRepository<MultipleContext_ECRM_T004_A_New> repository_MCTemp = new WebServiceRepository<MultipleContext_ECRM_T004_A_New>();
        WebServiceRepository<MultipleContext_ECRM_T004_A_New> repository_MCTemp1 = new WebServiceRepository<MultipleContext_ECRM_T004_A_New>();
        WebServiceRepository<MultipleContext_ECRM_T004_A_New> repository_MCTemp2 = new WebServiceRepository<MultipleContext_ECRM_T004_A_New>();
        WebServiceRepository<MultipleContext_ECRM_T004_A_New> repository_MCTemp4 = new WebServiceRepository<MultipleContext_ECRM_T004_A_New>();

        ObjectSerializationService obj = new ObjectSerializationService();

        private MultipleContext_ECRM_T004_A_New _MC = new MultipleContext_ECRM_T004_A_New();
        public MultipleContext_ECRM_T004_A_New MC
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

        private MultipleContext_ECRM_T004_A_New _MCTemp = new MultipleContext_ECRM_T004_A_New();
        public MultipleContext_ECRM_T004_A_New MCTemp
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

        private MultipleContext_ECRM_T004_A_New _MCTemp1 = new MultipleContext_ECRM_T004_A_New();
        public MultipleContext_ECRM_T004_A_New MCTemp1
        {
            get { return _MCTemp1; }
            set
            {
                if (_MCTemp1 != value)
                {
                    _MCTemp1 = value; RaisePropertyChanged("MCTemp");
                }
            }
        }

        private MultipleContext_ECRM_T004_A_New _MCTemp2 = new MultipleContext_ECRM_T004_A_New();
        public MultipleContext_ECRM_T004_A_New MCTemp2
        {
            get { return _MCTemp2; }
            set
            {
                if (_MCTemp2 != value)
                {
                    _MCTemp2 = value; RaisePropertyChanged("MCTem2p");
                }
            }
        }

        private MultipleContext_ECRM_T004_A_New _MCTemp4 = new MultipleContext_ECRM_T004_A_New();
        public MultipleContext_ECRM_T004_A_New MCTemp4
        {
            get { return _MCTemp4; }
            set
            {
                if (_MCTemp4 != value)
                {
                    _MCTemp4 = value; RaisePropertyChanged("MCTemp4");
                }
            }
        }

        private ECRM_T004_A _MasterEntity;
        public ECRM_T004_A MasterEntity
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

        private TransHistory _Transhistory;
        public TransHistory Transhistory
        {
            get { return _Transhistory; }
            set
            {
                if (_Transhistory != value)
                {
                    _Transhistory = value; RaisePropertyChanged("Transhistory");
                }
            }
        }

        private ObservableCollection<ECRM_T004_C> _DefectEntity;
        public ObservableCollection<ECRM_T004_C> DefectEntity
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

        private ObservableCollection<ECRM_T003_P> _SODetails;
        public ObservableCollection<ECRM_T003_P> SODetails
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

        private List<ECRM_T004_Aflip> _FlipGridData;
        public List<ECRM_T004_Aflip> FlipGridData
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

        #endregion

        #region ICollection
        private ICollectionView _HistoryCollection;
        public ICollectionView HistoryCollection
        {
            get { return _HistoryCollection; }
            set
            {
                _HistoryCollection = value;
                RaisePropertyChanged("HistoryCollection");
            }
        }

        private ICollectionView _DataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _DataGridCollection; }
            set
            {
                _DataGridCollection = value;
                RaisePropertyChanged("DataGridCollection");
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
        #endregion

        #region String List
        List<string> _StringListParameter;
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

        List<string> _StringListDefect;
        public List<string> StringListDefect
        {
            get { return _StringListDefect; }
            set
            {
                if (_StringListDefect != value)
                {
                    _StringListDefect = value;
                }
            }
        }
        #endregion

        #region Relay Command Declaration
        public RelayCommand<object> CommandViewDocument { get; private set; }
        public RelayCommand<object> CmdAddBatchDetails { get; private set; }
        public RelayCommand<object> CMDParty { get; private set; }
        public RelayCommand<object> CMDShift { get; set; }
        public RelayCommand<object> CMDOperator { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand CMDLoadFromFilters { get; private set; }
        public RelayCommand<object> CMDLoadDocumentByDocumentNo { get; private set; }
        public RelayCommand<object> CmdParameter { get; private set; }
        public RelayCommand<object> CmdDefect { get; private set; }
        public RelayCommand<object> CmdDefectAction { get; private set; }
        public RelayCommand<object> CmdInsert_t_status { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> CmdInsertGrade { get; private set; }
        #endregion

        #region Constructor
        public ECRM_T004_AVM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new ECRM_T004_A();
            DefectEntity = new ObservableCollection<ECRM_T004_C>();
            SODetails = new ObservableCollection<ECRM_T003_P>();
            MC = new MultipleContext_ECRM_T004_A_New();
            MCTemp = new MultipleContext_ECRM_T004_A_New();
            MCTemp1 = new MultipleContext_ECRM_T004_A_New();
            MCTemp4 = new MultipleContext_ECRM_T004_A_New();
            ECRM_T004_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            LoadInitialData();

            
        }
        public ECRM_T004_AVM(string ts_code,string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new ECRM_T004_A();
            DefectEntity = new ObservableCollection<ECRM_T004_C>();
            SODetails = new ObservableCollection<ECRM_T003_P>();
            MC = new MultipleContext_ECRM_T004_A_New();
            MCTemp = new MultipleContext_ECRM_T004_A_New();
            MCTemp1 = new MultipleContext_ECRM_T004_A_New();
            MCTemp4 = new MultipleContext_ECRM_T004_A_New();
            ECRM_T004_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            LoadInitialData();


        }
        #endregion

        #region User Define Functions
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = MasterEntity.HasErrors;
            if (sender.ToString() == "qty" || sender.ToString() == "addition" || sender.ToString() == "sample_qty" || sender.ToString() == "rej_qty" || sender.ToString() == "check_qty" || sender.ToString() == "refil_qty")
            {
                cal();
            }
        }
        private void LoadInitialData()
        {
            try
            {

                MasterEntity.doc_type = "PDI";
                MasterEntity.doc_cat = "PDI";
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ECRM_T004_A_New>(MC, Request, "PDI Entry 2", "Production", "LoadAll", 0, "");

                #region Relay Command Initializatoin
                CommandViewDocument = new RelayCommand<object>(items => { if (items == null) { return; } ViewDocument(items); });
                CmdAddBatchDetails = new RelayCommand<object>(items => { if (items == null) { return; } InsertBatchDetails(items); });
                CMDParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertParty(items); });
                CMDShift = new RelayCommand<object>(items => { if (items == null) { return; } InsertShift(items); });
                CMDOperator = new RelayCommand<object>(items => { if (items == null) { return; } InsertOperator(items); });
                CMDLoadFromFilters = new GalaSoft.MvvmLight.Command.RelayCommand(() => { LoadFromFilters(); });
                CMDLoadDocumentByDocumentNo = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara); });
                CmdParameter = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertParameters(cmdPara, true, true, true); });
                CmdDefect = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDefectList(cmdPara, true, true, true); });
                CmdDefectAction = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Defect(cmdPara); });
                CmdInsert_t_status = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Insert_t_status(cmdPara); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                CmdInsertGrade = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertGrade(cmdPara); });
                #endregion

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => ((ADM_M028_P)o).PartyId.ToLower().Contains(prefix.ToLower()) || ((ADM_M028_P)o).PartyNm.ToLower().Contains(prefix.ToLower());
                AS_PartyMaster = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "PartyId", true);
                AS_PartyMaster.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M042_P)x).shift);
                TheFilter = (o, prefix) => ((ADM_M042_P)o).shift.ToLower().Contains(prefix.ToLower());
                AS_Shift = new AutoSuggestTextViewModel<dynamic>(MC.ShiftMaster, TheFilter, SuggestedValue, "shift", true);
                AS_Shift.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => ((ADM_M024_P)o).EmpId.ToLower().Contains(prefix.ToLower()) || ((ADM_M024_P)o).EmpName.ToLower().Contains(prefix);
                AS_Operator = new AutoSuggestTextViewModel<dynamic>(MC.OperatorData, TheFilter, SuggestedValue, "EmpId", true);
                AS_Operator.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ECRM_T003_P)x).barcode);
                TheFilter = (o, prefix) => ((ECRM_T003_P)o).barcode.ToLower().Contains(prefix.ToLower()) || ((ECRM_T003_P)o).order_no.ToLower().Contains(prefix) || ((ECRM_T003_P)o).wtno.ToLower().Contains(prefix) || ((ECRM_T003_P)o).machinecode.ToLower().Contains(prefix) || ((ECRM_T003_P)o).shift.ToLower().Contains(prefix) || ((ECRM_T003_P)o).prddt.ToString().Contains(prefix);
                AS_Barcode = new AutoSuggestTextViewModel<dynamic>(MC.BarcodeDetails, TheFilter, SuggestedValue, "barcode", false);
                AS_Barcode.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ENG_T003_P)x).spec_para_code);
                TheFilter = (o, prefix) => ((ENG_T003_P)o).spec_para_code.ToLower().Contains(prefix.ToLower()) || ((ENG_T003_P)o).parameter.ToLower().Contains(prefix.ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.ParameterMaster, TheFilter, SuggestedValue, "parameters", "spec_para_code", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ENG_T003_P)x).spec_para_code);
                TheFilter = (o, prefix) => ((ENG_T003_P)o).spec_para_code.ToLower().Contains(prefix.ToLower()) || ((ENG_T003_P)o).parameter.ToLower().Contains(prefix.ToLower());
                AS_Parameter = new AutoSuggestTextViewModel<dynamic>(MC.ParameterMaster, TheFilter, SuggestedValue, "parameters", "spec_para_code", true);
                AS_Parameter.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M016_P)x).dfctcda.ToString());
                TheFilter = (o, prefix) => ((ZADM_M016_P)o).dfctcda.ToString().ToLower().Contains(prefix.ToLower()) || ((ZADM_M016_P)o).dfctdsc.ToLower().Contains(prefix.ToLower());
                AS_Defect = new AutoSuggestTextViewModel<dynamic>(MC.DefectMaster, TheFilter, SuggestedValue, "defect", "dfctcda", true);
                AS_Defect.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => ((ADM_M024_P)o).EmpId.ToLower().Contains(prefix.ToLower()) || ((ADM_M024_P)o).EmpName.ToLower().Contains(prefix);
                ASqcperson = new AutoSuggestTextViewModel<dynamic>(MC.OperatorData, TheFilter, SuggestedValue, "EmpId", true);
                ASqcperson.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M042_P)x).shift);
                TheFilter = (o, prefix) => ((ADM_M042_P)o).shift.ToLower().Contains(prefix.ToLower());
                ASShift = new AutoSuggestTextViewModel<dynamic>(MC.ShiftMaster, TheFilter, SuggestedValue, "shift", true);
                ASShift.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_display);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASt_status = new AutoSuggestTextViewModel<dynamic>(MC.t_statusList, TheFilter, SuggestedValue, "t_display", true);
                ASt_status.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M030_P)x).parametervalue);
                TheFilter = (o, prefix) => (((ADM_M030_P)o).value_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M030_P)o).parametervalue ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASGrade = new AutoSuggestTextViewModel<dynamic>(MC.GradeList, TheFilter, SuggestedValue, "parametervalue", true);
                ASGrade.AutoSuggestVM.IsEmptyValueAllowed = true;

                ParameterCollection = CollectionViewSource.GetDefaultView(MC.ParameterMaster);
                ParameterCollection.Filter = new Predicate<object>(ParameterFilter);
                StringListParameter = MC.ParameterMaster.Select(x => x.parameter.ToString()).ToList();

                DefectCollection = CollectionViewSource.GetDefaultView(MC.DefectMaster);
                DefectCollection.Filter = new Predicate<object>(DefectFilter);
                StringListDefect = MC.DefectMaster.Select(x => x.dfctcda.ToString()).ToList();


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
        private void ViewDocument(object InputValue)
        {
            try
            {
                //TransHistory POPUPEntityObject = null;
                //UserAuthontication_Result userAuth = new UserAuthontication_Result();
                //if (InputValue != null && ((IEnumerable)InputValue).Cast<TransHistory>().Count() > 0)
                //{
                //    POPUPEntityObject = ((IEnumerable)InputValue).Cast<TransHistory>().ToList()[0];
                //}

                //var docdetails = AppSessionState.UserAuthorisations.Where(X => X.TranCode == POPUPEntityObject.TranCode).FirstOrDefault();
                //userAuth = docdetails;
                //AppSessionState.UserAuthSingle = userAuth;
                //AppSessionState.ViewTitle = userAuth.DisTitl;
                //AppSessionState.TransValue = POPUPEntityObject.doc_no;
                //AppSessionState.TransValueType = POPUPEntityObject.doc_no;
                //AppSessionState.TransParameter = "NO";
                //AppSessionState.ViewOtherRecordAllowed = false;
                //AppSessionState.TransId = userAuth.id.ToString();
                //AppSessionState.TransactionCode = userAuth.TranCode;

                //if (userAuth.SbModCod != null && userAuth.SbModCod != "" && userAuth.ClsFileName != null && userAuth.ClsFileName != "")
                //{
                //    string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, userAuth.Nspace);
                //    Assembly assembly = Assembly.LoadFile(path1);
                //    Type type = assembly.GetType(userAuth.ClsFileName);
                //    if (type != null)
                //    {
                //        dynamic instance = Activator.CreateInstance(type);
                //        SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                //    }
                //}
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
        private void InsertParty(Object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M028_P POPUPEntityObject = null;
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.PartyMaster.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M028_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                    }
                }


                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.PartyId = POPUPEntityObject.PartyId;
                    MasterEntity.PartyNm = POPUPEntityObject.PartyNm;

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
        private void InsertShift(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M042_P POPUPEntityObject = null;
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ShiftMaster.Where(x => x.shift.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M042_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M042_P>().ToList()[0];
                    }
                }


                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.shift = POPUPEntityObject.shift;
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
        private void InsertOperator(object InputValue)
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
                        { POPUPEntityObject = MC.OperatorData.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    MasterEntity.@operator = POPUPEntityObject.EmpId;
                    MasterEntity.EmpNm = POPUPEntityObject.EmpName;
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
        private void InsertBatchDetails(object InputValue)
            {
            try
            {
                #region Insert Barcode Details
                string Request = "";
                ECRM_T003_P POPUPEntityObject = null;
                barcode = InputValue.ToString();
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length >= 10)
                    {
                        var InputValueIfExists = MC.BarcodeDetails.Where(X => X.barcode == Request).FirstOrDefault();//Checking Weather Barcode is Valid or Not By Checking in Business Entity
                        if (InputValueIfExists != null)
                        {
                            try
                            {
                                POPUPEntityObject = MC.BarcodeDetails.Where(x => (x.barcode ?? "").Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; //If Barcode is Valid Get All the Information in PopupEntityObject
                                if (POPUPEntityObject != null)
                                {
                                    MasterEntity.barcode_no = POPUPEntityObject.barcode;
                                    MasterEntity.prodate = POPUPEntityObject.prddt;
                                    MasterEntity.ItemCode = POPUPEntityObject.prdct_code;
                                    MasterEntity.ItemName = POPUPEntityObject.ItemName;
                                    MasterEntity.mach_no = POPUPEntityObject.mchn_id;
                                    MasterEntity.machinecode = POPUPEntityObject.machinecode;
                                    MasterEntity.shift = POPUPEntityObject.shift;
                                    MasterEntity.PartyId = POPUPEntityObject.PartyId;
                                    MasterEntity.PartyNm = POPUPEntityObject.PartyNm;
                                    MasterEntity.mod_no = POPUPEntityObject.modlno;
                                    MasterEntity.@operator = POPUPEntityObject.EmpId;
                                    MasterEntity.EmpNm = POPUPEntityObject.EmpName;
                                    MasterEntity.order_no = POPUPEntityObject.order_no;
                                    MasterEntity.qty = POPUPEntityObject.counter_qty;
                                    MasterEntity.set_ink = POPUPEntityObject.ink;
                                    MasterEntity.ildmin = POPUPEntityObject.tmnild;
                                    MasterEntity.ildmax = POPUPEntityObject.tmxild;
                                    MasterEntity.Conv_no = POPUPEntityObject.Conv_lot;
                                    MasterEntity.Grade = POPUPEntityObject.Grade;
                                    MasterEntity.wc_code = POPUPEntityObject.wc_code;
                                    MasterEntity.counter_remark = POPUPEntityObject.counter_remark;
                                   

                                    SODetails.Clear();
                                    SODetails.Add(new ECRM_T003_P()
                                    {
                                        sono = POPUPEntityObject.sono,
                                        PartyId1 = POPUPEntityObject.PartyId1,
                                        PartyName1 = POPUPEntityObject.PartyName1,
                                        quantity1 = POPUPEntityObject.quantity1,
                                        ItemCode1 = POPUPEntityObject.ItemCode1,
                                        ItemName1 = POPUPEntityObject.ItemName1,
                                        sodate = POPUPEntityObject.sodate
                                    });
                                    string RequestParameter = "LoadHistory" + "!@" + MasterEntity.barcode_no + "!@" + MasterEntity.order_no;
                                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ECRM_T004_A_New>(MCTemp, RequestParameter, "PDI Entry 2", "Production", "LoadAll", 0, "");

                                    //foreach (var item in MCTemp.TransactionHistory)
                                    //{
                                    //    var docdetails = AppSessionState.UserAuthorisations.Where(X => X.TranCode == item.TranCode).FirstOrDefault();
                                    //    UserAuthontication_Result user_auth = docdetails;
                                    //    if (user_auth != null)
                                    //    {
                                    //        item.Transaction = user_auth.DisTitl;
                                    //    }
                                    //}
                                    HistoryCollection = CollectionViewSource.GetDefaultView(MCTemp.TransactionHistory);
                                }
                            }
                            catch (Exception ex) { }
                        }
                        else
                        {
                            IShowMessageViewService ShowMessage2 = this.GetViewService<IShowMessageViewService>();
                            ShowMessage2.ButtonSetup = DialogButton.OkCancel;
                            ShowMessage2.Caption = "Message";
                            ShowMessage2.Text = String.Format("Entered Barcode is Used.\n Press OK To Re-Sacn Barcode OR Press Cancel To Cancel Re-Scan", this.Title);
                            //ShowMessage2.ShowMessage();

                            if (ShowMessage2.ShowMessage() == DialogResult.Ok)
                            {
                                string Request1 = "RescanBarcode" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + Request;
                                MCTemp4 = repository_MCTemp4.GetDataWithReturnDomainObject<MultipleContext_ECRM_T004_A_New>(MCTemp4, Request1, "PDI Entry 2", "Production", "LoadAll", 0, "");

                                if(MCTemp4.RescanBarcode !=null)
                                {
                                    if(MCTemp4.RescanBarcode.Count > 0)
                                    {
                                        MasterEntity = MCTemp4.RescanBarcode[0];
                                        SODetails = MCTemp4.SODetails;
                                        DefaultValues();
                                        MasterEntity.t_status = "021";
                                        //foreach (var item in MCTemp4.TransactionHistory)
                                        //{
                                        //    var docdetails = AppSessionState.UserAuthorisations.Where(X => X.TranCode == item.TranCode).FirstOrDefault();
                                        //    UserAuthontication_Result user_auth = docdetails;
                                        //    if (user_auth != null)
                                        //    {
                                        //        item.Transaction = user_auth.DisTitl;
                                        //    }
                                        //}
                                        HistoryCollection = CollectionViewSource.GetDefaultView(MCTemp4.TransactionHistory);
                                    }
                                    else
                                    {
                                        ShowMessage2.ButtonSetup = DialogButton.OkCancel;
                                        ShowMessage2.Caption = "Message";
                                        ShowMessage2.Text = String.Format("Entered Barcode is Invalid", this.Title);
                                        ShowMessage2.ShowMessage();
                                    }
                                }
                                else
                                {
                                    ShowMessage2.ButtonSetup = DialogButton.OkCancel;
                                    ShowMessage2.Caption = "Message";
                                    ShowMessage2.Text = String.Format("Entered Barcode is Invalid", this.Title);
                                    ShowMessage2.ShowMessage();
                                }
                                
                            }
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ECRM_T003_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ECRM_T003_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.barcode_no = POPUPEntityObject.barcode;
                    MasterEntity.prodate = POPUPEntityObject.prddt;
                    MasterEntity.ItemCode = POPUPEntityObject.prdct_code;
                    MasterEntity.ItemName = POPUPEntityObject.ItemName;
                    MasterEntity.mach_no = POPUPEntityObject.mchn_id;
                    MasterEntity.machinecode = POPUPEntityObject.machinecode;
                    MasterEntity.shift = POPUPEntityObject.shift;
                    MasterEntity.PartyId = POPUPEntityObject.PartyId;
                    MasterEntity.PartyNm = POPUPEntityObject.PartyNm;
                    MasterEntity.mod_no = POPUPEntityObject.modlno;
                    MasterEntity.@operator = POPUPEntityObject.EmpId;
                    MasterEntity.EmpNm = POPUPEntityObject.EmpName;
                    MasterEntity.order_no = POPUPEntityObject.order_no;
                    MasterEntity.qty = POPUPEntityObject.counter_qty;
                    MasterEntity.set_ink = POPUPEntityObject.ink;
                    MasterEntity.ildmin = POPUPEntityObject.tmnild;
                    MasterEntity.ildmax = POPUPEntityObject.tmxild;
                    MasterEntity.Conv_no = POPUPEntityObject.Conv_lot;
                    MasterEntity.Grade = POPUPEntityObject.Grade;
                    MasterEntity.counter_remark = POPUPEntityObject.counter_remark;

                    SODetails.Clear();
                    SODetails.Add(new ECRM_T003_P()
                    {
                        sono = POPUPEntityObject.sono,
                        PartyId1 = POPUPEntityObject.PartyId1,
                        PartyName1 = POPUPEntityObject.PartyName1,
                        quantity1 = POPUPEntityObject.quantity1,
                        ItemCode1 = POPUPEntityObject.ItemCode1,
                        ItemName1 = POPUPEntityObject.ItemName1,
                        sodate = POPUPEntityObject.sodate
                    });
                    string RequestParameter = "LoadHistory" + "!@" + MasterEntity.barcode_no + "!@" + MasterEntity.order_no;
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ECRM_T004_A_New>(MCTemp, RequestParameter, "PDI Entry 2", "Production", "LoadAll", 0, "");

                    //foreach (var item in MCTemp.TransactionHistory)
                    //{
                    //    var docdetails = AppSessionState.UserAuthorisations.Where(X => X.TranCode == item.TranCode).FirstOrDefault();
                    //    UserAuthontication_Result user_auth = docdetails;
                    //    if (user_auth != null)
                    //    {
                    //        item.Transaction = user_auth.DisTitl;
                    //    }
                    //}
                    HistoryCollection = CollectionViewSource.GetDefaultView(MCTemp.TransactionHistory);
                }
            }
            catch (Exception ex) { }
            #endregion
            var msg = new NotificationMessage("ECRM_T004_AVM");
            Messenger.Default.Send<NotificationMessage>(msg);
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
                        { POPUPEntityObject = MC.ParameterMaster.Where(x => x.spec_para_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                        DefectEntity.Add(new ECRM_T004_C()
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

                ECRM_T004_C newObj = new ECRM_T004_C();
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
        private void InsertDefectList(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            #region ABC
            //try
            //{            
            //    string Request = "";
            //    ZADM_M016_P POPUPEntityObject = null;
            //    #region Command Parameter Read Section
            //    if (InputValue.GetType() == typeof(string) && InputValue != null)
            //    {
            //        Request = InputValue.ToString();
            //        if (Request.Length > 0)
            //        {
            //            POPUPEntityObject = MC.DefectMaster.Where(x => x.dfctcda.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];

            //        }
            //    }
            //    else if (InputValue != null)
            //    {
            //        if (((IEnumerable)InputValue).Cast<ZADM_M016_P>().Count() > 0)
            //        {
            //            POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M016_P>().ToList()[0];
            //        }
            //    }
            //    #endregion
            //    if (POPUPEntityObject != null)
            //    {
            //        var InputValueIfExists = DefectEntity.Where(X => X.defect == POPUPEntityObject.dfctcda.ToString()).FirstOrDefault(); // Prefer Primary Key for this instruction.
            //        int IndexOfExistValue = DefectEntity.IndexOf(DefectEntity.Where(X => X.defect == POPUPEntityObject.dfctcda.ToString()).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

            //        if (dgSelectedIndexDefect >= 0 && DefectEntity.Count > dgSelectedIndexDefect) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
            //        {
            //            if (DefectEntity[dgSelectedIndexDefect].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
            //            {
            //                DefectEntity[dgSelectedIndexDefect].defect = POPUPEntityObject.dfctcda.ToString();
            //                DefectEntity[dgSelectedIndexDefect].defectNm = POPUPEntityObject.dfctdsc;
            //            }
            //            else if (DefectEntity[dgSelectedIndexDefect].defect != POPUPEntityObject.dfctcda.ToString())
            //            {
            //                DefectEntity[dgSelectedIndexDefect].defect = POPUPEntityObject.dfctcda.ToString();
            //                DefectEntity[dgSelectedIndexDefect].defectNm = POPUPEntityObject.dfctdsc;
            //            }
            //        }
            //    }
            //    #region Clear Empty Row
            //    ECRM_T004_C newObj = new ECRM_T004_C();
            //    for (int i = DefectEntity.Count - 1; i >= 0; i--)
            //    {
            //        bool xx = DefectEntity[i].ComparePropertiesTo(newObj);
            //        if (DefectEntity[i].ComparePropertiesTo(newObj) == true && DefectEntity.Count > 1)
            //        {
            //            DefectEntity.RemoveAt(i);
            //            if (DefectEntity.Count == 0)
            //            {
            //                DefectEntity.Add(newObj);
            //            }
            //        }
            //    }
            //    #endregion
            //}
            //catch (Exception ex)
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format(ex.Message, this.Title);
            //    showMessageService.ShowMessage();

            //}
            #endregion

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
                        { POPUPEntityObject = MC.DefectMaster.Where(x => x.dfctcda.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                        DefectEntity.Add(new ECRM_T004_C()
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
        private void DefaultValues()
        {
            MasterEntity.doc_cat = "PDI";
            MasterEntity.doc_type = "PDI";
            MasterEntity.client = AppSessionState.client;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.pdi_date = DateTime.Now;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.pdi_no = "";
            MasterEntity.active = true;
            MasterEntity.add_date = DateTime.Now;
            //MasterEntity.prodate = System.DateTime.Now;
            MasterEntity.Fromdate = DateTime.Now;
            MasterEntity.ToDate = DateTime.Now;
            MasterEntity.t_status = "001";
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;
        }
        private void LoadFromFilters()
        {
            try
            {
                if (Validation1() == true)
                {
                    string RequestParameter = "LoadFromFilters" + "!@" + MasterEntity.EmpId1 + "!@" + MasterEntity.qc_person1 + "!@" + MasterEntity.Fromdate.ToString() + "!@" + MasterEntity.ToDate.ToString() + "!@" + MasterEntity.con_no + "!@" + MasterEntity.sshift + "!@" + MasterEntity.machine + "!@" + MasterEntity.item + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id;
                    MCTemp1 = repository_MCTemp1.GetDataWithReturnDomainObject<MultipleContext_ECRM_T004_A_New>(MCTemp1, RequestParameter, "PDI Entry 2", "Production", "LoadAll", 0, "");

                    FlipGridData = MCTemp1.DocumentDataFlipGrid.ToList();
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
            if (MasterEntity.Fromdate == null)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select From Date... ");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.ToDate == null)
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

        private void DeleteDataGridRow_Defect(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (DefectEntity.Count > i && DefectEntity[dgSelectedIndexDefect].id == 0)
                {
                    DefectEntity.RemoveAt(i);
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
        private void cal()
        {
            try
            {
                decimal? qty = 0;
                decimal? check_qty = 0;
                decimal? rej_qty = 0;
                decimal? addition = 0;
                decimal? final_qty = 0;
                if (MasterEntity.qty != null)
                {
                    MasterEntity.final_qty = (Convert.ToDecimal(MasterEntity.qty)) - (Convert.ToDecimal(MasterEntity.sample_qty)) - (Convert.ToDecimal(MasterEntity.check_qty)) - (Convert.ToDecimal(MasterEntity.rej_qty)) - (Convert.ToDecimal(MasterEntity.refil_qty)) + (Convert.ToDecimal(MasterEntity.addition));
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
        private void LoadDocumentByDocumentNumber(object ParameterObject)
        {
            try
            {
                string Request = "";
                string ParametersStringValue = "";
                ECRM_T004_Aflip POPUPEntityObject = null;
                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null)
                {
                    ParametersStringValue = ParameterObject.ToString().Trim();
                    if (ParametersStringValue.Length > 0)
                    {
                        try
                        { Request = "LoadALL" + "!@" + ParametersStringValue; }
                        catch (Exception ex) { }
                    }
                }

                else if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<ECRM_T004_Aflip>().ToList().Count > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)ParameterObject).Cast<ECRM_T004_Aflip>().ToList()[0];

                        string RequestParameterData = "LoadDocumentByDocumentNumber" + "!@" + POPUPEntityObject.pdi_no + "!@" + POPUPEntityObject.barcode_no; ;
                        MCTemp2 = repository_MCTemp2.GetDataWithReturnDomainObject<MultipleContext_ECRM_T004_A_New>(MCTemp2, RequestParameterData, "PDI Entry 2", "Production", "LoadAll", 0, "");

                        if (MCTemp2.MasterEntity.Count > 0)
                        {
                            MasterEntity = MCTemp2.MasterEntity[0];
                            DefectEntity = MCTemp2.DefectEntity;
                            SODetails = MCTemp2.SODetails;

                            //foreach (var item in MCTemp2.TransactionHistory)
                            //{
                            //    var docdetails = AppSessionState.(List<ADM_AUTH>)ADM_AUTH_OBJ.Where(X => X.TranCode == item.TranCode).FirstOrDefault();
                            //    UserAuthontication_Result user_auth = docdetails;
                            //    if (user_auth != null)
                            //    {
                            //        item.Transaction = user_auth.DisTitl;
                            //    }
                            //}

                            HistoryCollection = CollectionViewSource.GetDefaultView(MCTemp2.TransactionHistory);

                            AttachmentCollection = MCTemp2.AttachmentData;
                            if (MCTemp2.AttachmentData != null)
                            {
                                AttachmentCollection = MCTemp2.AttachmentData;
                            }
                            else
                            {
                                MCTemp2.AttachmentData = new List<COM_T003>();
                            }
                            SelectedTabControlIndex = 0;
                            NewRecord = false;
                            SetPopupSuggestionDataAfterLoad();
                            MasterEntity.ts_code = ts_code_vm;
                            var msg = new NotificationMessage("ECRM_T004_AVM");
                            Messenger.Default.Send<NotificationMessage>(msg);
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
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                MasterEntity.ts_code = ts_code_vm;
                if (MasterEntity.XmlDataDocument_ECRM_T004_C != null && ParameterOption1 == "Save")
                {
                    DefectEntity.Clear();
                    MC.DefectEntity = (ObservableCollection<ECRM_T004_C>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ECRM_T004_C, MC.DefectEntity);

                    DefectEntity = MC.DefectEntity;
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
            //if (MasterEntity.barcode_no == null || MasterEntity.barcode_no == "" && MasterEntity.ItemCode == null || MasterEntity.ItemCode == "")
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format("Please Scan/Select Barcode To Load PDI Data ");
            //    showMessageService.ShowMessage();
            //    return false;
            //}

            return true;
        }

        private void SetPopupSuggestionDataAfterLoad()
        {
            AS_PartyMaster.AutoSuggestVM.Suggestion = MC.PartyMaster.Find(x => x.PartyId == MasterEntity.PartyId);

            AS_Barcode.AutoSuggestVM.Suggestion = MC.BarcodeDetails.Find(x => x.barcode == MasterEntity.barcode_no);

            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
            TheFilter = (o, prefix) => ((ADM_M024_P)o).EmpId.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase) || ((ADM_M024_P)o).EmpName.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase);
            AS_Operator = new AutoSuggestTextViewModel<dynamic>(MC.OperatorData, TheFilter, SuggestedValue, "EmpId", true);
            AS_Operator.AutoSuggestVM.IsEmptyValueAllowed = true;

            AS_Operator.AutoSuggestVM.Suggestion = MC.OperatorData.Find(x => x.EmpId == MasterEntity.@operator);

            AS_Shift.AutoSuggestVM.Suggestion = MC.ShiftMaster.Find(x => x.shift == MasterEntity.shift);

        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(doc_no_vm);
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
                    MasterEntity.Grade = POPUPEntityObject.parametervalue;
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
                if (string.IsNullOrWhiteSpace(MasterEntity.barcode_no) == false)
                {
                    MC.BarcodeDetails.Remove(MC.BarcodeDetails.Single(s => s.barcode == MasterEntity.barcode_no));
                }
            }
            catch (Exception ex)
            {
            }

        }
        #endregion

        #region Abstract Methods
        protected override void OnCreateAction(InquiryActionResult<ECRM_T004_A> result)
        {
            NewRecord = true;
            MasterEntity = new ECRM_T004_A();
            DefectEntity = new ObservableCollection<ECRM_T004_C>();
            MC.TransactionHistory = new List<TransHistory>();
            MCTemp.TransactionHistory = new List<TransHistory>();
            MCTemp2.TransactionHistory = new List<TransHistory>();
            MCTemp4.RescanBarcode = new List<ECRM_T004_A>();
            HistoryCollection = CollectionViewSource.GetDefaultView(MCTemp.TransactionHistory);
            SODetails.Clear();
            DefaultValues();

            var msg = new NotificationMessage("ECRM_T004_AVM");
            Messenger.Default.Send<NotificationMessage>(msg);

        }

        protected override void OnDiscardAction(InquiryActionResult<ECRM_T004_A> result)
        {

        }

        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ECRM_T004_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ECRM_T004_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ECRM_T004_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ECRM_T004_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ECRM_T004_A> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ECRM_T004_A> result)
        {

        }

        protected override void OnFlipAction(InquiryActionResult<ECRM_T004_A> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<ECRM_T004_A> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<ECRM_T004_A> result)
        {

        }

        protected override void OnRemoveAction(InquiryActionResult<ECRM_T004_A> result)
        {

        }

        protected override void OnSaveAction(InquiryActionResult<ECRM_T004_A> result)
        {
            try
            {
                MasterEntity.editby = AppSessionState.UserID;
                MasterEntity.XmlDataDocument_ECRM_T004_C = obj.ObjectToXML(DefectEntity);
                this.MasterEntity.EndEdit();
                if (Validation() == true)
                {
                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ECRM_T004_A>(MasterEntity, "PDI Entry 2", "Production");
                        NewRecord = false;
                        RemoveReferenceDocuments();
                        if (MasterEntity.pdi_no != " " || MasterEntity.pdi_no != null)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Data Saved Successfully");
                            showMessageService.ShowMessage();
                        }
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ECRM_T004_A>(MasterEntity, "PDI Entry 2", "Production");
                        if (MasterEntity.pdi_no != " " || MasterEntity.pdi_no != null)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Data Update Successfully");
                            showMessageService.ShowMessage();
                        }
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    var msg = new NotificationMessage("ECRM_T004_AVM");
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
        #endregion

        #region Filters

        private string _filterString;
        private void FilterCollection()
        {
            if (_DataGridCollection != null)
            {
                _DataGridCollection.Refresh();
            }
        }
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
        public bool Filter(object obj)
        {
            var data = obj as ECRM_T004_Aflip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString))
                {
                    return ((data.pdi_no != null) && data.pdi_no.ToLower().Contains(_filterString.ToLower()) ||
                           (data.machinecode != null) && data.machinecode.ToLower().Contains(_filterString.ToLower()) ||
                           (data.shift != null) && data.shift.ToLower().Contains(_filterString.ToLower()) ||
                           (data.ItemName != null) && data.ItemName.ToLower().Contains(_filterString.ToLower()) ||
                           (data.ItemCode != null) && data.ItemCode.ToLower().Contains(_filterString.ToLower()));
                }
                return true;
            }
            return false;
        }

        #region Filter For Parameter
        private string _FilterStringParameter;
        public string FilterStringParameter
        {
            get { return _FilterStringParameter; }
            set
            {
                _FilterStringParameter = value;
                RaisePropertyChanged("FilterStringParameter");
                FilterParameterCollection();
            }
        }
        private void FilterParameterCollection()
        {
            if (_ParameterCollection != null)
            {
                _ParameterCollection.Refresh();
            }
        }
        public bool ParameterFilter(object obj)
        {
            var data = obj as ENG_T003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringParameter))
                {
                    return (data.parameter != null && data.parameter.ToString().ToLower().Contains(_FilterStringParameter.ToLower())) ||
                           (data.para_details != null && data.para_details.ToString().ToLower().Contains(_FilterStringParameter.ToLower())) ||
                           (data.spec_para_code != null && data.spec_para_code.ToString().ToLower().Contains(_FilterStringParameter.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filter For Defect
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
        public bool DefectFilter(object obj)
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
