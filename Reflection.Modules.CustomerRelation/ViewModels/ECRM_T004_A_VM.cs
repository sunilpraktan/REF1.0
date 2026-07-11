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
using System.Collections.ObjectModel;
using System.Windows;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;
using Reflection.ReportingServices;
using Reflection.BusinessEntity.CustomerRelation;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class ECRM_T004_A_VM : WorkspaceViewModel<ECRM_T004_A>
    {
        bool blNew = true;
        WebServiceRepository<ECRM_T004_A> repository = new WebServiceRepository<ECRM_T004_A>();
        WebServiceRepository<MultipleContext_ECRM_T004_A> repositoryM = new WebServiceRepository<MultipleContext_ECRM_T004_A>();
        MultipleContext_ECRM_T004_A MCTemp = new MultipleContext_ECRM_T004_A();
        MultipleContext_ECRM_T004_A MCConLot = new MultipleContext_ECRM_T004_A();
        MultipleContext_ECRM_T004_A MCMchin = new MultipleContext_ECRM_T004_A();
        MultipleContext_ECRM_T004_A MCRpt = new MultipleContext_ECRM_T004_A();
        WebServiceRepository<MultipleContext_ECRM_T004_A> repositoryRpt = new WebServiceRepository<MultipleContext_ECRM_T004_A>();


        private ICollectionView _dataGridCollection;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        private int _dgSelectedIndex;
        private string _filterString;

        private string _filterStringILDChart;
        private string _filterStringConv_lot;
        private string _filterStringShift_lot;
        private string _filterStringCustomerBack;

        private List<SEL_T001_PDIQualityInstRpt> _RptQualityInst;
        public List<SEL_T001_PDIQualityInstRpt> RptQualityInst
        {
            get { return _RptQualityInst; }
            set
            {
                if (_RptQualityInst != value)
                {
                    _RptQualityInst = value;
                    RaisePropertyChanged("RptQualityInst");
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
       

        #region ICollection
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }
        private ICollectionView _ShiftCollection;
        public ICollectionView ShiftCollection
        {
            get { return _ShiftCollection; }
            set { _ShiftCollection = value; RaisePropertyChanged("ShiftCollection"); }
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
        //private ICollectionView _ILDCollection;
        //public ICollectionView ILDCollection
        //{
        //    get { return _ILDCollection; }
        //    set
        //    {
        //        _ILDCollection = value;

        //        RaisePropertychanged("ILDCollection");
        //    }
        //}

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

        private ICollectionView _Shift_lotCollection;
        public ICollectionView Shift_lotCollection
        {
            get { return _Shift_lotCollection; }
            set
            {
                _Shift_lotCollection = value;

                RaisePropertyChanged("Shift_lotCollection");
            }
        }

        private ICollectionView _CustomerCollectionBack;
        public ICollectionView CustomerCollectionBack
        {
            get { return _CustomerCollectionBack; }
            set
            {
                _CustomerCollectionBack = value;

                RaisePropertyChanged("CustomerCollectionBack");
            }
        }
        private ICollectionView _OperatorCollection;
        public ICollectionView OperatorCollection
        {
            get { return _OperatorCollection; }
            set { _OperatorCollection = value; RaisePropertyChanged("OperatorCollection"); }
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
        //public RelayCommand<IList> SelectionChangedCommand
        //{
        //    get;
        //    private set;
        //}
        public RelayCommand<IList> SelectionChangedCommandPDIEntery
        {
            get;
            private set;
        }

        public RelayCommand<IList> SelectionChangedCommandShift
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandILDChart
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionIDCommand
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandILD
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandConv_lot
        {
            get;
            private set;
        }

        public RelayCommand<IList> SelectionChangedCommandShift_lot
        {
            get;
            private set;
        }
        public RelayCommand<DateTime> SelectedDateChangedCommand
        {
            get;
            private set;
        }
        private RelayCommand _ReportCommand;
        public RelayCommand ReportCommand
        {
            get;
            private set;
        }
        public RelayCommand LoadQualityInterest { get; private set; }
        public RelayCommand<IList> SelectionChangedCommandCustomerBack
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
        #endregion

        #region ECRM_T004_A

        private string _type;
        public string type
        {
            get { return _type; }
            set { _type = value; RaisePropertyChanged("type"); }
        }

        private List<ECRM_T004_A> _SelectedList;
        public List<ECRM_T004_A> SelectedList
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
        private ECRM_T004_A _SelectedECRM_T004_A;
        public ECRM_T004_A SelectedECRM_T004_A
        {
            get
            {
                this.ErrorExist = _SelectedECRM_T004_A.HasErrors;
                return _SelectedECRM_T004_A;
            }
            set
            {
                if (_SelectedECRM_T004_A != value)
                {
                    _SelectedECRM_T004_A = value;
                    this.ErrorExist = _SelectedECRM_T004_A.HasErrors;
                    RaisePropertyChanged("SelectedECRM_T004_A");
                    value.BeginEdit();
                }
            }
        }
        #endregion

        #region ECRM_T004_B
        private static ObservableCollection<ECRM_T004_B> _PDI_Entry_Dtails = new ObservableCollection<ECRM_T004_B>();
        public ObservableCollection<ECRM_T004_B> PDI_Entry_Dtails
        {
            get { return _PDI_Entry_Dtails; }
            set
            {
                if (_PDI_Entry_Dtails != value)
                {
                    _PDI_Entry_Dtails = value;

                    RaisePropertyChanged("PDI_Entry_Dtails");
                }
            }
        }
        public ECRM_T004_B _SelectedECRM_T004_B { get; private set; }
        public ECRM_T004_B SelectedECRM_T004_B
        {
            get { return _SelectedECRM_T004_B; }
            set
            {
                if (_SelectedECRM_T004_B != value)
                {
                    _SelectedECRM_T004_B = value;
                    RaisePropertyChanged("SelectedECRM_T004_B");
                    // value.BeginEdit();
                }
            }
        }
        private List<ECRM_T004_B> _SelectedECRM_T004_B_List;
        public List<ECRM_T004_B> SelectedECRM_T004_B_List
        {
            get
            {
                return _SelectedECRM_T004_B_List;
            }
            set
            {
                _SelectedECRM_T004_B_List = value;
                RaisePropertyChanged("SelectedECRM_T004_B_List");
            }
        }

        #endregion

        #region PDIRpt_ECRM_T004_A  Report
        private PDIRpt_ECRM_T004_A _SelectedPDIRpt_ECRM_T004_A;
        public PDIRpt_ECRM_T004_A SelectedPDIRpt_ECRM_T004_A
        {
            get
            {
                _SelectedPDIRpt_ECRM_T004_A.ValidateAsync().Wait();
                this.ErrorExist = _SelectedPDIRpt_ECRM_T004_A.HasErrors;
                return _SelectedPDIRpt_ECRM_T004_A;
            }
            set
            {
                if (_SelectedPDIRpt_ECRM_T004_A != value)
                {
                    _SelectedPDIRpt_ECRM_T004_A = value;


                    RaisePropertyChanged("SelectedPDIRpt_ECRM_T004_A");
                    value.BeginEdit();

                }
            }
        }
        private ObservableCollection<PDIRpt_ECRM_T004_A> _PDIReport;
        public ObservableCollection<PDIRpt_ECRM_T004_A> PDIReport
        {
            get { return _PDIReport; }
            set
            {
                if (_PDIReport != value)
                {
                    _PDIReport = value;


                    RaisePropertyChanged("PDIReport");

                }
            }
        }
        #endregion

        #region EPR_T001_PopUp
        private EPR_T001_PopUp _SelectedILDChart;
        public EPR_T001_PopUp SelectedILDChart
        {
            get { return _SelectedILDChart; }
            set
            {
                if (_SelectedILDChart != value)
                {
                    _SelectedILDChart = value;
                    RaisePropertyChanged("SelectedILDChart");

                }
            }
        }
        private List<EPR_T001_PopUp> _SelectedListOfILDChartList;
        public List<EPR_T001_PopUp> SelectedListOfILDChartList
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
        private ObservableCollection<EPR_T001_PopUp> _ILDChartDtls;
        public ObservableCollection<EPR_T001_PopUp> ILDChartDtls
        {
            get { return _ILDChartDtls; }
            set
            {
                _ILDChartDtls = value;
                RaisePropertyChanged("ILDChartDtls");
            }
        }


        #endregion

        #region ECR_T004_PopUp_Lot
        private ECR_T004_PopUp_Lot _SelectedConv_lot;
        public ECR_T004_PopUp_Lot SelectedConv_lot
        {
            get { return _SelectedConv_lot; }
            set
            {
                if (_SelectedConv_lot != value)
                {
                    _SelectedConv_lot = value;
                    RaisePropertyChanged("SelectedConv_lot");

                }
            }
        }
        private List<ECR_T004_PopUp_Lot> _SelectedListOfConv_lotList;
        public List<ECR_T004_PopUp_Lot> SelectedListOfConv_lotList
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
        private ObservableCollection<ECR_T004_PopUp_Lot> _Conv_lotDtls;
        public ObservableCollection<ECR_T004_PopUp_Lot> Conv_lotDtls
        {
            get { return _Conv_lotDtls; }
            set
            {
                _Conv_lotDtls = value;
                RaisePropertyChanged("Conv_lotDtls");
            }
        }


        #endregion

        ////private Nullable<System.DateTime> _prodate;
        ////public Nullable<System.DateTime> prodate
        ////{
        ////    get { return _prodate; }
        ////    set
        ////    {
        ////        _prodate = value;
        ////        RaisePropertychanged("prodate");
        ////    }
        ////}

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

        #region MultipleContext_ECRM_T004_A


        MultipleContext_ECRM_T004_A _MC = new MultipleContext_ECRM_T004_A();
        public MultipleContext_ECRM_T004_A MC
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

        #endregion

        #region MOdel updated

        void ModelUpdated_Master(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = SelectedECRM_T004_A.HasErrors;
            if (sender.ToString() == "qty" || sender.ToString() == "addition" || sender.ToString() == "rej_qty" || sender.ToString() == "check_qty" || sender.ToString() == "sample_qty" || sender.ToString() == "refil_qty")
            {
                cal();
            }
        }

        private void cal()
        {
            try
            {
                decimal? qty = 0;
                decimal? sample_qty = 0;
                decimal? check_qty = 0;
                decimal? rej_qty = 0;
                decimal? addition = 0;
                decimal? final_qty = 0;
                if (SelectedECRM_T004_A.qty != null)
                {
                    SelectedECRM_T004_A.final_qty = (Convert.ToDecimal(SelectedECRM_T004_A.qty)) - (Convert.ToDecimal(SelectedECRM_T004_A.sample_qty)) - (Convert.ToDecimal(SelectedECRM_T004_A.check_qty)) - (Convert.ToDecimal(SelectedECRM_T004_A.rej_qty)) + (Convert.ToDecimal(SelectedECRM_T004_A.addition));
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

        #region
        public ECRM_T004_A_VM(string ts_code)
            : base()
        {
            this.ts_code_vm = ts_code;
            SelectedList = new List<ECRM_T004_A>();
            SelectedECRM_T004_A = new ECRM_T004_A();
            MC = new MultipleContext_ECRM_T004_A();
            PDI_Entry_Dtails = new ObservableCollection<ECRM_T004_B>();
            SelectedECRM_T004_B_List = new List<ECRM_T004_B>();
            SelectedECRM_T004_B = new ECRM_T004_B();
            MC.PDIEntryDetails = new ObservableCollection<ECRM_T004_B>();
            SelectedECRM_T004_A.ValidateAsync().Wait();
            ECRM_T004_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            SelectedECRM_T004_A.pdi_date = DateTime.Now;
            SelectedECRM_T004_A.prodate = DateTime.Now;
            SelectedECRM_T004_A.client = AppSessionState.client;
            SelectedECRM_T004_A.user_source1 = AppSessionState.UserSource1;
            SelectedECRM_T004_A.user_source2 = AppSessionState.UserSource2;
            SelectedECRM_T004_A.userid = AppSessionState.UserID;
            LoadInitialData();
        }
        public ECRM_T004_A_VM(string ts_code, string doc_no)
            : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            SelectedList = new List<ECRM_T004_A>();
            SelectedECRM_T004_A = new ECRM_T004_A();
            MC = new MultipleContext_ECRM_T004_A();
            PDI_Entry_Dtails = new ObservableCollection<ECRM_T004_B>();
            SelectedECRM_T004_B_List = new List<ECRM_T004_B>();
            SelectedECRM_T004_B = new ECRM_T004_B();
            MC.PDIEntryDetails = new ObservableCollection<ECRM_T004_B>();
            SelectedECRM_T004_A.ValidateAsync().Wait();
            ECRM_T004_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            SelectedECRM_T004_A.pdi_date = DateTime.Now;
            SelectedECRM_T004_A.prodate = DateTime.Now;
            SelectedECRM_T004_A.client = AppSessionState.client;
            SelectedECRM_T004_A.user_source1 = AppSessionState.UserSource1;
            SelectedECRM_T004_A.user_source2 = AppSessionState.UserSource2;
            SelectedECRM_T004_A.userid = AppSessionState.UserID;
            LoadInitialData();
        }

        #endregion    

        #region User Defined Function .
        //private void GetSelectedList(IList DataList)
        //{
        //    IList list = DataList as IList;
        //    List<ECRM_T004_A> tSelectedItemsList = list.Cast<ECRM_T004_A>().ToList();
        //    if (tSelectedItemsList.Count > 0)
        //    {
        //        SelectedECRM_T004_A = (ECRM_T004_A)tSelectedItemsList[0];
        //        blNew = false;
        //    }
        //}

        private void GetSelectedPDIEnteryDetailsList(IList PDIEnList)
        {
            try
            {
                IList list = PDIEnList as IList;
                List<ECRM_T004_A> GetSelectedPDIEnteryDetails = list.Cast<ECRM_T004_A>().ToList();

                if (GetSelectedPDIEnteryDetails.Count > 0)
                {
                    blNew = false;
                    SelectedECRM_T004_A = (ECRM_T004_A)GetSelectedPDIEnteryDetails[0];

                    //MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T004_A>(MCTemp, "ECRM_T004_A_Data", "PDI_Entry", "CRM", "PDIEntry_Details", SelectedECRM_T004_A.id, "");

                    SelectedTabControlIndex = 0;
                    if (SelectedECRM_T004_A != null)
                    {
                        MC.PDIEntryDetails = MCTemp.PDIEntryDetails;
                        PDI_Entry_Dtails = MCTemp.PDIEntryDetails;
                    }
                    if (GetSelectedPDIEnteryDetails[0].ToDate == null)
                    {
                        SelectedECRM_T004_A.ToDate = GetSelectedPDIEnteryDetails[0].prodate; //(DateTime.Now);
                    }
                    if (GetSelectedPDIEnteryDetails[0].Fromdate == null)
                    {
                        SelectedECRM_T004_A.Fromdate = GetSelectedPDIEnteryDetails[0].prodate; //(DateTime.Now);
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
            IList list = ILDChartList as IList;
            List<EPR_T001_PopUp> SelectedILDChartDetailsTemp = list.Cast<EPR_T001_PopUp>().ToList();
            if (ILDChartList.Count > 0)
            {
                string request = "";
                string TempDate = Convert.ToDateTime(SelectedECRM_T004_A.prodate).ToString("MM/dd/yyyy");
                request = Convert.ToString(SelectedILDChartDetailsTemp[0].machine_id) + "!@" + TempDate;

                if (SelectedILDChartDetailsTemp.Count > 0)
                {


                    SelectedECRM_T004_A.Conv_no = "";
                    SelectedECRM_T004_A.mod_no = "";
                    SelectedECRM_T004_A.ItemCode = "";
                    SelectedECRM_T004_A.PartyId = "";
                    SelectedECRM_T004_A.PartyNm = "";

                    SelectedECRM_T004_A.shift = "";
                    //SelectedECRM_T004_A.Grade = SelectedConv_lotDetailsTemp[0].Grade;
                    SelectedECRM_T004_A.shdia = "";
                    SelectedECRM_T004_A.shlen = "";
                    SelectedECRM_T004_A.nedledia = "";
                    SelectedECRM_T004_A.nedlen = "";
                    SelectedECRM_T004_A.totlen = "";
                    SelectedECRM_T004_A.set_ink = "";
                    SelectedECRM_T004_A.set_ild = "";

                    SelectedECRM_T004_A.ildmin = 0;
                    SelectedECRM_T004_A.ildmax = 0;
                    SelectedECRM_T004_A.ildavg = 0;


                    SelectedECRM_T004_A.ildrang = "";
                    //---------------------------------------------------
                    MCMchin = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T003_A>(MCMchin, "ECRM_T004_A_Data", "PDI_Entry", "CRM", "Machine_Conversion_Data", SelectedILDChartDetailsTemp[0].machine_id, request);

                    SelectedECRM_T004_A.mach_no = SelectedILDChartDetailsTemp[0].machine_id;
                    SelectedECRM_T004_A.machinecode = SelectedILDChartDetailsTemp[0].machinecode;

                    SelectedECRM_T004_A.Conv_no = " ";
                    SelectedECRM_T004_A.mod_no = "";
                    SelectedECRM_T004_A.ItemCode = "";
                    SelectedECRM_T004_A.PartyId = "";
                    SelectedECRM_T004_A.shift = "";





                    Conv_lotCollection = CollectionViewSource.GetDefaultView(MCMchin.ConvLot);
                    Conv_lotCollection.Filter = new Predicate<object>(Conv_lotFilter);

                    Shift_lotCollection = CollectionViewSource.GetDefaultView(MCMchin.ShiftLot);
                    Shift_lotCollection.Filter = new Predicate<object>(Shift_lotFilter);

                    if (MCMchin.ConvLot.Count == 1)
                    {
                        GetSelectedConv_lotDetails(MCMchin.ConvLot);
                    }
                    else
                    {
                        GetSelectedConv_lotDetails(MCMchin.ConvLot);

                        SelectedECRM_T004_A.Conv_no = "";
                        SelectedECRM_T004_A.mod_no = "";
                        SelectedECRM_T004_A.ItemCode = "";
                        SelectedECRM_T004_A.PartyId = "";
                        SelectedECRM_T004_A.PartyNm = "";
                        SelectedECRM_T004_A.ItemName = "";
                        SelectedECRM_T004_A.shift = "";
                        //SelectedECRM_T004_A.Grade = SelectedConv_lotDetailsTemp[0].Grade;
                        SelectedECRM_T004_A.shdia = "";
                        SelectedECRM_T004_A.shlen = "";
                        SelectedECRM_T004_A.nedledia = "";
                        SelectedECRM_T004_A.nedlen = "";
                        SelectedECRM_T004_A.totlen = "";
                        SelectedECRM_T004_A.set_ink = "";
                        SelectedECRM_T004_A.set_ild = "";

                        SelectedECRM_T004_A.ildmin = 0;
                        SelectedECRM_T004_A.ildmax = 0;
                        SelectedECRM_T004_A.ildavg = 0;


                        SelectedECRM_T004_A.ildrang = "";




                    }
                    //for (int i = 0; i < MCMchin.Refil.Count(); i++)
                    //{
                    //    WTDetails.Add(new ECRM_T003_B
                    //    {
                    //        refilno = MCMchin.Refil[i].refilno
                    //    });
                    //};
                }
            }
        }
        private void GetSelectedConv_lotDetails(IList Conv_lotList)
        {
            IList list = Conv_lotList as IList;
            List<ECR_T004_PopUp_Lot> SelectedConv_lotDetailsTemp = list.Cast<ECR_T004_PopUp_Lot>().ToList();
            if (SelectedConv_lotDetailsTemp.Count > 0)
            {
                SelectedECRM_T004_A.Conv_no = Convert.ToString(SelectedConv_lotDetailsTemp[0].Conv_lot);
                SelectedECRM_T004_A.mod_no = SelectedConv_lotDetailsTemp[0].model_no;
                SelectedECRM_T004_A.ItemCode = SelectedConv_lotDetailsTemp[0].item_code;
                SelectedECRM_T004_A.ItemName = SelectedConv_lotDetailsTemp[0].ItemName;
                SelectedECRM_T004_A.PartyId = SelectedConv_lotDetailsTemp[0].PartyId;
                SelectedECRM_T004_A.PartyNm = SelectedConv_lotDetailsTemp[0].PartyNm;

                //SelectedECRM_T004_A.shift = SelectedConv_lotDetailsTemp[0].shift;
                //SelectedECRM_T004_A.Grade = SelectedConv_lotDetailsTemp[0].Grade;
                SelectedECRM_T004_A.shdia = Convert.ToString(SelectedConv_lotDetailsTemp[0].shank_dia);
                SelectedECRM_T004_A.shlen = SelectedConv_lotDetailsTemp[0].shank_len;
                SelectedECRM_T004_A.nedledia = SelectedConv_lotDetailsTemp[0].needle_dia;
                SelectedECRM_T004_A.nedlen = SelectedConv_lotDetailsTemp[0].needle;
                SelectedECRM_T004_A.totlen = SelectedConv_lotDetailsTemp[0].total_len;
                SelectedECRM_T004_A.set_ink = SelectedConv_lotDetailsTemp[0].ink;
                SelectedECRM_T004_A.set_ild = SelectedConv_lotDetailsTemp[0].ild;

                SelectedECRM_T004_A.ildmin = Convert.ToDecimal(SelectedConv_lotDetailsTemp[0].amnild);
                SelectedECRM_T004_A.ildmax = Convert.ToDecimal(SelectedConv_lotDetailsTemp[0].amxild);
                SelectedECRM_T004_A.ildavg = Convert.ToDecimal(SelectedConv_lotDetailsTemp[0].aavild);


                SelectedECRM_T004_A.ildrang = Convert.ToString((SelectedConv_lotDetailsTemp[0].amxild - SelectedConv_lotDetailsTemp[0].amnild));
                SelectedECRM_T004_A.baout = SelectedConv_lotDetailsTemp[0].ballout;
                SelectedECRM_T004_A.shchmfr = SelectedConv_lotDetailsTemp[0].ShankChamfer;

                var ShiftList = (from o in MCMchin.ShiftLot
                                 where o.item_code == SelectedECRM_T004_A.ItemCode
                                    && o.ink == SelectedECRM_T004_A.set_ink
                                    && o.ild == SelectedECRM_T004_A.set_ild

                                 select o).ToList();
                Shift_lotCollection = CollectionViewSource.GetDefaultView(ShiftList);
                Shift_lotCollection.Filter = new Predicate<object>(Shift_lotFilter);
                SelectedECRM_T004_A.shift = "";

            }
        }
        private void GetSelectedShift_lotDetails(IList Shift_lotList)
        {
            IList list = Shift_lotList as IList;
            List<ECR_T004_PopUp_Lot> SelectedShift_lotDetailsTemp = list.Cast<ECR_T004_PopUp_Lot>().ToList();
            if (SelectedShift_lotDetailsTemp.Count > 0)
            {
                SelectedECRM_T004_A.shift = SelectedShift_lotDetailsTemp[0].shift;
                SelectedECRM_T004_A.ildmin = Convert.ToDecimal(SelectedShift_lotDetailsTemp[0].amnild);
                SelectedECRM_T004_A.ildmax = Convert.ToDecimal(SelectedShift_lotDetailsTemp[0].amxild);
                SelectedECRM_T004_A.ildavg = Convert.ToDecimal(SelectedShift_lotDetailsTemp[0].aavild);
                SelectedECRM_T004_A.ildrang = Convert.ToString((SelectedShift_lotDetailsTemp[0].amxild - SelectedShift_lotDetailsTemp[0].amnild));
            }
        }
        private void InsertShift(IList Shift_lotList)
        {
            IList list = Shift_lotList as IList;
            List<ADM_M042_P> SelectedShift_lotDetailsTemp = list.Cast<ADM_M042_P>().ToList();
            if (SelectedShift_lotDetailsTemp.Count > 0)
            {
                SelectedECRM_T004_A.shift = SelectedShift_lotDetailsTemp[0].shift;


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
                    SelectedECRM_T004_A.@operator = GetSelectedOperator[0].EmpId;
                    SelectedECRM_T004_A.EmpNm = GetSelectedOperator[0].EmpLName;

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
        private void GetSelectedDateDetails(DateTime prodate)
        {
            if (blNew == true)
            {
                //SelectedECRM_T004_A.Machine_Code = "";
                SelectedECRM_T004_A.machinecode = "";
                SelectedECRM_T004_A.mach_no = 0;
                SelectedECRM_T004_A.Conv_no = "";
                SelectedECRM_T004_A.mod_no = "";
                SelectedECRM_T004_A.ItemCode = "";
                SelectedECRM_T004_A.PartyId = "";
                SelectedECRM_T004_A.PartyNm = "";

                SelectedECRM_T004_A.shift = "";
                //SelectedECRM_T004_A.Grade = SelectedConv_lotDetailsTemp[0].Grade;
                SelectedECRM_T004_A.shdia = "";
                SelectedECRM_T004_A.shlen = "";
                SelectedECRM_T004_A.nedledia = "";
                SelectedECRM_T004_A.nedlen = "";
                SelectedECRM_T004_A.totlen = "";
                SelectedECRM_T004_A.set_ink = "";
                SelectedECRM_T004_A.set_ild = "";

                SelectedECRM_T004_A.ildmin = 0;
                SelectedECRM_T004_A.ildmax = 0;
                SelectedECRM_T004_A.ildavg = 0;


                SelectedECRM_T004_A.ildrang = "";
            }
        }
        private void GetSelectedID(IList PDIDetailsList)
        {
            try
            {
                IList list = PDIDetailsList as IList;
                List<ECRM_T004_A> GetSelectedPDIDetails = list.Cast<ECRM_T004_A>().ToList();

                if (GetSelectedPDIDetails.Count > 0)
                {
                    if (SelectedECRM_T004_A != null)
                    {
                        try
                        {
                            SelectedECRM_T004_A.id = GetSelectedPDIDetails[0].id;
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
        private void GetSelectedCustomerOnFlip(IList CustomerList)
        {
            IList list = CustomerList as IList;
            List<ADM_M028_PopUp> SelectedCustomerDetailsTemp = list.Cast<ADM_M028_PopUp>().ToList();
            if (SelectedCustomerDetailsTemp.Count > 0)
            {
                //SelectedECRM_T004_A.customer_codeid = SelectedCustomerDetailsTemp[0].id;
                SelectedECRM_T004_A.PartyId = SelectedCustomerDetailsTemp[0].PartyId;
                SelectedECRM_T004_A.customer_codeBack = SelectedCustomerDetailsTemp[0].PartyNm;
            }
        }
        private void Load()
        {
            string request = "";
            //request = (SelectedECRM_T003_A.prdct_codeBack) + "!@" + Convert.ToString(Convert.ToDateTime(SelectedECRM_T003_A.Fromdate)) + "!@" + Convert.ToString(Convert.ToDateTime(SelectedECRM_T003_A.ToDate)) + "!@" + SelectedECRM_T003_A.doc_type + "!@" + Convert.ToString(SelectedECRM_T003_A.plant_id);
            SelectedECRM_T004_A.doc_type = "PDI";
            SelectedECRM_T004_A.location_Id = AppSessionState.location_Id;

            request = (SelectedECRM_T004_A.customer_codeid) + "!@" + Convert.ToDateTime(SelectedECRM_T004_A.Fromdate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(SelectedECRM_T004_A.ToDate).ToString("MM/dd/yyyy") + "!@" + SelectedECRM_T004_A.doc_type + "!@" + SelectedECRM_T004_A.location_Id;
            MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T004_A>(MC, "ECRM_T004_A_Data", "PDI_Entry", "CRM", "LoadAll", 0, request);//request
            SelectedList = MC.PDIEntry;
            DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
            DataGridCollection.Filter = new Predicate<object>(Filter);

            PDI_Entry_Dtails = MC.PDIEntryDetails;
        }
        private void QualityInstReport()
        {
            try
            {
                if (SelectedECRM_T004_A.PartyId != null && SelectedECRM_T004_A.PartyId != " ")
                {
                    string Request = "LoadQualityInterestRpt" + "!@" + SelectedECRM_T004_A.PartyId + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code;
                    MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T004_A>(MCTemp, Request, "PDI_QualityInst", "CRM", "", 0, " ");
                    RptQualityInst = MCTemp.PDI_QualityInst;

                    object[] objDataSource = new object[3];
                    string[] objDataSourceName = new string[3];

                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == AppSessionState.comp_code).ToList();
                    objDataSource[0] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == AppSessionState.location_Id).ToList();
                    objDataSource[1] = Result;

                    objDataSource[2] = MCTemp.PDI_QualityInst;

                    objDataSourceName[0] = "dsCompany";
                    objDataSourceName[1] = "dsLocation";
                    objDataSourceName[2] = "dsPDI_QualityInst";

                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\QMS\\QualityInterestRptForPDI.rdlc", "MRPReport");
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("First Select Machine no.....", this.Title);
                    showMessageService.ShowMessage();
                }
            }
            catch (Exception ex)
            {

                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Cannot Print Report...", this.Title);
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
                    Request = SelectedECRM_T004_A.client + "!@" + SelectedECRM_T004_A.comp_code + "!@" + InputValue.ToString();
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
                ECRM_T003_A POPUPEntityObject = null;
                barcode = InputValue.ToString();
                if (InputValue.GetType() == typeof(string) && barcode.Length > 12)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        var InputValueIfExists = MC.BatchDetails.Where(X => X.batch_no == Request).FirstOrDefault();//Checking Weather Barcode is Valid or Not By Checking in Business Entity
                        if (InputValueIfExists != null)
                        {
                            try { POPUPEntityObject = MC.BatchDetails.Where(x => (x.batch_no ?? "").Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; } //If Barcode is Valid Get All the Information in PopupEntityObject
                            catch { }
                        }
                        else
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Invalid Barcode.\n Please Scan Valid Barcode", this.Title);
                            showMessageService.ShowMessage();
                            SelectedECRM_T004_A = new ECRM_T004_A();
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ECRM_T003_A>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ECRM_T003_A>().ToList()[0];
                }

                if (POPUPEntityObject != null)
                {
                    //IList list = InputValue as IList;
                    //List<ECRM_T003_A> GetSelectedWTTemp = list.Cast<ECRM_T003_A>().ToList();

                    SelectedECRM_T004_A.barcode_no = POPUPEntityObject.batch_no;

                    Request = "LoadBarcode" + "!@" + SelectedECRM_T004_A.barcode_no + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code;
                    MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T004_A>(MCTemp, Request, "PDI_QualityInst", "CRM", "", 0, " ");
                    if (MCTemp.WritingTestPopup.Count > 0)
                    {
                        SelectedECRM_T004_A.mod_no = MCTemp.WritingTestPopup[0].modlno;
                        SelectedECRM_T004_A.ItemCode = MCTemp.WritingTestPopup[0].prdct_code;
                        SelectedECRM_T004_A.mach_no = MCTemp.WritingTestPopup[0].mchn_id;
                        SelectedECRM_T004_A.machinecode = MCTemp.WritingTestPopup[0].machinecode;
                        SelectedECRM_T004_A.order_no = MCTemp.WritingTestPopup[0].order_no;
                        SelectedECRM_T004_A.PartyId = MCTemp.WritingTestPopup[0].PartyId;
                        SelectedECRM_T004_A.PartyNm = MCTemp.WritingTestPopup[0].PartyNm;
                        SelectedECRM_T004_A.shift = MCTemp.WritingTestPopup[0].shift;
                        SelectedECRM_T004_A.EmpNm = MCTemp.WritingTestPopup[0].EmpNm;
                        SelectedECRM_T004_A.@operator = MCTemp.WritingTestPopup[0].EmpId;
                        SelectedECRM_T004_A.ildmin = MCTemp.WritingTestPopup[0].amnild;
                        SelectedECRM_T004_A.ildmax = MCTemp.WritingTestPopup[0].amxild;
                        SelectedECRM_T004_A.ildavg = MCTemp.WritingTestPopup[0].aavild;
                        //SelectedECRM_T004_A.ildmin = MCTemp.WritingTestPopup[0].tmnild;
                        //SelectedECRM_T004_A.ildmax = MCTemp.WritingTestPopup[0].tmxild;
                        //SelectedECRM_T004_A.ildavg = MCTemp.WritingTestPopup[0].tavild;
                        SelectedECRM_T004_A.ildrang = Convert.ToString(MCTemp.WritingTestPopup[0].Ranget);
                        SelectedECRM_T004_A.set_ink = MCTemp.WritingTestPopup[0].ink;
                        SelectedECRM_T004_A.set_ild = MCTemp.WritingTestPopup[0].ild;
                        SelectedECRM_T004_A.shdia = Convert.ToString(MCTemp.WritingTestPopup[0].shank_dia);
                        SelectedECRM_T004_A.shlen = MCTemp.WritingTestPopup[0].shanklen;
                        SelectedECRM_T004_A.shchmfr = MCTemp.WritingTestPopup[0].ShankChamfer;
                        SelectedECRM_T004_A.nedlen = MCTemp.WritingTestPopup[0].needlelen;
                        SelectedECRM_T004_A.nedledia = MCTemp.WritingTestPopup[0].needledia;
                        SelectedECRM_T004_A.totlen = MCTemp.WritingTestPopup[0].TotalLen;
                        SelectedECRM_T004_A.baout = MCTemp.WritingTestPopup[0].ballout;
                        SelectedECRM_T004_A.qty = MCTemp.WritingTestPopup[0].counter_qty;
                        SelectedECRM_T004_A.Conv_no = MCTemp.WritingTestPopup[0].Conv_lot;
                    }
                }
            }
            catch (Exception ex) { }
        }
        #endregion

        #region Load
        private void LoadInitialData()
        {
            try
            {
                #region Commands
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                SelectionChangedCommandPDIEntery = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }
                    GetSelectedPDIEnteryDetailsList(items);
                });


                SelectionChangedCommandShift = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }
                    InsertShift(items);
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
                SelectionChangedCommandConv_lot = new RelayCommand<IList>(
              items =>
              {
                  if (items == null)
                  {
                      return;
                  }

                  GetSelectedConv_lotDetails(items);
              });

                SelectionChangedCommandShift_lot = new RelayCommand<IList>(
              items =>
              {
                  if (items == null)
                  {
                      return;
                  }

                  GetSelectedShift_lotDetails(items);
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
                SelectionChangedCommandCustomerBack = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedCustomerOnFlip(items);
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
                SelectionChangedCommandOperator = new RelayCommand<IList>(
               items =>
               {
                   if (items == null)
                   {
                       return;
                   }
                   GetSelectedOperator(items);
               });
                CmdAddBatchDetails = new RelayCommand<object>(items => { if (items == null) { return; } InsertBatchDetails(items); });

                ReportCommand = new RelayCommand(Load);
                LoadQualityInterest = new RelayCommand(() => { QualityInstReport(); });
                #endregion
                SelectedECRM_T004_A.location_Id = AppSessionState.location_Id;
                SelectedECRM_T004_A.add_by = AppSessionState.UserID;
                type = "PDI";
                SelectedECRM_T004_A.doc_type = "PDI";
                SelectedECRM_T004_A.Fromdate = DateTime.Now;
                SelectedECRM_T004_A.ToDate = DateTime.Now;
                //string company = SelectedECRM_T004_A.PlantCode.ToString() + "@" + type;
                string company = (SelectedECRM_T004_A.customer_codeid) + "!@" + Convert.ToDateTime(SelectedECRM_T004_A.Fromdate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(SelectedECRM_T004_A.ToDate).ToString("MM/dd/yyyy") + "!@" + SelectedECRM_T004_A.doc_type + "!@" + SelectedECRM_T004_A.location_Id;
                MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T004_A>(MC, "ECRM_T004_A_Data", "PDI_Entry", "CRM", "LoadAll", 0, company);
                SelectedList = MC.PDIEntry;
                PDI_Entry_Dtails = MC.PDIEntryDetails;
                SelectedECRM_T004_A.pdi_date = DateTime.Now;

                SelectedECRM_T004_A.chips = "Yes";
                SelectedECRM_T004_A.coll_mdg = "Ok";
                SelectedECRM_T004_A.clngqulit = "Good";
                SelectedECRM_T004_A.pltqulit = "Ok";
                SelectedECRM_T004_A.mixing = "Yes";
                SelectedECRM_T004_A.nonwrt = "Yes";

                //SelectedECRM_T004_A.Fromdate = DateTime.Now;


                DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                ILDChartCollection = CollectionViewSource.GetDefaultView(MC.ILDChart);
                ILDChartCollection.Filter = new Predicate<object>(ILDChartFilter);

                //ShiftCollection = CollectionViewSource.GetDefaultView(MC.ShiftMaster);

                CustomerCollectionBack = CollectionViewSource.GetDefaultView(MC.CustomerForBack);
                CustomerCollectionBack.Filter = new Predicate<object>(CustomerBackFilter);

                //ILDCollection = CollectionViewSource.GetDefaultView(MC.ILD);
                //ILDCollection.Filter = new Predicate<object>(ILDFilter);


                //Conv_lotCollection = CollectionViewSource.GetDefaultView(MCMchin.ConvLot);
                //Conv_lotCollection.Filter = new Predicate<object>(Conv_lotFilter);
                OperatorCollection = CollectionViewSource.GetDefaultView(MC.EmpList);
                OperatorCollection.Filter = new Predicate<object>(OperatorFilter);

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

        #endregion

        #region · Command Actions ·
        protected override void OnSaveAction(InquiryActionResult<ECRM_T004_A> result)
        {
            try
            {
                //if (PDI_Entry_Dtails.Count > 0)
                // {

                SelectedECRM_T004_A.type1 = "PDI";
                SelectedECRM_T004_A.add_by = AppSessionState.UserID;
                SelectedECRM_T004_A.location_Id = AppSessionState.location_Id;
                SelectedECRM_T004_A.comp_code = AppSessionState.comp_code;
                SelectedECRM_T004_A.client = AppSessionState.client;
                //SelectedECRM_T004_A.prodate = SelectedECRM_T004_A.prodate.Value.Date;
                //SelectedECRM_T004_A.pdi_date = SelectedECRM_T004_A.pdi_date.Value.Date;
                //SelectedECRM_T004_A.prodate.Value.GetDateTimeFormats();
                //SelectedECRM_T004_A.pdi_date.Value.
                //SelectedECRM_T004_A.pdi_date = SelectedECRM_T004_A.pdi_date+''+ SelectedECRM_T004_A.pdi_date.Value.TimeOfDay;
                // SelectedECRM_T004_A.pdi_date =(DateTime)SelectedECRM_T004_A.pdi_date.Value.TimeOfDay;
                ObjectSerializationService objSer = new ObjectSerializationService();

                if (PDI_Entry_Dtails != null)
                {
                    SelectedECRM_T004_A.XmlDataDocument_ECRM_T004_B = objSer.ObjectToXML(PDI_Entry_Dtails);
                }
                this.SelectedECRM_T004_A.EndEdit();
                if ((SelectedECRM_T004_A.shift != "" && SelectedECRM_T004_A.shift != null) && (SelectedECRM_T004_A.Grade != "" && SelectedECRM_T004_A.Grade != null))
                {
                    if (blNew == true)
                    {
                        SelectedECRM_T004_A = repository.SaveWithReturnDomainObject<ECRM_T004_A>(SelectedECRM_T004_A, "PDI_Entry", "CRM");
                        var tempSelectRemove = SelectedList.Where(x => x.id == SelectedECRM_T004_A.id).FirstOrDefault();
                        SelectedList.Remove(tempSelectRemove);
                        //SelectedList.Add(SelectedECRM_T004_A);
                        SelectedList.Add(SelectedECRM_T004_A);

                        blNew = false;
                    }
                    else if (blNew == false)
                    {
                        SelectedECRM_T004_A = repository.UpdateWithReturnDomainObject<ECRM_T004_A>(SelectedECRM_T004_A, "PDI_Entry", "CRM");
                        var tempSelectRemove = SelectedList.Where(x => x.id == SelectedECRM_T004_A.id).FirstOrDefault();
                        SelectedList.Remove(tempSelectRemove);
                        if (SelectedECRM_T004_A.active == true)
                        {
                            SelectedList.Add(SelectedECRM_T004_A);
                        }
                        this.SelectedECRM_T004_A.EndEdit();
                    }
                    _dataGridCollection.Refresh();
                    cal();
                    MessageBox.Show("Record Saved Successfully");

                    if (SelectedECRM_T004_A.XmlDataDocument_ECRM_T004_B != null)
                    {
                        MC.PDIEntryDetails = (ObservableCollection<ECRM_T004_B>)new ObjectSerializationService().XMLToObject(SelectedECRM_T004_A.XmlDataDocument_ECRM_T004_B, MC.PDIEntryDetails);

                    }
                    else
                    {
                        MC.PDIEntryDetails = new ObservableCollection<ECRM_T004_B>();
                    }
                    PDI_Entry_Dtails = MC.PDIEntryDetails;
                    _dataGridCollection.Refresh();
                    SelectedECRM_T004_A.Fromdate = SelectedECRM_T004_A.prodate;//DateTime.Now;
                    SelectedECRM_T004_A.ToDate = SelectedECRM_T004_A.prodate;//DateTime.Now;
                }
                else
                {
                    MessageBox.Show("Please select Shift and Grade");
                }
            }


            //}
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        protected override void OnCreateAction(InquiryActionResult<ECRM_T004_A> result)
        {

            blNew = true;
            string tempPrdDate;
            tempPrdDate = "";
            tempPrdDate = Convert.ToString(SelectedECRM_T004_A.prodate);
            SelectedECRM_T004_A = new ECRM_T004_A();
            SelectedECRM_T004_A.ValidateAsync().Wait();
            PDI_Entry_Dtails = new ObservableCollection<ECRM_T004_B>();
            PDI_Entry_Dtails.Clear();
            _dataGridCollection.Refresh();
            SelectedECRM_T004_A.pdi_date = DateTime.Now;
            SelectedECRM_T004_A.prodate = Convert.ToDateTime(tempPrdDate); //DateTime.Now.Date;

            SelectedECRM_T004_A.chips = "Yes";
            SelectedECRM_T004_A.coll_mdg = "Ok";
            SelectedECRM_T004_A.clngqulit = "Good";
            SelectedECRM_T004_A.pltqulit = "Ok";
            SelectedECRM_T004_A.mixing = "Yes";
            SelectedECRM_T004_A.nonwrt = "Yes";
            SelectedECRM_T004_A.Fromdate = Convert.ToDateTime(tempPrdDate); //DateTime.Now;
            SelectedECRM_T004_A.ToDate = Convert.ToDateTime(tempPrdDate); //DateTime.Now;
            SelectedECRM_T004_A.client = AppSessionState.client;

        }
        protected override void OnRemoveAction(InquiryActionResult<ECRM_T004_A> result)
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
                this.SelectedECRM_T004_A.CancelEdit();
                string response = repository.Delete(SelectedECRM_T004_A.id, "PDI_Entry", "CRM");
                SelectedList.Remove(SelectedECRM_T004_A);
                _dataGridCollection.Refresh();
                SelectedECRM_T004_A = new ECRM_T004_A();
                PDI_Entry_Dtails = new ObservableCollection<ECRM_T004_B>();

            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ECRM_T004_A> result)
        {
            SelectedECRM_T004_A.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ECRM_T004_A> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<ECRM_T004_A> result)
        {
            SelectedList = SelectedList;
            SelectedECRM_T004_A = SelectedECRM_T004_A;
        }
        protected override void OnHelpAction(InquiryActionResult<ECRM_T004_A> result)
        {
            SelectedList = SelectedList;
            SelectedECRM_T004_A = SelectedECRM_T004_A;
        }
        protected override void OnPrintAction(InquiryActionResult<ECRM_T004_A> result)
        {

            SelectedList = SelectedList;
            SelectedECRM_T004_A = SelectedECRM_T004_A;

            MCRpt = repositoryRpt.GetDataWithReturnDomainObject<MultipleContext_ECRM_T004_A>(MCRpt, "ECRM_T004_A_Data", "PDI_Entry", "CRM", "PDIEntryReport", SelectedECRM_T004_A.id, " ");
            PDIReport = MCRpt.PdiRpt;
            object objDS;
            objDS = MCRpt.PdiRpt;

            ReportManager ReportManager = new ReportingServices.ReportManager();
            ReportManager.DisplayReport(objDS, "PDIds", "\\CRM\\PDIEntry.rdlc");

        }
        //protected override void OnExportAction(InquiryActionResult<ECRM_T004_A> result)
        //{
        //    try
        //    {
        //        List<ECRM_T004_A> Export_List = new List<ECRM_T004_A>();
        //        foreach (var o in DataGridCollection)
        //        {
        //            ECRM_T004_A Data = o as ECRM_T004_A;
        //            Export_List.Add(Data);
        //        }

        //        //--------------------------------------

        //        ExportToExcel<ECRM_T004_A, List<ECRM_T004_A>> export = new ExportToExcel<ECRM_T004_A, List<ECRM_T004_A>>();
        //        ICollectionView view = CollectionViewSource.GetDefaultView(Export_List);
        //        export.dataToPrint = (List<ECRM_T004_A>)view.SourceCollection;

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
            var data = obj as EPR_T001_PopUp;
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
            var data = obj as ECR_T004_PopUp_Lot;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringConv_lot))
                {
                    return (data.Conv_lot != null && data.Conv_lot.ToString().ToLower().Contains(_filterStringConv_lot.ToLower())) ||
                   (data.MachineCode != null && data.MachineCode.ToString().ToLower().Contains(_filterStringConv_lot.ToLower())) ||
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

        #region Filters For Shift_lot
        private void FilterCollectionShift_lot()
        {
            if (_Shift_lotCollection != null)
            {
                _Shift_lotCollection.Refresh();
            }

        }
        public string FilterStringShift_lot
        {
            get { return _filterStringShift_lot; }
            set
            {
                _filterStringShift_lot = value;
                RaisePropertyChanged("FilterStringConv_lot");
                FilterCollectionShift_lot();
            }
        }
        public bool Shift_lotFilter(object obj)
        {
            var data = obj as ECR_T004_PopUp_Lot;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringShift_lot))
                {
                    return (data.shift != null && data.shift.ToString().ToLower().Contains(_filterStringShift_lot.ToLower())) ||
                   (data.item_code != null && data.item_code.ToString().ToLower().Contains(_filterStringShift_lot.ToLower())) ||
                   (data.ink != null && data.ink.ToString().ToLower().Contains(_filterStringShift_lot.ToLower()) //||
                                                                                                                 //(data.tmnild != null && data.tmnild.ToString().ToLower().Contains(_filterStringShift_lot.ToLower())) ||
                                                                                                                 //(data.tmxild != null && data.tmxild.ToString().ToLower().Contains(_filterStringShift_lot.ToLower())
                                                                                                                 //(data.amnild != null && data.amnild.ToString().ToLower().Contains(_filterStringShift_lot.ToLower())
                                                                                                                 //(data.amxild != null && data.amxild.ToString().ToLower().Contains(_filterStringShift_lot.ToLower())
                                                                                                                 //(data.aavild != null && data.aavild.ToString().ToLower().Contains(_filterStringShift_lot.ToLower())
                 );

                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For CustomerBack
        private void FilterCollectionCustomerBack()
        {
            if (_CustomerCollectionBack != null)
            {
                _CustomerCollectionBack.Refresh();
            }

        }
        public string FilterStringCustomerBack
        {
            get { return _filterStringCustomerBack; }
            set
            {
                _filterStringCustomerBack = value;
                RaisePropertyChanged("FilterStringCustomerBack");
                FilterCollectionCustomerBack();
            }
        }
        public bool CustomerBackFilter(object obj)
        {

            var data = obj as ADM_M028_PopUp;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringCustomerBack))
                {
                    return (

                        (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterStringCustomerBack.ToLower()))

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
            var data = obj as ECRM_T004_A;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.pdi_no != null && data.pdi_no.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    (data.pdi_date != null && data.pdi_date.ToString().ToLower().Contains(_filterString.ToLower())) ||

                    (data.prodate != null && data.prodate.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    (data.Conv_no != null && data.Conv_no.ToString().ToLower().Contains(_filterString.ToLower())); //||
                                                                                                                   //(data.invoice_date != null && data.invoice_date.ToString().ToLower().Contains(_filterString.ToLower())) ||
                                                                                                                   //(data.delivery_status != null && data.delivery_status.ToString().ToLower().Contains(_filterString.ToLower()));

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
            var data = obj as ECRM_T003_A;
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
