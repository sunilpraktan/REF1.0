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
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;
using Reflection.ReportingServices;
using Reflection.BusinessEntity.Production;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.Production.ViewModels
{

    public class PPC_T003VM : WorkspaceViewModel<PPC_T003>
    {
        #region AutoSuggest TextBox Declaration Region
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
        private AutoSuggestTextViewModel<dynamic> _ASDocType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDocType
        {
            get { return _ASDocType; }
            set
            {
                if (_ASDocType != value)
                {
                    _ASDocType = value; RaisePropertyChanged("DocType");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDocNo { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDocNo
        {
            get { return _ASDocNo; }
            set
            {
                if (_ASDocNo != value)
                {
                    _ASDocNo = value; RaisePropertyChanged("ASDocNo");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASShift_Incharge { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASShift_Incharge
        {
            get { return _ASShift_Incharge; }
            set
            {
                if (_ASShift_Incharge != value)
                {
                    _ASShift_Incharge = value; RaisePropertyChanged("ASShift_Incharge");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_M_Operator { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_M_operator
        {
            get { return _AS_M_Operator; }
            set
            {
                if (_AS_M_Operator != value)
                {
                    _AS_M_Operator = value; RaisePropertyChanged("AS_M_Operator");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_ShiftNo { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ShiftNo
        {
            get { return _AS_ShiftNo; }
            set
            {
                if (_AS_ShiftNo != value)
                {
                    _AS_ShiftNo = value; RaisePropertyChanged("AS_ShiftNo");
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

        private AutoSuggestTextViewModel<dynamic> _ASEmp { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASEmp
        {
            get { return _ASEmp; }
            set
            {
                if (_ASEmp != value)
                {
                    _ASEmp = value; RaisePropertyChanged("ASEmp");
                }
            }
        }

        private AutoSuggestTextViewModel <dynamic> _ASqcperson { get; set; }
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

        #region Declaration
        bool isNewRecord = true;

        WebServiceRepository<PPC_T003> repository = new WebServiceRepository<PPC_T003>();
        WebServiceRepository<MultipleContext_PPC_T003> repository_MC = new WebServiceRepository<MultipleContext_PPC_T003>();
        WebServiceRepository<MultipleContext_PPC_T003> repository_MCTemp = new WebServiceRepository<MultipleContext_PPC_T003>();
        WebServiceRepository<MultipleContext_PPC_T003> repository_MCTemp1 = new WebServiceRepository<MultipleContext_PPC_T003>();
        WebServiceRepository<MultipleContext_PPC_T003> repository_MT = new WebServiceRepository<MultipleContext_PPC_T003>();
        WebServiceRepository<MultipleContext_PPC_T003> repository_MCTemp5 = new WebServiceRepository<MultipleContext_PPC_T003>();
        WebServiceRepository<MultipleContext_PPC_T003> repository_Filters = new WebServiceRepository<MultipleContext_PPC_T003>();
        ObjectSerializationService obj = new ObjectSerializationService();
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        private MultipleContext_PPC_T003 _MC = new MultipleContext_PPC_T003();
        public MultipleContext_PPC_T003 MC
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

        private MultipleContext_PPC_T003 _MCTemp = new MultipleContext_PPC_T003();
        public MultipleContext_PPC_T003 MCTemp
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

        private MultipleContext_PPC_T003 _MCTemp1 = new MultipleContext_PPC_T003();
        public MultipleContext_PPC_T003 MCTemp1
        {
            get { return _MCTemp1; }
            set
            {
                if (_MCTemp1 != value)
                {
                    _MCTemp1 = value; RaisePropertyChanged("MCTemp1");
                }
            }
        }

        private MultipleContext_PPC_T003 _MT = new MultipleContext_PPC_T003();
        public MultipleContext_PPC_T003 MT
        {
            get { return _MT; }
            set
            {
                if (_MT != value)
                {
                    _MT = value; RaisePropertyChanged("MT");
                }
            }
        }

        private MultipleContext_PPC_T003 _Filters = new MultipleContext_PPC_T003();
        public MultipleContext_PPC_T003 Filters
        {
            get { return _Filters; }
            set
            {
                if (_Filters != value)
                {
                    _Filters = value; RaisePropertyChanged("Filters");
                }
            }
        }

        private MultipleContext_PPC_T003 _MCTemp5;
        public MultipleContext_PPC_T003 MCTemp5
        {
            get { return _MCTemp5; }
            set
            {
                if (_MCTemp5 != value)
                {
                    _MCTemp5 = value; RaisePropertyChanged("MCTemp5");
                }
            }
        }

        private PPC_T003 _MasterEntity;
        public PPC_T003 MasterEntity
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

        private string _PrintOption;
        public string PrintOption
        {
            get
            {
                return _PrintOption;
            }
            set
            {
                if (_PrintOption != value)
                {
                    _PrintOption = value;
                    RaisePropertyChanged("PrintOption");
                }
            }
        }

        private List<PPC_T003_BackFlip> _FlipGridData;
        public List<PPC_T003_BackFlip> FlipGridData
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

        private List<ADM_M042_P> _strListShift;
        public List<ADM_M042_P> StrListShift
        {
            get { return _strListShift; }
            set
            {
                if (_strListShift != value)
                {
                    _strListShift = value;
                    RaisePropertyChanged("StrListShift");
                }
            }
        }
        public List<ADM_M042_P> _ObjShift = new List<ADM_M042_P>();
        private List<ADM_M042_P> ObjShift
        {
            get { return _ObjShift; }
            set
            {
                if (_ObjShift != value)
                {
                    _ObjShift = value;
                }
            }
        }

        private Dictionary<string, object> _shiftDictionaryParent;
        public Dictionary<string, object> shiftDictionaryParent
        {
            get { return _shiftDictionaryParent; }
            set
            {
                if (_shiftDictionaryParent != value)
                {
                    _shiftDictionaryParent = value;
                    RaisePropertyChanged("shiftDictionaryParent");
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

        #region Collection

        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
        }

        private ICollectionView _machineCollection;
        public ICollectionView machineCollection
        {
            get { return _machineCollection; }
            set { _machineCollection = value; RaisePropertyChanged("machineCollection"); }
        }
        private ICollectionView _shiftCollection;
        public ICollectionView shiftCollection
        {
            get { return _shiftCollection; }
            set { _shiftCollection = value; RaisePropertyChanged("shiftCollection"); }
        }

        private ICollectionView _employeeCollection;
        public ICollectionView employeeCollection
        {
            get { return _employeeCollection; }
            set { _employeeCollection = value; RaisePropertyChanged("employeeCollection"); }
        }
        private ICollectionView _operatorCollection;
        public ICollectionView operatorCollection
        {
            get { return _operatorCollection; }
            set { _operatorCollection = value; RaisePropertyChanged("operatorCollection"); }
        }
        private ICollectionView _UOMCollection;// UOM Collection
        public ICollectionView UOMCollection
        {
            get { return _UOMCollection; }
            set
            {
                _UOMCollection = value;
                RaisePropertyChanged("UOMCollection");
            }
        }

        private ICollectionView _Ref_DocTypeCollection;
        public ICollectionView Ref_DocTypeCollection
        {
            get { return _Ref_DocTypeCollection; }
            set
            {
                _Ref_DocTypeCollection = value;
                RaisePropertyChanged("Ref_DocTypeCollection");
            }
        }

        private ICollectionView _Ref_DocNoCollection;
        public ICollectionView Ref_DocNoCollection
        {
            get { return _Ref_DocNoCollection; }
            set
            {
                _Ref_DocNoCollection = value;
                RaisePropertyChanged("Ref_DocNoCollection");
            }
        }

        private List<COM_T003> _AttachmentCollection;
        public List<COM_T003> AttachmentCollection
        {
            get { return _AttachmentCollection; }
            set { _AttachmentCollection = value; RaisePropertyChanged("AttachmentCollection"); }
        }



        #endregion

        #region StringList 

        private List<string> _strListmachine;
        public List<string> StringListmachine
        {
            get { return _strListmachine; }
            set
            {
                if (_strListmachine != value)
                {
                    _strListmachine = value;
                }
            }
        }
        private List<string> _strListshift;
        public List<string> StringListshift
        {
            get { return _strListshift; }
            set
            {
                if (_strListshift != value)
                {
                    _strListshift = value;
                }
            }
        }

        private List<string> _strListemployee;
        public List<string> StringListemployee
        {
            get { return _strListemployee; }
            set
            {
                if (_strListemployee != value)
                {
                    _strListemployee = value;
                }
            }
        }
        private List<string> _strListoperator;
        public List<string> StringListoperator
        {
            get { return _strListoperator; }
            set
            {
                if (_strListoperator != value)
                {
                    _strListoperator = value;
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

        //private List<string> _StringListRefDocNo;
        //public List<string> StringListRefDocNo
        //{
        //    get { return _StringListRefDocNo; }
        //    set
        //    {
        //        if (_StringListRefDocNo != value)
        //        {
        //            _StringListRefDocNo = value;
        //        }
        //    }
        //}
        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> CommandMachine { get; private set; }
        public RelayCommand<object> CommandShift { get; private set; }
        public RelayCommand<object> CommandEmployee { get; private set; }
        public RelayCommand<object> CommandOperator { get; private set; }
        public RelayCommand<object> CmdAddUOM { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByByDocumentNumber { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand CmdForLoadLabel { get; private set; }
        public RelayCommand<object> CMDInsertRef_DocType { get; private set; }
        public RelayCommand<object> CMDInsertDocNo { get; private set; }
        public RelayCommand<object> CMDLoadData { get; private set; }
        public RelayCommand<object> CMDInsertBarcode { get; private set; }
        public RelayCommand<object> CmdInsert_t_status { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand CMdloadfromfilter { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> CmdInsertGrade { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for ViewModel
        /// </summary>
        /// <param name="NA"></param>
        public PPC_T003VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new PPC_T003();
            FlipGridData = new List<PPC_T003_BackFlip>();
            MC = new MultipleContext_PPC_T003();
            MCTemp = new MultipleContext_PPC_T003();
            MCTemp1 = new MultipleContext_PPC_T003();
            MCTemp5 = new MultipleContext_PPC_T003();
            MT = new MultipleContext_PPC_T003();
            MasterEntity.ValidateAsync().Wait();
            PPC_T003.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            MasterEntity.active = true;
            
            LoadInitialData();

            //if (AppSessionState.TransValue != null && AppSessionState.TransactionCode == MC.DocTypeInfo[0].TranCode)
            //{
            //    LoadDocumentByDocumentNumber(AppSessionState.TransValue, "DocumentNo");
            //    isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
            //    AppSessionState.TransValue = null;
            //    AppSessionState.TransId = null;
            //    AppSessionState.TransParameter = null;
            //    AppSessionState.ViewOtherRecordAllowed = true;
            //}
        }
        public PPC_T003VM(string ts_code,string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new PPC_T003();
            FlipGridData = new List<PPC_T003_BackFlip>();
            MC = new MultipleContext_PPC_T003();
            MCTemp = new MultipleContext_PPC_T003();
            MCTemp1 = new MultipleContext_PPC_T003();
            MCTemp5 = new MultipleContext_PPC_T003();
            MT = new MultipleContext_PPC_T003();
            MasterEntity.ValidateAsync().Wait();
            PPC_T003.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            MasterEntity.active = true;


            LoadInitialData();
        }
        #endregion

        #region Relay Command Actions ·
        private void InsertMachine(object InputValue)
        {
            try
            {
                string Request = "";
                EPR_T001_P POPUPEntityObject = null;
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.MachineMaster.Where(x => x.machinecode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<EPR_T001_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<EPR_T001_P>().ToList()[0];
                    }
                }


                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.machine_id = POPUPEntityObject.machine_id;
                    MasterEntity.machinecode = POPUPEntityObject.machinecode;
                    //MasterEntity.ItemCode = POPUPEntityObject.ItemCode;
                    //MasterEntity.shift1 = POPUPEntityObject.shift;
                    //MasterEntity.ItemName = POPUPEntityObject.ItemName;
                    //MasterEntity.order_no = POPUPEntityObject.order_no;
                    //MasterEntity.unit_code = POPUPEntityObject.Unit_Code;
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
                    MasterEntity.shift1 = POPUPEntityObject.shift;
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
        private void InsertUOM(object InputValue)
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
                        { POPUPEntityObject = MC.UOMList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null)
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
        private void InsertEmployee(object InputValue)
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
                        { POPUPEntityObject = MC.EmployeeMaster.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    MasterEntity.shift_incharge = POPUPEntityObject.EmpId;
                    MasterEntity.EmpName = POPUPEntityObject.EmpName;

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
                        { POPUPEntityObject = MC.EmployeeMaster.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    MasterEntity.m_operator = POPUPEntityObject.EmpId;
                    MasterEntity.operatornm = POPUPEntityObject.EmpName;

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
                PPC_T003_BackFlip ParameterEntityObject = null;

                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null)
                {
                    Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + ParameterObject;
                    isNewRecord = false;
                    MasterEntity = new PPC_T003();
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_PPC_T003>(MCTemp, Request, "UltrasonicCleaning", "Production", "LoadDocumentWithReferenceDocumentNumber", 0, "");
                    MasterEntity = MCTemp.MasterEntity[0];

                    AttachmentCollection = MCTemp.AttachmentData;
                    if (MCTemp.AttachmentData != null)
                    {
                        AttachmentCollection = MCTemp.AttachmentData;
                    }
                    else
                    {
                        MCTemp.AttachmentData = new List<COM_T003>();
                    }
                    SelectedTabControlIndex = 0;
                    DefaultRefDocType();
                }
                else if (((IEnumerable)ParameterObject).Cast<PPC_T003_BackFlip>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<PPC_T003_BackFlip>().ToList()[0];
                    Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + ParameterEntityObject.doc_no;
                    isNewRecord = false;
                    MasterEntity = new PPC_T003();
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_PPC_T003>(MCTemp, Request, "UltrasonicCleaning", "Production", "LoadDocumentWithReferenceDocumentNumber", 0, "");
                    MasterEntity = MCTemp.MasterEntity[0];

                    AttachmentCollection = MCTemp.AttachmentData;
                    if (MCTemp.AttachmentData != null)
                    {
                        AttachmentCollection = MCTemp.AttachmentData;
                    }
                    else
                    {
                        MCTemp.AttachmentData = new List<COM_T003>();
                    }
                    SelectedTabControlIndex = 0;
                    DefaultRefDocType();
                    MasterEntity.ts_code = ts_code_vm;
                }
                SetPopupSuggestionDataAfterLoad();
                MasterEntity.ts_code = ts_code_vm;
                var msg = new NotificationMessage("PPC_T003VM");
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
        private void SetPopupSuggestionDataAfterLoad()
        {
            ASShift_Incharge.AutoSuggestVM.Suggestion = MC.EmployeeMaster.Find(x => x.EmpId == MasterEntity.shift_incharge);
            AS_M_operator.AutoSuggestVM.Suggestion = MC.EmployeeMaster.Find(x => x.EmpId == MasterEntity.m_operator);
            AS_ShiftNo.AutoSuggestVM.Suggestion = MC.ShiftMaster.Find(x => x.shift == MasterEntity.shift1);
            AS_Unit.AutoSuggestVM.Suggestion = MC.UOMList.Find(a => a.unit_code == MasterEntity.unit_code);

        }
        private void Labeleport()
        {
            try
            {

                string Request = "LoadInitialData" + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_no;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PPC_T003>(MC, Request, "UltrasonicCleaning", "Production", "LoadInitialData", 0, "");

                object[] objDataSource = new object[3];
                string[] objDataSourceName = new string[3];

                objDataSource[0] = MC.RptUltraLabelList;
                objDataSourceName[0] = "dsUltarLabelGen";

                ReportManager ReportManager = new ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\UltrasonicLabel.rdlc", "UltrasonicLabel");

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
        private void Insert_RefDocType(object InputValue)
        {
            try
            {
                string Request = "";
                SYS_M013_P POPUPEntityObject = null;
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Ref_DocTypeData.Where(x => x.doc_desc_user.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<SYS_M013_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M013_P>().ToList()[0];
                    }
                }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.ref_Doc_TypeNm = POPUPEntityObject.doc_desc_user;
                    MasterEntity.ref_doc_type = POPUPEntityObject.doc_type_user;

                    if (MasterEntity.ref_doc_type == "CN")
                    {

                        var abc = (from o in MC.Ref_DocNoData where o.doc_type == "CN" select o).ToList();
                        Ref_DocNoCollection = CollectionViewSource.GetDefaultView(abc);
                        Ref_DocNoCollection.Filter = new Predicate<object>(Filter_RefDocNo);
                        //StringListRefDocNo = abc.Select(x => x.batch_no).ToList();
                    }
                    else 
                    {
                        var abc = (from o in MC.Ref_DocNoData where o.doc_type == "PC" select o).ToList();
                        Ref_DocNoCollection = CollectionViewSource.GetDefaultView(abc);
                        Ref_DocNoCollection.Filter = new Predicate<object>(Filter_RefDocNo);
                        //   StringListRefDocNo = abc.Select(x => x.batch_no).ToList();
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
        private void Insert_RefDocNo(object InputValue)
        {
            try
            {
                string Request = "";
                Ref_Doc_no POPUPEntityObject = null;
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Ref_DocNoData.Where(x => x.order_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<Ref_Doc_no>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<Ref_Doc_no>().ToList()[0];
                    }
                }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.ref_doc_no = POPUPEntityObject.RefDocNo;
                    MasterEntity.barcode = POPUPEntityObject.barcode;
                    MasterEntity.order_no = POPUPEntityObject.conversion_no;
                    MasterEntity.machine_id = POPUPEntityObject.machine_id;
                    MasterEntity.machinecode = POPUPEntityObject.machinecode;
                    MasterEntity.wc_code = POPUPEntityObject.wc_code;
                    MasterEntity.ItemCode = POPUPEntityObject.ItemCode;
                    MasterEntity.ItemName = POPUPEntityObject.ItemName;
                    MasterEntity.shift1 = POPUPEntityObject.shift;
                    MasterEntity.unit_code = POPUPEntityObject.unit_code;
                    MasterEntity.prod_date = POPUPEntityObject.prod_date;
                    MasterEntity.counter_q = POPUPEntityObject.counter_q;
                    MasterEntity.shift_incharge = POPUPEntityObject.shift_incharge;
                    MasterEntity.m_operator = POPUPEntityObject.m_operator;
                    MasterEntity.EmpName = POPUPEntityObject.EmpName;
                    MasterEntity.operatornm = POPUPEntityObject.operatornm;
                    MasterEntity.t_status = POPUPEntityObject.t_status;
                    MasterEntity.t_display = POPUPEntityObject.t_display;
                    MasterEntity.remarks = POPUPEntityObject.remarks;
                    MasterEntity.remark1 = POPUPEntityObject.remark1;
                    MasterEntity.remark2 = POPUPEntityObject.remark2;
                    MasterEntity.active = POPUPEntityObject.active;
                    MasterEntity.doc_date = POPUPEntityObject.doc_date;
                    MasterEntity.clean_date = POPUPEntityObject.clean_date;
                    MasterEntity.sample_qty = POPUPEntityObject.sample_qty;
                    MasterEntity.excess_qty = POPUPEntityObject.excess_qty;
                    MasterEntity.rejection_q = POPUPEntityObject.rejection_q;
                    MasterEntity.grade = POPUPEntityObject.grade;
                    MasterEntity.quantity = POPUPEntityObject.quantity;
                    MasterEntity.counter_remark = POPUPEntityObject.counter_remark;

                }
                var msg = new NotificationMessage("PPC_T003VM");
                Messenger.Default.Send<NotificationMessage>(msg);
            }
            catch (Exception ex)
            { }
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
                    MC.Ref_DocNoData.Remove(MC.Ref_DocNoData.Single(s => s.barcode == MasterEntity.barcode));
                }
            }
            catch (Exception ex)
            {
            }

        }

        #endregion

        #region Abstract Command Actions
        private IEnumerable<T> MakeMeEnumerable<T>(T Entity)
        {
            yield return Entity;
        }
        protected override void OnSaveAction(InquiryActionResult<PPC_T003> result)
        {
            try
            {

                if (Validation() == true)
                {
                    this.MasterEntity.EndEdit();
                    MasterEntity.editby = AppSessionState.UserID;
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<PPC_T003>(MasterEntity, "UltrasonicCleaning", "Production");
                        isNewRecord = false;
                        RemoveReferenceDocuments();
                        if (MasterEntity.doc_no != " " || MasterEntity.doc_no != null)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Data Saved Successfully");
                            showMessageService.ShowMessage();
                        }
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<PPC_T003>(MasterEntity, "UltrasonicCleaning", "Production");
                        if (MasterEntity.doc_no != " " || MasterEntity.doc_no != null)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Data Update Successfully");
                            showMessageService.ShowMessage();
                        }
                    }
                    SetBackFlipEntitiesAfterLoad();

                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message);
                showMessageService.ShowMessage();
            }
            DefaultRefDocType();
        }
        protected override void OnCreateAction(InquiryActionResult<PPC_T003> result)
        {
            isNewRecord = true;
            MasterEntity = new PPC_T003();
            MasterEntity.active = true;
            MasterEntity.ValidateAsync().Wait();
            DefaultRefDocType();
            DefaultValues();

            var msg = new NotificationMessage("PPC_T003VM");
            Messenger.Default.Send<NotificationMessage>(msg);
        }
        protected override void OnRemoveAction(InquiryActionResult<PPC_T003> result)
        {
            try
            {
                if (MasterEntity.doc_no != null)
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
                        string response = repository.Delete(MasterEntity.doc_no, "UltrasonicCleaning", "Production");

                        MasterEntity = new PPC_T003();
                        DefaultRefDocType();
                        FlipDataGridCollection.Refresh();
                        isNewRecord = true;
                    }
                    DefaultValues();
                }
            }
            catch (Exception ex)
            { }
        }
        protected override void OnDiscardAction(InquiryActionResult<PPC_T003> result)
        {
            //SelectedSEL_T001.CancelEdit();   
            DefaultRefDocType();
        }
        protected override void OnFevoriteAction(InquiryActionResult<PPC_T003> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<PPC_T003> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<PPC_T003> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<PPC_T003> result)
        { }
        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.doc_no))
            {
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), DocumentList = MCTemp.AttachmentData, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.comp_code) });
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<PPC_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<PPC_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<PPC_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<PPC_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<PPC_T003> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Event Handler
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            //this.ErrorExist = MasterEntity.HasErrors;
            if (sender.ToString() == "counter_q" || sender.ToString() == "rejection_q" || sender.ToString() == "excess_qty")
            {
                cal();
            }
        }


        #endregion

        #region User Defined Functions
        private void LoadfromFilters()
        {
            try
            {
                if (Validation1() == true)
                {
                   
                    string RequestParameter = "LoadFromFilters" + "!@" + MasterEntity.EmpId1 + "!@" + MasterEntity.qc_person1 + "!@" + MasterEntity.Fromdt.ToString() + "!@" + MasterEntity.Todt.ToString() + "!@" + MasterEntity.con_no + "!@" + MasterEntity.sshift + "!@" + MasterEntity.machine + "!@" + MasterEntity.item + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code;
                    Filters = repository_Filters.GetDataWithReturnDomainObject<MultipleContext_PPC_T003>(Filters, RequestParameter, "UltrasonicCleaning", "Production", "LoadInitialData", 0, "");

                    FlipGridData = Filters.BackFlipEntity.ToList();
                    FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                    FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);
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
        private void LoadInitialData()
        {
            try
            {
                MasterEntity.ref_Doc_TypeNm = "Production Counter Entry";
                MasterEntity.ref_doc_type = "PC";
                MasterEntity.doc_type = "UC";
                MasterEntity.doc_cat = "UC";
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PPC_T003>(MC, Request, "UltrasonicCleaning", "Production", "LoadInitialData", 0, "");

                #region Command Initialisation
                CommandMachine = new RelayCommand<object>(items => { if (items == null) { return; } InsertMachine(items); });
                CommandShift = new RelayCommand<object>(items => { if (items == null) { return; } InsertShift(items); });
                CommandEmployee = new RelayCommand<object>(items => { if (items == null) { return; } InsertEmployee(items); });
                CommandOperator = new RelayCommand<object>(items => { if (items == null) { return; } InsertOperator(items); });
                CmdAddUOM = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUOM(cmdPara); });
                CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); }); // confirm assignment
                CmdForLoadLabel = new GalaSoft.MvvmLight.Command.RelayCommand(() => { Labeleport(); });
                CMDInsertRef_DocType = new RelayCommand<object>(items => { if (items == null) { return; } Insert_RefDocType(items); });
                CMDInsertDocNo = new RelayCommand<object>(items => { if (items == null) { return; } Insert_RefDocNo(items); });
                CMDLoadData = new RelayCommand<object>(items => { if (items == null) { return; } LoadData(); });
                CMDInsertBarcode = new RelayCommand<object>(items => { if (items == null) { return; } InsertBarcodeDetails(items); });
                CMdloadfromfilter = new GalaSoft.MvvmLight.Command.RelayCommand(() => { LoadfromFilters(); });
                CmdInsert_t_status = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Insert_t_status(cmdPara); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                CmdInsertGrade = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertGrade(cmdPara); });
                #endregion
                #region AutoSuggest Initialisation
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpName ?? "").ToLower().Contains(prefix.ToLower());
                ASShift_Incharge = new AutoSuggestTextViewModel<dynamic>(MC.EmployeeMaster, TheFilter, SuggestedValue, "EmpId", true);
                ASShift_Incharge.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpName ?? "").ToLower().Contains(prefix.ToLower());
                ASEmp = new AutoSuggestTextViewModel<dynamic>(MC.EmployeeMaster, TheFilter, SuggestedValue, "EmpId", true);
                ASEmp.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpName ?? "").ToLower().Contains(prefix.ToLower());
                AS_M_operator = new AutoSuggestTextViewModel<dynamic>(MC.EmployeeMaster, TheFilter, SuggestedValue, "EmpId", true);
                AS_M_operator.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpName ?? "").ToLower().Contains(prefix.ToLower());
                ASqcperson = new AutoSuggestTextViewModel<dynamic>(MC.EmployeeMaster, TheFilter, SuggestedValue, "EmpId", true);
                ASqcperson.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M042_P)x).shift);
                TheFilter = (o, prefix) => (((ADM_M042_P)o).shift ?? "").ToLower().Contains(prefix.ToLower());
                AS_ShiftNo = new AutoSuggestTextViewModel<dynamic>(MC.ShiftMaster, TheFilter, SuggestedValue, "shift1", "shift", true);
                AS_ShiftNo.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M042_P)x).shift);
                TheFilter = (o, prefix) => (((ADM_M042_P)o).shift ?? "").ToLower().Contains(prefix.ToLower());
                ASShift = new AutoSuggestTextViewModel<dynamic>(MC.ShiftMaster, TheFilter, SuggestedValue, "shift1", "shift", true);
                ASShift.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToLower());
                AS_Unit = new AutoSuggestTextViewModel<dynamic>(MC.UOMList, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                AS_Unit.AutoSuggestVM.IsEmptyValueAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_display);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASt_status = new AutoSuggestTextViewModel<dynamic>(MC.t_statusList, TheFilter, SuggestedValue, "t_display", true);
                ASt_status.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M030_P)x).parametervalue);
                TheFilter = (o, prefix) => (((ADM_M030_P)o).value_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M030_P)o).parametervalue ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASGrade = new AutoSuggestTextViewModel<dynamic>(MC.GradeList, TheFilter, SuggestedValue, "parametervalue", true);
                ASGrade.AutoSuggestVM.IsEmptyValueAllowed = true;
                #endregion

                FlipGridData = MC.BackFlipEntity.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);

                Ref_DocTypeCollection = CollectionViewSource.GetDefaultView(MC.Ref_DocTypeData);
                Ref_DocTypeCollection.Filter = new Predicate<object>(Filter_Ref_DocType);
                StringListRefDocType = MC.Ref_DocTypeData.Select(x => x.doc_desc_user).ToList();

                var abc1 = (from o in MC.Ref_DocNoData where o.doc_type == "PC" select o).ToList();
                Ref_DocNoCollection = CollectionViewSource.GetDefaultView(abc1);
                Ref_DocNoCollection.Filter = new Predicate<object>(Filter_RefDocNo);

                //machineCollection = CollectionViewSource.GetDefaultView(MC.MachineMaster.ToList());
                //machineCollection.Filter = new Predicate<object>(Filter_Machine);
                //StringListmachine = MC.MachineMaster.Select(x => x.machinecode).ToList();

                //shiftCollection = CollectionViewSource.GetDefaultView(MC.ShiftMaster.ToList());
                //shiftCollection.Filter = new Predicate<object>(Filter_Shift);
                //StringListshift = MC.ShiftMaster.Select(x => x.shift).ToList();

                //UOMCollection = CollectionViewSource.GetDefaultView(MC.UOMList);
                //UOMCollection.Filter = new Predicate<object>(UOMFilter);
                //StringListUOM = MC.UOMList.Select(x => x.unit_code.ToString()).ToList();

                //employeeCollection = CollectionViewSource.GetDefaultView(MC.EmployeeMaster.ToList());
                //employeeCollection.Filter = new Predicate<object>(Filter_Employee);
                //StringListemployee = MC.EmployeeMaster.Select(x => x.EmpId).ToList();

                //operatorCollection = CollectionViewSource.GetDefaultView(MC.EmployeeMaster.ToList());
                //operatorCollection.Filter = new Predicate<object>(Filter_Operator);
                //StringListoperator = MC.EmployeeMaster.Select(x => x.EmpId).ToList();

                DefaultValues();
            }
            catch (Exception ex)
            { }
        }
        private void LoadData()
        {
            try
            {

                if (MasterEntity.ref_doc_no == "" || MasterEntity.ref_doc_no == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Please Select Ref Doc No");
                    showMessageService.ShowMessage();
                }
                else
                {
                    string Request = "LoadData" + "!@" + MasterEntity.ref_doc_no;
                    MT = repository_MT.GetDataWithReturnDomainObject<MultipleContext_PPC_T003>(MT, Request, "UltrasonicCleaning", "Production", "", 0, "");

                    if (MT.MasterEntity.Count > 0)
                    {
                        MasterEntity = MT.MasterEntity[0];
                        DefaultRefDocType();
                    }
                }
            }
            catch (Exception ex)
            { }

        }
        private void DefaultRefDocType()
        {
            MasterEntity.ref_Doc_TypeNm = "Production Counter Entry";
            MasterEntity.ref_doc_type = "PC";
            var abc1 = (from o in MC.Ref_DocNoData where o.doc_type == "PC" select o).ToList();
            Ref_DocNoCollection = CollectionViewSource.GetDefaultView(abc1);
            Ref_DocNoCollection.Filter = new Predicate<object>(Filter_RefDocNo);
            //StringListRefDocNo = abc.Select(x => x.batch_no).ToList();
        }
        private void DefaultValues()
        {

            // MasterEntity.doc_no = "";
            MasterEntity.doc_type = "UC";
            MasterEntity.doc_cat = "UC";
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.location_Id = AppSessionState.location_Id;

            MasterEntity.doc_date = System.DateTime.Now;
            MasterEntity.clean_date = System.DateTime.Now;
            MasterEntity.active = true;
            MasterEntity.t_status = "001";
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;

        }
        private bool Validation()
        {
            try
            {

                if (MasterEntity.machinecode == null || MasterEntity.machinecode == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Machine Is Required", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.shift1 == null || MasterEntity.shift1 == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Shift Is Required", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.doc_date == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Document Date Is Required", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.clean_date == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Clean Date Is Required", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.ItemCode == null || MasterEntity.ItemCode == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Please Load Record From Reference Doc No", this.Title);
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
        private void InsertBarcodeDetails(object InputValue)
        {
            try
            { 
                string Request = "";
                Ref_Doc_no POPUPEntityObject = null;
                barcode = InputValue.ToString();
                #region Command Parameter Read Section
                if (barcode.Length >= 10)
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length >= 10)
                        {
                            var InputValueIfExists = MC.Ref_DocNoData.Where(X => X.RefDocNo == Request).FirstOrDefault();//Checking Weather Barcode is Valid or Not By Checking in Business Entity                
                            if (InputValueIfExists != null)
                            {
                                POPUPEntityObject = MC.Ref_DocNoData.Where(x => (x.RefDocNo ?? "").Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; //If Barcode is Valid Get All the Information in PopupEntityObject
                                MasterEntity.barcode = POPUPEntityObject.barcode;
                                MasterEntity.order_no = POPUPEntityObject.conversion_no;
                                MasterEntity.machine_id = POPUPEntityObject.machine_id;
                                MasterEntity.machinecode = POPUPEntityObject.machinecode;
                                MasterEntity.wc_code = POPUPEntityObject.wc_code;
                                MasterEntity.ItemCode = POPUPEntityObject.ItemCode;
                                MasterEntity.ItemName = POPUPEntityObject.ItemName;
                                MasterEntity.shift1 = POPUPEntityObject.shift;
                                MasterEntity.unit_code = POPUPEntityObject.unit_code;
                                MasterEntity.prod_date = POPUPEntityObject.prod_date;
                                MasterEntity.counter_q = POPUPEntityObject.counter_q;
                                MasterEntity.shift_incharge = POPUPEntityObject.shift_incharge;
                                MasterEntity.m_operator = POPUPEntityObject.m_operator;
                                MasterEntity.EmpName = POPUPEntityObject.EmpName;
                                MasterEntity.operatornm = POPUPEntityObject.operatornm;
                                MasterEntity.t_status = POPUPEntityObject.t_status;
                                MasterEntity.t_display = POPUPEntityObject.t_display;
                                MasterEntity.remarks = POPUPEntityObject.remarks;
                                MasterEntity.remark1 = POPUPEntityObject.remark1;
                                MasterEntity.remark2 = POPUPEntityObject.remark2;
                                MasterEntity.active = POPUPEntityObject.active;
                                MasterEntity.doc_date = POPUPEntityObject.doc_date;
                                MasterEntity.clean_date = POPUPEntityObject.clean_date;
                                MasterEntity.sample_qty = POPUPEntityObject.sample_qty;
                                MasterEntity.excess_qty = POPUPEntityObject.excess_qty;
                                MasterEntity.rejection_q = POPUPEntityObject.rejection_q;
                                MasterEntity.grade = POPUPEntityObject.grade;
                                MasterEntity.quantity = POPUPEntityObject.quantity;
                                MasterEntity.counter_remark = POPUPEntityObject.counter_remark;
                            }
                            else
                            {
                                IShowMessageViewService ShowMessage1 = this.GetViewService<IShowMessageViewService>();
                                ShowMessage1.ButtonSetup = DialogButton.Ok;
                                ShowMessage1.Caption = "Message";
                                ShowMessage1.Text = String.Format("Entered Barcode is Used.\n Press OK To Re-Scan Barcode OR Press Cancel To Cancel Re-Scan");
                                //ShowMessage1.ShowMessage();       
                                if (ShowMessage1.ShowMessage() == DialogResult.Ok)
                                {
                                    string Request1 = "RescanBarcode" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + Request;
                                    MCTemp5 = repository_MCTemp5.GetDataWithReturnDomainObject<MultipleContext_PPC_T003>(MCTemp5, Request1, "UltrasonicCleaning", "Production", "LoadInitialData", 0, "");

                                    if (MCTemp5.RescanBarcode != null)
                                    {
                                        if (MCTemp5.RescanBarcode.Count > 0)
                                        {
                                            MasterEntity = MCTemp5.RescanBarcode[0];
                                            DefaultValues();
                                            MasterEntity.t_status = "021";
                                        }
                                        else
                                        {
                                            ShowMessage1.ButtonSetup = DialogButton.OkCancel;
                                            ShowMessage1.Caption = "Message";
                                            ShowMessage1.Text = String.Format("Entered Barcode is Invalid", this.Title);
                                            ShowMessage1.ShowMessage();
                                        }
                                    }
                                    else
                                    {
                                        ShowMessage1.ButtonSetup = DialogButton.OkCancel;
                                        ShowMessage1.Caption = "Message";
                                        ShowMessage1.Text = String.Format("Entered Barcode is Invalid", this.Title);
                                        ShowMessage1.ShowMessage();
                                    }
                                }
                            }
                            MasterEntity.ref_doc_no = "";
                        }
                    }
                }
                var msg = new NotificationMessage("PPC_T003VM");
                Messenger.Default.Send<NotificationMessage>(msg);
            }
            #endregion

            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        private void SetBackFlipEntitiesAfterLoad()
        {
            try
            {
                if (MasterEntity.XmlDataDocument_FlipGrid != null)
                {
                    MC.BackFlipEntity = (List<PPC_T003_BackFlip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.BackFlipEntity);
                    FlipGridData.Add(MC.BackFlipEntity[0]);
                    FlipDataGridCollection.Refresh();
                    FlipDataGridCollection.SortDescriptions.Add(new SortDescription("doc_no", ListSortDirection.Descending));
                    MasterEntity.ts_code = ts_code_vm;
                }
                else
                {
                    MC.BackFlipEntity = new List<PPC_T003_BackFlip>();
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message);
                showMessageService.ShowMessage();
            }
        }
        private void cal()
        {
            try
            {
                decimal? counter_q = 0;
                decimal? excess_qty = 0;
                decimal? rejection_q = 0;
                decimal? sample_qty = 0;

                if (MasterEntity.counter_q != null && MasterEntity.counter_q != 0)
                {
                    if (MasterEntity.excess_qty != null && MasterEntity.excess_qty != 0)
                    {
                        MasterEntity.quantity = ((Convert.ToDecimal(MasterEntity.counter_q) + Convert.ToDecimal(MasterEntity.excess_qty)) - Convert.ToDecimal(MasterEntity.rejection_q));
                    }
                }
            }
            catch (Exception ex)
            { }

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
            var data = obj as PPC_T003_BackFlip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_FlipGrid))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
                }
                return true;
            }
            return false;
        }

        // Machine
        private string _filterString_Machine;
        public string FilterString_Machine
        {
            get { return _filterString_Machine; }
            set
            {
                _filterString_Machine = value;
                RaisePropertyChanged("FilterString_Machine");
                FilterCollection_Machine();
            }
        }
        private void FilterCollection_Machine()
        {
            if (_machineCollection != null)
            {
                _machineCollection.Refresh();
            }
        }
        public bool Filter_Machine(object obj)
        {
            var data = obj as EPR_T001_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_Machine))
                {
                    return (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(FilterString_Machine.ToLower())); //||
                                                                                                                                         // (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||

                }
                return true;
            }
            return false;
        }

        //Shift
        private string _filterString_Shift;
        public string FilterString_Shift
        {
            get { return _filterString_Shift; }
            set
            {
                _filterString_Shift = value;
                RaisePropertyChanged("FilterString_Shift");
                FilterCollection_Shift();
            }
        }
        private void FilterCollection_Shift()
        {
            if (_shiftCollection != null)
            {
                _shiftCollection.Refresh();
            }
        }
        public bool Filter_Shift(object obj)
        {
            var data = obj as ADM_M042_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_Shift))
                {
                    return (data.shift != null && data.shift.ToString().ToLower().Contains(FilterString_Shift.ToLower())); //||
                                                                                                                           // (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||

                }
                return true;
            }
            return false;
        }

        //UOM
        private string _filterStringUOM;
        public string FilterStringUOM
        {
            get { return _filterStringUOM; }
            set
            {
                _filterStringUOM = value;
                RaisePropertyChanged("FilterStringUOM");
                FilterCollectionUOM();
            }
        }
        private void FilterCollectionUOM()
        {
            if (_UOMCollection != null)
            {
                _UOMCollection.Refresh();
            }
        }
        public bool UOMFilter(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringUOM))
                {
                    return ((data.unit_code != null) && data.unit_code.ToLower().Contains(_filterStringUOM.ToLower()));
                }
                return true;
            }
            return false;
        }

        //Shift Incharge
        private string _filterString_Employee;
        public string FilterString_Employee
        {
            get { return _filterString_Employee; }
            set
            {
                _filterString_Employee = value;
                RaisePropertyChanged("FilterString_Employee");
                FilterCollection_Employee();
            }
        }
        private void FilterCollection_Employee()
        {
            if (_employeeCollection != null)
            {
                _employeeCollection.Refresh();
            }
        }
        public bool Filter_Employee(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Employee))
                {
                    return (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_filterString_Employee.ToLower()) ||
                         data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterString_Employee.ToLower())
                );
                }
                return true;
            }
            return false;
        }

        //operator
        private string _filterString_Operator;
        public string FilterString_Operator
        {
            get { return _filterString_Operator; }
            set
            {
                _filterString_Operator = value;
                RaisePropertyChanged("FilterString_Operator");
                FilterCollection_Operator();
            }
        }
        private void FilterCollection_Operator()
        {
            if (_operatorCollection != null)
            {
                _operatorCollection.Refresh();
            }
        }
        public bool Filter_Operator(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Operator))
                {
                    return (data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterString_Operator.ToLower())) ||
                           (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_filterString_Operator.ToLower()));

                }
                return true;
            }
            return false;
        }

        // Ref Doc Type
        private string _FilterStringRefDocType;
        public string FilterStringRefDocType
        {
            get { return _FilterStringRefDocType; }
            set
            {
                _FilterStringRefDocType = value;
                RaisePropertyChanged("FilterStringRefDocType");
                Filter_Ref_DocTypeCollection();
            }
        }
        private void Filter_Ref_DocTypeCollection()
        {
            if (_Ref_DocTypeCollection != null)
            {
                _Ref_DocTypeCollection.Refresh();
            }
        }
        public bool Filter_Ref_DocType(object obj)
        {
            var data = obj as SYS_M013_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringRefDocType))
                {
                    return (data.doc_desc_user != null && data.doc_desc_user.ToString().ToLower().Contains(_FilterStringRefDocType.ToLower())) ||
                           (data.doc_type_user != null && data.doc_type_user.ToString().ToLower().Contains(_FilterStringRefDocType.ToLower()));

                }
                return true;
            }
            return false;
        }

        //Ref Doc No
        private string _FilterStringRefDocNo;
        public string FilterStringRefDocNo
        {
            get { return _FilterStringRefDocNo; }
            set
            {
                _FilterStringRefDocNo = value;
                RaisePropertyChanged("FilterStringRefDocNo");
                Filter_Ref_DocNoCollection();
            }
        }
        private void Filter_Ref_DocNoCollection()
        {
            if (_Ref_DocNoCollection != null)
            {
                _Ref_DocNoCollection.Refresh();
            }
        }
        public bool Filter_RefDocNo(object obj)
        {
            var data = obj as Ref_Doc_no;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringRefDocNo))
                {
                    return (data.batch_no != null && data.batch_no.ToString().ToLower().Contains(_FilterStringRefDocNo.ToLower())) ||
                           (data.order_no != null && data.order_no.ToString().ToLower().Contains(_FilterStringRefDocNo.ToLower())) ||
                           (data.prod_date != null && data.prod_date.ToString().ToLower().Contains(_FilterStringRefDocNo.ToLower())) ||
                          (data.conversion_no != null && data.conversion_no.ToString().ToLower().Contains(_FilterStringRefDocNo.ToLower())) ||
                          (data.doc_type != null && data.doc_type.ToString().ToLower().Contains(_FilterStringRefDocNo.ToLower())) ||
                          (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_FilterStringRefDocNo.ToLower())) ||
                          (data.shift != null && data.shift.ToString().ToLower().Contains(_FilterStringRefDocNo.ToLower())) ||
                          (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_FilterStringRefDocNo.ToLower())) ||
                          (data.ball_make != null && data.ball_make.ToString().ToLower().Contains(_FilterStringRefDocNo.ToLower())) ||
                          (data.wire_make != null && data.wire_make.ToString().ToLower().Contains(_FilterStringRefDocNo.ToLower())) ||
                          (data.ink != null && data.ink.ToString().ToLower().Contains(_FilterStringRefDocNo.ToLower())) ||
                          (data.RefDocNo != null && data.RefDocNo.ToString().ToLower().Contains(_FilterStringRefDocNo.ToLower())) ||
                          (data.ild != null && data.ild.ToString().ToLower().Contains(_FilterStringRefDocNo.ToLower()));

                }
                return true;
            }
            return false;
        }

        
        #endregion
    }
}
