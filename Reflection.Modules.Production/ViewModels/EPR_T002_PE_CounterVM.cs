using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Reflection.ReportingServices;
using Reflection.BusinessEntity.Admin;

namespace Reflection.Modules.Production.ViewModels
{
    class EPR_T002_PE_CounterVM : WorkspaceViewModel<EPR_T002>
    {
        #region Variable Declaration
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        bool isNewRecord = true;
        bool Flag = false;
        WebServiceRepository<List<EPR_T002>> repository = new WebServiceRepository<List<EPR_T002>>();
        WebServiceRepository<MultipleContext_EPR_T002> repositoryM = new WebServiceRepository<MultipleContext_EPR_T002>();
        WebServiceRepository<MultipleContext_EPR_T002> repository_MC = new WebServiceRepository<MultipleContext_EPR_T002>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private MultipleContext_EPR_T002 _MC = new MultipleContext_EPR_T002();
        public MultipleContext_EPR_T002 MC
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

        private MultipleContext_EPR_T002 _MCTemp = new MultipleContext_EPR_T002();
        public MultipleContext_EPR_T002 MCTemp
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

        private MultipleContext_EPR_T002 _MCTemp2 = new MultipleContext_EPR_T002();
        public MultipleContext_EPR_T002 MCTemp2
        {
            get { return _MCTemp2; }
            set
            {
                if (_MCTemp2 != value)
                {
                    _MCTemp2 = value; RaisePropertyChanged("MCTemp2");
                }
            }
        }

        private ObservableCollection<EPR_T002> _MasterEntity;
        //Data source for Items DataGrid
        public ObservableCollection<EPR_T002> MasterEntity
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
                    RaisePropertyChanged("MasterEntity");
                }
            }
        }

        private List<EPR_T002> _TobeSaveEntity = new List<EPR_T002>();
        //Data source for Items DataGrid
        public List<EPR_T002> TobeSaveEntity
        {
            get
            {
                return _TobeSaveEntity;
            }
            set
            {
                if (_TobeSaveEntity != value)
                {
                    _TobeSaveEntity = value;
                    RaisePropertyChanged("TobeSaveEntity");
                }
            }
        }

        // This Object is Used for backflip Searching
        private EPR_T002 _SelectedEPR_T002;
        public EPR_T002 SelectedEPR_T002
        {
            get
            {
                return _SelectedEPR_T002;
            }
            set
            {
                if (_SelectedEPR_T002 != value)
                {
                    _SelectedEPR_T002 = value;
                    RaisePropertyChanged("SelectedEPR_T002");
                }
            }
        }

        private ObservableCollection<EPR_T002> _BackFlipEntity;
        //Data source for Items DataGrid
        public ObservableCollection<EPR_T002> BackFlipEntity
        {
            get
            {
                return _BackFlipEntity;
            }
            set
            {
                if (_BackFlipEntity != value)
                {
                    _BackFlipEntity = value;
                    RaisePropertyChanged("BackFlipEntity");
                }
            }
        }

        private EPR_T002 _TempCollection;
        public EPR_T002 TempCollection
        {
            get
            {
                return _TempCollection;
            }
            set
            {
                if (_TempCollection != value)
                {
                    _TempCollection = value;
                    RaisePropertyChanged("TempCollection");
                }
            }
        }

        private int _dgSelectedIndex;
        public int dgSelectedIndex
        {
            get
            {
                return _dgSelectedIndex;
            }
            set
            {
                if (_dgSelectedIndex != value)
                {
                    _dgSelectedIndex = value;
                    RaisePropertyChanged("dgSelectedIndex");
                }
            }
        }

        private DateTime? _Date;
        public DateTime? Date
        {
            get
            {
                return _Date;
            }
            set
            {
                if (_Date != value)
                {
                    _Date = value;
                    RaisePropertyChanged("Date");
                }
            }
        }

        private List<ADM_M042_P> _Shift;
        public List<ADM_M042_P> Shift
        {
            get
            {
                return _Shift;
            }
            set
            {
                if (_Shift != value)
                {
                    _Shift = value;
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
        #endregion

        #region ICollection for Popup Control

        private ICollectionView _UnitCollection;
        public ICollectionView UnitCollection
        {
            get { return _UnitCollection; }
            set
            {
                _UnitCollection = value;
                RaisePropertyChanged("UnitCollection");
            }
        }

        private ICollectionView _PkgUnitCollection;
        public ICollectionView PkgUnitCollection
        {
            get { return _PkgUnitCollection; }
            set
            {
                _PkgUnitCollection = value;
                RaisePropertyChanged("PkgUnitCollection");
            }
        }

        private ICollectionView _CustomerProductCollection;
        public ICollectionView CustomerProductCollection
        {
            get { return _CustomerProductCollection; }
            set
            {
                _CustomerProductCollection = value;
                RaisePropertyChanged("CustomerProductCollection");
            }
        }

        private ICollectionView _BallMakeCollection;
        public ICollectionView BallMakeCollection
        {
            get { return _BallMakeCollection; }
            set
            {
                _BallMakeCollection = value;
                RaisePropertyChanged("BallMakeCollection");
            }
        }

        private ICollectionView _WireMakeCollection;
        public ICollectionView WireMakeCollection
        {
            get { return _WireMakeCollection; }
            set
            {
                _WireMakeCollection = value;
                RaisePropertyChanged("WireMakeCollection");
            }
        }

        private ICollectionView _ShiftCollection;
        public ICollectionView ShiftCollection
        {
            get { return _ShiftCollection; }
            set
            {
                _ShiftCollection = value;
                RaisePropertyChanged("ShiftCollection");
            }
        }

        private ICollectionView _BShiftCollection;
        public ICollectionView BShiftCollection
        {
            get { return _BShiftCollection; }
            set
            {
                _BShiftCollection = value;
                RaisePropertyChanged("BShiftCollection");
            }
        }

        private ICollectionView _MachineCollection;
        public ICollectionView MachineCollection
        {
            get { return _MachineCollection; }
            set
            {
                _MachineCollection = value;
                RaisePropertyChanged("MachineCollection");
            }
        }

        private ICollectionView _BPkgUnitCollection;
        public ICollectionView BPkgUnitCollection
        {
            get { return _BPkgUnitCollection; }
            set
            {
                _BPkgUnitCollection = value;
                RaisePropertyChanged("BPkgUnitCollection");
            }
        }

        private ICollectionView _ItemCollection;
        public ICollectionView ItemCollection
        {
            get { return _ItemCollection; }
            set
            {
                _ItemCollection = value;
                RaisePropertyChanged("ItemCollection");
            }
        }

        private ICollectionView _InkCollection;
        public ICollectionView InkCollection
        {
            get { return _InkCollection; }
            set
            {
                _InkCollection = value;
                RaisePropertyChanged("InkCollection");
            }
        }

        private ICollectionView _IldCollection;
        public ICollectionView IldCollection
        {
            get { return _IldCollection; }
            set
            {
                _IldCollection = value;
                RaisePropertyChanged("IldCollection");
            }
        }

        private ICollectionView _BackFlipCollection;
        public ICollectionView BackFlipCollection
        {
            get { return _BackFlipCollection; }
            set
            {
                _BackFlipCollection = value;
                RaisePropertyChanged("BackFlipCollection");
            }
        }

        private ICollectionView _GradeCollection;
        public ICollectionView GradeCollection
        {
            get { return _GradeCollection; }
            set
            {
                _GradeCollection = value;
                RaisePropertyChanged("GradeCollection");
            }
        }

        private ICollectionView _GradeCollection2;
        public ICollectionView GradeCollection2
        {
            get { return _GradeCollection2; }
            set
            {
                _GradeCollection2 = value;
                RaisePropertyChanged("GradeCollection2");
            }
        }

        private ICollectionView _BreakdownReasonCollection;
        public ICollectionView BreakdownReasonCollection
        {
            get { return _BreakdownReasonCollection; }
            set
            {
                _BreakdownReasonCollection = value;
                RaisePropertyChanged("BreakdownReasonCollection");
            }
        }
        private ICollectionView _RemarksCollection;
        public ICollectionView RemarksCollection
        {
            get { return _RemarksCollection; }
            set
            {
                _RemarksCollection = value;
                RaisePropertyChanged("RemarksCollection");
            }
        }
        #endregion

        #region StringList Variables

        private List<string> _stringListUOM;
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

        private List<string> _stringListPkgUOM;
        public List<string> StringListPkgUOM
        {
            get { return _stringListPkgUOM; }
            set
            {
                if (_stringListPkgUOM != value)
                {
                    _stringListPkgUOM = value;
                }
            }
        }

        private List<string> _stringListWireMake;
        public List<string> StringListWireMake
        {
            get { return _stringListWireMake; }
            set
            {
                if (_stringListWireMake != value)
                {
                    _stringListWireMake = value;
                }
            }
        }

        private List<string> _stringListBallMake;
        public List<string> StringListBallMake
        {
            get { return _stringListBallMake; }
            set
            {
                if (_stringListBallMake != value)
                {
                    _stringListBallMake = value;
                }
            }
        }

        private List<string> _stringListCustProd;
        public List<string> StringListCustProd
        {
            get { return _stringListCustProd; }
            set
            {
                if (_stringListCustProd != value)
                {
                    _stringListCustProd = value;
                }
            }
        }

        private List<string> _stringListBreakdownReason;
        public List<string> StringListBreakdownReason
        {
            get { return _stringListBreakdownReason; }
            set
            {
                if (_stringListBreakdownReason != value)
                {
                    _stringListBreakdownReason = value;
                }
            }
        }
        #endregion

        #region Relay Commands Declaration
        public RelayCommand CommandLoadIldDetails { get; private set; }
        public RelayCommand<object> CommandUnit { get; private set; }
        public RelayCommand<object> CommandPkgUnit { get; private set; }
        public RelayCommand<object> CommandCustomerProduct { get; private set; }
        public RelayCommand<object> CommandBallMake { get; private set; }
        public RelayCommand<object> CommandWireMake { get; private set; }
        public RelayCommand<object> cmdCopyAndPaste { get; private set; }
        public RelayCommand<object> cmdMachineOperator { get; private set; }
        public RelayCommand<object> cmdBreakdownReason { get; private set; }

        // BackFlip
        public RelayCommand<IList> CommandMachine { get; private set; }
        public RelayCommand<IList> CommandBPkgUnit { get; private set; }
        public RelayCommand<IList> CommandItem { get; private set; }
        public RelayCommand<IList> CommandInk { get; private set; }
        public RelayCommand<IList> CommandIld { get; private set; }
        public RelayCommand CommandLoadLabelGenration { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> CommandRemarks { get; private set; }
        #endregion



        #region Constructor
        public EPR_T002_PE_CounterVM(string ts_code): base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new ObservableCollection<EPR_T002>();
            SelectedEPR_T002 = new EPR_T002();
            TempCollection = new EPR_T002();
            MC = new MultipleContext_EPR_T002();
            MCTemp = new MultipleContext_EPR_T002();
            MCTemp2 = new MultipleContext_EPR_T002();
            PrintOption = "All";
            SelectedEPR_T002.client = AppSessionState.client;
            TempCollection.client = AppSessionState.client;
            SelectedEPR_T002.user_source1 = AppSessionState.UserSource1;
            SelectedEPR_T002.user_source2 = AppSessionState.UserSource2;
            SelectedEPR_T002.userid = AppSessionState.UserID;
            SelectedEPR_T002.record_type = "01";
            Date = DateTime.Now;

            LoadInitialData();
        }
        public EPR_T002_PE_CounterVM(string ts_code,string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new ObservableCollection<EPR_T002>();
            SelectedEPR_T002 = new EPR_T002();
            TempCollection = new EPR_T002();
            MC = new MultipleContext_EPR_T002();
            MCTemp = new MultipleContext_EPR_T002();
            MCTemp2 = new MultipleContext_EPR_T002();
            PrintOption = "All";
            SelectedEPR_T002.client = AppSessionState.client;
            TempCollection.client = AppSessionState.client;
            SelectedEPR_T002.user_source1 = AppSessionState.UserSource1;
            SelectedEPR_T002.user_source2 = AppSessionState.UserSource2;
            SelectedEPR_T002.userid = AppSessionState.UserID;
            SelectedEPR_T002.record_type = "01";
            Date = DateTime.Now;

            LoadInitialData();
        }
        #endregion

        #region UserDefinedFunctions

        private void LoadInitialData()
        {
            string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id;
            MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T002>(MC, Request, "LabelGenerationMaster", "Production", "LoadAll", 0, "");

            #region Command Initialisation

            CommandLoadIldDetails = new RelayCommand(() => { LoadIldDetails(); });
            CommandUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUOM(cmdPara, false, true, true); });
            CommandPkgUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertPkgUOM(cmdPara, false, true, true); });
            CommandCustomerProduct = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCustomerProduct(cmdPara, false, true, true); });
            CommandBallMake = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertBallMake(cmdPara, false, true, true); });
            CommandWireMake = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertWireMake(cmdPara, false, true, true); });
            cmdCopyAndPaste = new RelayCommand<object>(items => { if (items == null) { return; } InsertRow_CopyPaste(items); });
            cmdMachineOperator = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertMachineOperator(cmdPara, false, true, true); });
            cmdBreakdownReason = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertBreakdownReason(cmdPara, false, true, true); });

            //BackFlip
            CommandLoadLabelGenration = new RelayCommand(() => { LoadLabelGenerationDetails(); });
            CommandMachine = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertMachine(cmdPara); });
            CommandBPkgUnit = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertBPkgUnit(cmdPara); });
            CommandItem = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertItem(cmdPara); });
            CommandInk = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertInk(cmdPara); });
            CommandIld = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertIld(cmdPara); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
            CommandRemarks = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertRemarks(cmdPara, false, true, true); });
            #endregion
            UnitCollection = CollectionViewSource.GetDefaultView(MC.UnitList);
            UnitCollection.Filter = new Predicate<object>(Filter_Unit);
            StringListUOM = MC.UnitList.Select(x => x.unit_code).ToList();

            PkgUnitCollection = CollectionViewSource.GetDefaultView(MC.PkgUnitList);
            PkgUnitCollection.Filter = new Predicate<object>(Filter_PkgUnit);
            StringListPkgUOM = MC.PkgUnitList.Select(x => x.pkgunit).ToList();

            CustomerProductCollection = CollectionViewSource.GetDefaultView(MC.CustomerProductList);
            CustomerProductCollection.Filter = new Predicate<object>(Filter_CustProduct);
            StringListCustProd = MC.CustomerProductList.Select(x => x.CustomerProductName).ToList();

            BallMakeCollection = CollectionViewSource.GetDefaultView(MC.BallMakeList);
            BallMakeCollection.Filter = new Predicate<object>(Filter_BallMake);
            StringListBallMake = MC.BallMakeList.Select(x => x.Make).ToList();

            WireMakeCollection = CollectionViewSource.GetDefaultView(MC.WireMakeList);
            WireMakeCollection.Filter = new Predicate<object>(Filter_WireMake);
            StringListWireMake = MC.WireMakeList.Select(x => x.Make).ToList();

            Shift = (from o in MC.ShiftList where o.shift != "All" select o).ToList();
            ShiftCollection = CollectionViewSource.GetDefaultView(Shift);

            BShiftCollection = CollectionViewSource.GetDefaultView(MC.ShiftList);

            var grade = (from o in MC.GradeList where o.grade_code != "All" select o).ToList();
            GradeCollection = CollectionViewSource.GetDefaultView(grade.ToList());

            GradeCollection2 = CollectionViewSource.GetDefaultView(MC.GradeList);

            BreakdownReasonCollection = CollectionViewSource.GetDefaultView(MC.BreakdownReasonList);
            BreakdownReasonCollection.Filter = new Predicate<object>(Filter_bdr);
            StringListBreakdownReason = MC.BreakdownReasonList.Select(x => x.bdr_code).ToList();

            MachineCollection = CollectionViewSource.GetDefaultView(MC.MachineList);
            MachineCollection.Filter = new Predicate<object>(Filter_Machine);

            BPkgUnitCollection = CollectionViewSource.GetDefaultView(MC.BPkgUnitList);
            BPkgUnitCollection.Filter = new Predicate<object>(Filter_BPkgUnit);

            ItemCollection = CollectionViewSource.GetDefaultView(MC.ItemList);
            ItemCollection.Filter = new Predicate<object>(Filter_ItemCode);

            InkCollection = CollectionViewSource.GetDefaultView(MC.BInkList);
            InkCollection.Filter = new Predicate<object>(Filter_Ink);

            IldCollection = CollectionViewSource.GetDefaultView(MC.BIldList);
            IldCollection.Filter = new Predicate<object>(Filter_Ild);

            RemarksCollection = CollectionViewSource.GetDefaultView(MC.Remarks);
            RemarksCollection.Filter = new Predicate<object>(Filter_Remarks);


        }
        private void LoadIldDetails()
        {
            try
            {
                if (Date == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.OkCancel;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select production date ", this.Title);
                    showMessageService.ShowMessage();
                }
                else
                {
                    string Request = "LoadIldDetailsForPE" + "!@" + Convert.ToDateTime(Date).ToString("MM/dd/yyyy") + "!@" + AppSessionState.location_Id; 
                    MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T002>(MC, Request, "LabelGenerationMaster", "Production", "LoadAll", 0, "");

                    foreach (var o in MC.LabelGenerationFromILD)
                    {
                        int IndexOfExistRow = MasterEntity.IndexOf(MasterEntity.Where(X => X.shift == o.shift && X.ItemCode == o.ItemCode
                                                && X.ink_id == o.ink_id && X.ild_id == o.ild_id && X.wire_make == o.wire_make && X.ball_make
                                                == o.ball_make && X.machine_id == o.machine_id && X.active == true && X.prod_dt == Date && X.barcode == o.barcode).FirstOrDefault());
                        //int IndexOfExistRow = MasterEntity.IndexOf(MasterEntity.Where(X => X.ItemCode == o.ItemCode
                        //                       && X.ink_id == o.ink_id && X.ild_id == o.ild_id && X.wire_make == o.wire_make && X.ball_make
                        //                       == o.ball_make && X.machine_id == o.machine_id && X.active == true && X.prod_dt == Date).FirstOrDefault());

                        if (IndexOfExistRow == -1)
                        {
                            o.entry_dt = DateTime.Now;
                            o.add_by = AppSessionState.UserID;
                            o.editby = AppSessionState.UserID;
                            o.location_Id = AppSessionState.location_Id;
                            o.comp_code = AppSessionState.comp_code;
                            o.client = AppSessionState.client;
                            o.doc_cat = "02";
                            o.doc_type = "02";
                            o.active = true;
                            o.prod_dt = Date;
                            o.grade = "A";

                            MasterEntity.Add(o);
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
            dgSelectedIndex = dgSelectedIndex;
            #region Command Parameter Read Section
            // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
            if (InputValue.GetType() == typeof(string) && InputValue != null)
            {
                //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                Request = InputValue.ToString();
                if (Request.Length > 0)
                {
                    try
                    { POPUPEntityObject = MC.UnitList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                    catch (Exception ex) { }
                }
            }
            else if (((IEnumerable)InputValue).Cast<ADM_M038_B_P>().Count() > 0)
            {
                POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
            }

            #endregion

            if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
            {
                var InputValueIfExists = MasterEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                if (dgSelectedIndex >= 0 && MasterEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                {
                    if (MasterEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    {
                        MasterEntity[dgSelectedIndex].unit_code = POPUPEntityObject.unit_code;
                    }
                    else if (MasterEntity[dgSelectedIndex].unit_code != POPUPEntityObject.unit_code)
                    {
                        MasterEntity[dgSelectedIndex].unit_code = POPUPEntityObject.unit_code;
                    }
                }
            }
            #region Clear Empty Row
            EPR_T002 newObj = new EPR_T002();
            for (int i = MasterEntity.Count - 1; i >= 0; i--)
            {
                bool xx = MasterEntity[i].ComparePropertiesTo(newObj);
                if (MasterEntity[i].ComparePropertiesTo(newObj) == true && MasterEntity.Count > 1)
                {
                    MasterEntity.RemoveAt(i);
                    if (MasterEntity.Count == 0)
                    {
                        MasterEntity.Add(newObj);
                    }
                }
            }
            #endregion
        }
        private void InsertPkgUOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ZADM_M017_P POPUPEntityObject = null;
            dgSelectedIndex = dgSelectedIndex;
            #region Command Parameter Read Section
            // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
            if (InputValue.GetType() == typeof(string) && InputValue != null)
            {
                //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                Request = InputValue.ToString();
                if (Request.Length > 0)
                {
                    try
                    { POPUPEntityObject = MC.PkgUnitList.Where(x => x.pkgunit.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                    catch (Exception ex) { }
                }
            }
            else if (((IEnumerable)InputValue).Cast<ZADM_M017_P>().Count() > 0)
            {
                POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M017_P>().ToList()[0];
            }

            #endregion

            if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
            {
                var InputValueIfExists = MasterEntity.Where(X => X.pack_style == POPUPEntityObject.id).FirstOrDefault(); // Prefer Primary Key for this instruction.
                int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.pack_style == POPUPEntityObject.id).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                if (dgSelectedIndex >= 0 && MasterEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                {
                    if (MasterEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    {
                        MasterEntity[dgSelectedIndex].pack_style = POPUPEntityObject.id;
                        MasterEntity[dgSelectedIndex].PackingUnit = POPUPEntityObject.pkgunit;
                    }
                    else if (MasterEntity[dgSelectedIndex].id != POPUPEntityObject.id)
                    {
                        MasterEntity[dgSelectedIndex].pack_style = POPUPEntityObject.id;
                        MasterEntity[dgSelectedIndex].PackingUnit = POPUPEntityObject.pkgunit;
                    }
                }
            }
            #region Clear Empty Row
            EPR_T002 newObj = new EPR_T002();
            for (int i = MasterEntity.Count - 1; i >= 0; i--)
            {
                bool xx = MasterEntity[i].ComparePropertiesTo(newObj);
                if (MasterEntity[i].ComparePropertiesTo(newObj) == true && MasterEntity.Count > 1)
                {
                    MasterEntity.RemoveAt(i);
                    if (MasterEntity.Count == 0)
                    {
                        MasterEntity.Add(newObj);
                    }
                }
            }
            #endregion
        }
        private void InsertCustomerProduct(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ZADM_M020_P POPUPEntityObject = null;
            dgSelectedIndex = dgSelectedIndex;
            #region Command Parameter Read Section
            // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
            if (InputValue.GetType() == typeof(string) && InputValue != null)
            {
                //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                Request = InputValue.ToString();
                if (Request.Length > 0)
                {
                    try
                    { POPUPEntityObject = MC.CustomerProductList.Where(x => x.CustomerProductName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                    catch (Exception ex) { }
                }
            }
            else if (((IEnumerable)InputValue).Cast<ZADM_M020_P>().Count() > 0)
            {
                POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M020_P>().ToList()[0];
            }

            #endregion

            if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
            {
                var InputValueIfExists = MasterEntity.Where(X => X.CustomerProductName == POPUPEntityObject.CustomerProductName).FirstOrDefault(); // Prefer Primary Key for this instruction.
                int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.CustomerProductName == POPUPEntityObject.CustomerProductName).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                if (dgSelectedIndex >= 0 && MasterEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                {
                    if (MasterEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    {
                        MasterEntity[dgSelectedIndex].CustomerProductName = POPUPEntityObject.CustomerProductName;
                        //scalar name to be mapped
                    }
                    else if (MasterEntity[dgSelectedIndex].id != POPUPEntityObject.id)
                    {
                        MasterEntity[dgSelectedIndex].CustomerProductName = POPUPEntityObject.CustomerProductName;
                    }
                }
            }
            #region Clear Empty Row
            EPR_T002 newObj = new EPR_T002();
            for (int i = MasterEntity.Count - 1; i >= 0; i--)
            {
                bool xx = MasterEntity[i].ComparePropertiesTo(newObj);
                if (MasterEntity[i].ComparePropertiesTo(newObj) == true && MasterEntity.Count > 1)
                {
                    MasterEntity.RemoveAt(i);
                    if (MasterEntity.Count == 0)
                    {
                        MasterEntity.Add(newObj);
                    }
                }
            }
            #endregion
        }
        private void InsertBallMake(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M032_P POPUPEntityObject = null;
            dgSelectedIndex = dgSelectedIndex;
            #region Command Parameter Read Section
            // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
            if (InputValue.GetType() == typeof(string) && InputValue != null)
            {
                //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                Request = InputValue.ToString();
                if (Request.Length > 0)
                {
                    try
                    { POPUPEntityObject = MC.BallMakeList.Where(x => x.MakeCode.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                    catch (Exception ex) { }
                }
            }
            else if (((IEnumerable)InputValue).Cast<ADM_M032_P>().Count() > 0)
            {
                POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M032_P>().ToList()[0];
            }

            #endregion

            if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
            {
                var InputValueIfExists = MasterEntity.Where(X => X.ball_make == POPUPEntityObject.MakeCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.ball_make == POPUPEntityObject.MakeCode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                if (dgSelectedIndex >= 0 && MasterEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                {
                    if (MasterEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    {
                        MasterEntity[dgSelectedIndex].ball_make = POPUPEntityObject.MakeCode;
                        MasterEntity[dgSelectedIndex].BallMake = POPUPEntityObject.Make;
                    }
                    else if (MasterEntity[dgSelectedIndex].id != POPUPEntityObject.MakeCode)
                    {
                        MasterEntity[dgSelectedIndex].ball_make = POPUPEntityObject.MakeCode;
                        MasterEntity[dgSelectedIndex].BallMake = POPUPEntityObject.Make;
                    }
                }
            }
            #region Clear Empty Row
            EPR_T002 newObj = new EPR_T002();
            for (int i = MasterEntity.Count - 1; i >= 0; i--)
            {
                bool xx = MasterEntity[i].ComparePropertiesTo(newObj);
                if (MasterEntity[i].ComparePropertiesTo(newObj) == true && MasterEntity.Count > 1)
                {
                    MasterEntity.RemoveAt(i);
                    if (MasterEntity.Count == 0)
                    {
                        MasterEntity.Add(newObj);
                    }
                }
            }
            #endregion
        }
        private void InsertWireMake(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M032_P POPUPEntityObject = null;
            dgSelectedIndex = dgSelectedIndex;
            #region Command Parameter Read Section
            // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
            if (InputValue.GetType() == typeof(string) && InputValue != null)
            {
                //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                Request = InputValue.ToString();
                if (Request.Length > 0)
                {
                    try
                    { POPUPEntityObject = MC.BallMakeList.Where(x => x.MakeCode.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                    catch (Exception ex) { }
                }
            }
            else if (((IEnumerable)InputValue).Cast<ADM_M032_P>().Count() > 0)
            {
                POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M032_P>().ToList()[0];
            }

            #endregion

            if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
            {
                var InputValueIfExists = MasterEntity.Where(X => X.ball_make == POPUPEntityObject.MakeCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.ball_make == POPUPEntityObject.MakeCode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                if (dgSelectedIndex >= 0 && MasterEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                {
                    if (MasterEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    {
                        MasterEntity[dgSelectedIndex].wire_make = POPUPEntityObject.MakeCode;
                        MasterEntity[dgSelectedIndex].WireMake = POPUPEntityObject.Make;
                    }
                    else if (MasterEntity[dgSelectedIndex].id != POPUPEntityObject.MakeCode)
                    {
                        MasterEntity[dgSelectedIndex].wire_make = POPUPEntityObject.MakeCode;
                        MasterEntity[dgSelectedIndex].WireMake = POPUPEntityObject.Make;
                    }
                }
            }
            #region Clear Empty Row
            EPR_T002 newObj = new EPR_T002();
            for (int i = MasterEntity.Count - 1; i >= 0; i--)
            {
                bool xx = MasterEntity[i].ComparePropertiesTo(newObj);
                if (MasterEntity[i].ComparePropertiesTo(newObj) == true && MasterEntity.Count > 1)
                {
                    MasterEntity.RemoveAt(i);
                    if (MasterEntity.Count == 0)
                    {
                        MasterEntity.Add(newObj);
                    }
                }
            }
            #endregion
        }
        private bool Validations()
        {
            string Message = "";
            int flag = 0;
            foreach (var o in MasterEntity)
            {
                Message = "Following Fields Are Compulsory For All Checked Rows Please Check Row Index {0}";
                flag = 0;
                if (o.check == true)
                {
                    if (o.shift == null || o.shift == "")
                    {
                        Message += "\n =>Please select Shift ";
                        flag = 1;
                    }
                    if (o.machine_id == null || o.machine_id == 0)
                    {
                        Message += "\n =>Machine Cannot Be Blank or 0 ";
                        flag = 1;
                    }
                    if (o.ItemCode == null || o.ItemCode == "")
                    {
                        Message += "\n =>Product Cannot Be Null or Blank ";
                        flag = 1;
                    }
                    if (o.ink_id == null || o.ink_id == 0)
                    {
                        Message += "\n =>Ink Cannot Be Blank or 0 ";
                        flag = 1;
                    }
                    if (o.ild_id == null || o.ild_id == 0)
                    {
                        Message += "\n =>Ild Cannot Be Blank or 0 ";
                        flag = 1;
                    }
                    if (o.unit_code == null || o.unit_code == "")
                    {
                        Message += "\n =>Please select unit code ";
                        flag = 1;
                    }

                    if (o.ball_make == null || o.ball_make == 0)
                    {
                        Message += "\n =>Please select Ball Make ";
                        flag = 1;
                    }
                    if (o.wire_make == null || o.wire_make == 0)
                    {
                        Message += "\n =>Please select Wire Make ";
                        flag = 1;
                    }
                    //if (o.counter_qty == null || o.counter_qty == 0)
                    //{
                    //    Message += "\n =>Counter Quantity Cannot be null or 0 ";
                    //    flag = 1;
                    //}

                    if (o.conversion == null || o.conversion == "")
                    {
                        Message += "\n =>Please Enter conversion ";
                        flag = 1;
                    }


                    if (flag == 1)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Validation";
                        showMessageService.Text = string.Format(Message, MasterEntity.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }
                }
            }
            return true;
        }
        private void InsertRow_CopyPaste(object InputRow)
        {
            try
            {
                EPR_T002 EntityObject = null;
                if (InputRow != null && dgSelectedIndex != -1 && MasterEntity.Count > 0 && dgSelectedIndex < MasterEntity.Count)
                {
                    if (((IEnumerable)InputRow).Cast<EPR_T002>().Count() > 0)
                    {
                        EntityObject = ((IEnumerable)InputRow).Cast<EPR_T002>().ToList()[0];
                        MasterEntity.Add(new EPR_T002()
                        {
                            entry_dt = EntityObject.entry_dt,
                            prod_dt = EntityObject.prod_dt,
                            ItemCode = EntityObject.ItemCode,
                            pack_style = EntityObject.pack_style,
                            ink_id = EntityObject.ink_id,
                            ild_id = EntityObject.ild_id,
                            batch_no = EntityObject.batch_no,
                            machine_id = EntityObject.machine_id,
                            machinecode = EntityObject.machinecode,
                            shift = EntityObject.shift,
                            conversion = EntityObject.conversion,
                            tip_wt_1 = EntityObject.tip_wt_1,
                            tip_wt_2 = EntityObject.tip_wt_2,
                            tip_wt_3 = EntityObject.tip_wt_3,
                            tip_ave_wt = EntityObject.tip_ave_wt,
                            unit_code = EntityObject.unit_code,
                            wire_make = EntityObject.wire_make,
                            ball_make = EntityObject.ball_make,
                            active = EntityObject.active,
                            add_by = EntityObject.add_by,
                            location_Id = EntityObject.location_Id,
                            comp_code = EntityObject.comp_code,
                            client = EntityObject.client,
                            doc_type = EntityObject.doc_type,
                            doc_cat = EntityObject.doc_cat,
                            fin_year = EntityObject.fin_year,
                            posting_period = EntityObject.posting_period,
                            conversion_no = EntityObject.conversion_no,
                            Ink = EntityObject.Ink,
                            Ild = EntityObject.Ild,
                            BallMake = EntityObject.BallMake,
                            WireMake = EntityObject.WireMake,
                            PackingUnit = EntityObject.PackingUnit,
                            ItemName = EntityObject.ItemName,
                            check = false,
                            a_qty = 0,
                            b_qty = 0,
                            c_qty = 0,
                            blank_wt = EntityObject.blank_wt,
                            auto_sort = EntityObject.auto_sort,
                            grade = EntityObject.grade,
                            WireSize = EntityObject.WireSize,
                            WireType = EntityObject.WireType,
                            BallSize = EntityObject.BallSize,
                            BallType = EntityObject.BallType,
                            TipLen = EntityObject.TipLen
                        });
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
        private void InsertMachineOperator(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                string Request = "";
                ADM_M024_P POPUPEntityObject = null;
                dgSelectedIndex = dgSelectedIndex;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.EmployeeList.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (((IEnumerable)InputValue).Cast<ADM_M024_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MasterEntity.Where(X => X.PartyId == POPUPEntityObject.PartyId).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.PartyId == POPUPEntityObject.PartyId).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && MasterEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MasterEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MasterEntity[dgSelectedIndex].m_operator = POPUPEntityObject.EmpId;
                            MasterEntity[dgSelectedIndex].OperatorNm = POPUPEntityObject.EmpName;
                        }
                        else if (MasterEntity[dgSelectedIndex].m_operator != POPUPEntityObject.EmpId)
                        {
                            MasterEntity[dgSelectedIndex].m_operator = POPUPEntityObject.EmpId;
                            MasterEntity[dgSelectedIndex].OperatorNm = POPUPEntityObject.EmpName;
                        }
                    }
                }
                #region Clear Empty Row
                EPR_T002 newObj = new EPR_T002();
                for (int i = MasterEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = MasterEntity[i].ComparePropertiesTo(newObj);
                    if (MasterEntity[i].ComparePropertiesTo(newObj) == true && MasterEntity.Count > 1)
                    {
                        MasterEntity.RemoveAt(i);
                        if (MasterEntity.Count == 0)
                        {
                            MasterEntity.Add(newObj);
                        }
                    }
                }
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
        private void InsertBreakdownReason(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                string Request = "";
                PMT_M001_P POPUPEntityObject = null;
                dgSelectedIndex = dgSelectedIndex;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BreakdownReasonList.Where(x => x.bdr_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (((IEnumerable)InputValue).Cast<PMT_M001_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<PMT_M001_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MasterEntity.Where(X => X.breakdown_reason == POPUPEntityObject.bdr_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.breakdown_reason == POPUPEntityObject.bdr_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && MasterEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MasterEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MasterEntity[dgSelectedIndex].breakdown_reason = POPUPEntityObject.bdr_code;
                            MasterEntity[dgSelectedIndex].bdr_desc = POPUPEntityObject.bdr_desc;
                        }
                        else if (MasterEntity[dgSelectedIndex].breakdown_reason != POPUPEntityObject.bdr_code)
                        {
                            MasterEntity[dgSelectedIndex].breakdown_reason = POPUPEntityObject.bdr_code;
                            MasterEntity[dgSelectedIndex].OperatorNm = POPUPEntityObject.bdr_desc;
                        }
                    }
                }
                #region Clear Empty Row
                EPR_T002 newObj = new EPR_T002();
                for (int i = MasterEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = MasterEntity[i].ComparePropertiesTo(newObj);
                    if (MasterEntity[i].ComparePropertiesTo(newObj) == true && MasterEntity.Count > 1)
                    {
                        MasterEntity.RemoveAt(i);
                        if (MasterEntity.Count == 0)
                        {
                            MasterEntity.Add(newObj);
                        }
                    }
                }
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
        //BackFlip
        private void LoadLabelGenerationDetails()
        {
            try
            {
                //if (SelectedEPR_T002.machine_id == null || SelectedEPR_T002.machinecode == "All")
                //{
                //    SelectedEPR_T002.machine_id = 0;
                //}
                //if (SelectedEPR_T002.pack_style == null || SelectedEPR_T002.PackingUnit == "All")
                //{
                //    SelectedEPR_T002.pack_style = 0;
                //}
                //if (SelectedEPR_T002.ItemCode == null || SelectedEPR_T002.ItemCode == "")
                //{
                //    SelectedEPR_T002.ItemCode = "All";
                //}
                //if (SelectedEPR_T002.conversion == null)
                //{
                //    SelectedEPR_T002.conversion = "All";
                //}
                //if (SelectedEPR_T002.shift == null)
                //{
                //    SelectedEPR_T002.shift = "All";
                //}
                //if (SelectedEPR_T002.ink_id == null || SelectedEPR_T002.Ink == "All")
                //{
                //    SelectedEPR_T002.ink_id = 0;
                //}
                //if (SelectedEPR_T002.ild_id == null || SelectedEPR_T002.Ild == "All")
                //{
                //    SelectedEPR_T002.ild_id = 0;
                //}
                //if (SelectedEPR_T002.grade == null)
                //{
                //    SelectedEPR_T002.grade = "All";
                //}

                string Request = "LoadProdCounterEntry" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + SelectedEPR_T002.machine_id + "!@" + SelectedEPR_T002.pack_style + "!@" + SelectedEPR_T002.ItemCode
                        + "!@" + SelectedEPR_T002.conversion + "!@" + SelectedEPR_T002.shift + "!@" + SelectedEPR_T002.ink_id + "!@" + SelectedEPR_T002.ild_id + "!@" + SelectedEPR_T002.prod_dt + "!@" + SelectedEPR_T002.grade;
                MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T002>(MC, Request, "LabelGenerationMaster", "Production", "LoadAll", 0, "");

                if (MC.ProductionCounterEntryList.Count >= 0)
                {
                    BackFlipCollection = CollectionViewSource.GetDefaultView(MC.ProductionCounterEntryList);
                    BackFlipCollection.Filter = new Predicate<object>(Filter_FlipGrid);

                    BackFlipCollection.Refresh();
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
        private void InsertMachine(IList InputValue)
        {
            IList list = InputValue as IList;
            List<ZADM_M013_P> GetSelectedMachine = list.Cast<ZADM_M013_P>().ToList();

            if (GetSelectedMachine.Count > 0)
            {
                SelectedEPR_T002.machine_id = GetSelectedMachine[0].machine_id;
                SelectedEPR_T002.machinecode = GetSelectedMachine[0].machinecode;
            }
        }
        private void InsertBPkgUnit(IList InputValue)
        {
            IList list = InputValue as IList;
            List<ZADM_M017_P> GetSelectedPkgUnit = list.Cast<ZADM_M017_P>().ToList();

            if (GetSelectedPkgUnit.Count > 0)
            {
                SelectedEPR_T002.pack_style = GetSelectedPkgUnit[0].id;
                SelectedEPR_T002.PackingUnit = GetSelectedPkgUnit[0].pkgunit;
            }
        }
        private void InsertItem(IList InputValue)
        {
            IList list = InputValue as IList;
            List<ADM_M022_P> GetSelectedItem = list.Cast<ADM_M022_P>().ToList();

            if (GetSelectedItem.Count > 0)
            {
                SelectedEPR_T002.ItemCode = GetSelectedItem[0].ItemCode;
            }
        }
        private void InsertInk(IList InputValue)
        {
            IList list = InputValue as IList;
            List<ZADM_M006_P> GetSelectedInk = list.Cast<ZADM_M006_P>().ToList();

            if (GetSelectedInk.Count > 0)
            {
                SelectedEPR_T002.ink_id = GetSelectedInk[0].ink_id;
                SelectedEPR_T002.Ink = GetSelectedInk[0].ink;
            }
        }
        private void InsertIld(IList InputValue)
        {
            IList list = InputValue as IList;
            List<ZADM_M007_P> GetSelectedIld = list.Cast<ZADM_M007_P>().ToList();

            if (GetSelectedIld.Count > 0)
            {
                SelectedEPR_T002.ild_id = GetSelectedIld[0].ild_id;
                SelectedEPR_T002.Ild = GetSelectedIld[0].ild;
            }
        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    //LoadLabelGenerationDetails(doc_no_vm);
                    //isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
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
                    Request = SelectedEPR_T002.client + "!@" + SelectedEPR_T002.comp_code + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }
        private void InsertRemarks(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                string Request = "";
                ADM_M066 POPUPEntityObject = null;
                dgSelectedIndex = dgSelectedIndex;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Remarks.Where(x => x.remarks.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (((IEnumerable)InputValue).Cast<ADM_M066>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M066>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MasterEntity.Where(X => X.user_source1 == POPUPEntityObject.remarks).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.user_source1 == POPUPEntityObject.remarks).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && MasterEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MasterEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MasterEntity[dgSelectedIndex].user_source1 = POPUPEntityObject.remarks;

                        }
                        else if (MasterEntity[dgSelectedIndex].user_source1 != POPUPEntityObject.remarks)
                        {
                            MasterEntity[dgSelectedIndex].user_source1 = POPUPEntityObject.remarks;

                        }
                    }
                }
                #region Clear Empty Row
                EPR_T002 newObj = new EPR_T002();
                for (int i = MasterEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = MasterEntity[i].ComparePropertiesTo(newObj);
                    if (MasterEntity[i].ComparePropertiesTo(newObj) == true && MasterEntity.Count > 1)
                    {
                        MasterEntity.RemoveAt(i);
                        if (MasterEntity.Count == 0)
                        {
                            MasterEntity.Add(newObj);
                        }
                    }
                }
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


        #endregion

        #region · Command Actions ·

        protected override void OnSaveAction(InquiryActionResult<EPR_T002> result)
        {
            TobeSaveEntity = new List<EPR_T002>();

            if (isNewRecord == true)
            {
                foreach (var o in MasterEntity)  //First Selected Rows Will be Added To New Collection
                {
                    if (o.check == true)
                    {
                        TobeSaveEntity.Add(o);
                    }
                }

                if (TobeSaveEntity.Count > 0)   // If At Least One Row is Selected The Only It Will Save
                {
                    if (Validations() == true)
                    {
                        string reader = repository.Save<List<EPR_T002>>(TobeSaveEntity, "LabelGenerationMaster", "Production");
                        int intreader = Convert.ToInt32(reader);

                        if (intreader > 0) // intreader is always greater than 0 if data is saved
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Saved Successfully", this.Title);
                            showMessageService.ShowMessage();

                            foreach (var o in TobeSaveEntity)
                            {
                                for (int i = MasterEntity.Count - 1; i >= 0; i--)
                                {
                                    MasterEntity.Remove(o);
                                }
                            }
                        }
                    }
                }
                else  // if No rows are selected it will give Message
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select At Least One Row", this.Title);
                    showMessageService.ShowMessage();
                }
                SelectedEPR_T002.prod_dt = Date;
            }
        }
        protected override void OnCreateAction(InquiryActionResult<EPR_T002> result)
        {
            isNewRecord = true;
            MasterEntity = new ObservableCollection<EPR_T002>();
            Date = DateTime.Now;
            SelectedEPR_T002.record_type = "01";
        }
        protected override void OnRemoveAction(InquiryActionResult<EPR_T002> result)
        {
        }
        protected override void OnDiscardAction(InquiryActionResult<EPR_T002> result)
        {
        }
        protected override void OnFevoriteAction(InquiryActionResult<EPR_T002> result)
        {
        }
        protected override void OnFlipAction(InquiryActionResult<EPR_T002> result)
        {
        }
        protected override void OnHelpAction(InquiryActionResult<EPR_T002> result)
        {
        }
        protected override void OnPrintAction(InquiryActionResult<EPR_T002> result)
        {
            try
            {
                MC.RptUltraLabelList.Clear();
                foreach (var item in MC.ProductionCounterEntryList)
                {
                   if (item.check == true && PrintOption == "Selected")
                    {

                        MC.RptUltraLabelList.Add(new BusinessEntity.Production.RptUltrasonicLabelGen {barcode=item.barcode,batch_no=item.batch_no,doc_no=item.doc_no,ItemCode=item.ItemCode,machinecode=item.machinecode,prod_date=(DateTime)item.prod_dt, quantity=item.counter_qty,shift1=item.shift });
                       
                    }
                    else if (PrintOption == "All")
                    {
                        MC.RptUltraLabelList.Add(new BusinessEntity.Production.RptUltrasonicLabelGen { barcode = item.barcode, batch_no = item.batch_no, doc_no = item.doc_no, ItemCode = item.ItemCode, machinecode = item.machinecode, prod_date = (DateTime)item.prod_dt, quantity = item.counter_qty, shift1 = item.shift });
                    }


                }

                //if(TempCollection.doc_no !=null || TempCollection.doc_no !="")
                //{
                    // This 2 below lines is commented by sunil as there is no relevance of server trip. on 28/09/2017
                    //string Request = "LoadInitialData" + "!@" + TempCollection.comp_code + "!@" + TempCollection.location_Id + "!@" + TempCollection.doc_cat + "!@" + TempCollection.doc_type + "!@" + TempCollection.doc_no;
                    //MCTemp2 = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T002>(MCTemp2, Request, "LabelGenerationMaster", "Production", "LoadAll", 0, "");

                    object[] objDataSource = new object[1];
                    string[] objDataSourceName = new string[1];

                    objDataSource[0] = MC.RptUltraLabelList;
                    objDataSourceName[0] = "dsBatchCard";

                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\BatchCard.rdlc", "BatchCard");
                //}
               
                //else
                //    {
                //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //        showMessageService.ButtonSetup = DialogButton.Ok;
                //        showMessageService.Caption = "Message";
                //        showMessageService.Text = String.Format("Please Select Record And Then Print Report", this.Title);
                //        showMessageService.ShowMessage();
                //    }

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
        protected override void OnRefreshCommand(InquiryActionResult<EPR_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<EPR_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<EPR_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<EPR_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<EPR_T002> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Filters

        #region Unit

        private string _filterString_Unit;
        public string FilterString_Unit
        {
            get { return _filterString_Unit; }
            set
            {
                _filterString_Unit = value;
                RaisePropertyChanged("FilterString_Unit");
                FilterCollection_Unit();
            }
        }
        private void FilterCollection_Unit()
        {
            if (_UnitCollection != null)
            {
                _UnitCollection.Refresh();
            }
        }
        public bool Filter_Unit(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Unit))
                {
                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterString_Unit.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Pkg Unit

        private string _filterString_PkgUnit;
        public string FilterString_PkgUnit
        {
            get { return _filterString_PkgUnit; }
            set
            {
                _filterString_PkgUnit = value;
                RaisePropertyChanged("FilterString_PkgUnit");
                FilterCollection_PkgUnit();
            }
        }
        private void FilterCollection_PkgUnit()
        {
            if (_PkgUnitCollection != null)
            {
                _PkgUnitCollection.Refresh();
            }
        }
        public bool Filter_PkgUnit(object obj)
        {
            var data = obj as ZADM_M017_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_PkgUnit))
                {
                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterString_PkgUnit.ToLower()) ||
                        data.pkgunit != null && data.pkgunit.ToString().ToLower().Contains(_filterString_PkgUnit.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Customer Production

        private string _filterString_CustProduct;
        public string FilterString_CustProduct
        {
            get { return _filterString_CustProduct; }
            set
            {
                _filterString_CustProduct = value;
                RaisePropertyChanged("FilterString_CustProduct");
                FilterCollection_CustProduct();
            }
        }
        private void FilterCollection_CustProduct()
        {
            if (_CustomerProductCollection != null)
            {
                _CustomerProductCollection.Refresh();
            }
        }
        public bool Filter_CustProduct(object obj)
        {
            var data = obj as ZADM_M020_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_CustProduct))
                {
                    return (data.CustomerProductName != null && data.CustomerProductName.ToString().ToLower().Contains(_filterString_CustProduct.ToLower()) ||
                        data.ProductName != null && data.ProductName.ToString().ToLower().Contains(_filterString_CustProduct.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Ball Make

        private string _filterString_BallMake;
        public string FilterString_BallMake
        {
            get { return _filterString_BallMake; }
            set
            {
                _filterString_BallMake = value;
                RaisePropertyChanged("FilterString_BallMake");
                FilterCollection_BallMake();
            }
        }
        private void FilterCollection_BallMake()
        {
            if (_BallMakeCollection != null)
            {
                _BallMakeCollection.Refresh();
            }
        }
        public bool Filter_BallMake(object obj)
        {
            var data = obj as ADM_M032_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_BallMake))
                {
                    return (data.MakeCode != null && data.MakeCode.ToString().ToLower().Contains(_filterString_BallMake.ToLower()) ||
                        data.Make != null && data.Make.ToString().ToLower().Contains(_filterString_BallMake.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Wire Make

        private string _filterString_WireMake;
        public string FilterString_WireMake
        {
            get { return _filterString_WireMake; }
            set
            {
                _filterString_WireMake = value;
                RaisePropertyChanged("FilterString_WireMake");
                FilterCollection_WireMake();
            }
        }
        private void FilterCollection_WireMake()
        {
            if (_WireMakeCollection != null)
            {
                _WireMakeCollection.Refresh();
            }
        }
        public bool Filter_WireMake(object obj)
        {
            var data = obj as ADM_M032_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_WireMake))
                {
                    return (data.MakeCode != null && data.MakeCode.ToString().ToLower().Contains(_filterString_WireMake.ToLower()) ||
                        data.Make != null && data.Make.ToString().ToLower().Contains(_filterString_WireMake.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Breakdown Reason

        private string _filterString_bdr;
        public string FilterString_bdr
        {
            get { return _filterString_bdr; }
            set
            {
                _filterString_bdr = value;
                RaisePropertyChanged("FilterString_bdr");
                FilterCollection_Bdr();
            }
        }
        private void FilterCollection_Bdr()
        {
            if (_BreakdownReasonCollection != null)
            {
                _BreakdownReasonCollection.Refresh();
            }
        }
        public bool Filter_bdr(object obj)
        {
            var data = obj as PMT_M001_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_bdr))
                {
                    return (data.bdr_code != null && data.bdr_code.ToString().ToLower().Contains(_filterString_bdr.ToLower()) ||
                        data.bdr_desc != null && data.bdr_desc.ToString().ToLower().Contains(_filterString_bdr.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        //Backflip

        #region FlipGrid
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
            if (_BackFlipCollection != null)
            {
                _BackFlipCollection.Refresh();
            }
        }
        public bool Filter_FlipGrid(object obj)
        {
            var data = obj as EPR_T002;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_FlipGrid))
                {
                    return (data.shift != null && data.shift.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.Ink != null && data.Ink.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.Ild != null && data.Ild.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.PackingUnit != null && data.PackingUnit.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.conversion != null && data.conversion.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.BallMake != null && data.BallMake.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.WireMake != null && data.WireMake.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.a_qty != null && data.a_qty.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.b_qty != null && data.b_qty.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.c_qty != null && data.c_qty.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.counter_qty != null && data.counter_qty.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.tip_wt_1 != null && data.tip_wt_1.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.tip_wt_2 != null && data.tip_wt_2.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.tip_wt_3 != null && data.tip_wt_3.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.blank_wt != null && data.blank_wt.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Machine

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
            if (_MachineCollection != null)
            {
                _MachineCollection.Refresh();
            }
        }
        public bool Filter_Machine(object obj)
        {
            var data = obj as ZADM_M013_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Machine))
                {
                    return (data.machine_id != null && data.machine_id.ToString().ToLower().Contains(_filterString_Machine.ToLower())) ||
                        (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterString_Machine.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region BPackUnit

        private string _filterString_BPkgUnit;
        public string FilterString_BPkgUnit
        {
            get { return _filterString_BPkgUnit; }
            set
            {
                _filterString_BPkgUnit = value;
                RaisePropertyChanged("FilterString_BPkgUnit");
                FilterCollection_BPkgUnit();
            }
        }
        private void FilterCollection_BPkgUnit()
        {
            if (_BPkgUnitCollection != null)
            {
                _BPkgUnitCollection.Refresh();
            }
        }
        public bool Filter_BPkgUnit(object obj)
        {
            var data = obj as ZADM_M017_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_BPkgUnit))
                {
                    return (data.pkgunit != null && data.pkgunit.ToString().ToLower().Contains(_filterString_BPkgUnit.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Product

        private string _filterString_ItemCode;
        public string FilterString_ItemCode
        {
            get { return _filterString_ItemCode; }
            set
            {
                _filterString_ItemCode = value;
                RaisePropertyChanged("FilterString_ItemCode");
                FilterCollection_ItemCode();
            }
        }
        private void FilterCollection_ItemCode()
        {
            if (_ItemCollection != null)
            {
                _ItemCollection.Refresh();
            }
        }
        public bool Filter_ItemCode(object obj)
        {
            var data = obj as ADM_M022_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ItemCode))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_ItemCode.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Ink
        private string _filterString_Ink;
        public string FilterString_Ink
        {
            get { return _filterString_Ink; }
            set
            {
                _filterString_Ink = value;
                RaisePropertyChanged("FilterString_Ink");
                FilterCollection_Ink();
            }
        }
        private void FilterCollection_Ink()
        {
            if (_InkCollection != null)
            {
                _InkCollection.Refresh();
            }
        }
        public bool Filter_Ink(object obj)
        {
            var data = obj as ZADM_M006_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Ink))
                {
                    return (data.ink != null && data.ink.ToString().ToLower().Contains(_filterString_Ink.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Ild
        private string _filterString_Ild;
        public string FilterString_Ild
        {
            get { return _filterString_Ild; }
            set
            {
                _filterString_Ild = value;
                RaisePropertyChanged("FilterString_Ild");
                FilterCollection_Ild();
            }
        }
        private void FilterCollection_Ild()
        {
            if (_IldCollection != null)
            {
                _IldCollection.Refresh();
            }
        }
        public bool Filter_Ild(object obj)
        {
            var data = obj as ZADM_M007_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Ild))
                {
                    return (data.ild != null && data.ild.ToString().ToLower().Contains(_filterString_Ild.ToLower()) ||
                        data.tip_type != null && data.tip_type.ToString().ToLower().Contains(_filterString_Ild.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Remarks
        private string _filterString_Remarks;
        public string FilterString_Remarks
        {
            get { return _filterString_Remarks; }
            set
            {
                _filterString_Remarks = value;
                RaisePropertyChanged("FilterString_Remarks");
                FilterCollection_Remarks();
            }
        }
        private void FilterCollection_Remarks()
        {
            if (_RemarksCollection != null)
            {
                _RemarksCollection.Refresh();
            }
        }
        public bool Filter_Remarks(object obj)
        {
            var data = obj as ADM_M066;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Remarks))
                {
                    return (data.code != null && data.code.ToString().ToLower().Contains(_filterString_Remarks.ToLower()) ||
                        data.remarks != null && data.remarks.ToString().ToLower().Contains(_filterString_Remarks.ToLower()));
                }
                return true;
            }
            return false;
        }

        
        #endregion
        #endregion
    }
}
