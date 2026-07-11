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
using Reflection.BusinessEntity.CustomerRelation;
using Reflection.BusinessEntity.Production;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.Production.ViewModels
{
    class ZCRM_T003_VM : WorkspaceViewModel<ZCRM_T003>
    {
        #region AutoSuggestTextBox Decleration Region
        
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
                    if (SourceName == "parameters")
                    { ASDefault = AS_Parameter; }
                    else if (SourceName == "dfctcda")
                    { ASDefault = AS_Defect; }

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

        private AutoSuggestTextViewModel<dynamic> _AS_RefDocType { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_RefDocType
        {
            get { return _AS_RefDocType; }
            set
            {
                if (_AS_RefDocType != value)
                {
                    _AS_RefDocType = value; RaisePropertyChanged("AS_RefDocType");
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

        private AutoSuggestTextViewModel<dynamic> _AS_Employee { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Employee
        {
            get { return _AS_Employee; }
            set
            {
                if (_AS_Employee != value)
                {
                    _AS_Employee = value; RaisePropertyChanged("AS_Employee");
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
        bool isNewRecord = true;

        WebServiceRepository<ZCRM_T003> repository = new WebServiceRepository<ZCRM_T003>();
        WebServiceRepository<MultipleContext_ZCRM_T003> repository_MC = new WebServiceRepository<MultipleContext_ZCRM_T003>();
        WebServiceRepository<MultipleContext_ZCRM_T003> repository_MCTemp = new WebServiceRepository<MultipleContext_ZCRM_T003>();
        WebServiceRepository<MultipleContext_ZCRM_T003> repository_MCTemp4 = new WebServiceRepository<MultipleContext_ZCRM_T003>();
        WebServiceRepository<MultipleContext_ZCRM_T003> repository_MCTemp1 = new WebServiceRepository<MultipleContext_ZCRM_T003>();
        ObjectSerializationService obj = new ObjectSerializationService();

        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
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

        private MultipleContext_ZCRM_T003 _MC = new MultipleContext_ZCRM_T003();
        public MultipleContext_ZCRM_T003 MC
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

        private MultipleContext_ZCRM_T003 _MCTemp = new MultipleContext_ZCRM_T003();
        public MultipleContext_ZCRM_T003 MCTemp
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

        private MultipleContext_ZCRM_T003 _MCTemp1 = new MultipleContext_ZCRM_T003();
        public MultipleContext_ZCRM_T003 MCTemp1
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

        private MultipleContext_ZCRM_T003 _MCTemp4 = new MultipleContext_ZCRM_T003();
        public MultipleContext_ZCRM_T003 MCTemp4
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

        private ZCRM_T003 _MasterEntity;
        public ZCRM_T003 MasterEntity
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

        private ObservableCollection<ZCRM_T003_A> _DefectEntity;
        public ObservableCollection<ZCRM_T003_A> DefectEntity
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

        private ObservableCollection<ZCRM_T003_Batch> _SODetails;
        public ObservableCollection<ZCRM_T003_Batch> SODetails
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

        private List<ZCRM_T003_BackFlip> _FlipGridData;
        public List<ZCRM_T003_BackFlip> FlipGridData
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

        private List<SYS_M013_P> _RefDocType;
        public List<SYS_M013_P> RefDocType
        {
            get { return _RefDocType; }
            set
            {
                if (_RefDocType != value)
                {
                    _RefDocType = value;
                    RaisePropertyChanged("RefDocType");
                }
            }
        }

        private List<ZCRM_T003_Batch> _BarcodeDetails;
        public List<ZCRM_T003_Batch> BarcodeDetails
        {
            get { return _BarcodeDetails; }
            set
            {
                if (_BarcodeDetails != value)
                {
                    _BarcodeDetails = value;
                    RaisePropertyChanged("BarcodeDetails");
                }
            }
        }

        private List<ADM_M042_P> _ShiftData;
        public List<ADM_M042_P> ShiftData
        {
            get { return _ShiftData; }
            set
            {
                if (_ShiftData != value)
                {
                    _ShiftData = value;
                    RaisePropertyChanged("ShiftData");
                }
            }
        }

        private List<ADM_M024_P> _EmpData;

        public List<ADM_M024_P> EmpData
        {
            get { return _EmpData; }
            set
            {
                if (_EmpData != value)
                {
                    _EmpData = value;
                    RaisePropertyChanged("EmpData");
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
        #endregion

        #region StringList
        List<string> _StringListBarcode;
        public List<string> StringListBarcode
        {
            get { return _StringListBarcode; }
            set
            {
                if (_StringListBarcode != value)
                {
                    _StringListBarcode = value;
                }
            }
        }

        private List<string> _StringListShift;
        public List<string> StringListShift
        {
            get { return _StringListShift; }
            set
            {
                if (_StringListShift != value)
                {
                    _StringListShift = value;
                }
            }
        }

        private List<string> _StringListEmp;
        public List<string> StringListEmp
        {
            get { return _StringListEmp; }
            set
            {
                if (_StringListEmp != value)
                {
                    _StringListEmp = value;
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

        private List<string> _StringListDefect;
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

        #region ICollection

        private ICollectionView _BarcodeCollection;
        public ICollectionView BarcodeCollection
        {
            get { return _BarcodeCollection; }
            set { _BarcodeCollection = value; RaisePropertyChanged("BarcodeCollection"); }
        }

        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
        }

        private ICollectionView _RefDocTypeCollection;
        public ICollectionView RefDocTypeCollection
        {
            get { return _RefDocTypeCollection; }
            set { _RefDocTypeCollection = value; RaisePropertyChanged("RefDocTypeCollection"); }
        }

        private ICollectionView _ShiftCollection;
        public ICollectionView ShiftCollection
        {
            get { return _ShiftCollection; }
            set { _ShiftCollection = value; RaisePropertyChanged("ShiftCollection"); }
        }

        private ICollectionView _EmpCollection;
        public ICollectionView EmpCollection
        {
            get { return _EmpCollection; }
            set { _EmpCollection = value; RaisePropertyChanged("EmpCollection"); }
        }

        private List<COM_T003> _AttachmentCollection;
        public List<COM_T003> AttachmentCollection
        {
            get { return _AttachmentCollection; }
            set { _AttachmentCollection = value; RaisePropertyChanged("AttachmentCollection"); }
        }

        private ICollectionView _ParameterCollection;
        public ICollectionView ParameterCollection
        {
            get { return _ParameterCollection; }
            set { _ParameterCollection = value; RaisePropertyChanged("ParameterCollection"); }
        }

        private ICollectionView _DefectCollection;
        public ICollectionView DefectCollection
        {
            get { return _DefectCollection; }
            set { _DefectCollection = value; RaisePropertyChanged("DefectCollection"); }
        }

        #endregion

        #region Relay Commands Declaration
        public GalaSoft.MvvmLight.Command.RelayCommand cmdLoadFromFilter { get; private set; }
        public RelayCommand<object> CmdBarcode { get; private set; }
        public RelayCommand<object> CmdLoadDocumentByByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdBarcodeScan { get; private set; }
        public RelayCommand<object> CMDRefDocType { get; private set; }
        public RelayCommand<object> CommandShift { get; private set; }
        public RelayCommand<object> CommandEmployee { get; private set; }
        public RelayCommand<object> CMDRefDocNo { get; private set; }
        public RelayCommand<object> CmdDefectAction { get; private set; }
        public RelayCommand<object> CmdParameter { get; private set; }
        public RelayCommand<object> CmdDefect { get; private set; }
        public RelayCommand<object> CMDQCPerson { get; private set; }
        public RelayCommand<object> CommandEmployee1 { get; private set; }
        public RelayCommand<object> CMDQCPerson1 { get; private set; }
        public RelayCommand<object> CmdInsert_t_status { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> CmdInsertGrade { get; private set; }

        #endregion

        #region Constructor
        public ZCRM_T003_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new ZCRM_T003();
            FlipGridData = new List<ZCRM_T003_BackFlip>();
            MC = new MultipleContext_ZCRM_T003();
            SODetails = new ObservableCollection<ZCRM_T003_Batch>();
            MCTemp = new MultipleContext_ZCRM_T003();
            MCTemp1 = new MultipleContext_ZCRM_T003();
            DefectEntity = new ObservableCollection<ZCRM_T003_A>();
            MasterEntity.ValidateAsync().Wait();
            ZCRM_T003.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);

           
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
        public ZCRM_T003_VM(string ts_code,string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new ZCRM_T003();
            FlipGridData = new List<ZCRM_T003_BackFlip>();
            MC = new MultipleContext_ZCRM_T003();
            SODetails = new ObservableCollection<ZCRM_T003_Batch>();
            MCTemp = new MultipleContext_ZCRM_T003();
            MCTemp1 = new MultipleContext_ZCRM_T003();
            DefectEntity = new ObservableCollection<ZCRM_T003_A>();
            MasterEntity.ValidateAsync().Wait();
            ZCRM_T003.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);


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

        #endregion

        #region Relay Command Actions ·
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
        private void Insert_RefDocNo(object InputValue)
        {
            try
            {
                #region Insert Barcode Details
                string Request = "";
                ZCRM_T003_Batch POPUPEntityObject = null;
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
                                    MasterEntity.barcode = POPUPEntityObject.barcode;
                                    MasterEntity.machinecode = POPUPEntityObject.machinecode;
                                    MasterEntity.wc_code = POPUPEntityObject.wc_code;
                                    MasterEntity.shift = POPUPEntityObject.shift;
                                    MasterEntity.EmpId = POPUPEntityObject.shift_incharge;
                                    MasterEntity.EmpName = POPUPEntityObject.EmpName;
                                    MasterEntity.ItemCode = POPUPEntityObject.ItemCode;
                                    MasterEntity.ItemName = POPUPEntityObject.ItemName;
                                    MasterEntity.conversion_no = POPUPEntityObject.order_no;
                                    MasterEntity.prod_dt = POPUPEntityObject.pro_dt;
                                    MasterEntity.counter_remark = POPUPEntityObject.counter_remark;
                                    MasterEntity.grade = POPUPEntityObject.grade;
                                    
                                    MasterEntity.counter_qty = POPUPEntityObject.counter_qty;


                                    SODetails.Clear();
                                    SODetails.Add(new ZCRM_T003_Batch()
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
                            IShowMessageViewService ShowMessage2 = this.GetViewService<IShowMessageViewService>();
                            ShowMessage2.ButtonSetup = DialogButton.OkCancel;
                            ShowMessage2.Caption = "Message";
                            ShowMessage2.Text = String.Format("Entered Barcode is Used.\n Press OK To Re-Sacn Barcode OR Press Cancel To Cancel Re-Scan", this.Title);
                            ShowMessage2.ShowMessage();

                            if (ShowMessage2.ShowMessage() == DialogResult.Ok)
                            {
                                string Request1 = "RescanBarcode" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + Request;
                                MCTemp4 = repository_MCTemp4.GetDataWithReturnDomainObject<MultipleContext_ZCRM_T003>(MCTemp4, Request1, "ProcessInspection", "Production", "LoadInitialData", 0, "");

                                if (MCTemp4.RescanBarcode != null)
                                {
                                    if (MCTemp4.RescanBarcode.Count > 0)
                                    {
                                        MasterEntity = MCTemp4.RescanBarcode[0];
                                        SODetails = MCTemp4.SODetails;
                                        DefaultValues();
                                        MasterEntity.t_status = "021";
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
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ZCRM_T003_Batch>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZCRM_T003_Batch>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.barcode = POPUPEntityObject.barcode;
                    MasterEntity.machinecode = POPUPEntityObject.machinecode;
                    MasterEntity.wc_code = POPUPEntityObject.wc_code;
                    MasterEntity.shift = POPUPEntityObject.shift;
                    MasterEntity.EmpId = POPUPEntityObject.shift_incharge;
                    MasterEntity.EmpName = POPUPEntityObject.EmpName;
                    MasterEntity.ItemCode = POPUPEntityObject.ItemCode;
                    MasterEntity.ItemName = POPUPEntityObject.ItemName;
                    MasterEntity.conversion_no = POPUPEntityObject.order_no;
                    MasterEntity.prod_dt = POPUPEntityObject.pro_dt;
                    MasterEntity.counter_remark = POPUPEntityObject.counter_remark;
                    MasterEntity.grade = POPUPEntityObject.grade;
                    MasterEntity.counter_qty = POPUPEntityObject.counter_qty;

                    SODetails.Clear();
                    SODetails.Add(new ZCRM_T003_Batch()
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
            #endregion
            catch (Exception ex)
            { }
            var msg = new NotificationMessage("ZCRM_T003_VM");
            Messenger.Default.Send<NotificationMessage>(msg);
        }
        private void InsertRefDocType(object InputValue)
        {
            try
            {

                string Request = "";
                SYS_M013_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
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
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M013_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.ref_Doc_TypeNm = POPUPEntityObject.doc_desc_user;
                    MasterEntity.ref_doc_type = POPUPEntityObject.doc_type_user;

                    if (MasterEntity.ref_doc_type == "CN")
                    {
                        var abc = (from o in MC.BarcodeDetails where o.doc_type == "CN" select o).ToList();
                        BarcodeCollection = CollectionViewSource.GetDefaultView(abc);
                        BarcodeCollection.Filter = new Predicate<object>(Filter_Barcode);
                    }
                    else
                    {
                        var abc = (from o in MC.BarcodeDetails where o.doc_type == "PC" select o).ToList();
                        BarcodeCollection = CollectionViewSource.GetDefaultView(abc);
                        BarcodeCollection.Filter = new Predicate<object>(Filter_Barcode);
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
        private void InsertEmp(object InputValue)
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
                    MasterEntity.EmpId = POPUPEntityObject.EmpId;
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
        private void InsertEmp1(object InputValue)
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
                    MasterEntity.EmpId1 = POPUPEntityObject.EmpId;
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
        private void InsertQCPerson1(object InputValue)
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
                    MasterEntity.qc_person1 = POPUPEntityObject.EmpId;
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
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";
                string ParametersStringValue = "";
                ZCRM_T003_BackFlip ParameterEntityObject = null;
                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null)
                {
                    Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + ParameterObject;
                    isNewRecord = false;
                }
                else if (((IEnumerable)ParameterObject).Cast<ZCRM_T003_BackFlip>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ZCRM_T003_BackFlip>().ToList()[0];
                    Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + ParameterEntityObject.doc_no;
                    isNewRecord = false;
                }
                MasterEntity = new ZCRM_T003();
                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ZCRM_T003>(MCTemp, Request, "ProcessInspection", "Production", "LoadDocumentWithReferenceDocumentNumber", 0, "");

                if (MCTemp.MasterEntity.Count > 0)
                {
                    MasterEntity = MCTemp.MasterEntity[0];
                }
                DefectEntity = MCTemp.DefectEntity;

                AttachmentCollection = MCTemp.AttachmentData;
                if (MCTemp.AttachmentData != null)
                {
                    AttachmentCollection = MCTemp.AttachmentData;
                }
                else
                {
                    MCTemp.AttachmentData = new List<COM_T003>();
                }
                SODetails.Clear();
                SODetails = MCTemp.SODetails;
                SelectedTabControlIndex = 0;
                MasterEntity.ts_code = ts_code_vm;
                var msg = new NotificationMessage("ZCRM_T003_VM");
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
        #endregion

        #region Abstract Command Actions
        private IEnumerable<T> MakeMeEnumerable<T>(T Entity)
        {
            yield return Entity;
        }
        protected override void OnSaveAction(InquiryActionResult<ZCRM_T003> result)
        {
            try
            {

                if (Validation() == true)
                {

                    MasterEntity.XmlDataDocument_ZCRM_T003_A = obj.ObjectToXML(DefectEntity);
                    this.MasterEntity.EndEdit();
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ZCRM_T003>(MasterEntity, "ProcessInspection", "Production");
                        isNewRecord = false;

                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Saved Successfully");
                        showMessageService.ShowMessage();

                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ZCRM_T003>(MasterEntity, "ProcessInspection", "Production");

                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Updated Successfully");
                        showMessageService.ShowMessage();

                    }
                    SetBackFlipEntitiesAfterLoad();

                    isNewRecord = false;
                    RemoveReferenceDocuments();
                }
                DefaultRefDocType();
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
        protected override void OnCreateAction(InquiryActionResult<ZCRM_T003> result)
        {
            isNewRecord = true;
            MasterEntity = new ZCRM_T003();
            SODetails.Clear();
            DefectEntity = new ObservableCollection<ZCRM_T003_A>();
            MasterEntity.ValidateAsync().Wait();
            DefaultValues();
            DefaultRefDocType();

            var msg = new NotificationMessage("ZCRM_T003_VM");
            Messenger.Default.Send<NotificationMessage>(msg);
        }
        protected override void OnRemoveAction(InquiryActionResult<ZCRM_T003> result)
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
                        string response = repository.Delete(MasterEntity.doc_no, "ProcessInspection", "Production");

                        MasterEntity = new ZCRM_T003();

                        FlipDataGridCollection.Refresh();
                        isNewRecord = true;
                    }
                    DefaultRefDocType();
                    DefaultValues();
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
        protected override void OnDiscardAction(InquiryActionResult<ZCRM_T003> result)
        {
            MasterEntity.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ZCRM_T003> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ZCRM_T003> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ZCRM_T003> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ZCRM_T003> result)
        {

        }

        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.doc_no))
            {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), DocumentList = MCTemp.AttachmentData, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.comp_code) });
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<ZCRM_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ZCRM_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ZCRM_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ZCRM_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ZCRM_T003> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Event Handler
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = MasterEntity.HasErrors;
        }
        #endregion

        #region User Defined Functions
        private void DefaultRefDocType()
        {
            MasterEntity.ref_Doc_TypeNm = "Production Counter Entry";
            MasterEntity.ref_doc_type = "PC";
            var abc = (from o in MC.BarcodeDetails where o.doc_type == "PC" select o).ToList();
            BarcodeCollection = CollectionViewSource.GetDefaultView(abc);
            BarcodeCollection.Filter = new Predicate<object>(Filter_Barcode);
        }
        private void LoadInitialData()
        {
            try
            {
                MasterEntity.ref_Doc_TypeNm = "Production Counter Entry";
                MasterEntity.ref_doc_type = "PC";
                MasterEntity.doc_cat = "PN";
                MasterEntity.doc_type = "PN";
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ZCRM_T003>(MC, Request, "ProcessInspection", "Production", "LoadInitialData", 0, "");

                #region Command Initialisation

                CmdLoadDocumentByByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); }); // confirm assignment
                CMDRefDocType = new RelayCommand<object>(items => { if (items == null) { return; } InsertRefDocType(items); });
                CommandShift = new RelayCommand<object>(items => { if (items == null) { return; } InsertShift(items); });
                CommandEmployee = new RelayCommand<object>(items => { if (items == null) { return; } InsertEmp(items); });
                CommandEmployee1 = new RelayCommand<object>(items => { if (items == null) { return; } InsertEmp1(items); });
                CMDRefDocNo = new RelayCommand<object>(items => { if (items == null) { return; } Insert_RefDocNo(items); });
                CmdDefectAction = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Defect(cmdPara); });
                CmdParameter = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertParameters(cmdPara, true, true, true); });
                CmdDefect = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDefect(cmdPara, true, true, true); });
                CMDQCPerson = new RelayCommand<object>(items => { if (items == null) { return; } InsertQCPerson(items); });
                CMDQCPerson1 = new RelayCommand<object>(items => { if (items == null) { return; } InsertQCPerson1(items); });
                cmdLoadFromFilter = new GalaSoft.MvvmLight.Command.RelayCommand(() => { Load(); });
                CmdInsert_t_status = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Insert_t_status(cmdPara); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                CmdInsertGrade = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertGrade(cmdPara); });
                #endregion

                #region Autosuggest Initialization

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M042_P)x).shift);
                TheFilter = (o, prefix) => (((ADM_M042_P)o).shift ?? "").ToLower().Contains(prefix.ToLower());
                AS_Shift = new AutoSuggestTextViewModel<dynamic>(MC.ShiftMaster, TheFilter, SuggestedValue, "shift", true);
                AS_Shift.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M016_P)x).dfctcda.ToString());
                TheFilter = (o, prefix) => (((ZADM_M016_P)o).dfctcda.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((ZADM_M016_P)o).dfctdsc ?? "").ToLower().Contains(prefix.ToLower());
                AS_Defect = new AutoSuggestTextViewModel<dynamic>(MC.DefectData, TheFilter, SuggestedValue, "defect", "dfctcda", true);
                AS_Defect.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ENG_T003_P)x).spec_para_code);
                TheFilter = (o, prefix) => (((ENG_T003_P)o).spec_para_code ?? "").ToLower().Contains(prefix.ToLower()) || (((ENG_T003_P)o).parameter ?? "").ToLower().Contains(prefix.ToLower());
                AS_Parameter = new AutoSuggestTextViewModel<dynamic>(MC.ParameterData, TheFilter, SuggestedValue, "parameters", "spec_para_code", true);
                AS_Parameter.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ENG_T003_P)x).spec_para_code);
                TheFilter = (o, prefix) => (((ENG_T003_P)o).spec_para_code ?? "").ToLower().Contains(prefix.ToLower()) || (((ENG_T003_P)o).parameter ?? "").ToLower().Contains(prefix.ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.ParameterData, TheFilter, SuggestedValue, "parameters", "spec_para_code", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpName ?? "").ToLower().Contains(prefix.ToLower());
                AS_Employee = new AutoSuggestTextViewModel<dynamic>(MC.EmployeeMaster, TheFilter, SuggestedValue, "EmpId", true);
                AS_Employee.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpName ?? "").ToLower().Contains(prefix.ToLower());
                ASQcPerson = new AutoSuggestTextViewModel<dynamic>(MC.EmployeeMaster, TheFilter, SuggestedValue, "EmpId", true);
                ASQcPerson.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpName ?? "").ToLower().Contains(prefix.ToLower());
                ASEmp = new AutoSuggestTextViewModel<dynamic>(MC.EmployeeMaster, TheFilter, SuggestedValue, "EmpId", true);
                ASEmp.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpName ?? "").ToLower().Contains(prefix.ToLower());
                ASqcperson = new AutoSuggestTextViewModel<dynamic>(MC.EmployeeMaster, TheFilter, SuggestedValue, "EmpId", true);
                ASqcperson.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M042_P)x).shift);
                TheFilter = (o, prefix) => (((ADM_M042_P)o).shift ?? "").ToLower().Contains(prefix.ToLower());
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
                #endregion


                RefDocType = MC.Ref_DocTypeData.ToList();
                RefDocTypeCollection = CollectionViewSource.GetDefaultView(RefDocType);
                RefDocTypeCollection.Filter = new Predicate<object>(Filter_RefDocType);

                var abc = (from o in MC.BarcodeDetails where o.doc_type == "PC" select o).ToList();
                BarcodeCollection = CollectionViewSource.GetDefaultView(abc);
                BarcodeCollection.Filter = new Predicate<object>(Filter_Barcode);

                DefectCollection = CollectionViewSource.GetDefaultView(MC.DefectData);
                DefectCollection.Filter = new Predicate<object>(FilterDefect);
                StringListDefect = MC.DefectData.Select(x => x.dfctcda.ToString()).ToList();

                ParameterCollection = CollectionViewSource.GetDefaultView(MC.ParameterData);
                ParameterCollection.Filter = new Predicate<object>(Filter_Parameter);
                StringListParameter = MC.ParameterData.Select(x => x.spec_para_code).ToList();

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
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.doc_date = System.DateTime.Now;
            MasterEntity.insp_date = System.DateTime.Now;
            MasterEntity.active = true;
            MasterEntity.t_status = "001";
            MasterEntity.doc_cat = "PN";
            MasterEntity.doc_type = "PN";
            MasterEntity.ts_code = ts_code_vm;
        }
        private bool Validation()
        {
            try
            {
                if (MasterEntity.insp_date == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Inspection Date Is Required", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
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
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
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
        private void Load()
        {
            try
            {
                if (Validation1() == true)
                {
                    string RequestParameter = "LoadFromFilters" + "!@" + MasterEntity.EmpId1 + "!@" + MasterEntity.qc_person + "!@" + MasterEntity.Fromdt.ToString() + "!@" + MasterEntity.Todt.ToString() + "!@" + MasterEntity.con_no + "!@" + MasterEntity.sshift + "!@" + MasterEntity.machine + "!@" + MasterEntity.item + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code;
                    MCTemp1 = repository_MCTemp1.GetDataWithReturnDomainObject<MultipleContext_ZCRM_T003>(MCTemp1, RequestParameter, "ProcessInspection", "Production", "LoadInitialData", 0, "");

                    FlipGridData = MCTemp1.BackFlipEntity.ToList();
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
        private void SetBackFlipEntitiesAfterLoad()
        {
            try
            {
                MasterEntity.ts_code = ts_code_vm;
                if (MasterEntity.BackFlipEntity != null)
                {
                    MC.BackFlipEntity = (List<ZCRM_T003_BackFlip>)new ObjectSerializationService().XMLToObject(MasterEntity.BackFlipEntity, MC.BackFlipEntity);
                    FlipGridData.Add(MC.BackFlipEntity[0]);
                    FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                    _FlipDataGridCollection.Refresh();
                }
                if (MasterEntity.XmlDataDocument_ZCRM_T003_A != null)
                {
                    DefectEntity.Clear();
                    MC.DefectEntity = (ObservableCollection<ZCRM_T003_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ZCRM_T003_A, MC.DefectEntity);
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
                        { POPUPEntityObject = MC.ParameterData.Where(x => x.spec_para_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
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
                        DefectEntity.Add(new ZCRM_T003_A()
                        {
                            id = 0,
                            parameters = POPUPEntityObject.spec_para_code,
                            parameterNm = POPUPEntityObject.parameter,
                            active = true,
                            location_Id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            add_by = AppSessionState.UserID,
                            editby = AppSessionState.UserID,
                            posting_period = "1",
                            fin_year = "15-16",
                            t_status = "001"
                        });
                    }
                    else if (dgSelectedIndexDefect >= 0 && DefectEntity.Count > dgSelectedIndexDefect)
                    {
                        if (DefectEntity[dgSelectedIndexDefect].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                        {
                            DefectEntity[dgSelectedIndexDefect].parameters = POPUPEntityObject.spec_para_code;
                            DefectEntity[dgSelectedIndexDefect].parameterNm = POPUPEntityObject.parameter;
                            DefectEntity[dgSelectedIndexDefect].location_Id = AppSessionState.location_Id;
                            DefectEntity[dgSelectedIndexDefect].comp_code = AppSessionState.comp_code;
                            DefectEntity[dgSelectedIndexDefect].add_by = AppSessionState.UserID;
                            DefectEntity[dgSelectedIndexDefect].fin_year = "15-16";
                            DefectEntity[dgSelectedIndexDefect].posting_period = "1";
                            DefectEntity[dgSelectedIndexDefect].active = true;
                            DefectEntity[dgSelectedIndexDefect].t_status = "001";
                        }
                        else if (DefectEntity[dgSelectedIndexDefect].parameters != POPUPEntityObject.parameter)
                        {
                            DefectEntity[dgSelectedIndexDefect].parameters = POPUPEntityObject.spec_para_code;
                            DefectEntity[dgSelectedIndexDefect].parameterNm = POPUPEntityObject.parameter;

                        }
                    }
                }

                ZCRM_T003_A newObj = new ZCRM_T003_A();
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
                        { POPUPEntityObject = MC.DefectData.Where(x => x.dfctcda.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
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
                        DefectEntity.Add(new ZCRM_T003_A()
                        {
                            id = 0,
                            defect = POPUPEntityObject.dfctcda.ToString(),
                            DefectNm = POPUPEntityObject.dfctdsc,
                            active = true,
                            location_Id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            add_by = AppSessionState.UserID,
                            editby = AppSessionState.UserID,
                            posting_period = "1",
                            fin_year = "15-16",
                            t_status = "001"
                        });
                    }
                    else if (dgSelectedIndexDefect >= 0 && DefectEntity.Count > dgSelectedIndexDefect)
                    {
                        if (DefectEntity[dgSelectedIndexDefect].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                        {
                            DefectEntity[dgSelectedIndexDefect].defect = POPUPEntityObject.dfctcda.ToString();
                            DefectEntity[dgSelectedIndexDefect].DefectNm = POPUPEntityObject.dfctdsc;
                            DefectEntity[dgSelectedIndexDefect].location_Id = AppSessionState.location_Id;
                            DefectEntity[dgSelectedIndexDefect].comp_code = AppSessionState.comp_code;
                            DefectEntity[dgSelectedIndexDefect].add_by = AppSessionState.UserID;
                            DefectEntity[dgSelectedIndexDefect].fin_year = "15-16";
                            DefectEntity[dgSelectedIndexDefect].posting_period = "1";
                            DefectEntity[dgSelectedIndexDefect].active = true;
                            DefectEntity[dgSelectedIndexDefect].t_status = "001";
                        }
                        else if (DefectEntity[dgSelectedIndexDefect].defect != POPUPEntityObject.dfctcda.ToString())
                        {
                            DefectEntity[dgSelectedIndexDefect].defect = POPUPEntityObject.dfctcda.ToString();
                            DefectEntity[dgSelectedIndexDefect].DefectNm = POPUPEntityObject.dfctdsc;
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
        private void RemoveReferenceDocuments()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(MasterEntity.barcode) == false)
                {
                    MC.BarcodeDetails.Remove(MC.BarcodeDetails.Single(s => s.barcode == MasterEntity.barcode));
                }
            }
            catch (Exception ex)
            {
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
        #endregion

        #region Filters
        //Filter String Flip Grid
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
            var data = obj as ZCRM_T003_BackFlip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_FlipGrid))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.insp_date != null && data.insp_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));

                }
                return true;
            }
            return false;
        }

        private string _filterString_Barcode;
        public string filterString_Barcode
        {
            get { return _filterString_Barcode; }
            set
            {
                _filterString_Barcode = value;
                RaisePropertyChanged("filterString_Barcode");
                Filter_Barcode();
            }
        }
        private void Filter_Barcode()
        {
            if (_BarcodeCollection != null)
            {
                _BarcodeCollection.Refresh();
            }
        }
        public bool Filter_Barcode(object obj)
        {
            var data = obj as ZCRM_T003_Batch;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(filterString_Barcode))
                {
                    return
                        (data.RefDocNo != null && data.RefDocNo.ToString().ToLower().Contains(_filterString_Barcode.ToLower())) ||
                         (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_Barcode.ToLower())) ||
                        (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_Barcode.ToLower())) ||
                        (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterString_Barcode.ToLower())) ||
                        (data.order_no != null && data.order_no.ToString().ToLower().Contains(_filterString_Barcode.ToLower())) ||
                        (data.barcode != null && data.barcode.ToString().ToLower().Contains(_filterString_Barcode.ToLower())) ||
                        (data.shift != null && data.shift.ToString().ToLower().Contains(_filterString_Barcode.ToLower())) ||
                        (data.shift_incharge != null && data.shift_incharge.ToString().ToLower().Contains(_filterString_Barcode.ToLower())) ||
                        (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterString_Barcode.ToLower())) ||
                        (data.conversion_no != null && data.conversion_no.ToString().ToLower().Contains(_filterString_Barcode.ToLower())) ||
                        (data.pro_dt != null && data.pro_dt.ToString().ToLower().Contains(_filterString_Barcode.ToLower()));


                }
                return true;
            }
            return false;
        }

        private string _filterStringDefect;
        public string filterStringDefect
        {
            get { return _filterStringDefect; }
            set
            {
                _filterStringDefect = value;
                RaisePropertyChanged("_filterStringDefect");
                FilterDefect();
            }
        }
        private void FilterDefect()
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
                if (!string.IsNullOrEmpty(_filterStringDefect))
                {
                    return (data.dfctcda != null && data.dfctcda.ToString().ToLower().Contains(_filterStringDefect.ToLower())) ||
                           (data.dfctdsc != null && data.dfctdsc.ToString().ToLower().Contains(_filterStringDefect.ToLower()));
                }
                return true;
            }
            return false;
        }


        private string _filterString_RefDocType;
        public string filterString_RefDocType
        {
            get { return _filterString_RefDocType; }
            set
            {
                _filterString_RefDocType = value;
                RaisePropertyChanged("filterString_RefDocType");
                Filter_RefDocType();
            }
        }
        private void Filter_RefDocType()
        {
            if (_RefDocTypeCollection != null)
            {
                _RefDocTypeCollection.Refresh();
            }
        }
        public bool Filter_RefDocType(object obj)
        {
            var data = obj as SYS_M013_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(filterString_RefDocType))
                {
                    return (data.doc_type_user != null && data.doc_type_user.ToString().ToLower().Contains(_filterString_RefDocType.ToLower())) ||
                           (data.doc_desc_user != null && data.doc_desc_user.ToString().ToLower().Contains(_filterString_RefDocType.ToLower()));


                }
                return true;
            }
            return false;
        }

        private string _FilterStringShift;
        public string FilterStringShift
        {
            get { return _FilterStringShift; }
            set
            {
                _FilterStringShift = value;
                RaisePropertyChanged("FilterStringShift");
                Filter_Shift();
            }
        }
        private void Filter_Shift()
        {
            if (_ShiftCollection != null)
            {
                _ShiftCollection.Refresh();
            }
        }
        public bool Filter_Shift(object obj)
        {
            var data = obj as ADM_M042_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringShift))
                {
                    return (data.shift != null && data.shift.ToString().ToLower().Contains(FilterStringShift.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _FilterStringEmployee;
        public string FilterStringEmployee
        {
            get { return _FilterStringEmployee; }
            set
            {
                _FilterStringEmployee = value;
                RaisePropertyChanged("FilterStringEmployee");
                Filter_Employee();
            }
        }
        private void Filter_Employee()
        {
            if (_EmpCollection != null)
            {
                _EmpCollection.Refresh();
            }
        }
        public bool Filter_Employee(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringEmployee))
                {
                    return (data.EmpId != null && data.EmpId.ToString().ToLower().Contains(FilterStringEmployee.ToLower())) ||
                        (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(FilterStringEmployee.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _FilterStringParameter;
        public string FilterStringParameter
        {
            get { return _FilterStringParameter; }
            set
            {
                _FilterStringParameter = value;
                RaisePropertyChanged("FilterStringParameter");
                Filter_ParameterCollection();
            }
        }
        private void Filter_ParameterCollection()
        {
            if (_ParameterCollection != null)
            {
                _ParameterCollection.Refresh();
            }
        }
        public bool Filter_Parameter(object obj)
        {
            var data = obj as ENG_T003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringParameter))
                {
                    return (data.spec_para_code != null && data.spec_para_code.ToString().ToLower().Contains(FilterStringParameter.ToLower())) ||
                        (data.parameter != null && data.parameter.ToString().ToLower().Contains(FilterStringParameter.ToLower()));
                }
                return true;
            }
            return false;
        }

       
        #endregion

    }
}
