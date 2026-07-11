using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.Presentation.Controls.AutoSuggestTextBox.Core;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.ReportingServices;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class ECRM_T003_A_VM : WorkspaceViewModel<ECRM_T003_A>
    {

        WebServiceRepository<ECRM_T003_A> repository = new WebServiceRepository<ECRM_T003_A>();
        WebServiceRepository<MultipleContext_ECRM_T003_A> repositoryM = new WebServiceRepository<MultipleContext_ECRM_T003_A>();
        MultipleContext_ECRM_T003_A MCTemp = new MultipleContext_ECRM_T003_A();
        MultipleContext_ECRM_T003_A MCConLot = new MultipleContext_ECRM_T003_A();
        MultipleContext_ECRM_T003_A MCMchin = new MultipleContext_ECRM_T003_A();
        MultipleContext_WTRpt_ECRM_T003_A MCRpt = new MultipleContext_WTRpt_ECRM_T003_A();
        WebServiceRepository<MultipleContext_WTRpt_ECRM_T003_A> repositoryRpt = new WebServiceRepository<MultipleContext_WTRpt_ECRM_T003_A>();

        private string _filterStringILDChart;
        private string _filterStringILD;
        private string _filterStringConv_lot;
        private string _filterStringDefect_desc;
        private string _filterStringProdctBack;

        private string _filterString;
        private int _dgSelectedIndex;
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
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }


        #region ICollection
        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }

        private ICollectionView _ILDChartCollection;
        public ICollectionView ILDChartCollection
        {
            get { return _ILDChartCollection; }
            set
            {
                _ILDChartCollection = value;

                RaisePropertyChanged("ILDChartCollection");
            }
        }

        private ICollectionView _Conv_lotCollection;
        public ICollectionView Conv_lotCollection
        {
            get { return _Conv_lotCollection; }
            set
            {
                _Conv_lotCollection = value;

                RaisePropertyChanged("Conv_lotCollection");
            }
        }

        private ICollectionView _Defect_descCollection;
        public ICollectionView Defect_descCollection
        {
            get { return _Defect_descCollection; }
            set
            {
                _Defect_descCollection = value;

                RaisePropertyChanged("Defect_descCollection");
            }
        }
        private ICollectionView _ProdctCollectionBack;
        public ICollectionView ProdctCollectionBack
        {
            get { return _ProdctCollectionBack; }
            set
            {
                _ProdctCollectionBack = value;

                RaisePropertyChanged("ProdctCollectionBack");
            }
        }

        private ICollectionView _testTypeCollection;
        public ICollectionView testTypeCollection
        {
            get { return _testTypeCollection; }
            set
            {
                _testTypeCollection = value;

                RaisePropertyChanged("testTypeCollection");
            }
        }
        private ICollectionView _OperatorCollection;
        public ICollectionView OperatorCollection
        {
            get { return _OperatorCollection; }
            set
            {
                _OperatorCollection = value;

                RaisePropertyChanged("OperatorCollection");
            }
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
        #endregion

        #region RelayCommand
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<IList> SelectionChangedCommand
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionIDCommand
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandILDChart
        {
            get;
            private set;
        }


        public RelayCommand<DateTime> SelectedDateChangedCommand
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandLoadILDChartButn
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandConv_lot
        {
            get;
            private set;
        }


        public RelayCommand<IList> SelectionChangedCommandDefect_desc
        {
            get;
            private set;
        }
        public RelayCommand<IList> CellChangedCommand
        {
            get;
            private set;
        }
        public RelayCommand ReportCommand
        {
            get;
            private set;
        }
        public RelayCommand<IList> DeleteILDCommand
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandProdctBack
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandTestType
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandOperator
        {
            get;
            private set;
        }
        public RelayCommand<object> CmdAddBatchDetails { get; private set; }
        public RelayCommand<object> cmdResetScale { get; private set; }
        #endregion

        #region ECRM_T003_A
        private List<ECRM_T003_A> _SelectedList;
        public List<ECRM_T003_A> SelectedList
        {
            get { return _SelectedList; }
            set
            {
                if (_SelectedList != value)
                {
                    _SelectedList = value;
                    RaisePropertyChanged("SelectedList");
                }
            }
        }
        private ECRM_T003_A _SelectedECRM_T003_A;
        public ECRM_T003_A SelectedECRM_T003_A
        {
            get
            {
                this.ErrorExist = _SelectedECRM_T003_A.HasErrors;
                return _SelectedECRM_T003_A;
            }
            set
            {
                if (_SelectedECRM_T003_A != value)
                {
                    _SelectedECRM_T003_A = value;
                    this.ErrorExist = _SelectedECRM_T003_A.HasErrors;
                    RaisePropertyChanged("SelectedECRM_T003_A");
                    value.BeginEdit();
                }
            }
        }
        #endregion

        #region WTRpt_ECRM_T003_A
        private WTRpt_ECRM_T003_A _SelectedWTRpt_ECRM_T003_A;
        public WTRpt_ECRM_T003_A SelectedWTRpt_ECRM_T003_A
        {
            get
            {
                _SelectedWTRpt_ECRM_T003_A.ValidateAsync().Wait();
                this.ErrorExist = _SelectedWTRpt_ECRM_T003_A.HasErrors;
                return _SelectedWTRpt_ECRM_T003_A;
            }
            set
            {
                if (_SelectedWTRpt_ECRM_T003_A != value)
                {
                    _SelectedWTRpt_ECRM_T003_A = value;


                    RaisePropertyChanged("SelectedWTRpt_ECRM_T003_A");
                    value.BeginEdit();

                }
            }
        }
        private ObservableCollection<WTRpt_ECRM_T003_A> _WTReport;
        public ObservableCollection<WTRpt_ECRM_T003_A> WTReport
        {
            get { return _WTReport; }
            set
            {
                if (_WTReport != value)
                {
                    _WTReport = value;


                    RaisePropertyChanged("WTReport");

                }
            }
        }
        #endregion

        #region ECRM_T003_B
        private static ObservableCollection<ECRM_T003_B> _WTDetails = new ObservableCollection<ECRM_T003_B>();
        public ObservableCollection<ECRM_T003_B> WTDetails
        {
            get { return _WTDetails; }
            set
            {
                if (_WTDetails != value)
                {
                    _WTDetails = value;

                    RaisePropertyChanged("WTDetails");
                }
            }
        }
        public ECRM_T003_B _SelectedECRM_T003_B { get; private set; }
        public ECRM_T003_B SelectedECRM_T003_B
        {
            get { return _SelectedECRM_T003_B; }
            set
            {
                if (_SelectedECRM_T003_B != value)
                {
                    _SelectedECRM_T003_B = value;
                    RaisePropertyChanged("SelectedECRM_T003_B");
                }
            }
        }
        private List<ECRM_T003_B> _SelectedECRM_T003_B_List;
        public List<ECRM_T003_B> SelectedECRM_T003_B_List
        {
            get
            {
                return _SelectedECRM_T003_B_List;
            }
            set
            {
                _SelectedECRM_T003_B_List = value;
                RaisePropertyChanged("SelectedECRM_T003_B_List");
            }
        }

        #endregion

        #region EPR_T001_P       
        private List<EPR_T001_P> _SelectedListOfILDChartList;
        public List<EPR_T001_P> SelectedListOfILDChartList
        {
            get { return _SelectedListOfILDChartList; }
            set
            {
                if (_SelectedListOfILDChartList != value)
                {
                    _SelectedListOfILDChartList = value;
                    RaisePropertyChanged("SelectedListOfILDChartList");
                }
            }
        }


        #endregion

        #region ADM_M022_P_ESSEM       
        private List<ADM_M022_P_ESSEM> _SelectedListOfProdctList;
        public List<ADM_M022_P_ESSEM> SelectedListOfProdctList
        {
            get { return _SelectedListOfProdctList; }
            set
            {
                if (_SelectedListOfProdctList != value)
                {
                    _SelectedListOfProdctList = value;
                    RaisePropertyChanged("SelectedListOfProdctList");
                }
            }
        }
        #endregion

        #region EPR_T001_P

        private List<EPR_T001_P> _SelectedListOfConv_lotList;
        public List<EPR_T001_P> SelectedListOfConv_lotList
        {
            get { return _SelectedListOfConv_lotList; }
            set
            {
                if (_SelectedListOfConv_lotList != value)
                {
                    _SelectedListOfConv_lotList = value;
                    RaisePropertyChanged("SelectedListOfConv_lotList");
                }
            }
        }
        #endregion

        #region ZADM_M016_P

        private List<ZADM_M016_P> _SelectedListOfDefect_descList;
        public List<ZADM_M016_P> SelectedListOfDefect_descList
        {
            get { return _SelectedListOfDefect_descList; }
            set
            {
                if (_SelectedListOfDefect_descList != value)
                {
                    _SelectedListOfDefect_descList = value;
                    RaisePropertyChanged("SelectedListOfDefect_descList");
                }
            }
        }

        #endregion

        private Nullable<System.DateTime> _prddt;
        public Nullable<System.DateTime> prddt
        {
            get { return _prddt; }
            set
            {
                _prddt = value;
                RaisePropertyChanged("prddt");
            }
        }
        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                _doc_type = value;
                RaisePropertyChanged("doc_type");
            }
        }

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
        private Nullable<bool> _blNew;
        public Nullable<bool> blNew
        {
            get
            {
                return _blNew;
            }
            set
            {
                {
                    _blNew = value;
                    RaisePropertyChanged("blNew");
                }
            }
        }

        private Nullable<bool> _blA;
        public Nullable<bool> blA
        {
            get
            {
                return _blA;
            }
            set
            {
                {
                    _blA = value;
                    RaisePropertyChanged("blA");
                }
            }
        }

        private Nullable<bool> _blB;
        public Nullable<bool> blB
        {
            get
            {
                return _blB;
            }
            set
            {
                {
                    _blB = value;
                    RaisePropertyChanged("blB");
                }
            }
        }

        private string _WTRN;
        public string WTRN
        {
            get
            {
                return _WTRN;
            }
            set
            {
                {
                    _WTRN = value;
                    RaisePropertyChanged("WTRN");
                }
            }
        }

        private string _WTAW;
        public string WTAW
        {
            get
            {
                return _WTAW;
            }
            set
            {
                {
                    _WTAW = value;
                    RaisePropertyChanged("WTAW");
                }
            }
        }

        private string _WTBW;
        public string WTBW
        {
            get
            {
                return _WTBW;
            }
            set
            {
                {
                    _WTBW = value;
                    RaisePropertyChanged("WTBW");
                }
            }
        }

        private Nullable<bool> _hide;
        public Nullable<bool> hide
        {
            get
            {
                return _hide;
            }
            set
            {
                {
                    _hide = value;
                    RaisePropertyChanged("hide");
                }
            }
        }
        MultipleContext_ECRM_T003_A _MC = new MultipleContext_ECRM_T003_A();
        public MultipleContext_ECRM_T003_A MC
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

        private ECRM_T003_B _SelectedRow;
        public ECRM_T003_B SelectedRow
        {
            get
            {
                return _SelectedRow;
            }
            set
            {
                if (_SelectedRow != value)
                {
                    _SelectedRow = value;
                    RaisePropertyChanged("SelectedRow");
                }
            }
        }

        public SerialPort _serialPort;
        public readonly StringBuilder _rxBuffer = new StringBuilder(256);

        // drain-after-event control
        public volatile bool _drainActive;
        public DateTime _lastByteAt;

        int CurrentARowIndex = 0;
        int CurrentBRowIndex = -1;
        int CurrentCRowIndex = -1;
        //ECRM_T003_B SelectedRow;
        decimal ResetValue = 0;
        bool AWeightAll = false;
        bool BWeightAll = false;

        public ECRM_T003_A_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            blNew = true;
            SelectedList = new List<ECRM_T003_A>();
            SelectedECRM_T003_A = new ECRM_T003_A();
            MC = new MultipleContext_ECRM_T003_A();
            WTDetails = new ObservableCollection<ECRM_T003_B>();
            SelectedECRM_T003_B_List = new List<ECRM_T003_B>();
            SelectedECRM_T003_B = new ECRM_T003_B();
            MC.WTDetails = new ObservableCollection<ECRM_T003_B>();
            SelectedECRM_T003_A.ValidateAsync().Wait();
            hide = true;
            blA = true;
            blB = true;
            LoadInitialData();
            SelectedECRM_T003_A.client = AppSessionState.client;
            SelectedECRM_T003_A.user_source1 = AppSessionState.UserSource1;
            SelectedECRM_T003_A.user_source2 = AppSessionState.UserSource2;
            SelectedECRM_T003_A.userid = AppSessionState.UserID;

            _serialPort = MachineInterface.StartComportSession(_serialPort, MachineInterface.DetectScalePort(), 9600, Parity.None, 8, StopBits.One, Handshake.None, _rxBuffer, _drainActive, _lastByteAt);
            _serialPort.DataReceived += async (s, e) =>
            {
                AssignWeightGradeWise(await MachineInterface.OnSerialDataReceived(s, e, _drainActive, _serialPort, _rxBuffer, _lastByteAt));
            };
        }
        public ECRM_T003_A_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            blNew = true;
            SelectedList = new List<ECRM_T003_A>();
            SelectedECRM_T003_A = new ECRM_T003_A();
            MC = new MultipleContext_ECRM_T003_A();
            WTDetails = new ObservableCollection<ECRM_T003_B>();
            SelectedECRM_T003_B_List = new List<ECRM_T003_B>();
            SelectedECRM_T003_B = new ECRM_T003_B();
            MC.WTDetails = new ObservableCollection<ECRM_T003_B>();
            SelectedECRM_T003_A.ValidateAsync().Wait();
            hide = true;
            blA = true;
            blB = true;
            LoadInitialData();
            SelectedECRM_T003_A.client = AppSessionState.client;
            SelectedECRM_T003_A.user_source1 = AppSessionState.UserSource1;
            SelectedECRM_T003_A.user_source2 = AppSessionState.UserSource2;
            SelectedECRM_T003_A.userid = AppSessionState.UserID;
        }
        private void LoadInitialData()
        {
            try
            {
                #region Commands
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                SelectionChangedCommand = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }
                    GetSelectedWTDetails(items);
                });
                SelectionIDCommand = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }
                    GetSelectedID(items);
                });
                SelectionChangedCommandILDChart = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedILDChartDetails(items);
                });
                SelectedDateChangedCommand = new RelayCommand<DateTime>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedDateDetails(items);
                });
                SelectionChangedCommandConv_lot = new RelayCommand<IList>(
               items =>
               {
                   if (items == null)
                   {
                       return;
                   }

                   GetSelectedConv_lotDetails(items);
               });
                ReportCommand = new RelayCommand(Load);
                CellChangedCommand = new RelayCommand<IList>(
                 items =>
                 {
                     if (items == null)
                     {
                         return;
                     }

                     CellChangeUpdate(items);
                 });

                DeleteILDCommand = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    getSelectedRow(items);
                });
                SelectionChangedCommandDefect_desc = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedDefect_descDetails(items);
                });
                SelectionChangedCommandOperator = new RelayCommand<IList>(
               items =>
               {
                   if (items == null)
                   {
                       return;
                   }

                   GetSelectedOperator(items);
               });
                SelectionChangedCommandTestType = new RelayCommand<IList>(
               items =>
               {
                   if (items == null)
                   {
                       return;
                   }

                   GetSelectedTestType(items);
               });
                SelectionChangedCommandProdctBack = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedProductOnFlip(items);
                });
                CmdAddBatchDetails = new RelayCommand<object>(items => { if (items == null) { return; } InsertBatchDetails(items); });
                cmdResetScale = new RelayCommand<object>(items => { if (items == null) { return; } ResetScale(items); });
                #endregion
                string request = "";

                string FromDate; string ToDate;
                if (SelectedECRM_T003_A.Fromdate == null)
                { FromDate = Convert.ToDateTime(System.DateTime.Now.Date).ToString("MM/dd/yyyy"); }
                else { FromDate = Convert.ToDateTime(SelectedECRM_T003_A.Fromdate).ToString("MM/dd/yyyy"); }
                if (SelectedECRM_T003_A.ToDate == null)
                { ToDate = Convert.ToDateTime(System.DateTime.Now.Date).ToString("MM/dd/yyyy"); }
                else { ToDate = Convert.ToDateTime(SelectedECRM_T003_A.ToDate).ToString("MM/dd/yyyy"); }
                SelectedECRM_T003_A.doc_type = "PD";
                SelectedECRM_T003_A.location_Id = AppSessionState.location_Id;

                request = (SelectedECRM_T003_A.prdct_code) + "!@" + Convert.ToDateTime(System.DateTime.Now.Date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(System.DateTime.Now.Date).ToString("MM/dd/yyyy") + "!@" + SelectedECRM_T003_A.doc_type + "!@" + SelectedECRM_T003_A.location_Id;
                MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T003_A>(MC, "ECRM_T003_A_Data", "WritingTest", "CRM", "LoadAll", 0, request);
                SelectedList = MC.WritingTest;

                SelectedECRM_T003_A.wtdt = DateTime.Now;
                SelectedECRM_T003_A.timeto = DateTime.Now.ToString(" HH:mm");
                SelectedECRM_T003_A.prddt = DateTime.Now;
                SelectedECRM_T003_A.tm = 25;
                SelectedECRM_T003_A.Fromdate = DateTime.Now;
                SelectedECRM_T003_A.ToDate = DateTime.Now;
                SelectedECRM_T003_A.amnild = 0;
                SelectedECRM_T003_A.amxild = 0;

                SelectedECRM_T003_A.aavgoo = 0;
                SelectedECRM_T003_A.aavild = 0;
                SelectedECRM_T003_A.tavgoo = 0;
                SelectedECRM_T003_A.tmp = "25";
                SelectedECRM_T003_A.humdt = "55%";
                WTRN = "refilno";
                WTAW = "wbtsta";
                WTBW = "watstb";

                DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                ILDChartCollection = CollectionViewSource.GetDefaultView(MC.ILDChart);
                ILDChartCollection.Filter = new Predicate<object>(ILDChartFilter);

                Defect_descCollection = CollectionViewSource.GetDefaultView(MC.Defect);
                Defect_descCollection.Filter = new Predicate<object>(Defect_descFilter);

                OperatorCollection = CollectionViewSource.GetDefaultView(MC.EmpList);
                OperatorCollection.Filter = new Predicate<object>(OperatorFilter);

                testTypeCollection = CollectionViewSource.GetDefaultView(MC.Test_Type);
                testTypeCollection.Filter = new Predicate<object>(TestTypeFilter);

                BatchCollection = CollectionViewSource.GetDefaultView(MC.BatchDetails);
                BatchCollection.Filter = new Predicate<object>(BatchFilter);

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

        private void AssignWeightGradeWise(decimal latestStableWeight)
        {
            if (WTDetails.Count > 0)
            {
                AWeightAll = WTDetails.All(x => x.wbtsta > 0);
                BWeightAll = WTDetails.All(x => x.watstb > 0);

                if (Math.Round(latestStableWeight, 2) <= ResetValue)
                {
                    if (AWeightAll == false)
                    {
                        if ((WTDetails.Count != CurrentARowIndex + 1) && WTDetails[CurrentARowIndex].wbtsta > 0)
                            CurrentARowIndex++;
                        SelectedRow = WTDetails[CurrentARowIndex];
                    }
                    else if (BWeightAll == false)
                    {
                        if (WTDetails.Count != CurrentBRowIndex + 1)
                            CurrentBRowIndex++;
                        SelectedRow = WTDetails[CurrentBRowIndex];
                    }
                    else
                    {
                        if (WTDetails.Count != CurrentCRowIndex + 1)
                            CurrentCRowIndex++;
                        SelectedRow = WTDetails[CurrentCRowIndex];
                    }

                    return;
                }

                if (latestStableWeight > 0.2m)
                {
                    if (AWeightAll == false)
                    {
                        SelectedRow.wbtsta = latestStableWeight;
                    }
                    else
                    {
                        if (BWeightAll == false)
                        {
                            SelectedRow.watstb = latestStableWeight;
                        }
                        else
                        {
                            SelectedRow.waclgc = latestStableWeight;
                        }
                    }
                }
            }
        }
        private void ResetScale(object InputValue)
        {
            AssignWeightGradeWise(0);
        }


        #region . User Defined Function .
        private void Load()
        {
            string request = "";
            SelectedECRM_T003_A.location_Id = Convert.ToString(AppSessionState.location_Id);
            SelectedECRM_T003_A.doc_type = "PD";
            request = (SelectedECRM_T003_A.prdct_codeBack) + "!@" + Convert.ToDateTime(SelectedECRM_T003_A.Fromdate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(SelectedECRM_T003_A.ToDate).ToString("MM/dd/yyyy") + "!@" + SelectedECRM_T003_A.doc_type + "!@" + Convert.ToString(SelectedECRM_T003_A.location_Id);
            MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T003_A>(MC, "ECRM_T003_A_Data", "WritingTest", "CRM", "LoadAll", 0, request);//request
            SelectedList = MC.WritingTest;

            DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
            DataGridCollection.Filter = new Predicate<object>(Filter);
            WTDetails = MC.WTDetails;
        }
        private void GetSelectedID(IList WTDetailsList)
        {
            try
            {
                IList list = WTDetailsList as IList;
                List<ECRM_T003_A> GetSelectedWTDetails = list.Cast<ECRM_T003_A>().ToList();

                if (GetSelectedWTDetails.Count > 0)
                {
                    if (SelectedECRM_T003_A != null)
                    {
                        try
                        {
                            SelectedECRM_T003_A.id = GetSelectedWTDetails[0].id;
                        }
                        catch
                        { }

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
        private void GetSelectedWTDetails(IList WTDetailsList)
        {
            try
            {
                IList list = WTDetailsList as IList;
                List<ECRM_T003_A> GetSelectedWTDetails = list.Cast<ECRM_T003_A>().ToList();

                if (GetSelectedWTDetails.Count > 0)
                {
                    blNew = false;
                    SelectedECRM_T003_A = (ECRM_T003_A)GetSelectedWTDetails[0];
                    MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T003_A>(MCTemp, GetSelectedWTDetails[0].wtno, "WritingTest", "CRM", "WT_Details", SelectedECRM_T003_A.id, SelectedECRM_T003_A.doc_type);
                    if (SelectedECRM_T003_A != null)
                    {
                        MC.WTDetails = MCTemp.WTDetails;
                        WTDetails.Clear();
                        WTDetails = new ObservableCollection<ECRM_T003_B>();
                        WTDetails = MCTemp.WTDetails;
                        try
                        {
                            //-----------------------------Change By Pallavi--------------------------------------
                            SelectedECRM_T003_A.aavgoo = MCTemp.WritingTest.ToList()[0].aavgoo;
                            SelectedECRM_T003_A.aavild = MCTemp.WritingTest.ToList()[0].aavild;
                            SelectedECRM_T003_A.amnild = MCTemp.WritingTest.ToList()[0].amnild;
                            SelectedECRM_T003_A.amxild = MCTemp.WritingTest.ToList()[0].amxild;
                            SelectedECRM_T003_A.Conv_lot = MCTemp.WritingTest.ToList()[0].Conv_lot;
                            SelectedECRM_T003_A.doc_cat = MCTemp.WritingTest.ToList()[0].doc_cat;
                            SelectedECRM_T003_A.doc_type = MCTemp.WritingTest.ToList()[0].doc_type;
                            SelectedECRM_T003_A.Fromdate = MCTemp.WritingTest.ToList()[0].Fromdate;
                            SelectedECRM_T003_A.humdt = MCTemp.WritingTest.ToList()[0].humdt;
                            SelectedECRM_T003_A.id = MCTemp.WritingTest.ToList()[0].id;
                            SelectedECRM_T003_A.ink = MCTemp.WritingTest.ToList()[0].ink;
                            SelectedECRM_T003_A.lotno = MCTemp.WritingTest.ToList()[0].lotno;
                            SelectedECRM_T003_A.machinecode = MCTemp.WritingTest.ToList()[0].machinecode;
                            SelectedECRM_T003_A.mchn_id = MCTemp.WritingTest.ToList()[0].mchn_id;
                            SelectedECRM_T003_A.modlno = MCTemp.WritingTest.ToList()[0].modlno;
                            SelectedECRM_T003_A.obrem = MCTemp.WritingTest.ToList()[0].obrem;
                            SelectedECRM_T003_A.prdct_code = MCTemp.WritingTest.ToList()[0].prdct_code;
                            SelectedECRM_T003_A.prdct_codeBack = MCTemp.WritingTest.ToList()[0].prdct_codeBack;
                            SelectedECRM_T003_A.prddt = MCTemp.WritingTest.ToList()[0].prddt;
                            SelectedECRM_T003_A.Rangea = MCTemp.WritingTest.ToList()[0].Rangea;
                            SelectedECRM_T003_A.Ranget = MCTemp.WritingTest.ToList()[0].Ranget;
                            SelectedECRM_T003_A.shift = MCTemp.WritingTest.ToList()[0].shift;
                            SelectedECRM_T003_A.tavgoo = MCTemp.WritingTest.ToList()[0].tavgoo;
                            SelectedECRM_T003_A.tavild = MCTemp.WritingTest.ToList()[0].tavild;
                            SelectedECRM_T003_A.timefr = MCTemp.WritingTest.ToList()[0].timefr;
                            SelectedECRM_T003_A.timeto = MCTemp.WritingTest.ToList()[0].timeto;
                            SelectedECRM_T003_A.tiptp = MCTemp.WritingTest.ToList()[0].tiptp;
                            SelectedECRM_T003_A.tm = MCTemp.WritingTest.ToList()[0].tm;
                            SelectedECRM_T003_A.tmnild = MCTemp.WritingTest.ToList()[0].tmnild;
                            SelectedECRM_T003_A.tmp = MCTemp.WritingTest.ToList()[0].tmp;
                            SelectedECRM_T003_A.tmxild = MCTemp.WritingTest.ToList()[0].tmxild;
                            SelectedECRM_T003_A.uhdec = MCTemp.WritingTest.ToList()[0].uhdec;
                            SelectedECRM_T003_A.uhrem = MCTemp.WritingTest.ToList()[0].uhrem;
                            SelectedECRM_T003_A.wtdt = MCTemp.WritingTest.ToList()[0].wtdt;
                            SelectedECRM_T003_A.wtno = MCTemp.WritingTest.ToList()[0].wtno;
                            SelectedECRM_T003_A.readonlly = "Visible";

                            if (MCTemp.WritingTest.ToList()[0].ToDate == null)
                            {
                                SelectedECRM_T003_A.ToDate = MCTemp.WritingTest.ToList()[0].prddt; //(DateTime.Now);
                            }
                            if (MCTemp.WritingTest.ToList()[0].Fromdate == null)
                            {
                                SelectedECRM_T003_A.Fromdate = MCTemp.WritingTest.ToList()[0].prddt; //(DateTime.Now);
                            }
                            //--------------------------------------------------------------
                            //SelectedECRM_T003_A.aavgoo = GetSelectedWTDetails[0].aavgoo;
                            //SelectedECRM_T003_A.aavild = GetSelectedWTDetails[0].aavild;
                            //SelectedECRM_T003_A.amnild = GetSelectedWTDetails[0].amnild;
                            //SelectedECRM_T003_A.amxild = GetSelectedWTDetails[0].amxild;
                            //SelectedECRM_T003_A.Conv_lot = GetSelectedWTDetails[0].Conv_lot;
                            //SelectedECRM_T003_A.doc_cat = GetSelectedWTDetails[0].doc_cat;
                            //SelectedECRM_T003_A.doc_type = GetSelectedWTDetails[0].doc_type;
                            //SelectedECRM_T003_A.Fromdate = GetSelectedWTDetails[0].Fromdate;
                            //SelectedECRM_T003_A.humdt = GetSelectedWTDetails[0].humdt;
                            //SelectedECRM_T003_A.id = GetSelectedWTDetails[0].id;
                            //SelectedECRM_T003_A.ink = GetSelectedWTDetails[0].ink;
                            //SelectedECRM_T003_A.lotno = GetSelectedWTDetails[0].lotno;
                            //SelectedECRM_T003_A.machinecode = GetSelectedWTDetails[0].machinecode;
                            //SelectedECRM_T003_A.mchn_id = GetSelectedWTDetails[0].mchn_id;
                            //SelectedECRM_T003_A.modlno = GetSelectedWTDetails[0].modlno;
                            //SelectedECRM_T003_A.obrem = GetSelectedWTDetails[0].obrem;
                            //SelectedECRM_T003_A.prdct_code = GetSelectedWTDetails[0].prdct_code;
                            //SelectedECRM_T003_A.prdct_codeBack = GetSelectedWTDetails[0].prdct_codeBack;
                            //SelectedECRM_T003_A.prddt = GetSelectedWTDetails[0].prddt;
                            //SelectedECRM_T003_A.Rangea = GetSelectedWTDetails[0].Rangea;
                            //SelectedECRM_T003_A.Ranget = GetSelectedWTDetails[0].Ranget;
                            //SelectedECRM_T003_A.shift = GetSelectedWTDetails[0].shift;
                            //SelectedECRM_T003_A.tavgoo = GetSelectedWTDetails[0].tavgoo;
                            //SelectedECRM_T003_A.tavild = GetSelectedWTDetails[0].tavild;
                            //SelectedECRM_T003_A.timefr = GetSelectedWTDetails[0].timefr;
                            //SelectedECRM_T003_A.timeto = GetSelectedWTDetails[0].timeto;
                            //SelectedECRM_T003_A.tiptp = GetSelectedWTDetails[0].tiptp;
                            //SelectedECRM_T003_A.tm = GetSelectedWTDetails[0].tm;
                            //SelectedECRM_T003_A.tmnild = GetSelectedWTDetails[0].tmnild;
                            //SelectedECRM_T003_A.tmp = GetSelectedWTDetails[0].tmp;
                            //SelectedECRM_T003_A.tmxild = GetSelectedWTDetails[0].tmxild;
                            //SelectedECRM_T003_A.uhdec = GetSelectedWTDetails[0].uhdec;
                            //SelectedECRM_T003_A.uhrem = GetSelectedWTDetails[0].uhrem;
                            //SelectedECRM_T003_A.wtdt = GetSelectedWTDetails[0].wtdt;
                            //SelectedECRM_T003_A.wtno = GetSelectedWTDetails[0].wtno;
                            //SelectedECRM_T003_A.readonlly = "Visible";

                            //if (GetSelectedWTDetails[0].ToDate == null)
                            //{
                            //    SelectedECRM_T003_A.ToDate = GetSelectedWTDetails[0].prddt; //(DateTime.Now);
                            //}
                            //if (GetSelectedWTDetails[0].Fromdate == null)
                            //{
                            //    SelectedECRM_T003_A.Fromdate = GetSelectedWTDetails[0].prddt; //(DateTime.Now);
                            //}

                            try
                            {
                                foreach (var item in WTDetails)
                                {
                                    if (item.wbtsta == (decimal)(0.00) || item.watstb == (decimal)(0.00))
                                    {
                                        hide = true;
                                    }
                                    else
                                    {
                                        hide = false;
                                    }
                                }
                                setReadOnly();
                                SelectedTabControlIndex = 0;
                            }
                            catch
                            {

                            }

                        }
                        catch
                        {

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
        private void GetSelectedILDChartDetails(IList ILDChartList)
        {
            if (SelectedECRM_T003_A.prddt == null)
            {
                MessageBox.Show("Please Select Production Date");
            }
            else
            {
                IList list = ILDChartList as IList;
                List<EPR_T001_P> SelectedILDChartDetailsTemp = list.Cast<EPR_T001_P>().ToList();
                if (ILDChartList.Count > 0)
                {
                    string request = "";
                    SelectedECRM_T003_A.doc_type = "PD";
                    SelectedECRM_T003_A.location_Id = Convert.ToString(AppSessionState.location_Id);
                    string temp_date = Convert.ToDateTime(SelectedECRM_T003_A.prddt).ToString("MM/dd/yyyy");
                    request = Convert.ToString(SelectedILDChartDetailsTemp[0].machine_id) + "!@" + SelectedECRM_T003_A.doc_type + "!@" + Convert.ToString(SelectedECRM_T003_A.location_Id + "!@" + temp_date);
                    SelectedECRM_T003_A.Conv_lot = "";
                    SelectedECRM_T003_A.tiptp = "";
                    SelectedECRM_T003_A.modlno = "";
                    SelectedECRM_T003_A.ink = "";
                    SelectedECRM_T003_A.prdct_code = "";
                    SelectedECRM_T003_A.order_no = "";
                    SelectedECRM_T003_A.tmnild = 0;
                    SelectedECRM_T003_A.tmxild = 0;
                    SelectedECRM_T003_A.tavild = 0;
                    SelectedECRM_T003_A.Ranget = 0;

                    if (SelectedILDChartDetailsTemp.Count > 0)
                    {
                        //load matchine detals from ild chart on the basis of conversion no and machine
                        WTDetails = new ObservableCollection<ECRM_T003_B>();
                        MCMchin = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T003_A>(MCMchin, "ECRM_T003_A_Data", "WritingTest", "CRM", "Machine_Details", SelectedILDChartDetailsTemp[0].machine_id, request);
                        SelectedECRM_T003_A.mchn_id = SelectedILDChartDetailsTemp[0].machine_id;
                        SelectedECRM_T003_A.machinecode = SelectedILDChartDetailsTemp[0].machinecode;

                        SelectedECRM_T003_A.Conv_lot = "";
                        SelectedECRM_T003_A.tiptp = "";
                        SelectedECRM_T003_A.modlno = "";
                        SelectedECRM_T003_A.ink = "";
                        SelectedECRM_T003_A.prdct_code = "";
                        SelectedECRM_T003_A.order_no = "";
                        Conv_lotCollection = CollectionViewSource.GetDefaultView(MCMchin.ConvLot);
                        Conv_lotCollection.Filter = new Predicate<object>(Conv_lotFilter);
                        if (MCMchin.ConvLot.ToList() != null && MCMchin.ConvLot.ToList().Count == 1)
                        {
                            SelectedECRM_T003_A.Conv_lot = Convert.ToString(MCMchin.ConvLot.ToList()[0].Conv_lot);
                            SelectedECRM_T003_A.ink = MCMchin.ConvLot.ToList()[0].ink;
                            SelectedECRM_T003_A.prdct_code = MCMchin.ConvLot.ToList()[0].ItemCode;
                            SelectedECRM_T003_A.itemname = MCMchin.ConvLot.ToList()[0].ItemName;
                            SelectedECRM_T003_A.modlno = MCMchin.ConvLot.ToList()[0].modelno;
                            SelectedECRM_T003_A.order_no = MCMchin.ConvLot.ToList()[0].order_no;

                            //--------------Min Max Avg ILD From ILD Chart ---------------------------------------//
                            SelectedECRM_T003_A.tmnild = MCMchin.ConvLot.ToList()[0].min_val;
                            SelectedECRM_T003_A.tmxild = MCMchin.ConvLot.ToList()[0].max_val;
                            SelectedECRM_T003_A.tavild = (MCMchin.ConvLot.ToList()[0].min_val + MCMchin.ConvLot.ToList()[0].max_val) / 2;
                            SelectedECRM_T003_A.Ranget = (MCMchin.ConvLot.ToList()[0].max_val - MCMchin.ConvLot.ToList()[0].min_val);

                            //------------------------------------------------------------------------------------------------//
                            List<ADM_M022_P_ESSEM> result1 = (List<ADM_M022_P_ESSEM>)MC.Products.Cast<ADM_M022_P_ESSEM>();
                            IEnumerable<ADM_M022_P_ESSEM> barEnumerable1 =
                                    from data in result1
                                    where data.prdct_code == SelectedECRM_T003_A.prdct_code
                                    select data;

                            foreach (var temp in barEnumerable1)
                            {
                                SelectedECRM_T003_A.tiptp = temp.tip_type;
                            }
                        }
                        else
                        {
                            SelectedECRM_T003_A.Conv_lot = "";
                            SelectedECRM_T003_A.tiptp = "";
                            SelectedECRM_T003_A.modlno = "";
                            SelectedECRM_T003_A.ink = "";
                            SelectedECRM_T003_A.prdct_code = "";
                            SelectedECRM_T003_A.order_no = "";
                        }

                        for (int i = 0; i < MCMchin.Refil.Count(); i++)
                        {
                            WTDetails.Add(new ECRM_T003_B
                            {
                                refilno = MCMchin.Refil[i].refilno
                            });
                        }
                        ;

                        CurrentARowIndex = 0;
                        CurrentBRowIndex = -1;
                        CurrentCRowIndex = -1;
                        SelectedRow = null;
                        AWeightAll = false;
                        BWeightAll = false;
                        SelectedRow = WTDetails[CurrentARowIndex];
                    }
                }
            }
        }
        private void GetSelectedDateDetails(DateTime prddt)
        {
            if (blNew == true)
            {
                SelectedECRM_T003_A.machinecode = "";
                SelectedECRM_T003_A.mchn_id = 0;
                SelectedECRM_T003_A.Conv_lot = "";
                SelectedECRM_T003_A.tiptp = "";
                SelectedECRM_T003_A.modlno = "";
                SelectedECRM_T003_A.ink = "";
                SelectedECRM_T003_A.prdct_code = "";
                SelectedECRM_T003_A.order_no = "";
                SelectedECRM_T003_A.tmnild = 0;
                SelectedECRM_T003_A.tmxild = 0;
                SelectedECRM_T003_A.tavild = 0;
                SelectedECRM_T003_A.Ranget = 0;
            }
        }
        private void GetSelectedConv_lotDetails(IList Conv_lotList)
        {
            IList list = Conv_lotList as IList;
            List<EPR_T001_P> SelectedConv_lotDetailsTemp = list.Cast<EPR_T001_P>().ToList();
            if (SelectedConv_lotDetailsTemp.Count > 0)
            {
                SelectedECRM_T003_A.Conv_lot = Convert.ToString(SelectedConv_lotDetailsTemp[0].Conv_lot);
                SelectedECRM_T003_A.ink = SelectedConv_lotDetailsTemp[0].ink;
                SelectedECRM_T003_A.prdct_code = SelectedConv_lotDetailsTemp[0].ItemCode;
                SelectedECRM_T003_A.itemname = SelectedConv_lotDetailsTemp[0].ItemName;
                SelectedECRM_T003_A.modlno = SelectedConv_lotDetailsTemp[0].modelno;
                SelectedECRM_T003_A.order_no = SelectedConv_lotDetailsTemp[0].order_no;
                //on selection of conversion no calculate tavild
                SelectedECRM_T003_A.tmnild = SelectedConv_lotDetailsTemp[0].min_val;
                SelectedECRM_T003_A.tmxild = SelectedConv_lotDetailsTemp[0].max_val;
                SelectedECRM_T003_A.tavild = (SelectedConv_lotDetailsTemp[0].min_val + SelectedConv_lotDetailsTemp[0].max_val) / 2;
                SelectedECRM_T003_A.Ranget = (SelectedConv_lotDetailsTemp[0].max_val - SelectedConv_lotDetailsTemp[0].min_val);

                //on the basis of product from ild get tip type
                List<ADM_M022_P_ESSEM> result1 = (List<ADM_M022_P_ESSEM>)MC.Products.Cast<ADM_M022_P_ESSEM>();
                IEnumerable<ADM_M022_P_ESSEM> barEnumerable1 =
                        from data in result1
                        where data.prdct_code == SelectedECRM_T003_A.prdct_code
                        select data;

                foreach (var temp in barEnumerable1)
                {
                    SelectedECRM_T003_A.tiptp = temp.tip_type;
                }
            }
        }
        private void GetSelectedDefect_descDetails(IList Defect_descList)
        {
            try
            {
                IList list = Defect_descList as IList;
                List<ZADM_M016_P> SelectedDefect_descDetailsTemp = list.Cast<ZADM_M016_P>().ToList();

                if (SelectedDefect_descDetailsTemp.Count > 0 && dgSelectedIndex != -1)
                {
                    var q = WTDetails.Where(X => X.defects == SelectedDefect_descDetailsTemp[0].dfctdsc).FirstOrDefault();

                    if (q != null)
                    {
                        if (WTDetails.Count() > dgSelectedIndex)
                        {
                            WTDetails[dgSelectedIndex].defects = SelectedDefect_descDetailsTemp[0].dfctdsc;
                        }
                    }
                    else
                    {
                        if (WTDetails.Count() <= dgSelectedIndex)
                        {
                            WTDetails.Add(new ECRM_T003_B() { defects = SelectedDefect_descDetailsTemp[0].dfctdsc });
                        }
                        else
                        {
                            WTDetails[dgSelectedIndex].defects = SelectedDefect_descDetailsTemp[0].dfctdsc;
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
        private void CellChangeUpdate(IList ItemsList)//chk duplicate Refill not enter
        {
            if (dgSelectedIndex != -1 && WTDetails.Count > 0 && WTDetails.Count > dgSelectedIndex && ItemsList.Count > 0)
            {
                IList list = ItemsList as IList;
                List<ECRM_T003_B> SelectedILDDetailsTemp = list.Cast<ECRM_T003_B>().ToList();
                {
                    if (SelectedILDDetailsTemp.Count > 0 && WTDetails[dgSelectedIndex].refilno != null)
                    {
                        if (WTDetails.Count > 0)
                        {
                            IEnumerable<ECRM_T003_B> distinctrefilno = (from o in WTDetails where o.refilno == SelectedILDDetailsTemp[0].refilno select o).ToList();
                            if (distinctrefilno.Count() <= 1)
                            {
                                WtCompare();
                            }
                            else
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Weight";
                                showMessageService.Text =
                                    String.Format("Refill No Should not be Duplicate'{0}'", this.Title);
                                showMessageService.ShowMessage();
                            }
                        }
                        try
                        {
                            foreach (var item in WTDetails)
                            {
                                if (item.wbtsta == (decimal)(0.00) || item.watstb == (decimal)(0.00))
                                {
                                    hide = true;
                                }
                                else
                                {
                                    hide = false;
                                }
                            }
                        }
                        catch
                        {

                        }
                    }
                }
            }
        }
        private void GetSelectedOperator(IList Operator)
        {
            try
            {

                IList list = Operator as IList;
                List<ADM_M024_P> GetSelectedOperator = list.Cast<ADM_M024_P>().ToList();

                if (GetSelectedOperator.Count > 0)
                {
                    SelectedECRM_T003_A.EmpId = GetSelectedOperator[0].EmpId;
                    SelectedECRM_T003_A.EmpNm = GetSelectedOperator[0].EmpLName;

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
        private void GetSelectedTestType(IList testType)
        {
            try
            {

                IList list = testType as IList;
                List<ECRM_T003_C_P> GetSelectedTestTest = list.Cast<ECRM_T003_C_P>().ToList();

                if (GetSelectedTestTest.Count > 0)
                {
                    SelectedECRM_T003_A.test_code = GetSelectedTestTest[0].test_code;
                    //SelectedECRM_T003_A.EmpNm = GetSelectedTestTest[0].test_desc;

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
        private bool WtCompare()//chk wt(A>B>C)
        {
            try
            {
                int i = 0;
                try
                {
                    if (WTDetails[dgSelectedIndex].wbtsta <= 3 && WTDetails[dgSelectedIndex].watstb <= 3 && WTDetails[dgSelectedIndex].wbtsta >= WTDetails[dgSelectedIndex].waclgc && WTDetails[dgSelectedIndex].watstb >= WTDetails[dgSelectedIndex].waclgc)
                    {
                        i = 0;
                        if (WTDetails[dgSelectedIndex].waclgc == 0)
                        {
                            WTDetails[dgSelectedIndex].waclgc = WTDetails[dgSelectedIndex].watstb;
                        }

                        RowCalculation();
                    }
                    if (WTDetails[dgSelectedIndex].watstb > WTDetails[dgSelectedIndex].wbtsta)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Weight";
                        showMessageService.Text =
                            String.Format("B Weight Should be Less than A Weight'{0}'", this.Title);
                        showMessageService.ShowMessage();
                        i = 1;
                    }
                    else if (WTDetails[dgSelectedIndex].wbtsta > 3)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Weight";
                        showMessageService.Text =
                            String.Format("A Weight Should Be Less than 3'{0}'", this.Title);
                        showMessageService.ShowMessage();
                        i = 1;
                    }
                    else if (WTDetails[dgSelectedIndex].watstb > 3)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Weight";
                        showMessageService.Text =
                            String.Format("B Weight Should Be Less than 3'{0}'", this.Title);
                        showMessageService.ShowMessage();
                        i = 1;
                    }
                    if (i == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {

                }

                if (i == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return true;
            }

        }
        private void RowCalculation()
        {//calculate gooping, actual gooping, target gooping
            try
            {
                decimal weighta;
                decimal weightc;
                decimal weightb;
                decimal ild;
                decimal gooping;
                decimal mulfact;
                int MType;
                try
                {
                    MType = Convert.ToInt32(SelectedECRM_T003_A.tm);
                }
                catch (Exception ex)
                {
                    MType = 200;
                }
                if (MType == 200)
                {
                    mulfact = Convert.ToDecimal(0.5);
                }
                else
                if (MType == 100)
                {
                    mulfact = 1;
                }
                else if (MType == 50)
                {
                    mulfact = 2;
                }
                else
                {
                    mulfact = 4;
                }
                try
                {
                    weighta = Convert.ToDecimal(WTDetails[dgSelectedIndex].wbtsta);
                }
                catch (Exception ex)
                {
                    weighta = 0;
                }

                try
                {
                    weightb = Convert.ToDecimal(WTDetails[dgSelectedIndex].watstb);
                }
                catch (Exception ex)
                {
                    weightb = 0;
                }

                try
                {
                    weightc = Convert.ToDecimal(WTDetails[dgSelectedIndex].waclgc);
                }
                catch (Exception ex)
                {
                    weightc = 0;

                }

                ild = Convert.ToDecimal((weighta - weightb) * 1000 * mulfact);

                decimal weight = (weighta - weightc);

                if (weight == 0 || weight == Convert.ToDecimal(0.0))
                {
                    gooping = 0;
                }
                else
                {
                    gooping = Convert.ToDecimal((weightb - weightc) / (weight) * 100);
                }

                try
                {
                    WTDetails[dgSelectedIndex].gooping = Math.Round(gooping, 6);
                    SelectedECRM_T003_A.tavgoo = (WTDetails.Sum(t => t.gooping));
                    SelectedECRM_T003_A.aavgoo = (WTDetails.Sum(t => t.gooping)) / WTDetails.Count; ;

                }
                catch (Exception ex)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GetSelectedProductOnFlip(IList ProdctList)
        {//fire when on flip product selection
            IList list = ProdctList as IList;
            List<ECRM_T003_A_P> SelectedProdctDetailsTemp = list.Cast<ECRM_T003_A_P>().ToList();
            if (SelectedProdctDetailsTemp.Count > 0)
            {
                SelectedECRM_T003_A.prdct_codeBack = SelectedProdctDetailsTemp[0].prdct_code;
            }
        }
        private void getSelectedRow(IList SelectedItems)
        {
            IList list = SelectedItems as IList;
            List<ECRM_T003_B> GetSelectedWT_Details = list.Cast<ECRM_T003_B>().ToList();

            if (GetSelectedWT_Details.Count > 0)
            {
                int x = WTDetails.IndexOf(WTDetails.Where(X => X.refilno == GetSelectedWT_Details[0].refilno).FirstOrDefault());
                if (SelectedECRM_T003_A.id == 0 && GetSelectedWT_Details[0].wtid == null)
                {
                    if (x >= 0 && x != -1)
                    {
                        WTDetails.RemoveAt(x);
                    }
                }
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
                    Request = SelectedECRM_T003_A.client + "!@" + SelectedECRM_T003_A.comp_code + "!@" + InputValue.ToString();
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
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    //LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
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
        private void InsertBatchDetails(object InputValue)
        {
            try
            {
                string Request = "";
                PPC_T003_Batch POPUPEntityObject = null;
                barcode = InputValue.ToString();
                if (barcode.Length > 12)
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            var InputValueIfExists = MC.BatchDetails.Where(X => X.batch_no == Request).FirstOrDefault();//Checking Weather Barcode is Valid or Not By Checking in Business Entity
                            if (InputValueIfExists != null)
                            {
                                POPUPEntityObject = MC.BatchDetails.Where(x => (x.batch_no ?? "").Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; //If Barcode is Valid Get All the Information in PopupEntityObject
                            }
                            else
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Invalid Barcode.\n Please Scan Valid Barcode", this.Title);
                                showMessageService.ShowMessage();
                            }
                            SelectedECRM_T003_A = new ECRM_T003_A();
                        }
                    }

                    else if (InputValue != null && ((IEnumerable)InputValue).Cast<PPC_T003_Batch>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<PPC_T003_Batch>().ToList()[0];
                    }
                    if (POPUPEntityObject != null)
                    {
                        SelectedECRM_T003_A.batch_no = POPUPEntityObject.batch_no;
                        SelectedECRM_T003_A.prddt = POPUPEntityObject.prod_date;
                        SelectedECRM_T003_A.Conv_lot = POPUPEntityObject.conversion_no.ToString();
                        SelectedECRM_T003_A.order_no = POPUPEntityObject.doc_no;
                        SelectedECRM_T003_A.shift = POPUPEntityObject.shift1;
                        SelectedECRM_T003_A.EmpId = POPUPEntityObject.m_operator;
                        SelectedECRM_T003_A.EmpNm = POPUPEntityObject.operatornm;
                        SelectedECRM_T003_A.prdct_code = POPUPEntityObject.ItemCode;
                        SelectedECRM_T003_A.counter_qty = POPUPEntityObject.counter_q;
                        SelectedECRM_T003_A.machinecode = POPUPEntityObject.machinecode;
                        SelectedECRM_T003_A.mchn_id = POPUPEntityObject.machine_id;
                        SelectedECRM_T003_A.itemname = POPUPEntityObject.ItemName;
                        SelectedECRM_T003_A.modlno = POPUPEntityObject.model_code;
                        SelectedECRM_T003_A.ink = POPUPEntityObject.ink;
                    }
                }
            }

            catch (Exception ex) { }
        }
        #endregion
        #region · Command Actions ·

        private bool ValidateControls()
        {
            try
            {
                int i = 0;
                try
                {
                    if (SelectedECRM_T003_A.shift == "" || SelectedECRM_T003_A.shift == null)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Required";
                        showMessageService.Text =
                            String.Format("Shift Required", this.Title);
                        showMessageService.ShowMessage();
                        i = 1;
                    }


                    for (int P = 0; P < WTDetails.Count; P++)
                    {

                        if (WTDetails[P].refilno == "" || WTDetails[P].refilno == null)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Refil No";
                            showMessageService.Text =
                                String.Format("Refil No Required", this.Title);
                            showMessageService.ShowMessage();
                            i = 1;
                            break;
                        }
                        else if (WTDetails[P].watstb > WTDetails[P].wbtsta)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Weight";
                            showMessageService.Text =
                                String.Format("B Weight Should be Less than A Weight'{0}'", this.Title);
                            showMessageService.ShowMessage();
                            i = 1;
                            break;
                        }
                        else if (WTDetails[P].wbtsta > 3)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Weight";
                            showMessageService.Text =
                                String.Format("A Weight Should Be Less than 3'{0}'", this.Title);
                            showMessageService.ShowMessage();
                            i = 1;
                            break;
                        }
                        else if (WTDetails[P].watstb > 3)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Weight";
                            showMessageService.Text =
                                String.Format("B Weight Should Be Less than 3'{0}'", this.Title);
                            showMessageService.ShowMessage();
                            i = 1;
                            break;
                        }

                    }
                    if (i == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {

                }

                if (i == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return true;
            }
        }
        public void setReadOnly()//set a wt and b wt read only after save
        {
            int Z = 0; int Y = 0;
            for (int P = 0; P < WTDetails.Count; P++)
            {
                if (WTDetails[P].watstb > 0)
                {
                    Z = Z + 1;
                }
                else
                {
                    Z = 0;
                }
                if (WTDetails[P].wbtsta > 0)
                {
                    Y = Y + 1;
                }
                else
                {
                    Y = 0;
                }
            }
            if (Z > 0)
            {
                blB = false;

            }
            else
            {
                blB = true;
            }

            if (Y > 0)
            {
                blA = false;

            }
            else
            {
                blA = true;
            }
        }
        protected override void OnSaveAction(InquiryActionResult<ECRM_T003_A> result)
        {
            try
            {
                if (WTDetails.Count > 0)
                {
                    {
                        SelectedECRM_T003_A.add_by = AppSessionState.UserID;
                        SelectedECRM_T003_A.location_Id = Convert.ToString(AppSessionState.location_Id);
                        SelectedECRM_T003_A.comp_code = AppSessionState.comp_code;
                        SelectedECRM_T003_A.client = AppSessionState.client;
                        ObjectSerializationService objSer = new ObjectSerializationService();
                        SelectedECRM_T003_A.XmlDataDocument_ECRM_T003_B = objSer.ObjectToXML(WTDetails);
                        if (WtCompare() == true)
                        {
                            if (ValidateControls() == true)
                            {
                                if (blNew == true)
                                {
                                    SelectedECRM_T003_A = repository.SaveWithReturnDomainObject<ECRM_T003_A>(SelectedECRM_T003_A, "WritingTest", "CRM");
                                    var tempSelectRemove = SelectedList.Where(x => x.id == SelectedECRM_T003_A.id).FirstOrDefault();
                                    SelectedList.Remove(tempSelectRemove);
                                    SelectedList.Add(SelectedECRM_T003_A);
                                    blNew = false;
                                }
                                else if (blNew == false)
                                {
                                    int y = 0;
                                    if (SelectedECRM_T003_A.active == false)
                                    {
                                        y = 1;
                                    }
                                    SelectedECRM_T003_A = repository.UpdateWithReturnDomainObject<ECRM_T003_A>(SelectedECRM_T003_A, "WritingTest", "CRM");
                                    var tempSelectRemove = SelectedList.Where(x => x.id == SelectedECRM_T003_A.id).FirstOrDefault();
                                    SelectedList.Remove(tempSelectRemove);
                                    if (SelectedECRM_T003_A.active == true)
                                    {
                                        SelectedList.Add(SelectedECRM_T003_A);
                                    }
                                    this.SelectedECRM_T003_A.EndEdit();
                                    if (y == 1)
                                    {
                                        SelectedECRM_T003_A = new ECRM_T003_A();
                                    }
                                }
                                DataGridCollection.SortDescriptions.Add(new SortDescription("id", ListSortDirection.Descending));
                                _dataGridCollection.Refresh();
                                MessageBox.Show("Record Saved Successfully");
                                SelectedECRM_T003_A.prddt = SelectedECRM_T003_A.prddt;
                                SelectedECRM_T003_A.Fromdate = SelectedECRM_T003_A.prddt;//DateTime.Now;
                                SelectedECRM_T003_A.ToDate = SelectedECRM_T003_A.prddt; //DateTime.Now;
                                if (SelectedECRM_T003_A.XmlDataDocument_ECRM_T003_B != null)
                                {
                                    MC.WTDetails = (ObservableCollection<ECRM_T003_B>)new ObjectSerializationService().XMLToObject(SelectedECRM_T003_A.XmlDataDocument_ECRM_T003_B, MC.WTDetails);
                                }
                                else
                                {
                                    MC.WTDetails = new ObservableCollection<ECRM_T003_B>();
                                }
                                WTDetails = MC.WTDetails;
                                setReadOnly();
                            }
                        }
                    }
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter Refill No", this.Title);
                    showMessageService.ShowMessage();
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
        protected override void OnCreateAction(InquiryActionResult<ECRM_T003_A> result)
        {
            blNew = true;
            string tempPrdDate;
            tempPrdDate = "";
            tempPrdDate = Convert.ToString(SelectedECRM_T003_A.prddt);

            SelectedECRM_T003_A = new ECRM_T003_A();
            SelectedECRM_T003_A.ValidateAsync().Wait();


            WTDetails = new ObservableCollection<ECRM_T003_B>();
            WTDetails.Clear();
            _dataGridCollection.Refresh();
            SelectedECRM_T003_A.wtdt = DateTime.Now;

            SelectedECRM_T003_A.prddt = Convert.ToDateTime(tempPrdDate);
            SelectedECRM_T003_A.Fromdate = Convert.ToDateTime(tempPrdDate);// DateTime.Now;
            SelectedECRM_T003_A.ToDate = Convert.ToDateTime(tempPrdDate);// DateTime.Now;
            SelectedECRM_T003_A.timeto = DateTime.Now.ToString(" HH:mm");
            SelectedECRM_T003_A.tm = 25;
            SelectedECRM_T003_A.tmp = "25";
            SelectedECRM_T003_A.humdt = "55%";
            SelectedECRM_T003_A.client = AppSessionState.client;
            hide = true;
            blA = true;
            blB = true;
            SelectedECRM_T003_A.amnild = 0;
            SelectedECRM_T003_A.amxild = 0;

            SelectedECRM_T003_A.aavgoo = 0;
            SelectedECRM_T003_A.aavild = 0;
            SelectedECRM_T003_A.tavgoo = 0;
            SelectedECRM_T003_A.ts_code = ts_code_vm;
            SelectedECRM_T003_A.client = AppSessionState.client;

            CurrentARowIndex = 0;
            CurrentBRowIndex = -1;
            CurrentCRowIndex = -1;
            SelectedRow = null;
            AWeightAll = false;
            BWeightAll = false;
        }
        protected override void OnRemoveAction(InquiryActionResult<ECRM_T003_A> result)
        {
            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            showMessageService.ButtonSetup = DialogButton.Ok;
            showMessageService.Caption = "Delete Changes";
            showMessageService.Text =
                String.Format(
                    "This record will delete forever '{0}'",
                        this.Title);

            if (showMessageService.ShowMessage() == DialogResult.Ok)
            {
                this.SelectedECRM_T003_A.CancelEdit();
                string response = repository.Delete(SelectedECRM_T003_A.wtno, "WritingTest", "CRM");
                SelectedList.Remove(SelectedECRM_T003_A);
                _dataGridCollection.Refresh();
                SelectedECRM_T003_A = new ECRM_T003_A();
                WTDetails = new ObservableCollection<ECRM_T003_B>();
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ECRM_T003_A> result)
        {
            SelectedECRM_T003_A.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ECRM_T003_A> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<ECRM_T003_A> result)
        {
            SelectedList = SelectedList;
            SelectedECRM_T003_A = SelectedECRM_T003_A;
        }
        protected override void OnHelpAction(InquiryActionResult<ECRM_T003_A> result)
        {
            SelectedList = SelectedList;
            SelectedECRM_T003_A = SelectedECRM_T003_A;
        }
        protected override void OnPrintAction(InquiryActionResult<ECRM_T003_A> result)
        {
            MCRpt = repositoryRpt.GetDataWithReturnDomainObject<MultipleContext_WTRpt_ECRM_T003_A>(MCRpt, SelectedECRM_T003_A.wtno, "WritingTestForProduction", "Production", "WTProdcReport", SelectedECRM_T003_A.id, "");
            WTReport = MCRpt.WritingTest;
            object objDS;
            objDS = MCRpt.WritingTest;

            ReportManager ReportManager = new ReportingServices.ReportManager();
            ReportManager.DisplayReport(objDS, "WTProdcRptDS", "\\CRM\\WTest.rdlc");

        }
        //protected override void OnExportAction(InquiryActionResult<ECRM_T003_A> result)
        //{
        //    try
        //    {
        //        List<ECRM_T003_A> Export_List = new List<ECRM_T003_A>();
        //        foreach (var o in DataGridCollection)
        //        {
        //            ECRM_T003_A Data = o as ECRM_T003_A;
        //            Export_List.Add(Data);
        //        }

        //        //--------------------------------------

        //        ExportToExcel<ECRM_T003_A, List<ECRM_T003_A>> export = new ExportToExcel<ECRM_T003_A, List<ECRM_T003_A>>();
        //        ICollectionView view = CollectionViewSource.GetDefaultView(Export_List);
        //        export.dataToPrint = (List<ECRM_T003_A>)view.SourceCollection;

        //        export.GenerateReport();
        //    }
        //    catch (Exception ex)
        //    {
        //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //        showMessageService.ButtonSetup = DialogButton.Ok;
        //        showMessageService.Caption = "Message";
        //        showMessageService.Text = String.Format(ex.Message, this.Title);
        //        showMessageService.ShowMessage();
        //    }

        //}
        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }
        protected override void OnRefreshCommand(InquiryActionResult<ECRM_T003_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ECRM_T003_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ECRM_T003_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ECRM_T003_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ECRM_T003_A> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region "Filters"
        #region Filters For ILDChart
        private void FilterCollectionILDChart()
        {
            if (_ILDChartCollection != null)
            {
                _ILDChartCollection.Refresh();
            }

        }
        public string FilterStringILDChart
        {
            get { return _filterStringILDChart; }
            set
            {
                _filterStringILDChart = value;
                RaisePropertyChanged("FilterStringILDChart");
                FilterCollectionILDChart();
            }
        }
        public bool ILDChartFilter(object obj)
        {
            var data = obj as EPR_T001_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringILDChart))
                {
                    return (
                        (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterStringILDChart.ToLower())) ||
                        (data.machine_type != null && data.machine_type.ToString().ToLower().Contains(_filterStringILDChart.ToLower())) ||
                        (data.machinedesc != null && data.machinedesc.ToString().ToLower().Contains(_filterStringILDChart.ToLower()))
                        );

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Conv_lot
        private void FilterCollectionConv_lot()
        {
            if (_Conv_lotCollection != null)
            {
                _Conv_lotCollection.Refresh();
            }

        }
        public string FilterStringConv_lot
        {
            get { return _filterStringConv_lot; }
            set
            {
                _filterStringConv_lot = value;
                RaisePropertyChanged("FilterStringConv_lot");
                FilterCollectionConv_lot();
            }
        }
        public bool Conv_lotFilter(object obj)
        {
            var data = obj as EPR_T001_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringConv_lot))
                {
                    return (data.Conv_lot != null && data.Conv_lot.ToString().ToLower().Contains(_filterStringConv_lot.ToLower())) ||
                   (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterStringConv_lot.ToLower())) ||
                   (data.start_dt != null && data.start_dt.ToString().ToLower().Contains(_filterStringConv_lot.ToLower())) ||
                   (data.Status != null && data.Status.ToString().ToLower().Contains(_filterStringConv_lot.ToLower())) ||
                   (data.id != null && data.id.ToString().ToLower().Contains(_filterStringConv_lot.ToLower())
                 );

                }
                return true;
            }
            return false;
        }
        #endregion             
        #region Filters For Defect_desc
        private void FilterCollectionDefect_desc()
        {
            if (_Defect_descCollection != null)
            {
                _Defect_descCollection.Refresh();
            }

        }
        public string FilterStringDefect_desc
        {
            get { return _filterStringDefect_desc; }
            set
            {
                _filterStringDefect_desc = value;
                RaisePropertyChanged("FilterStringDefect_desc");
                FilterCollectionDefect_desc();
            }
        }
        public bool Defect_descFilter(object obj)
        {
            var data = obj as ZADM_M016_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringDefect_desc))
                {
                    return (
                        (data.dfctdsc != null && data.dfctdsc.ToString().ToLower().Contains(_filterStringDefect_desc.ToLower())) ||
                        (data.scope != null && data.scope.ToString().ToLower().Contains(_filterStringDefect_desc.ToLower()))

                        );

                }
                return true;
            }
            return false;
        }

        #endregion
        #region Filters For ProdctBack
        private void FilterCollectionProdctBack()
        {
            if (_ProdctCollectionBack != null)
            {
                _ProdctCollectionBack.Refresh();
            }

        }
        public string FilterStringProdctBack
        {
            get { return _filterStringProdctBack; }
            set
            {
                _filterStringProdctBack = value;
                RaisePropertyChanged("FilterStringProdctBack");
                FilterCollectionProdctBack();
            }
        }
        public bool ProdctBackFilter(object obj)
        {
            var data = obj as ECRM_T003_A;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringProdctBack))
                {
                    return (

                        (data.prdct_code != null && data.prdct_code.ToString().ToLower().Contains(_filterStringProdctBack.ToLower()))

                        );

                }
                return true;
            }
            return false;
        }

        #endregion
        #region "Filter for Back Content Datagrid"
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
            var data = obj as ECRM_T003_A;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.wtno != null && data.wtno.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    (data.wtdt != null && data.wtdt.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    (data.lotno != null && data.lotno.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    (data.shift != null && data.shift.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    (data.prddt != null && data.prddt.ToString().ToLower().Contains(_filterString.ToLower()) ||
                    (data.prdct_code != null && data.prdct_code.ToString().ToLower().Contains(_filterString.ToLower())));

                }
                return true;
            }
            return false;
        }
        #endregion
        #region Filters For Operator
        private void FilterCollectionOperator()
        {
            if (_OperatorCollection != null)
            {
                _OperatorCollection.Refresh();
            }

        }
        private string _filterStringOperator;
        public string FilterStringOperator
        {
            get { return _filterStringOperator; }
            set
            {
                _filterStringOperator = value;
                RaisePropertyChanged("FilterStringOperator");
                FilterCollectionOperator();
            }
        }
        public bool OperatorFilter(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringOperator))
                {
                    return (

                        (data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterStringOperator.ToLower()) ||
                        data.EmpLName != null && data.EmpLName.ToString().ToLower().Contains(_filterStringOperator.ToLower()))

                        );

                }
                return true;
            }
            return false;
        }

        #endregion
        #region Filters For test tyep
        private void FilterCollectionTestType()
        {
            if (_testTypeCollection != null)
            {
                _testTypeCollection.Refresh();
            }

        }
        private string _filterStringTestType;
        public string FilterStringTestType
        {
            get { return _filterStringTestType; }
            set
            {
                _filterStringTestType = value;
                RaisePropertyChanged("FilterStringTestType");
                FilterCollectionOperator();
            }
        }
        public bool TestTypeFilter(object obj)
        {
            var data = obj as ECRM_T003_C_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringProdctBack))
                {
                    return (

                        (data.test_code != null && data.test_code.ToString().ToLower().Contains(_filterStringProdctBack.ToLower()) ||
                        data.test_desc != null && data.test_desc.ToString().ToLower().Contains(_filterStringProdctBack.ToLower()))

                        );

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
            var data = obj as PPC_T003_Batch;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Barcode))
                {
                    return (data.batch_no != null && data.batch_no.ToString().ToLower().Contains(_filterString_Barcode.ToLower()));
                }
                return true;
            }
            return false;
        }


        #endregion

        #endregion


    }
}
