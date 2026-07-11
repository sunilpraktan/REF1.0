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
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.Production.ViewModels
{
    class EPR_T003_RepackingExport_VM : WorkspaceViewModel<EPR_T003_A>
    {
        #region Variable Declaration
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        bool isNewRecord = true;
        private string _scan_source;
        public string Scan_Source
        {
            get { return _scan_source; }
            set
            {
                if (_scan_source != value)
                {
                    _scan_source = value;
                    RaisePropertyChanged("Scan_Source");
                }
            }
        }
        private int _scan_length;
        public int Scan_Length
        {
            get { return _scan_length; }
            set
            {
                if (_scan_length != value)
                {
                    _scan_length = value;
                    RaisePropertyChanged("Scan_Length");
                }
            }
        }

        WebServiceRepository<EPR_T003_A> repository = new WebServiceRepository<EPR_T003_A>();
        WebServiceRepository<MultipleContext_EPR_T003> repository_MC = new WebServiceRepository<MultipleContext_EPR_T003>();
        WebServiceRepository<MultipleContext_EPR_T003> repository_MCTemp = new WebServiceRepository<MultipleContext_EPR_T003>();
        ObjectSerializationService obj = new ObjectSerializationService();
        WebServiceRepository<MultipleContext_EPR_T003> repositoryM = new WebServiceRepository<MultipleContext_EPR_T003>();

        private MultipleContext_EPR_T003 _MC = new MultipleContext_EPR_T003();
        public MultipleContext_EPR_T003 MC
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

        private MultipleContext_EPR_T003 _MCTemp = new MultipleContext_EPR_T003();
        public MultipleContext_EPR_T003 MCTemp
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

        private MultipleContext_EPR_T003 _MCTemp2 = new MultipleContext_EPR_T003();
        public MultipleContext_EPR_T003 MCTemp2
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

        private MultipleContext_EPR_T003 _MCTemp3 = new MultipleContext_EPR_T003();
        public MultipleContext_EPR_T003 MCTemp3
        {
            get { return _MCTemp3; }
            set
            {
                if (_MCTemp3 != value)
                {
                    _MCTemp3 = value; RaisePropertyChanged("MCTemp3");
                }
            }
        }

        private EPR_T003_A _MasterEntity;
        public EPR_T003_A MasterEntity
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
        private EPR_T003_A_Flip _BackFlipEntity;
        public EPR_T003_A_Flip BackFlipEntity
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
                    RaisePropertyChanged(nameof(BackFlipEntity));
                }
            }
        }

        private ObservableCollection<EPR_T003_B> _SmallCartonEntity;
        //Data source for Scanned Label Generated From Label Generation
        public ObservableCollection<EPR_T003_B> SmallCartonEntity
        {
            get
            {
                return _SmallCartonEntity;
            }
            set
            {
                if (_SmallCartonEntity != value)
                {
                    _SmallCartonEntity = value;
                    // ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("SmallCartonEntity");
                }
            }
        }

        private int _dgSelectedIndexBatch;
        public int dgSelectedIndexBatch
        {
            get
            {
                return _dgSelectedIndexBatch;
            }
            set
            {
                if (_dgSelectedIndexBatch != value)
                {
                    _dgSelectedIndexBatch = value;
                    RaisePropertyChanged("dgSelectedIndexBatch");
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

        private string _LabelStatus;
        public string LabelStatus
        {
            get
            {
                return _LabelStatus;
            }
            set
            {
                if (_LabelStatus != value)
                {
                    _LabelStatus = value;
                    RaisePropertyChanged("LabelStatus");
                }
            }
        }
        #endregion
        #region ICollection For Popup Control

        private ICollectionView _CustProductName;
        public ICollectionView CustProductName
        {
            get { return _CustProductName; }
            set
            {
                _CustProductName = value;
                RaisePropertyChanged("CustProductName");
            }
        }

        private ICollectionView _DescriptionOfGoods;
        public ICollectionView DescriptionOfGoods
        {
            get { return _DescriptionOfGoods; }
            set
            {
                _DescriptionOfGoods = value;
                RaisePropertyChanged("DescriptionOfGoods");
            }
        }

        private ICollectionView _ProductCollection;
        public ICollectionView ProductCollection
        {
            get { return _ProductCollection; }
            set
            {
                _ProductCollection = value;
                RaisePropertyChanged("ProductCollection");
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

        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set
            {
                _FlipDataGridCollection = value;
                RaisePropertyChanged("FlipDataGridCollection");
            }
        }

        #endregion
        #region StringList Variables
        private List<string> _strListCustProductName;
        public List<string> StringListCustProduct
        {
            get { return _strListCustProductName; }
            set
            {
                if (_strListCustProductName != value)
                {
                    _strListCustProductName = value;
                }
            }
        }
        #endregion
        #region RelayCommand Actions
        public RelayCommand<object> cmdCartonType { get; private set; }
        public RelayCommand<object> cmdCustProductName { get; private set; }
        public RelayCommand<object> cmdDescOfGoods { get; private set; }
        public RelayCommand<object> cmdBarcodeScan { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowBatch { get; private set; }

        //BackSide
        public RelayCommand<IList> cmdProduct { get; private set; }
        public RelayCommand<IList> cmdInk { get; private set; }
        public RelayCommand<IList> cmdIld { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByByDocumentNumber { get; private set; }
        public RelayCommand cmdLoadLocalExportCartons { get; private set; }
        public RelayCommand cmdPrintBigLabel { get; private set; }
        public RelayCommand cmdPrintBatchDetailsReport1 { get; private set; }
        public RelayCommand cmdPrintBatchDetailsReport2 { get; private set; }
        public RelayCommand cmdPrintWeightDetailsReport { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        #endregion

        #region Constructor

        public EPR_T003_RepackingExport_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MC = new MultipleContext_EPR_T003();
            MCTemp = new MultipleContext_EPR_T003();
            MCTemp2 = new MultipleContext_EPR_T003();
            MCTemp3 = new MultipleContext_EPR_T003();

            MasterEntity = new EPR_T003_A();
            SmallCartonEntity = new ObservableCollection<EPR_T003_B>();
            BackFlipEntity = new EPR_T003_A_Flip();
            PrintOption = "All";
            LabelStatus = "Unused";


            BackFlipEntity.FromDate = DateTime.Now;
            BackFlipEntity.ToDate = DateTime.Now;
            EPR_T003_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Calculation);

            // EPR_T003_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Batch);
            //  SmallCartonEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForBatch);

            LoadInitialData();
        }
        public EPR_T003_RepackingExport_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MC = new MultipleContext_EPR_T003();
            MCTemp = new MultipleContext_EPR_T003();
            MCTemp2 = new MultipleContext_EPR_T003();
            MCTemp3 = new MultipleContext_EPR_T003();

            MasterEntity = new EPR_T003_A();
            SmallCartonEntity = new ObservableCollection<EPR_T003_B>();
            BackFlipEntity = new EPR_T003_A_Flip();
            PrintOption = "All";
            LabelStatus = "Unused";


            BackFlipEntity.FromDate = DateTime.Now;
            BackFlipEntity.ToDate = DateTime.Now;
            EPR_T003_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Calculation);

            // EPR_T003_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Batch);
            //  SmallCartonEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForBatch);

            LoadInitialData();
        }
        #endregion

        #region User Defined Methods

        private void LoadInitialData()
        {
            try
            {
                MasterEntity.doc_type = "LC";
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + "EC" + "!@" + MasterEntity.doc_cat;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T003>(MC, Request, "SmallCarton", "Production", "LoadAll", 0, MasterEntity.doc_type);
                // MC = repositoryM.GetData<MultipleContext_EPR_T003>(MC, Request, "EC", "Reflection.BusinessLogic.EPR_T003BL");

                #region Command Initialization

                cmdCustProductName = new RelayCommand<object>(items => { if (items == null) { return; } InsertCustProductName(items); });
                cmdDescOfGoods = new RelayCommand<object>(items => { if (items == null) { return; } InsertDescOfGoods(items); });
                cmdBarcodeScan = new RelayCommand<object>(items => { if (items == null) { return; } InsertAllDataFromScannedBarcode(items); });

                cmdDeleteDataGridRowBatch = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Batch(cmdPara); });

                cmdLoadLocalExportCartons = new RelayCommand(() => { LoadLocalExportCartons(); });
                cmdProduct = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertItem(cmdPara); });
                cmdInk = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertInk(cmdPara); });
                cmdIld = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertIld(cmdPara); });

                cmdPrintBigLabel = new RelayCommand(() => { LoadBigLabelReport(); });
                cmdPrintBatchDetailsReport1 = new RelayCommand(() => { LoadBatchDetailsReport1(); });
                cmdPrintBatchDetailsReport2 = new RelayCommand(() => { LoadBatchDetailsReport2(); });
                cmdPrintWeightDetailsReport = new RelayCommand(() => { LoadWeightDetailsReport(); });

                CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                #endregion

                CustProductName = CollectionViewSource.GetDefaultView(MC.CustProdNameList);
                CustProductName.Filter = new Predicate<object>(Filter_CustProductName);
                StringListCustProduct = MC.CustProdNameList.Select(x => x.CustomerProductName).ToList();

                DescriptionOfGoods = CollectionViewSource.GetDefaultView(MC.DescGoodsList);


                ProductCollection = CollectionViewSource.GetDefaultView(MC.ItemList);
                ProductCollection.Filter = new Predicate<object>(Filter_ProductCollection);

                InkCollection = CollectionViewSource.GetDefaultView(MC.InkList);
                InkCollection.Filter = new Predicate<object>(Filter_Ink);

                IldCollection = CollectionViewSource.GetDefaultView(MC.IidList);
                IldCollection.Filter = new Predicate<object>(Filter_Ild);

                if (MC.SettingsList.Count > 0)
                {
                    MasterEntity.no_of_carton = MC.SettingsList[0].no_of_cartons;
                    MasterEntity.bags_per_carton = Convert.ToInt32(MC.SettingsList[0].no_of_bags);
                    MasterEntity.gross_wt = MC.SettingsList[0].gross_wt;
                    Scan_Source = MC.SettingsList[0].scan_source;
                    Scan_Length = MC.SettingsList[0].min_length;
                }

                DefaultValues();
                MasterEntity.dimension = MC.SettingsList[0].dimension;
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
            MasterEntity.doc_cat = "CP";
            MasterEntity.carton_pack_dt = DateTime.Now;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.fin_year = "16-17";
            MasterEntity.posting_period = "2";
            //MasterEntity.bags_per_carton = 10;
            //MasterEntity.no_of_carton = 5;
            MasterEntity.batch_no = "";
            MasterEntity.doc_type = "EC";
            MasterEntity.carton_type = "Export";
            MasterEntity.net_wt = 0;
            MasterEntity.packing_type = "REPACKING";
            MasterEntity.free_sale = "Sale";
            MasterEntity.ts_code = ts_code_vm;
        }

        private void InsertCustProductName(object InputValue)
        {
            try
            {
                string Request = "";
                ZADM_M020_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.CustProdNameList.Where(x => x.CustomerProductName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M020_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.cust_prod_code = POPUPEntityObject.CustomerProductName;
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
        private void InsertDescOfGoods(object InputValue)
        {
            try
            {

                string Request = "";
                ADM_M020_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.DescGoodsList.Where(x => x.ProdNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M020_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.prod_desc_id = POPUPEntityObject.id;
                    //MasterEntity.prod_desc = POPUPEntityObject.ProdNm;
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
        private void DeleteDataGridRow_Batch(object InputValue)
        {

            int i = (int)InputValue;
            if (i != -1)
            {
                if (SmallCartonEntity[i].id == 0)
                {
                    if (SmallCartonEntity.Count > i)
                    {
                        SmallCartonEntity.RemoveAt(i);
                    }
                    int count = SmallCartonEntity.Count;

                    decimal? wt = MasterEntity.net_wt / (SmallCartonEntity.Count + 1);
                    MasterEntity.net_wt -= wt;

                    decimal? wt1 = MasterEntity.gross_wt / (SmallCartonEntity.Count + 1);
                    MasterEntity.gross_wt -= wt1;
                }
            }

        }
        private void InsertAllDataFromScannedBarcode(object InputValue)
        {
            try
            {

                EPR_T003_A POPUPEntityObject = null;
                barcode = InputValue.ToString();

                if (MasterEntity.carton_type != null && MasterEntity.carton_type != "")
                {
                    if (MasterEntity.no_of_carton > 0 && MasterEntity.no_of_carton > SmallCartonEntity.Count && MC.SmallCartonList != null)
                    {
                        if (barcode.Length > Scan_Length) // condition change from Fix 9 to from DB
                        {
                            //Block  added to switch between Barcode and Batch Number as per specified in DB. Start
                            if (Scan_Source == "Barcode")
                            { barcode = barcode; }
                            else if (Scan_Source == "Batch" && MC.SmallCartonList.Where(X => X.batch_no == barcode).FirstOrDefault() != null)
                            {
                                barcode = MC.SmallCartonList.Where(X => X.batch_no == barcode).FirstOrDefault().barcode;
                            }
                            //Block  added to switch between Barcode and Batch Number as per specified in DB. End
                            var InputValueIfExists = MC.SmallCartonList.Where(X => X.barcode == barcode).FirstOrDefault();  //Checking Weather Barcode is Valid or Not By Checking in Business Entity

                            if (InputValueIfExists != null)
                            {
                                POPUPEntityObject = MC.SmallCartonList.Where(x => x.barcode.Equals(barcode, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; //If Barcode is Valid Get All the Information in PopupEntityObject

                                if (POPUPEntityObject != null)
                                {
                                    if (POPUPEntityObject.carton_used_Flg == false)
                                    {
                                        if (SmallCartonEntity.Count == 0)
                                        {
                                            MasterEntity.ItemCode = POPUPEntityObject.ItemCode;
                                            MasterEntity.ItemName = POPUPEntityObject.ItemName;
                                            MasterEntity.ink_id = Convert.ToInt32(POPUPEntityObject.ink_id);
                                            MasterEntity.ild_id = Convert.ToInt32(POPUPEntityObject.ild_id);
                                            MasterEntity.wire_make_id = Convert.ToInt32(POPUPEntityObject.wire_make_id);
                                            MasterEntity.ball_make_id = Convert.ToInt32(POPUPEntityObject.ball_make_id);
                                            MasterEntity.pack_style = Convert.ToInt32(POPUPEntityObject.pack_style);
                                            MasterEntity.unit_code = POPUPEntityObject.unit_code;
                                            MasterEntity.grade = POPUPEntityObject.grade;
                                            MasterEntity.cust_prod_code = POPUPEntityObject.cust_prod_code;
                                            MasterEntity.qty_per_bag = POPUPEntityObject.qty_per_bag;
                                            MasterEntity.machine_id = POPUPEntityObject.machine_id;
                                            MasterEntity.machinecode = POPUPEntityObject.machinecode;
                                            MasterEntity.Ink = POPUPEntityObject.Ink;
                                            MasterEntity.Ild = POPUPEntityObject.Ild;
                                            MasterEntity.WireMake = POPUPEntityObject.WireMake;
                                            MasterEntity.BallMake = POPUPEntityObject.BallMake;
                                            MasterEntity.PackingUnit = POPUPEntityObject.PackingUnit;
                                            MasterEntity.PartyId = POPUPEntityObject.PartyId;
                                            MasterEntity.PartyNm = POPUPEntityObject.PartyNm;
                                            MasterEntity.net_wt += POPUPEntityObject.net_wt;
                                            MasterEntity.gross_wt += POPUPEntityObject.net_wt;

                                            SmallCartonEntity.Add(new EPR_T003_B()
                                            {
                                                carton_no = POPUPEntityObject.doc_no,
                                                batch_no = POPUPEntityObject.batch_no,
                                                qty = Convert.ToDecimal(POPUPEntityObject.tot_qty),
                                                location_Id = AppSessionState.location_Id,
                                                comp_code = AppSessionState.comp_code,
                                                active = true,
                                                add_by = AppSessionState.UserID,
                                                fin_year = "16-17",
                                                posting_period = "2",
                                                doc_cat = "CP",
                                                doc_type = MasterEntity.doc_type

                                            });

                                            barcode = "";
                                        }
                                        else if (SmallCartonEntity.Count > 0 && MasterEntity.ItemCode == POPUPEntityObject.ItemCode && MasterEntity.ink_id == POPUPEntityObject.ink_id &&
                                            MasterEntity.ild_id == POPUPEntityObject.ild_id &&
                                           MasterEntity.grade == POPUPEntityObject.grade)
                                        {
                                            int IndexOfExistBatch = SmallCartonEntity.IndexOf(SmallCartonEntity.Where(X => X.batch_no == POPUPEntityObject.batch_no && X.active == true).FirstOrDefault());

                                            if (IndexOfExistBatch == -1)
                                            {
                                                MasterEntity.net_wt += POPUPEntityObject.net_wt;
                                                MasterEntity.gross_wt += POPUPEntityObject.net_wt;

                                                SmallCartonEntity.Add(new EPR_T003_B()
                                                {
                                                    carton_no = POPUPEntityObject.doc_no,
                                                    batch_no = POPUPEntityObject.batch_no,
                                                    qty = Convert.ToDecimal(POPUPEntityObject.tot_qty),
                                                    location_Id = AppSessionState.location_Id,
                                                    comp_code = AppSessionState.comp_code,
                                                    active = true,
                                                    add_by = AppSessionState.UserID,
                                                    fin_year = "16-17",
                                                    posting_period = "2",
                                                    doc_cat = "CP",
                                                    doc_type = MasterEntity.doc_type

                                                });
                                                barcode = "";
                                            }
                                            else
                                            {
                                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                                showMessageService.ButtonSetup = DialogButton.Ok;
                                                showMessageService.Caption = "Message";
                                                showMessageService.Text = String.Format("This Small Carton/Batch Scanned already Exist", this.Title);
                                                showMessageService.ShowMessage();

                                                if (showMessageService.ShowMessage() == DialogResult.Ok || showMessageService.ShowMessage() == DialogResult.Cancel)
                                                {
                                                    barcode = "";
                                                }
                                            }
                                        }
                                        else
                                        {
                                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                            showMessageService.ButtonSetup = DialogButton.Ok;
                                            showMessageService.Caption = "Message";
                                            showMessageService.Text = String.Format("Product, Grade, Ink, Ild Should Be Same", this.Title);
                                            showMessageService.ShowMessage();

                                            if (showMessageService.ShowMessage() == DialogResult.Ok || showMessageService.ShowMessage() == DialogResult.Cancel)
                                            {
                                                barcode = "";
                                            }
                                        }

                                    }
                                    else
                                    {
                                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                        showMessageService.ButtonSetup = DialogButton.Ok;
                                        showMessageService.Caption = "Message";
                                        showMessageService.Text = String.Format("This Small Carton/Batch is Already used in Another Local Or Export Carton. Cannot Add Again", this.Title);
                                        showMessageService.ShowMessage();
                                        if (showMessageService.ShowMessage() == DialogResult.Ok || showMessageService.ShowMessage() == DialogResult.Cancel)
                                        {
                                            barcode = "";
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (MasterEntity.no_of_carton == 0 && barcode != "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Enter No of Carton First and Then Scan", this.Title);
                        showMessageService.ShowMessage();
                        if (showMessageService.ShowMessage() == DialogResult.Ok || showMessageService.ShowMessage() == DialogResult.Cancel)
                        {
                            barcode = "";
                        }
                    }
                    else if (MasterEntity.no_of_carton < SmallCartonEntity.Count && barcode != "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("You Cannot Scan More Number of Cartons Than Number You have Entered", this.Title);
                        showMessageService.ShowMessage();
                        if (showMessageService.ShowMessage() == DialogResult.Ok || showMessageService.ShowMessage() == DialogResult.Cancel)
                        {
                            barcode = "";
                        }
                    }
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Carton Type First", this.Title);
                    showMessageService.ShowMessage();
                    if (showMessageService.ShowMessage() == DialogResult.Ok || showMessageService.ShowMessage() == DialogResult.Cancel)
                    {
                        barcode = "";
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
        void ModelUpdated_Calculation(object sender, EventArgs e)
        {
            try
            {

                if (sender.ToString() == "no_of_carton" || sender.ToString() == "qty_per_bag" || sender.ToString() == "bags_per_carton")
                {
                    if (MasterEntity.no_of_carton != null && MasterEntity.bags_per_carton != null && MasterEntity.qty_per_bag != null)
                    {
                        MasterEntity.tot_no_bags = MasterEntity.no_of_carton * MasterEntity.bags_per_carton;
                        MasterEntity.tot_qty = MasterEntity.tot_no_bags * MasterEntity.qty_per_bag;
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
        //void ModelUpdated_Batch(object sender, EventArgs e)
        //{
        //    if (sender.ToString() == "active")
        //    {
        //       // MasterEntity.tot_no_bags = SmallCartonEntity.Count(p => p.active == true);
        //        MasterEntity.tot_qty = MasterEntity.tot_no_bags * MasterEntity.qty_per_bag;
        //    }
        //}

        //private void CollectionChangedNotifyForBatch(object sender, NotifyCollectionChangedEventArgs e)
        //{
        //    if (e.Action == NotifyCollectionChangedAction.Add)
        //    {
        //      //  MasterEntity.tot_no_bags = SmallCartonEntity.Count(p => p.active == true);
        //        MasterEntity.tot_qty = MasterEntity.tot_no_bags * MasterEntity.qty_per_bag;
        //    }

        //    if (e.Action == NotifyCollectionChangedAction.Replace)
        //    {

        //    }
        //    if (e.Action == NotifyCollectionChangedAction.Remove)
        //    {
        //       // MasterEntity.tot_no_bags = SmallCartonEntity.Count(p => p.active == true);
        //        MasterEntity.tot_qty = MasterEntity.tot_no_bags * MasterEntity.qty_per_bag;
        //    }
        //    if (e.Action == NotifyCollectionChangedAction.Move)
        //    {
        //    }
        //}     

        private void InsertItem(IList InputValue)
        {
            try
            {

                IList list = InputValue as IList;
                List<ADM_M022_P> GetSelectedItem = list.Cast<ADM_M022_P>().ToList();

                if (GetSelectedItem.Count > 0)
                {
                    BackFlipEntity.ItemCode = GetSelectedItem[0].ItemCode;
                    BackFlipEntity.ItemName = GetSelectedItem[0].ItemName;
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
        private void InsertInk(IList InputValue)
        {
            try
            {

                IList list = InputValue as IList;
                List<ZADM_M006_P> GetSelectedInk = list.Cast<ZADM_M006_P>().ToList();

                if (GetSelectedInk.Count > 0)
                {
                    BackFlipEntity.ink_id = GetSelectedInk[0].ink_id;
                    BackFlipEntity.Ink = GetSelectedInk[0].ink;
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
        private void InsertIld(IList InputValue)
        {
            try
            {

                IList list = InputValue as IList;
                List<ZADM_M007_P> GetSelectedIld = list.Cast<ZADM_M007_P>().ToList();

                if (GetSelectedIld.Count > 0)
                {
                    BackFlipEntity.ild_id = GetSelectedIld[0].ild_id;
                    BackFlipEntity.Ild = GetSelectedIld[0].ild;
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

        private void LoadLocalExportCartons()
        {
            try
            {

                BackFlipEntity.carton_type = "Export";
                BackFlipEntity.doc_type = "EC";
                bool Label_used = false;
                //if (BackFlipEntity.ItemCode == null || BackFlipEntity.ItemCode == "")
                //{
                //    BackFlipEntity.ItemCode = "All";
                //}
                //if (BackFlipEntity.ink_id == null || BackFlipEntity.Ink == "All")
                //{
                //    BackFlipEntity.ink_id = 0;
                //}
                //if (BackFlipEntity.ild_id == null || BackFlipEntity.Ild == "All")
                //{
                //    BackFlipEntity.ild_id = 0;
                //}
                //if (BackFlipEntity.grade == null)
                //{
                //    BackFlipEntity.grade = "All";
                //}


                if (LabelStatus == "Used")
                {
                    Label_used = true;
                }

                string Request = "LoadSmallCartons" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + BackFlipEntity.ItemCode
                                + "!@" + BackFlipEntity.ink_id + "!@" + BackFlipEntity.ild_id + "!@" + BackFlipEntity.grade + "!@" + BackFlipEntity.doc_type
                             + "!@" + Label_used + "!@" + Convert.ToDateTime(BackFlipEntity.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(BackFlipEntity.ToDate).ToString("MM/dd/yyyy") + "!@!@" + "REPACKING";


                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T003>(MCTemp, Request, "SmallCarton", "Production", "LoadAll", 0, BackFlipEntity.doc_type);

                if (MCTemp.MasterEntityList.Count > 0)
                {
                    FlipDataGridCollection = CollectionViewSource.GetDefaultView(MCTemp.MasterEntityList);
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

        private void LoadBigLabelReport()
        {
            try
            {
                if (MCTemp.MasterEntityList != null && MCTemp.MasterEntityList.Count > 0 && MC.SettingsList.Count > 0)
                {
                    if (PrintOption == "All")
                    {
                        object[] objDataSource = new object[3];
                        string[] objDataSourceName = new string[3];

                        QRCodeService QRGenerator = new QRCodeService();
                        foreach (RptLocalExportCarton item in MCTemp.RptLocalExportCartonList)
                        {
                            if (MC.SettingsList[0].scan_source == "Barcode")
                            {
                                item.qr_batch = QRGenerator.RenderQrCodeForLabel(item.barcode, 15, "");
                            }
                            else if (MC.SettingsList[0].scan_source == "Batch")
                            {
                                item.qr_batch = QRGenerator.RenderQrCodeForLabel(item.batch_no, 15, "");
                            }

                        }

                        objDataSource[0] = MCTemp.RptLocalExportCartonList;
                        objDataSourceName[0] = "dsRptLocalExportCarton";

                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\" + MC.SettingsList[0].report_name2, MC.SettingsList[0].report_name2);
                    }
                    else if (PrintOption == "Selected")
                    {
                        int count = MCTemp.MasterEntityList.Count(x => x.check == true);

                        if (count > 0)
                        {
                            foreach (var k in MCTemp.RptLocalExportCartonList)
                            {
                                k.check = false;
                            }

                            foreach (var o in MCTemp.MasterEntityList)
                            {
                                if (o.check == true)
                                {
                                    foreach (var p in MCTemp.RptLocalExportCartonList)
                                    {
                                        if (p.batch_no == o.batch_no && p.check != true)
                                        {
                                            p.check = true;
                                        }
                                    }
                                }
                            }

                            object[] objDataSource = new object[3];
                            string[] objDataSourceName = new string[3];

                            QRCodeService QRGenerator = new QRCodeService();
                            foreach (RptLocalExportCarton item in MCTemp.RptLocalExportCartonList)
                            {
                                if (MC.SettingsList[0].scan_source == "Barcode")
                                {
                                    item.qr_batch = QRGenerator.RenderQrCodeForLabel(item.barcode, 15, "");
                                }
                                else if (MC.SettingsList[0].scan_source == "Batch")
                                {
                                    item.qr_batch = QRGenerator.RenderQrCodeForLabel(item.batch_no, 15, "");
                                }

                            }

                            objDataSource[0] = MCTemp.RptLocalExportCartonList.Where(x => x.check == true);
                            objDataSourceName[0] = "dsRptLocalExportCarton";

                            ReportManager ReportManager = new ReportManager();
                            ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\" + MC.SettingsList[0].report_name2, MC.SettingsList[0].report_name2);
                        }
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Select Print Option", this.Title);
                        showMessageService.ShowMessage();
                    }
                }
                else if (MCTemp.MasterEntityList == null || MCTemp.MasterEntityList.Count <= 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Load the Data First.", this.Title);
                    showMessageService.ShowMessage();
                }
                else if (MC.SettingsList.Count <= 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Report Setting Not Found", this.Title);
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
        private void LoadBatchDetailsReport1()
        {
            try
            {
                if (MCTemp.MasterEntityList != null && MCTemp.MasterEntityList.Count > 0 && MC.SettingsList.Count > 0)
                {
                    if (PrintOption == "All")
                    {
                        string Request = "";

                        foreach (var item in MCTemp.MasterEntityList)
                        {
                            if (Request == "")
                            {
                                Request = item.doc_no.ToString();
                            }
                            else
                            {
                                Request += "," + item.doc_no.ToString();
                            }
                        }
                        Request = "LocalExportBatchDetailsReport" + "!@" + Request;
                        MCTemp3 = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T003>(MCTemp3, Request, "SmallCarton", "Production", "LoadAll", 0, BackFlipEntity.doc_type);

                        object[] objDataSource = new object[3];
                        string[] objDataSourceName = new string[3];

                        objDataSource[0] = MCTemp3.RptCartonBatchDetailsList;
                        objDataSourceName[0] = "dsRptCartonBatchDetails";

                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\" + MC.SettingsList[0].report_name3, MC.SettingsList[0].report_name3);

                    }
                    else if (PrintOption == "Selected")
                    {
                        string Request = "";

                        foreach (var item in MCTemp.MasterEntityList)
                        {
                            if (item.check == true)
                            {
                                if (Request == "")
                                {
                                    Request = item.doc_no.ToString();
                                }
                                else
                                {
                                    Request += "," + item.doc_no.ToString();
                                }
                            }

                        }
                        Request = "LocalExportBatchDetailsReport" + "!@" + Request;
                        MCTemp3 = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T003>(MCTemp3, Request, "SmallCarton", "Production", "LoadAll", 0, BackFlipEntity.doc_type);

                        object[] objDataSource = new object[3];
                        string[] objDataSourceName = new string[3];

                        objDataSource[0] = MCTemp3.RptCartonBatchDetailsList;
                        objDataSourceName[0] = "dsRptCartonBatchDetails";

                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\" + MC.SettingsList[0].report_name3, MC.SettingsList[0].report_name3);
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Select Print Option", this.Title);
                        showMessageService.ShowMessage();
                    }
                }
                else if (MCTemp.MasterEntityList == null || MCTemp.MasterEntityList.Count <= 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Load the Data First.", this.Title);
                    showMessageService.ShowMessage();
                }
                else if (MC.SettingsList.Count <= 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Report Setting Not Found", this.Title);
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
        //private void LoadBatchDetailsReport1()
        //{
        //    try
        //    {
        //        if (MCTemp.MasterEntityList != null && MCTemp.MasterEntityList.Count > 0 && MC.SettingsList.Count > 0)
        //        {
        //            if (PrintOption == "All")
        //            {
        //                object[] objDataSource = new object[3];
        //                string[] objDataSourceName = new string[3];

        //                objDataSource[0] = MCTemp.RptCartonBatchDetailsList;
        //                objDataSourceName[0] = "dsRptCartonBatchDetails";

        //                ReportManager ReportManager = new ReportManager();
        //                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\" + MC.SettingsList[0].report_name3, MC.SettingsList[0].report_name3);
        //            }
        //            else if (PrintOption == "Selected")
        //            {
        //                int count = MCTemp.MasterEntityList.Count(x => x.check == true);

        //                if (count > 0)
        //                {
        //                    foreach (var k in MCTemp.RptCartonBatchDetailsList)
        //                    {
        //                        k.check = false;
        //                    }

        //                    foreach (var o in MCTemp.MasterEntityList)
        //                    {
        //                        if (o.check == true)
        //                        {
        //                            foreach (var p in MCTemp.RptCartonBatchDetailsList)
        //                            {
        //                                if (p.batch_no == o.batch_no && p.check != true)
        //                                {
        //                                    p.check = true;
        //                                }
        //                            }
        //                        }
        //                    }

        //                    object[] objDataSource = new object[3];
        //                    string[] objDataSourceName = new string[3];

        //                    objDataSource[0] = MCTemp.RptCartonBatchDetailsList.Where(x => x.check == true);
        //                    objDataSourceName[0] = "dsRptCartonBatchDetails";

        //                    ReportManager ReportManager = new ReportManager();
        //                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\" + MC.SettingsList[0].report_name3, MC.SettingsList[0].report_name3);
        //                }
        //            }
        //            else
        //            {
        //                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //                showMessageService.ButtonSetup = DialogButton.Ok;
        //                showMessageService.Caption = "Message";
        //                showMessageService.Text = String.Format("Please Select Print Option", this.Title);
        //                showMessageService.ShowMessage();
        //            }
        //        }
        //        else if (MCTemp.MasterEntityList == null || MCTemp.MasterEntityList.Count <= 0)
        //        {
        //            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //            showMessageService.ButtonSetup = DialogButton.Ok;
        //            showMessageService.Caption = "Message";
        //            showMessageService.Text = String.Format("Please Load the Data First.", this.Title);
        //            showMessageService.ShowMessage();
        //        }
        //        else if (MC.SettingsList.Count <= 0)
        //        {
        //            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //            showMessageService.ButtonSetup = DialogButton.Ok;
        //            showMessageService.Caption = "Message";
        //            showMessageService.Text = String.Format("Report Setting Not Found", this.Title);
        //            showMessageService.ShowMessage();
        //        }
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
        private void LoadBatchDetailsReport2()
        {
            try
            {
                if (MCTemp.MasterEntityList != null && MCTemp.MasterEntityList.Count > 0 && MC.SettingsList.Count > 0)
                {
                    if (PrintOption == "All")
                    {
                        string Request = "";

                        foreach (var item in MCTemp.MasterEntityList)
                        {
                            if (Request == "")
                            {
                                Request = item.doc_no.ToString();
                            }
                            else
                            {
                                Request += "," + item.doc_no.ToString();
                            }
                        }
                        Request = "LocalExportBatchDetailsReport" + "!@" + Request;
                        MCTemp3 = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T003>(MCTemp3, Request, "SmallCarton", "Production", "LoadAll", 0, BackFlipEntity.doc_type);

                        object[] objDataSource = new object[3];
                        string[] objDataSourceName = new string[3];

                        objDataSource[0] = MCTemp3.RptCartonBatchDetailsList;
                        objDataSourceName[0] = "dsRptCartonBatchDetails";

                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\" + MC.SettingsList[0].report_name4, MC.SettingsList[0].report_name4);

                    }
                    else if (PrintOption == "Selected")
                    {
                        string Request = "";

                        foreach (var item in MCTemp.MasterEntityList)
                        {
                            if (item.check == true)
                            {
                                if (Request == "")
                                {
                                    Request = item.doc_no.ToString();
                                }
                                else
                                {
                                    Request += "," + item.doc_no.ToString();
                                }
                            }

                        }

                        Request = "LocalExportBatchDetailsReport" + "!@" + Request;
                        MCTemp3 = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T003>(MCTemp3, Request, "SmallCarton", "Production", "LoadAll", 0, BackFlipEntity.doc_type);

                        object[] objDataSource = new object[3];
                        string[] objDataSourceName = new string[3];

                        objDataSource[0] = MCTemp3.RptCartonBatchDetailsList;
                        objDataSourceName[0] = "dsRptCartonBatchDetails";

                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\" + MC.SettingsList[0].report_name4, MC.SettingsList[0].report_name4);
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Select Print Option", this.Title);
                        showMessageService.ShowMessage();
                    }
                }
                else if (MCTemp.MasterEntityList == null || MCTemp.MasterEntityList.Count <= 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Load the Data First.", this.Title);
                    showMessageService.ShowMessage();
                }
                else if (MC.SettingsList.Count <= 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Report Setting Not Found", this.Title);
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
        private void LoadWeightDetailsReport()
        {
            try
            {
                if (MCTemp.MasterEntityList != null && MCTemp.MasterEntityList.Count > 0 && MC.SettingsList.Count > 0)
                {
                    if (PrintOption == "All")
                    {
                        object[] objDataSource = new object[3];
                        string[] objDataSourceName = new string[3];

                        objDataSource[0] = MCTemp.RptLocalExportCartonList;
                        objDataSourceName[0] = "dsRptLocalExportCarton";

                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\" + MC.SettingsList[0].report_name5, MC.SettingsList[0].report_name5);
                    }
                    else if (PrintOption == "Selected")
                    {
                        int count = MCTemp.MasterEntityList.Count(x => x.check == true);

                        if (count > 0)
                        {
                            foreach (var k in MCTemp.RptLocalExportCartonList)
                            {
                                k.check = false;
                            }

                            foreach (var o in MCTemp.MasterEntityList)
                            {
                                if (o.check == true)
                                {
                                    foreach (var p in MCTemp.RptLocalExportCartonList)
                                    {
                                        if (p.batch_no == o.batch_no && p.check != true)
                                        {
                                            p.check = true;
                                        }
                                    }
                                }
                            }

                            object[] objDataSource = new object[3];
                            string[] objDataSourceName = new string[3];

                            objDataSource[0] = MCTemp.RptLocalExportCartonList.Where(x => x.check == true);
                            objDataSourceName[0] = "dsRptLocalExportCarton";

                            ReportManager ReportManager = new ReportManager();
                            ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\" + MC.SettingsList[0].report_name5, MC.SettingsList[0].report_name5);
                        }
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Select Print Option", this.Title);
                        showMessageService.ShowMessage();
                    }
                }
                else if (MCTemp.MasterEntityList == null || MCTemp.MasterEntityList.Count <= 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Load the Data First.", this.Title);
                    showMessageService.ShowMessage();
                }
                else if (MC.SettingsList.Count <= 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Report Setting Not Found", this.Title);
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
        private bool Validation()
        {   //validation Pending Delete

            if (MasterEntity.no_of_carton == null || MasterEntity.no_of_carton < 1)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("You Must Enter No of Carton Greater Than 0", this.Title);
                showMessageService.ShowMessage();
                return false;
            }

            if (MasterEntity.net_wt == null || MasterEntity.net_wt < 0)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(" Net Weight Must Be Greater Than 0", this.Title);
                showMessageService.ShowMessage();
                return false;
            }

            if (MasterEntity.gross_wt == null || MasterEntity.gross_wt < 0)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(" Gross Weight Must Be Greater Than 0", this.Title);
                showMessageService.ShowMessage();
                return false;
            }

            if (SmallCartonEntity.Count != MasterEntity.no_of_carton && SmallCartonEntity.Count > 0)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Total No of Cartons Must be Equal To No of Cartons in Carton Details \n And You Must Enter No of Cartons Greater Than 0", this.Title);
                showMessageService.ShowMessage();
                return false;
            }

            if (SmallCartonEntity.Count <= 0 && MasterEntity.active == true)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Scan and Then Save", this.Title);
                showMessageService.ShowMessage();
                return false;
            }
            return true;
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                EPR_T003_A ParameterEntityObject = null;

                if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<EPR_T003_A>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<EPR_T003_A>().ToList()[0];

                        string RequestParameterData = "LoadDocumentByDocumentNo" + "!@" + ParameterEntityObject.doc_no;
                        MCTemp2 = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T003>(MCTemp2, RequestParameterData, "SmallCarton", "Production", "LoadAll", 0, "");

                        MasterEntity = ParameterEntityObject;
                        SmallCartonEntity = MCTemp2.LabelGeneratedEntity;
                        isNewRecord = false;
                        SelectedTabControlIndex = 0;
                        MasterEntity.ts_code = ts_code_vm;
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
        protected override void OnSaveAction(InquiryActionResult<EPR_T003_A> result)
        {
            try
            {
                if (Validation() == true && isNewRecord == true)
                {

                    MasterEntity.XmlDataDocument_EPR_T003_B = obj.ObjectToXML(SmallCartonEntity);

                    MasterEntity = repository.SaveWithReturnDomainObject<SEL_T001>(MasterEntity, "SmallCarton", "Production");

                    if (MasterEntity.XmlDataDocument_EPR_T003_B != null)
                    {
                        MC.LabelGeneratedEntity = new ObservableCollection<EPR_T003_B>();
                        MC.LabelGeneratedEntity = (ObservableCollection<EPR_T003_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_EPR_T003_B, MC.LabelGeneratedEntity);
                        SmallCartonEntity.Clear();
                        SmallCartonEntity = MC.LabelGeneratedEntity;

                    }
                    else
                    {
                        MC.LabelGeneratedEntity = new ObservableCollection<EPR_T003_B>();
                        SmallCartonEntity.Clear();
                    }

                    foreach (var item in SmallCartonEntity)
                    {
                        if (item.doc_no != null && item.doc_no != "")
                        {
                            foreach (var p in MC.SmallCartonList)
                            {
                                if (item.batch_no == p.batch_no)
                                {
                                    p.carton_used_Flg = true;
                                }
                            }
                        }

                    }
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Saved Successfully", this.Title);
                    showMessageService.ShowMessage();
                    isNewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 
                }
                else if (Validation() == true && isNewRecord == false)
                {
                    MasterEntity.XmlDataDocument_EPR_T003_B = obj.ObjectToXML(SmallCartonEntity);

                    MasterEntity = repository.UpdateWithReturnDomainObject<EPR_T003_A>(MasterEntity, "SmallCarton", "Production");

                    if (MasterEntity.XmlDataDocument_EPR_T003_B != null)
                    {
                        MC.LabelGeneratedEntity = (ObservableCollection<EPR_T003_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_EPR_T003_B, MC.LabelGeneratedEntity);
                        SmallCartonEntity.Clear();
                        SmallCartonEntity = MC.LabelGeneratedEntity;

                    }
                    else
                    {
                        MC.LabelGeneratedEntity = new ObservableCollection<EPR_T003_B>();
                        SmallCartonEntity.Clear();
                    }

                    foreach (var item in SmallCartonEntity)
                    {
                        if (item.doc_no != null && item.doc_no != "")
                        {
                            foreach (var p in MC.SmallCartonList)
                            {
                                if (item.batch_no == p.batch_no)
                                {
                                    p.carton_used_Flg = true;
                                }
                            }
                        }
                    }

                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Saved Successfully", this.Title);
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
        protected override void OnCreateAction(InquiryActionResult<EPR_T003_A> result)
        {
            try
            {
                int? noofcartons = MasterEntity.no_of_carton;
                string dimenstion = MasterEntity.dimension;
                int? bagspercarton = MasterEntity.bags_per_carton;

                isNewRecord = true;
                MasterEntity = new EPR_T003_A();
                SmallCartonEntity = new ObservableCollection<EPR_T003_B>();
                DefaultValues();
                MasterEntity.no_of_carton = noofcartons;
                MasterEntity.dimension = dimenstion;
                MasterEntity.bags_per_carton = bagspercarton;
                MasterEntity.gross_wt = MC.SettingsList[0].gross_wt;
                BackFlipEntity = new EPR_T003_A_Flip();
                BackFlipEntity.FromDate = DateTime.Now;
                BackFlipEntity.ToDate = DateTime.Now;

                var msg = new NotificationMessage("EPR_T003_RepackingExport_VM");
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
        protected override void OnRemoveAction(InquiryActionResult<EPR_T003_A> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<EPR_T003_A> result)
        {
            //SelectedSEL_T001.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<EPR_T003_A> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<EPR_T003_A> result)
        {
            LoadInitialData();
        }
        protected override void OnHelpAction(InquiryActionResult<EPR_T003_A> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<EPR_T003_A> result)
        {
            try
            {
                if (MCTemp.MasterEntityList != null && MCTemp.MasterEntityList.Count > 0 && MC.SettingsList.Count > 0)
                {
                    if (PrintOption == "All")
                    {
                        object[] objDataSource = new object[3];
                        string[] objDataSourceName = new string[3];

                        QRCodeService QRGenerator = new QRCodeService();
                        foreach (RptLocalExportCarton item in MCTemp.RptLocalExportCartonList)
                        {
                            if (MC.SettingsList[0].scan_source == "Barcode")
                            {
                                item.qr_batch = QRGenerator.RenderQrCodeForLabel(item.barcode, 15, "");
                            }
                            else if (MC.SettingsList[0].scan_source == "Batch")
                            {
                                item.qr_batch = QRGenerator.RenderQrCodeForLabel(item.batch_no, 15, "");
                            }

                        }

                        objDataSource[0] = MCTemp.RptLocalExportCartonList;
                        objDataSourceName[0] = "dsRptLocalExportCarton";

                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\" + MC.SettingsList[0].report_name, MC.SettingsList[0].report_name);
                    }
                    else if (PrintOption == "Selected")
                    {
                        int count = MCTemp.MasterEntityList.Count(x => x.check == true);

                        if (count > 0)
                        {
                            foreach (var k in MCTemp.RptLocalExportCartonList)
                            {
                                k.check = false;
                            }

                            foreach (var o in MCTemp.MasterEntityList)
                            {
                                if (o.check == true)
                                {
                                    foreach (var p in MCTemp.RptLocalExportCartonList)
                                    {
                                        if (p.batch_no == o.batch_no && p.check != true)
                                        {
                                            p.check = true;
                                        }
                                    }
                                }
                            }

                            object[] objDataSource = new object[3];
                            string[] objDataSourceName = new string[3];

                            QRCodeService QRGenerator = new QRCodeService();
                            foreach (RptLocalExportCarton item in MCTemp.RptLocalExportCartonList)
                            {
                                if (MC.SettingsList[0].scan_source == "Barcode")
                                {
                                    item.qr_batch = QRGenerator.RenderQrCodeForLabel(item.barcode, 15, "");
                                }
                                else if (MC.SettingsList[0].scan_source == "Batch")
                                {
                                    item.qr_batch = QRGenerator.RenderQrCodeForLabel(item.batch_no, 15, "");
                                }

                            }

                            objDataSource[0] = MCTemp.RptLocalExportCartonList.Where(x => x.check == true);
                            objDataSourceName[0] = "dsRptLocalExportCarton";

                            ReportManager ReportManager = new ReportManager();
                            ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\" + MC.SettingsList[0].report_name, MC.SettingsList[0].report_name);
                        }
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Select Print Option", this.Title);
                        showMessageService.ShowMessage();
                    }
                }
                else if (MCTemp.MasterEntityList == null || MCTemp.MasterEntityList.Count <= 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Load the Data First.", this.Title);
                    showMessageService.ShowMessage();
                }
                else if (MC.SettingsList.Count <= 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Report Setting Not Found", this.Title);
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
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<EPR_T003_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<EPR_T003_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<EPR_T003_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<EPR_T003_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<EPR_T003_A> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Filter Functions
        private string _filterString_CustProductName;
        public string FilterString_CustProductName
        {
            get { return _filterString_CustProductName; }
            set
            {
                _filterString_CustProductName = value;
                RaisePropertyChanged("FilterString_CustProductName");
                FilterCollection_CustProductName();
            }
        }
        private void FilterCollection_CustProductName()
        {
            if (_CustProductName != null)
            {
                _CustProductName.Refresh();
            }
        }
        public bool Filter_CustProductName(object obj)
        {
            var data = obj as ZADM_M020_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_CustProductName))
                {
                    return (data.id != null && data.id.ToString().ToLower().Contains(_filterString_CustProductName.ToLower())) ||
                        (data.ProductName != null && data.ProductName.ToString().ToLower().Contains(_filterString_CustProductName.ToLower())) ||
                         (data.CustomerProductName != null && data.CustomerProductName.ToString().ToLower().Contains(_filterString_CustProductName.ToLower()));

                }
                return true;
            }
            return false;
        }

        #region Product

        private string _filterString_ProductCollection;
        public string FilterString_ProductCollection
        {
            get { return _filterString_ProductCollection; }
            set
            {
                _filterString_ProductCollection = value;
                RaisePropertyChanged("FilterString_ProductCollection");
                FilterCollection_ProductCollection();
            }
        }
        private void FilterCollection_ProductCollection()
        {
            if (_ProductCollection != null)
            {
                _ProductCollection.Refresh();
            }
        }
        public bool Filter_ProductCollection(object obj)
        {
            var data = obj as ADM_M022_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ProductCollection))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_ProductCollection.ToLower()) ||
                                        data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_ProductCollection.ToLower()));
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
        #endregion
    }
}
