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
using System.Collections.ObjectModel;
using Reflection.BusinessEntity;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity.QMS;
using System.Windows;
using System.Reflection;
using Reflection.Presentation.Core.VirtualDesktops;
using GalaSoft.MvvmLight.Ioc;
using System.IO;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ADM;
using Reflection.ReportingServices;
using System.Globalization;

namespace Reflection.Modules.QMS.ViewModels
{
    public class QMS_T003_RR_VM : WorkspaceViewModel<QMS_T003_A>
    {
        #region Variables Declaration
        WebServiceRepository<QMS_T003> REPO = new WebServiceRepository<QMS_T003>();
        WebServiceRepository<MC_QMS_T003> REPO_MC = new WebServiceRepository<MC_QMS_T003>();
        ObjectSerializationService obj = new ObjectSerializationService();
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string doc_cat_vm { get; set; }
        public string defect_level_vm { get; set; }
        private bool _isNewRecord;
        public bool isNewRecord
        {
            get { return _isNewRecord; }
            set
            {
                if (_isNewRecord != value)
                {
                    _isNewRecord = value;
                    RaisePropertyChanged("isNewRecord");
                }
            }
        }
        private bool _OpenRRBPopup;
        public bool OpenRRBPopup
        {
            get { return _OpenRRBPopup; }
            set
            {
                if (_OpenRRBPopup != value)
                {
                    _OpenRRBPopup = value;
                    RaisePropertyChanged("OpenRRBPopup");
                }
            }
        }
        private bool _IsColumnVisible;
        public bool IsColumnVisible // NOTE: TBD whether to keep or not
        {
            get { return _IsColumnVisible; }
            set
            {
                if (_IsColumnVisible != value)
                {
                    _IsColumnVisible = value;
                    RaisePropertyChanged("IsColumnVisible");
                }
            }
        }
        private string _SelectionMode;
        public string SelectionMode
        {
            get { return _SelectionMode; }
            set
            {
                if (_SelectionMode != value)
                {
                    _SelectionMode = value;
                    RaisePropertyChanged("SelectionMode");
                }
            }
        }
        
        private MC_QMS_T003 _MC = new MC_QMS_T003();
        public MC_QMS_T003 MC
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
        private MC_QMS_T003 _MC_TEMP = new MC_QMS_T003();
        public MC_QMS_T003 MC_TEMP
        {
            get { return _MC_TEMP; }
            set
            {
                if (_MC_TEMP != value)
                {
                    _MC_TEMP = value; RaisePropertyChanged("MC_TEMP");
                }
            }
        }
        
        private QMS_T003 _MasterEntity;
        public QMS_T003 MasterEntity
        {
            get
            {
                return _MasterEntity;
            }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value; RaisePropertyChanged("MasterEntity");
                }
            }
        }
        private QMS_T003_A _SelectedItemsRRA;
        public QMS_T003_A SelectedItemsRRA
        {
            get
            {
                return _SelectedItemsRRA;
            }
            set
            {
                if (_SelectedItemsRRA != value && value != null)
                {
                    _SelectedItemsRRA = value; RaisePropertyChanged(nameof(SelectedItemsRRA));
                    if (_SelectedItemsRRA != null)
                    {
                        if (_SelectedItemsRRA.ind_mv == "N")
                        {
                            IsColumnVisible = false;
                            SelectionMode = "Single";
                        }
                        else
                        {
                            IsColumnVisible = true;
                            SelectionMode = "Extended";
                        }
                    }
                    DataGridRowSelectionChangedRRA(_SelectedItemsRRA);
                }
            }
        }
        private QMS_T003_B _SelectedItemsRRB;
        public QMS_T003_B SelectedItemsRRB
        {
            get
            {
                return _SelectedItemsRRB;
            }
            set
            {
                if (_SelectedItemsRRB != value)
                {
                    _SelectedItemsRRB = value; RaisePropertyChanged("SelectedItemsRRB");
                    if (_SelectedItemsRRB != null)
                    {
                        if (_SelectedItemsRRB.ind_mv == "N")
                        {
                            Visibility_MV = Visibility.Collapsed;
                            IsColumnVisible = false;
                            SelectionMode = "Single";
                        }
                        else
                        {
                            Visibility_MV = Visibility.Visible;
                            IsColumnVisible = true;
                            SelectionMode = "Extended";
                        }
                    }
                    DataGridRowSelectionChangedRRB(_SelectedItemsRRB);
                }
            }
        }
        private QMS_T003_C _SelectedItemsRRC;
        public QMS_T003_C SelectedItemsRRC
        {
            get
            {
                return _SelectedItemsRRC;
            }
            set
            {
                if (_SelectedItemsRRC != value)
                {
                    _SelectedItemsRRC = value; RaisePropertyChanged("SelectedItemsRRC");
                    if (_SelectedItemsRRC != null)
                    {
                        if (_SelectedItemsRRC.ind_mv == "N")
                        {
                            Visibility_MV = Visibility.Collapsed;
                            IsColumnVisible = false;
                            SelectionMode = "Single";
                        }
                        else
                        {
                            Visibility_MV = Visibility.Visible;
                            IsColumnVisible = true;
                            SelectionMode = "Extended";
                        }
                    }
                    DataGridRowSelectionChangedRRC(_SelectedItemsRRC);
                }
            }
        }

        private ObservableCollection<QMS_T003_A> _RRSummuryCollection;
        public ObservableCollection<QMS_T003_A> RRSummuryCollection
        {
            get
            {
                return _RRSummuryCollection;
            }
            set
            {
                if (_RRSummuryCollection != value)
                {
                    _RRSummuryCollection = value; RaisePropertyChanged("RRSummuryCollection");
                }
            }
        }

        private ObservableCollection<QMS_T003_B> _RRCharactorSummuryCollection;
        public ObservableCollection<QMS_T003_B> RRCharactorSummuryCollection
        {
            get
            {
                return _RRCharactorSummuryCollection;
            }
            set
            {
                if (_RRCharactorSummuryCollection != value)
                {
                    _RRCharactorSummuryCollection = value; RaisePropertyChanged("RRCharactorSummuryCollection");
                }
            }
        }

        private ObservableCollection<QMS_T003_C> _RRSingleCollection;
        public ObservableCollection<QMS_T003_C> RRSingleCollection
        {
            get
            {
                return _RRSingleCollection;
            }
            set
            {
                if (_RRSingleCollection != value)
                {
                    _RRSingleCollection = value; RaisePropertyChanged("RRSingleCollection");
                }
            }
        }

        private IEnumerable _VALUE_COLLECTION;
        public IEnumerable VALUE_COLLECTION
        {
            get { return _VALUE_COLLECTION; }
            set
            {
                if (_VALUE_COLLECTION != value)
                {
                    _VALUE_COLLECTION = value; RaisePropertyChanged("VALUE_COLLECTION");
                }
            }
        }

        private ICollectionView _dataGridviewFilter;
        public ICollectionView DataGridViewFilter
        {
            get { return _dataGridviewFilter; }
            set { _dataGridviewFilter = value; RaisePropertyChanged("DataGridViewFilter"); }
        }
        private Visibility _Visibility_MV;
        public Visibility Visibility_MV
        {
            get
            {
                return _Visibility_MV;
            }
            set
            {
                _Visibility_MV = value;

                RaisePropertyChanged("Visibility_MV");
            }
        }
        private Visibility _Visibility_RRA;
        public Visibility Visibility_RRA
        {
            get
            {
                return _Visibility_RRA;
            }
            set
            {
                _Visibility_RRA = value;

                RaisePropertyChanged("Visibility_RRA");
            }
        }
        private Visibility _Visibility_RRB;
        public Visibility Visibility_RRB
        {
            get
            {
                return _Visibility_RRB;
            }
            set
            {
                _Visibility_RRB = value;

                RaisePropertyChanged("Visibility_RRB");
            }
        }
        private Visibility _Visibility_RRC;
        public Visibility Visibility_RRC
        {
            get
            {
                return _Visibility_RRC;
            }
            set
            {
                _Visibility_RRC = value;

                RaisePropertyChanged("Visibility_RRC");
            }
        }

        private ICollectionView _SingleResultCollectionFilter;
        public ICollectionView SingleResultCollectionFilter
        {
            get { return _SingleResultCollectionFilter; }
            set { _SingleResultCollectionFilter = value; RaisePropertyChanged("SingleResultCollectionFilter"); }
        }

        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        //public RelayCommand<object> cmdSelectionChangedRRA { get; private set; }
        //public RelayCommand<object> cmdSelectionChangedRRB { get; private set; }
        //public RelayCommand<object> cmdSelectionChangedRRC { get; private set; }
        public RelayCommand<object> cmdVisibility_RRA { get; private set; }
        public RelayCommand<object> cmdVisibility_RRB { get; private set; }
        public RelayCommand<object> cmdVisibility_RRC { get; private set; } // Single Result
        public RelayCommand<object> cmdInspection_Processing_DR { get; private set; }
        public RelayCommand<object> cmdPreviousRRB { get; private set; }
        public RelayCommand<object> cmdNextRRB { get; private set; }
        public RelayCommand<object> cmdGetSelectedValues { get; private set; }
        public RelayCommand<object> cmdGotFocusRRBTextBox { get; private set; }


        #endregion
        #region Constructor
        public QMS_T003_RR_VM(string ts_code, string doc_no, QMS_T003 lot_nfo) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new QMS_T003();
            MasterEntity = lot_nfo;
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.userid = AppSessionState.UserID;
            SelectedItemsRRA = new QMS_T003_A();
            SelectedItemsRRB = new QMS_T003_B();
            SelectedItemsRRC = new QMS_T003_C();
            RRSummuryCollection = new ObservableCollection<QMS_T003_A>();
            RRCharactorSummuryCollection = new ObservableCollection<QMS_T003_B>();
            RRSingleCollection = new ObservableCollection<QMS_T003_C>();

            MC = new MC_QMS_T003();
            MC_TEMP = new MC_QMS_T003();

            QMS_T003_A.ModelEntityUpdated += new EventHandler(ModelUpdated_QMS_T003_A);
            QMS_T003_B.ModelEntityUpdated += new EventHandler(ModelUpdated_QMS_T003_B);
            QMS_T003_C.ModelEntityUpdated += new EventHandler(ModelUpdated_QMS_T003_C);

            CommandInitialization();
        }
        #endregion
        #region Default Functions
        private void CommandInitialization()
        {
            CursorControl.SetBusyState();
            cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            //cmdSelectionChangedRRA = new RelayCommand<object>(items => { if (items == null) { return; } DataGridRowSelectionChangedRRA(items); });
            //cmdSelectionChangedRRB = new RelayCommand<object>(items => { if (items == null) { return; } DataGridRowSelectionChangedRRB(items); });
            //cmdSelectionChangedRRC = new RelayCommand<object>(items => { if (items == null) { return; } DataGridRowSelectionChangedRRC(items); });
            cmdVisibility_RRA = new RelayCommand<object>(items => { if (items == null) { return; } Visibility_RRA_Call(items); });
            cmdVisibility_RRB = new RelayCommand<object>(items => { if (items == null) { return; } Visibility_RRB_Call(items); });
            cmdVisibility_RRC = new RelayCommand<object>(items => { if (items == null) { return; } Visibility_RRC_Call(items); });
            cmdInspection_Processing_DR = new RelayCommand<object>(items => { if (items == null) { return; } Inspection_Processing_DR_Call(items); });
            cmdPreviousRRB = new RelayCommand<object>(items => { if (items == null) { return; } PreviousRRB(items); });
            cmdNextRRB = new RelayCommand<object>(items => { if (items == null) { return; } NextRRB(items); });
            cmdGetSelectedValues = new RelayCommand<object>(items => { if (items == null) { return; } GetSelectedValues(items); });
            cmdGotFocusRRBTextBox = new RelayCommand<object>(items => { if (items == null) { return; } GotFocusRRBTextBox(items); });
        }
        private void Logging()
        {
            MasterEntity.ts_code = this.ts_code_vm;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.session_id = AppSessionState.session_id;
            MasterEntity.client = AppSessionState.client;
        }
        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {
                string Request = "LOAD_INI_SUM_RR" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_id + "!@" + doc_no_vm + "!@" + MasterEntity.tl_code + "!@" + MasterEntity.doc_no + "!@" + MasterEntity.tl_code + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type;
                MC = REPO_MC.GetDataWithReturnDomainObject<MC_QMS_T003>(MC, Request, "QMS_T003_BL", "QMS", "LOAD_INI_SUM_RR", 0, "");

                RRSummuryCollection = MC.SUMMURY_RR;
                RRCharactorSummuryCollection = MC.CHAR_RR;
                RRSingleCollection = MC.SINGLE_RR;

                if (RRCharactorSummuryCollection.Count > 0)
                {
                    SelectedItemsRRB = RRCharactorSummuryCollection[0];
                    FilterSummuryResultRRB(SelectedItemsRRB.sample_no);
                }
                if (RRSummuryCollection.Count > 0)
                {
                    SelectedItemsRRA = RRSummuryCollection[0];
                }

                isNewRecord = false;

                Visibility_RRA = Visibility.Visible;
                Visibility_RRB = Visibility.Collapsed;
                Visibility_RRC = Visibility.Collapsed;
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
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
                    Request = AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                LoadInitialData();
                //Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void DataGridRowSelectionChangedRRA(object InputValue)
        {
            try
            {
                if (InputValue != null && MC.CLASS_PROFILE_LIST != null)
                {
                    QMS_T003_A OBJ_B = (QMS_T003_A)InputValue;
                    VALUE_COLLECTION = MC.CLASS_PROFILE_LIST.Where(x => x.char_code == (OBJ_B.char_code ?? "")).ToList();
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void DataGridRowSelectionChangedRRB(object InputValue)
        {
            try
            {
                if (InputValue != null && MC.CLASS_PROFILE_LIST != null)
                {
                    QMS_T003_B OBJ_B = (QMS_T003_B)InputValue;
                    VALUE_COLLECTION = MC.CLASS_PROFILE_LIST.Where(x => x.char_code == (OBJ_B.char_code ?? "")).ToList();
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void DataGridRowSelectionChangedRRC(object InputValue)
        {
            try
            {
                if (InputValue != null && MC.CLASS_PROFILE_LIST != null)
                {
                    QMS_T003_C OBJ_B = (QMS_T003_C)InputValue;
                    VALUE_COLLECTION = MC.CLASS_PROFILE_LIST.Where(x => x.char_code == (OBJ_B.char_code ?? "")).ToList();
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void ResultValuationRRA(string InputValue)
        {
            try
            {
                Classification POPUPEntityObject = null;
                if (RRSummuryCollection.Count > 0) 
                {
                    if (SelectedItemsRRA.char_type == "N")//if (SelectedItemsRRA.char_type == "Quantitative")
                    {
                        //ExecuteFormulaRRA(SelectedItemsRRA.char_value);
                        decimal temp;
                        if (Decimal.TryParse(InputValue, out temp))
                        {
                            ExecuteFormulaRRA(SelectedItemsRRA.char_value);
                            decimal dcResultValue = Convert.ToDecimal(InputValue);
                            decimal dcLowerValue = Convert.ToDecimal(SelectedItemsRRA.specifications.Split('-')[0]);
                            decimal dcUpperValue = Convert.ToDecimal(SelectedItemsRRA.specifications.Split('-')[1]);

                            if (dcResultValue <= dcUpperValue && dcResultValue >= dcLowerValue)
                            {
                                SelectedItemsRRA.v_code = "A";
                                SelectedItemsRRA.v_code_text = "Accepted";
                            }
                            else if (dcResultValue > dcUpperValue || dcResultValue < dcLowerValue)
                            {
                                SelectedItemsRRA.v_code = "R";
                                SelectedItemsRRA.v_code_text = "Rejected";
                            }
                            SelectedItemsRRA.sample_inspected = (SelectedItemsRRA.sample_inspected ?? Convert.ToInt32(SelectedItemsRRA.sample_size));
                            SelectedItemsRRA.sample_recorded = SelectedItemsRRA.sample_inspected;
                            SelectedItemsRRA.ind_complete = "Y";
                            SelectedItemsRRA.active = (SelectedItemsRRA.active ?? "1");

                        }
                    }
                    else if (SelectedItemsRRA.char_type == "Q" && InputValue != null)
                    {
                        if (InputValue.GetType() == typeof(string))
                        {
                            if (InputValue.Length > 0)
                            {
                                try
                                { POPUPEntityObject = MC.CLASS_PROFILE_LIST.Where(x => x.char_value.Equals(InputValue, StringComparison.OrdinalIgnoreCase) == true && x.char_code.Equals(SelectedItemsRRA.char_code, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                                catch (Exception ex) { }
                            }
                        }
                        else if (InputValue != null)
                        {
                            POPUPEntityObject = ((IEnumerable)InputValue).Cast<Classification>().ToList()[0];
                        }
                        if (POPUPEntityObject != null)
                        {
                            SelectedItemsRRB.v_code = POPUPEntityObject.v_code;
                            SelectedItemsRRB.v_code_text = POPUPEntityObject.v_name;

                            SelectedItemsRRA.sample_inspected = (SelectedItemsRRA.sample_inspected ?? Convert.ToInt32(SelectedItemsRRA.sample_size));
                            SelectedItemsRRA.sample_recorded = SelectedItemsRRA.sample_inspected;
                            SelectedItemsRRA.ind_complete = "Y";
                            SelectedItemsRRA.char_code = POPUPEntityObject.char_code;
                            SelectedItemsRRA.char_type = POPUPEntityObject.char_type;
                            SelectedItemsRRA.version = POPUPEntityObject.ver_no;
                            SelectedItemsRRA.defect_class = POPUPEntityObject.def_class;
                            SelectedItemsRRA.active = (SelectedItemsRRA.active ?? "1");
                        }
                    }
                }
                if (string.IsNullOrWhiteSpace(SelectedItemsRRA.char_value))
                {
                    SelectedItemsRRA.v_code = "N";
                    SelectedItemsRRA.v_code_text = "Non Valuated";
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void ResultValuationRRB(string InputValue)
        {
            try
            {
                Classification POPUPEntityObject = null;
                if (RRCharactorSummuryCollection.Count > 0)
                {
                    if (SelectedItemsRRB.char_type == "N")//if (SelectedItemsRRB.char_type == "Quantitative")
                    {
                        ExecuteFormula(SelectedItemsRRB.char_value);
                        decimal temp;
                        if (Decimal.TryParse(InputValue, out temp))
                        {
                            decimal dcResultValue = Convert.ToDecimal(InputValue);
                            decimal dcLowerValue = Convert.ToDecimal(SelectedItemsRRB.specifications.Split('-')[0]);
                            decimal dcUpperValue = Convert.ToDecimal(SelectedItemsRRB.specifications.Split('-')[1]);

                            if (dcResultValue <= dcUpperValue && dcResultValue >= dcLowerValue)
                            {
                                SelectedItemsRRB.v_code = "A";
                                SelectedItemsRRB.v_code_text = "Accepted";
                            }
                            else if (dcResultValue > dcUpperValue || dcResultValue < dcLowerValue)
                            {
                                SelectedItemsRRB.v_code = "R";
                                SelectedItemsRRB.v_code_text = "Rejected";
                            }
                            SelectedItemsRRB.sample_inspected = (SelectedItemsRRB.sample_inspected ?? Convert.ToInt32(SelectedItemsRRB.sample_size));
                            SelectedItemsRRB.sample_recorded = SelectedItemsRRB.sample_inspected;
                            SelectedItemsRRB.ind_complete = "Y";
                            SelectedItemsRRB.active = (SelectedItemsRRB.active ?? "1");

                            // Auto update valuation for QMS_T003_A
                            if(!string.IsNullOrWhiteSpace(SelectedItemsRRB.char_value))
                            {
                                SelectedItemsRRA = RRSummuryCollection.Where(x => x.char_code == SelectedItemsRRB.char_code && x.char_type == "N").FirstOrDefault();
                                SelectedItemsRRA.char_value =  RRCharactorSummuryCollection.Where(x => x.char_code == SelectedItemsRRB.char_code && x.char_type=="N").Average(x => Convert.ToDecimal(x.char_value)).ToString();
                                ResultValuationRRA(SelectedItemsRRA.char_value);
                            }
                        }
                    }
                    else if (SelectedItemsRRB.char_type == "Q" && InputValue != null)
                    {
                        if (InputValue.GetType() == typeof(string))
                        {
                            if (InputValue.Length > 0)
                            {
                                try
                                { POPUPEntityObject = MC.CLASS_PROFILE_LIST.Where(x => x.char_value.Equals(InputValue, StringComparison.OrdinalIgnoreCase) == true && x.char_code.Equals(SelectedItemsRRB.char_code, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                                catch (Exception ex) { }
                            }
                        }
                        else if (InputValue != null)
                        {
                            POPUPEntityObject = ((IEnumerable)InputValue).Cast<Classification>().ToList()[0];
                        }
                        if (POPUPEntityObject != null)
                        {
                            
                            SelectedItemsRRB.v_code = POPUPEntityObject.v_code;
                            SelectedItemsRRB.v_code_text = POPUPEntityObject.v_name;

                            SelectedItemsRRB.sample_inspected = (SelectedItemsRRB.sample_inspected ?? Convert.ToInt32(SelectedItemsRRB.sample_size));
                            SelectedItemsRRB.sample_recorded = SelectedItemsRRB.sample_inspected;
                            SelectedItemsRRB.ind_complete = "Y";
                            SelectedItemsRRB.char_code = POPUPEntityObject.char_code;
                            SelectedItemsRRB.char_type = POPUPEntityObject.char_type;
                            SelectedItemsRRB.version = POPUPEntityObject.ver_no;
                            SelectedItemsRRB.defect_class = POPUPEntityObject.def_class;
                            SelectedItemsRRB.active = (SelectedItemsRRB.active ?? "1");
                        }
                    }
                }
                if(string.IsNullOrWhiteSpace(SelectedItemsRRB.char_value))
                {
                    SelectedItemsRRB.v_code = "N";
                    SelectedItemsRRB.v_code_text = "Non Valuated";
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void ResultValuationRRC(string InputValue) // Result Valuation Single Result Recording
        {
            try
            {
                Classification POPUPEntityObject = null;
                if (RRSingleCollection.Count > 0)
                {
                    if (SelectedItemsRRA.char_type == "N")
                    {
                        decimal temp;
                        if (Decimal.TryParse(InputValue, out temp))
                        {
                            double? dcResultValue = Convert.ToDouble(InputValue);
                            double? dcLowerValue = SelectedItemsRRA.low_limit;
                            double? dcUpperValue = SelectedItemsRRA.up_limit;

                            if (dcResultValue <= dcUpperValue && dcResultValue >= dcLowerValue)
                            {
                                SelectedItemsRRC.v_code = "A";
                                SelectedItemsRRC.v_code_text = "Accepted";
                            }
                            else if (dcResultValue > dcUpperValue || dcResultValue < dcLowerValue)
                            {
                                SelectedItemsRRC.v_code = "R";
                                SelectedItemsRRC.v_code_text = "Rejected";
                            }
                            SelectedItemsRRC.ind_complete = "Y";
                            SelectedItemsRRC.measured_value = dcResultValue;


                            // Auto update valuation for QMS_T003_B
                            if (!string.IsNullOrWhiteSpace(SelectedItemsRRC.char_value))
                            {
                                SelectedItemsRRB = RRCharactorSummuryCollection.Where(x => x.char_code == SelectedItemsRRC.char_code && x.sample_no == SelectedItemsRRC.sample_no && x.char_type == "N").FirstOrDefault();
                                SelectedItemsRRB.char_value = RRCharactorSummuryCollection.Where(x => x.char_code == SelectedItemsRRC.char_code && x.sample_no == SelectedItemsRRC.sample_no && x.char_type == "N").Average(x => Convert.ToDecimal(x.char_value)).ToString();
                                ResultValuationRRB(SelectedItemsRRB.char_value);
                            }
                        }
                    }
                    else if (SelectedItemsRRA.char_type == "Q")
                    {
                        if (InputValue.GetType() == typeof(string) && InputValue != null)
                        {
                            if (InputValue.Length > 0)
                            {
                                try
                                { POPUPEntityObject = MC.CLASS_PROFILE_LIST.Where(x => x.char_value.Equals(InputValue, StringComparison.OrdinalIgnoreCase) == true && x.char_code.Equals(SelectedItemsRRC.char_code, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                                catch (Exception ex) { }
                            }
                        }
                        else if (InputValue != null)
                        {
                            POPUPEntityObject = ((IEnumerable)InputValue).Cast<Classification>().ToList()[0];
                        }
                        if (POPUPEntityObject != null)
                        {
                            // NOTE: char_value instead of valuation_code
                            SelectedItemsRRC.char_value = POPUPEntityObject.char_value;
                            SelectedItemsRRC.v_code = POPUPEntityObject.v_code;
                            SelectedItemsRRC.v_code_text = POPUPEntityObject.v_name;
                            SelectedItemsRRC.ind_complete = "Y";
                            SelectedItemsRRC.char_code = POPUPEntityObject.char_code;
                            SelectedItemsRRC.char_type = POPUPEntityObject.char_type;
                            SelectedItemsRRC.version = POPUPEntityObject.ver_no;
                            SelectedItemsRRC.defect_class = POPUPEntityObject.def_class;
                           
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void ExecuteFormula(object InputValue)
        {
            try
            {
                if (RRCharactorSummuryCollection != null && SelectedItemsRRB != null)
                {
                    if (RRCharactorSummuryCollection.Count > 0 && SelectedItemsRRB.char_type=="N")
                    {
                        foreach (var row_item in RRCharactorSummuryCollection) // This loop for all rows of the colection and check for formula and evalute for all
                        {
                            if (!string.IsNullOrWhiteSpace(row_item.formula1))
                            {
                                NCalc.Expression ex = new NCalc.Expression(row_item.formula1);
                                foreach (var val in RRCharactorSummuryCollection)
                                {
                                    if (val.char_type == "N" && val.char_value != null)
                                    {
                                        ex.Parameters[val.fcode] = Convert.ToDouble(val.char_value);
                                    }
                                }
                                row_item.char_value = Math.Round(Convert.ToDouble(ex.Evaluate()),2).ToString();
                            }
                        }
                        //var item = RRCharactorSummuryCollection.Where(x => x.sample_no == SelectedItemsRRB.sample_no - 1).FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void ExecuteFormulaRRA(object InputValue)
        {
            try
            {
                if (RRSummuryCollection != null && SelectedItemsRRA != null)
                {
                    if (RRSummuryCollection.Count > 0 && SelectedItemsRRA.char_type == "N")
                    {
                        //QMS_T003_A.ModelEntityUpdated -= new EventHandler(ModelUpdated_QMS_T003_A);
                        foreach (var newObj in RRSummuryCollection) // This loop for all rows of the colection and check for formula and evalute for all
                        {
                            string formula = newObj.formula1;
                            string char_value = newObj.char_value;

                            if (!string.IsNullOrWhiteSpace(formula))
                            {
                                NCalc.Expression ex = new NCalc.Expression(formula);

                                foreach (var val_item in RRSummuryCollection)
                                {
                                    string val_char_type = val_item.char_type;
                                    string val_char_value = val_item.char_value;
                                    string val_fcode = val_item.fcode;

                                    if (formula.Contains(val_fcode))
                                    {
                                        if (val_char_type == "N" && !string.IsNullOrWhiteSpace(val_char_value) && IsNumeric(val_char_value))
                                        {
                                            ex.Parameters[val_fcode] = Convert.ToDouble(val_char_value);
                                        }
                                        else
                                        {
                                            continue;
                                            //val.char_value = null;
                                            //IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Parameter value for formula not valid for the parameter code {0} ", val.fcode, this.Title); sms.ShowMessage();
                                        }
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                try
                                {
                                    string strOutput = Math.Round(Convert.ToDouble(ex.Evaluate()), 2).ToString();
                                    if (strOutput != null)
                                    {
                                        newObj.char_value = strOutput;
                                    }
                                    //newObj.char_value = "123";
                                }
                                catch { continue; }
                                //row_item.char_value = ex.Evaluate().ToString();
                            }
                        }
                        //QMS_T003_A.ModelEntityUpdated -= new EventHandler(ModelUpdated_QMS_T003_A);
                        //QMS_T003_A.ModelEntityUpdated += new EventHandler(ModelUpdated_QMS_T003_A);
                        //var item = RRCharactorSummuryCollection.Where(x => x.sample_no == SelectedItemsRRB.sample_no - 1).FirstOrDefault();
                    }
                }
                //QMS_T003_A.ModelEntityUpdated -= ModelUpdated_QMS_T003_A;
                //QMS_T003_A.ModelEntityUpdated += ModelUpdated_QMS_T003_A;
            }
            catch (Exception ex)
            { }
        }
        private void ExecuteFormulaRRAOrg(object InputValue)
        {
            try
            {
                if (RRSummuryCollection != null && SelectedItemsRRA != null)
                {
                    if (RRSummuryCollection.Count > 0 && SelectedItemsRRA.char_type == "N")
                    {
                        QMS_T003_A.ModelEntityUpdated -= new EventHandler(ModelUpdated_QMS_T003_A);
                        foreach (var row_item in RRSummuryCollection) // This loop for all rows of the colection and check for formula and evalute for all
                        {
                            if (!string.IsNullOrWhiteSpace(row_item.formula1))
                            {
                                NCalc.Expression ex = new NCalc.Expression(row_item.formula1);
                                foreach (var val in RRSummuryCollection)
                                {
                                    if (row_item.formula1.Contains(val.fcode))
                                    {
                                        if (val.char_type == "N" && !string.IsNullOrWhiteSpace(val.char_value) && IsNumeric(val.char_value))
                                        {
                                            ex.Parameters[val.fcode] = Convert.ToDouble(string.IsNullOrWhiteSpace(val.char_value) ? 0 : int.Parse(val.char_value));
                                        }
                                        else
                                        {
                                            continue;
                                            //val.char_value = null;
                                            //IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Parameter value for formula not valid for the parameter code {0} ", val.fcode, this.Title); sms.ShowMessage();
                                        }
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                try
                                {
                                    if (row_item.char_value != Math.Round(Convert.ToDouble(ex.Evaluate()), 2).ToString())
                                    {
                                        QMS_T003_A.ModelEntityUpdated -= new EventHandler(ModelUpdated_QMS_T003_A);
                                        QMS_T003_A.ModelEntityUpdated += new EventHandler(ModelUpdated_QMS_T003_A);
                                        row_item.char_value = Math.Round(Convert.ToDouble(ex.Evaluate()), 2).ToString();
                                    }
                                }
                                catch { continue; }
                                //row_item.char_value = ex.Evaluate().ToString();
                            }
                        }
                        QMS_T003_A.ModelEntityUpdated -= new EventHandler(ModelUpdated_QMS_T003_A);
                        QMS_T003_A.ModelEntityUpdated += new EventHandler(ModelUpdated_QMS_T003_A);
                        //var item = RRCharactorSummuryCollection.Where(x => x.sample_no == SelectedItemsRRB.sample_no - 1).FirstOrDefault();
                    }
                }
                //QMS_T003_A.ModelEntityUpdated -= ModelUpdated_QMS_T003_A;
                //QMS_T003_A.ModelEntityUpdated += ModelUpdated_QMS_T003_A;
            }
            catch (Exception ex)
            { }
        }
        private void PreviousRRB(object InputValue)
        {
            try
            {
                if (RRCharactorSummuryCollection != null && SelectedItemsRRB != null)
                {
                    if (RRCharactorSummuryCollection.Count > 0 && SelectedItemsRRB.sample_no > 1)
                    {
                        var item = RRCharactorSummuryCollection.Where(x => x.sample_no == SelectedItemsRRB.sample_no - 1).FirstOrDefault();
                        if (item == null)
                        {
                            FilterSummuryResultRRB(SelectedItemsRRB.sample_no-1);
                        }
                        else
                        {
                            FilterSummuryResultRRB(SelectedItemsRRB.sample_no - 1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {}
        }
        private void NextRRB(object InputValue)
        {
            try
            {
                if (RRCharactorSummuryCollection != null && SelectedItemsRRB != null)
                {
                    if (RRCharactorSummuryCollection.Count > 0 && SelectedItemsRRB.sample_no < SelectedItemsRRA.sample_size)
                    {
                        var item = RRCharactorSummuryCollection.Where(x => x.sample_no == SelectedItemsRRB.sample_no + 1).FirstOrDefault();
                        if (item == null)
                        {
                            FilterSummuryResultRRB(SelectedItemsRRB.sample_no+1);
                        }
                        else
                        {
                            FilterSummuryResultRRB(SelectedItemsRRB.sample_no + 1);
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="InputValue"></param>
        private void GetSelectedValues(object InputValue)
        {
            try
            {
                if (RRCharactorSummuryCollection != null && SelectedItemsRRB != null && InputValue != null)
                {
                    //List<Classification> ObjRRBValue = (List<Classification>)InputValue;
                    foreach (Classification item in VALUE_COLLECTION)
                    {
                        if(item.selected==true)
                        {
                            SelectedItemsRRB.char_value = (SelectedItemsRRB.char_value ?? "") + "," + (item.char_value ?? "");
                            item.selected = false;
                        }
                    }
                    SelectedItemsRRB.char_value = (SelectedItemsRRB.char_value ?? "").TrimStart(',');
                    SelectedItemsRRB.char_value = UIServices.RemoveDuplicates(SelectedItemsRRB.char_value);
                    //string str = SelectedItemsRRB.char_value;
                    //List<string> uniques = new List<string>();
                    //uniques = str.Split(',').Reverse().Distinct().Take(100).Reverse().ToList();
                    //SelectedItemsRRB.char_value = string.Join(",", uniques);
                }
            }
            catch (Exception ex)
            { }
        }

        private void GotFocusRRBTextBox(object InputValue)
        {
            if (OpenRRBPopup != true)
            {
                OpenRRBPopup = true;
            }
        }
       
        void ModelUpdated_QMS_T003_A(object sender, EventArgs e)
        {
            try
            {
                if (sender.ToString() == "char_value" && RRSummuryCollection.Count > 0) 
                {
                    ResultValuationRRA(SelectedItemsRRA.char_value);
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>(); showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
        }
        void ModelUpdated_QMS_T003_B(object sender, EventArgs e)
        {
            try
            {
                this.ErrorExist = false;
                if (sender.ToString() == "char_value")
                {
                    ResultValuationRRB(SelectedItemsRRB.char_value);
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>(); showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
        }
        void ModelUpdated_QMS_T003_C(object sender, EventArgs e)
        {
            try
            {
                if (sender.ToString() == "char_value" && SelectedItemsRRC != null)
                {
                    if (!string.IsNullOrWhiteSpace(SelectedItemsRRC.char_value))
                    {
                        ResultValuationRRC(SelectedItemsRRC.char_value);
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>(); showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
        }
        private void FilterSingleResult()
        {
            try
            {
                if (SelectedItemsRRB != null && RRCharactorSummuryCollection != null && RRCharactorSummuryCollection.Count > 0)
                {
                    int RRS_Count = RRCharactorSummuryCollection.Where(x => x.char_code == SelectedItemsRRA.char_code && x.sample_no == SelectedItemsRRA.sample_no).ToList().Count;
                    if (RRS_Count == 0)
                    {
                        for (int i = 0; i < SelectedItemsRRA.sample_size; i++)
                        {
                            RRS_Count = RRSingleCollection.Where(x => x.char_code == SelectedItemsRRA.char_code && x.sample_no == SelectedItemsRRA.sample_no).ToList().Count;
                            RRSingleCollection.Add(new QMS_T003_C { id = 0, line_id_a = SelectedItemsRRB.line_no, a_row_id = SelectedItemsRRB.id, active = "1", add_date = DateTime.Now, sample_size = SelectedItemsRRA.sample_size, attribute = SelectedItemsRRB.attribute, char_code = SelectedItemsRRB.char_code, char_name = SelectedItemsRRB.char_name, client = AppSessionState.client, color_code = SelectedItemsRRB.color_code, comp_code = SelectedItemsRRB.comp_code, doc_no = SelectedItemsRRB.doc_no, end_date = SelectedItemsRRB.end_date, equipment = SelectedItemsRRA.equipment, ind_complete = SelectedItemsRRA.ind_complete, ind_equipment = SelectedItemsRRB.ind_equipment, inspector = SelectedItemsRRB.inspector, char_type = SelectedItemsRRB.char_type, mic_line_id = SelectedItemsRRB.mic_line_id, sample_no = SelectedItemsRRA.sample_no, specifications = SelectedItemsRRA.specifications, version = SelectedItemsRRB.version,start_date = SelectedItemsRRA.start_date, rr_number = RRS_Count + 1, line_no = RRCharactorSummuryCollection.Count + 1, single_unit_lot = RRS_Count + 1, low_limit = SelectedItemsRRB.low_limit, up_limit = SelectedItemsRRB.up_limit });
                            RRS_Count++;
                        }
                    }
                    SingleResultCollectionFilter = CollectionViewSource.GetDefaultView(RRSingleCollection);
                    SingleResultCollectionFilter.Filter = adv => ((QMS_T003_C)adv).op_no.Equals(SelectedItemsRRA.op_no) && ((QMS_T003_C)adv).char_code.Equals(SelectedItemsRRB.char_code);
                    SingleResultCollectionFilter.Refresh();
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void FilterSummuryResultRRB(int? Sample_No)
        {
            try
            {
                if (SelectedItemsRRB != null && RRCharactorSummuryCollection != null && RRCharactorSummuryCollection.Count > 0)
                {
                    int RRS_Count = RRCharactorSummuryCollection.Where(x => x.sample_no == Sample_No).ToList().Count;
                    var data = RRCharactorSummuryCollection.Where(x => x.sample_no == SelectedItemsRRA.sample_no).ToList();
                    int CharCount = RRCharactorSummuryCollection.Where(x => x.sample_no == SelectedItemsRRA.sample_no).ToList().Count();
                    if (RRS_Count == 0)
                    {
                        for (int i = 0; i < CharCount; i++)
                        {
                            QMS_T003_B OBJ_B = data[i];
                            RRCharactorSummuryCollection.Add(new QMS_T003_B { id = 0, line_no = i+1, sample_no= Sample_No, valid_sample_no = Sample_No, r_status = OBJ_B.r_status,sample_recorded=Sample_No,above_values= OBJ_B.above_values, below_values= OBJ_B.below_values,sample_inspected=Sample_No,max_value= OBJ_B.max_value,min_value= OBJ_B.min_value,median_value= OBJ_B.median_value,mean_value= OBJ_B.mean_value,sample_valid=Sample_No, active = "1", add_date = DateTime.Now, sample_size = OBJ_B.sample_size, attribute = OBJ_B.attribute, char_code = OBJ_B.char_code, char_name = OBJ_B.char_name, client = AppSessionState.client, color_code = OBJ_B.color_code, comp_code = OBJ_B.comp_code, doc_no = OBJ_B.doc_no,end_date = OBJ_B.end_date, equipment = OBJ_B.equipment, ind_complete = OBJ_B.ind_complete, ind_equipment = OBJ_B.ind_equipment, inspector = OBJ_B.inspector, char_type = OBJ_B.char_type, mic_line_id = OBJ_B.mic_line_id, specifications = OBJ_B.specifications, version = OBJ_B.version, start_date = OBJ_B.start_date, low_limit = OBJ_B.low_limit, up_limit = OBJ_B.up_limit });
                        }
                    }
                    SelectedItemsRRB = RRCharactorSummuryCollection.Where(x => x.sample_no == Sample_No).FirstOrDefault();
                    DataGridViewFilter = CollectionViewSource.GetDefaultView(RRCharactorSummuryCollection);
                    DataGridViewFilter.Filter = adv => ((QMS_T003_B)adv).sample_no.Equals(Sample_No);
                    DataGridViewFilter.Refresh();
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void OpenDocumentViewer(object InputValue)
        {
            WebServiceRepository<MultipleContext_Attachments> repository_MCAttachments = new WebServiceRepository<MultipleContext_Attachments>();
            List<COM_T003> Attachments = new List<COM_T003>();
            QMS_T003_A EntityObjectParameter = new QMS_T003_A();
            MultipleContext_Attachments MCAttachments = new MultipleContext_Attachments();
            try
            {
                string Request = "GetAllFiles" + "!@" + doc_no_vm;
                //MCAttachments = repository_MCAttachments.GetData<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Reflection.BusinessLogic.ReflectionFileHandlingServices");
                MCAttachments = repository_MCAttachments.GetDataWithReturnDomainObject<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Administration", "LoadDocumentByDocumentNumber", 0, "");
                if (!string.IsNullOrEmpty(doc_no_vm))
                {
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = doc_no_vm.Replace("/", "--"), DocumentList = MCAttachments.Attachments });
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }

        private bool Validation()
        {
            try
            {
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
            return true;
        }
        private void Visibility_RRA_Call(object InputValue)
        {
            try
            {
                Visibility_RRA = Visibility.Visible;
                Visibility_RRB = Visibility.Collapsed;
                Visibility_RRC = Visibility.Collapsed;
                if (SelectedItemsRRC != null)
                {
                    if (!string.IsNullOrWhiteSpace(SelectedItemsRRC.char_value) && SelectedItemsRRA.char_type == "N" && SelectedItemsRRC.char_type == "N")
                    {
                        double? dcMaxValue = RRSingleCollection.Where(x => x.op_no == SelectedItemsRRC.op_no && x.char_code == SelectedItemsRRC.char_code).Max(x => x.measured_value).Value; //measured_value
                        double? dcMinValue = RRSingleCollection.Where(x => x.op_no == SelectedItemsRRC.op_no && x.char_code == SelectedItemsRRC.char_code).Min(x => (double?)Convert.ToDouble(x.char_value)).Value; //measured_value
                        double? dcAverageValue = RRSingleCollection.Where(x => x.op_no == SelectedItemsRRC.op_no && x.char_code == SelectedItemsRRC.char_code).Average(x => (double?)Convert.ToDouble(x.char_value)).Value; //measured_value
                        SelectedItemsRRA.max_value = Math.Round(Convert.ToDouble(dcMaxValue), 2);
                        SelectedItemsRRA.min_value = Math.Round(Convert.ToDouble(dcMinValue), 2);
                        SelectedItemsRRA.mean_value = Math.Round(Convert.ToDouble(dcAverageValue), 2);
                        SelectedItemsRRA.char_value = Math.Round(Convert.ToDouble(dcAverageValue), 2).ToString();
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void Visibility_RRB_Call(object InputValue)
        {
            try
            {
                Visibility_RRA = Visibility.Collapsed;
                Visibility_RRB = Visibility.Visible;
                Visibility_RRC = Visibility.Collapsed;
                if (SelectedItemsRRC != null)
                {
                    if (!string.IsNullOrWhiteSpace(SelectedItemsRRC.char_value) && SelectedItemsRRB.char_type == "N" && SelectedItemsRRC.char_type == "N")
                    {
                        double dcMaxValue = RRSingleCollection.Where(x => x.op_no == SelectedItemsRRC.op_no && x.char_code == SelectedItemsRRC.char_code).Max(x => x.measured_value).Value; //measured_value
                        double dcMinValue = RRSingleCollection.Where(x => x.op_no == SelectedItemsRRC.op_no && x.char_code == SelectedItemsRRC.char_code).Min(x => (double?)Convert.ToDouble(x.char_value)).Value; //measured_value
                        double dcAverageValue = RRSingleCollection.Where(x => x.op_no == SelectedItemsRRC.op_no && x.char_code == SelectedItemsRRC.char_code).Average(x => (double?)Convert.ToDouble(x.char_value)).Value; //measured_value
                        SelectedItemsRRB.max_value = Math.Round(dcMaxValue, 2);
                        SelectedItemsRRB.min_value = Math.Round(dcMinValue, 2);
                        SelectedItemsRRB.mean_value = Math.Round(dcAverageValue, 2);
                        SelectedItemsRRB.char_value = Math.Round(dcAverageValue, 2).ToString();
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void Visibility_RRC_Call(object InputValue)
        {
            Visibility_RRA = Visibility.Collapsed;
            Visibility_RRB = Visibility.Collapsed;
            Visibility_RRC = Visibility.Visible;
            FilterSingleResult();
        }

        private void Inspection_Processing_DR_Call(object item)
        {
            try
            {
                if (((IEnumerable)item).Cast<QMS_T003>().ToList().Count > 0)
                {
                    QMS_T003 ParameterEntityObject = ((IEnumerable)item).Cast<QMS_T003>().ToList()[0];
                    AppSessionState.ViewTitle = "Inspection Processing : Defect Recording";
                    string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.QMS.dll");
                    Assembly assembly = Assembly.LoadFile(path1);
                    Type type = assembly.GetType("Reflection.Modules.QMS.Views.QMS_T013");
                    if (type != null)
                    {
                        dynamic instance = Activator.CreateInstance(type, "QM30", ParameterEntityObject.doc_no, ParameterEntityObject, "INSP_CHR");
                        SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        #endregion
        #region Abstract Commands

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        protected override void OnCreateAction(InquiryActionResult<QMS_T003_A> result)
        {
            //throw new NotImplementedException();
        }
        protected override void OnDiscardAction(InquiryActionResult<QMS_T003_A> result)
        {
            //throw new NotImplementedException();
        }
        protected override void OnDocumentAction()
        {
            //throw new NotImplementedException();
        }
        protected override void OnFevoriteAction(InquiryActionResult<QMS_T003_A> result)
        {
            //throw new NotImplementedException();
        }
        protected override void OnFlipAction(InquiryActionResult<QMS_T003_A> result)
        {
            //throw new NotImplementedException();
        }
        protected override void OnHelpAction(InquiryActionResult<QMS_T003_A> result)
        {
            //throw new NotImplementedException();
        }
        protected override void OnPrintAction(InquiryActionResult<QMS_T003_A> result)
        {
            try
            {
                CursorControl.SetBusyState();
                string ReportName = "";
                string Request = "PRINT_RR" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_no + "!@" + MasterEntity.tl_code;
                MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_QMS_T003>(MC_TEMP, Request, "QMS_T003_BL", "QMS", "LOAD_INI_SUM_RR", 0, "");

                object[] objDataSource = new object[1];
                string[] objDataSourceName = new string[1];

                objDataSource[0] = MC_TEMP.STD_MIS_LIST;
                objDataSourceName[0] = "dsMIS_1";

                //object[] objDataSource = new object[7];
                //string[] objDataSourceName = new string[7];

                //List<ADM_M002> TempCmpList = (List<ADM_M002>);
                //var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                //objDataSource[0] = CmpResult;

                //List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                //var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_id).ToList();
                //objDataSource[1] = Result;

                //if (MC_TEMP.MASTER_LIST != null)
                //{
                //    if (MC_TEMP.MASTER_LIST.Count > 0)
                //    {
                //        MC_TEMP.MASTER_LIST.Clear();
                //        MC_TEMP.MASTER_LIST.Add(MasterEntity);
                //    }
                //    else
                //    {
                //        MC.MASTER_LIST.Add(_MasterEntity);
                //    }
                //}



                //objDataSource[2] = MC.MASTER_LIST;
                //objDataSource[3] = RRSummuryCollection;
                //objDataSource[4] = RRCharactorSummuryCollection;
                //objDataSource[5] = RRSingleCollection;

                //objDataSourceName[0] = "dsCompany";
                //objDataSourceName[1] = "dsLocation";
                //objDataSourceName[2] = "dsMaster";
                //objDataSourceName[3] = "dsSummury";
                //objDataSourceName[4] = "dsCharSummury";
                //objDataSourceName[5] = "dsSingleSummury";

                ReportManager ReportManager = new ReportManager();

                var SystemDocumentObject = (from o in MC.DOC_TYPE_LIST where o.doc_cat == MasterEntity.doc_cat && o.doc_type == MasterEntity.doc_type select o).ToList();
                ReportName = SystemDocumentObject[0].report_name.Split(',')[0];
                //ReportName = "IL_C001.rdlc";

                //string ReportDisplayName = SystemDocumentObject[0].doc_type_name; // + "_" + MasterEntity.doc_no + "_" + MasterEntity.doc_date.Value.ToShortDateString();
                string ReportDisplayName = "PDI Inspection Report";
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\REPORTS_STD\\TXN\\" + ReportName, getParametersList(), ReportDisplayName);
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                //result.Add("comp_code", Convert.ToString(REQ_PARA_OBJ.comp_code));
                //result.Add("comp_name", Convert.ToString(REQ_PARA_OBJ.comp_name));
                //result.Add("para1", Convert.ToString(REQ_PARA_OBJ.para4));
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();

            }
            return result;
        }
        protected override void OnRemoveAction(InquiryActionResult<QMS_T003_A> result)
        {
            //throw new NotImplementedException();
        }
        protected override void OnSaveAction(InquiryActionResult<QMS_T003_A> result)
        {
            try
            {
                if (Validation() == true)
                {
                    Logging();
                    MasterEntity.XDOC_A = obj.ObjectToXML(RRSummuryCollection);
                    MasterEntity.XDOC_B = obj.ObjectToXML(RRCharactorSummuryCollection);
                    MasterEntity.XDOC_C = obj.ObjectToXML(RRSingleCollection);

                    QMS_T003 MasterEntityTemp = REPO.SaveWithReturnDomainObject<QMS_T003>(MasterEntity, "QMS_T012_BL", "QMS");
                    if (MasterEntityTemp.XDOC_A != null)
                    {
                        //RRSummuryCollection.Clear();
                        RRSummuryCollection = (ObservableCollection<QMS_T003_A>)new ObjectSerializationService().XMLToObject(MasterEntityTemp.XDOC_A, RRSummuryCollection);
                        if (RRSummuryCollection.Count > 0)
                        {
                            SelectedItemsRRA = RRSummuryCollection[0];
                        }
                    }
                    else
                    {
                        RRSummuryCollection = new ObservableCollection<QMS_T003_A>();
                    }
                    if (MasterEntityTemp.XDOC_C != null)
                    {
                        //RRSingleCollection.Clear();
                        RRSingleCollection = (ObservableCollection<QMS_T003_C>)new ObjectSerializationService().XMLToObject(MasterEntityTemp.XDOC_C, RRSingleCollection);
                    }
                    else
                    {
                        RRSingleCollection = new ObservableCollection<QMS_T003_C>();
                    }
                }
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<QMS_T003_A> result)
        {
            //throw new NotImplementedException();
        }
        protected override void OnLedgerViewCommand(InquiryActionResult<QMS_T003_A> result)
        {
            //throw new NotImplementedException();
        }
        protected override void OnValidateCommand(InquiryActionResult<QMS_T003_A> result)
        {
            //throw new NotImplementedException();
        }
        protected override void OnTraceCommand(InquiryActionResult<QMS_T003_A> result)
        {
            //throw new NotImplementedException();
        }
        protected override void OnMailCommand(InquiryActionResult<QMS_T003_A> result)
        {
            //throw new NotImplementedException();
        }

        #endregion


        public static bool IsNumeric(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            // Check for int, long, float, double, decimal, etc.
            return int.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out _) ||
                   long.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out _) ||
                   float.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out _) ||
                   double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out _) ||
                   decimal.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out _);
        }
    }
}
