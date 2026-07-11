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
    class EPR_T003_SampleCarton_VM : WorkspaceViewModel<EPR_T003_A>
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
        private ObservableCollection<EPR_T003_B> _LabelGeneratedEntity;
        //Data source for Scanned Label Generated From Label Generation

        public ObservableCollection<EPR_T003_B> LabelGeneratedEntity
        {
            get
            {
                return _LabelGeneratedEntity;
            }
            set
            {
                if (_LabelGeneratedEntity != value)
                {
                    _LabelGeneratedEntity = value;
                    // ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("LabelGeneratedEntity");
                }
            }
        }

        private int _dgSelectedIndexLabel;
        public int dgSelectedIndexLabel
        {
            get
            {
                return _dgSelectedIndexLabel;
            }
            set
            {
                if (_dgSelectedIndexLabel != value)
                {
                    _dgSelectedIndexLabel = value;
                    RaisePropertyChanged("dgSelectedIndexLabel");

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

        private int? _machine_id;
        public int? machine_id
        {
            get
            {
                return _machine_id;
            }
            set
            {
                if (_machine_id != value)
                {
                    _machine_id = value;
                    RaisePropertyChanged("machine_id");
                }
            }
        }

        private string _machinecode;
        public string machinecode
        {
            get
            {
                return _machinecode;
            }
            set
            {
                if (_machinecode != value)
                {
                    _machinecode = value;
                    RaisePropertyChanged("machinecode");
                }
            }
        }

        private bool _ReadOnly;   //movement type enable disable
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set { _ReadOnly = value; RaisePropertyChanged("ReadOnly"); }
        }

        private bool _IsHitTestVisible;   //movement type enable disable
        public bool IsHitTestVisible
        {
            get { return _IsHitTestVisible; }
            set { _IsHitTestVisible = value; RaisePropertyChanged("IsHitTestVisible"); }
        }

        #endregion
        #region ICollection For Popup Control

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

        private ICollectionView _ProductCollection2;
        public ICollectionView ProductCollection2
        {
            get { return _ProductCollection2; }
            set
            {
                _ProductCollection2 = value;
                RaisePropertyChanged("ProductCollection2");
            }
        }

        private ICollectionView _InkCollection2;
        public ICollectionView InkCollection2
        {
            get { return _InkCollection2; }
            set
            {
                _InkCollection2 = value;
                RaisePropertyChanged("InkCollection2");
            }
        }

        private ICollectionView _IldCollection2;
        public ICollectionView IldCollection2
        {
            get { return _IldCollection2; }
            set
            {
                _IldCollection2 = value;
                RaisePropertyChanged("IldCollection2");
            }
        }

        private ICollectionView _WiremakeCollection;
        public ICollectionView WiremakeCollection
        {
            get { return _WiremakeCollection; }
            set
            {
                _WiremakeCollection = value;
                RaisePropertyChanged("WiremakeCollection");
            }
        }

        private ICollectionView _BallmakeCollection;
        public ICollectionView BallmakeCollection
        {
            get { return _BallmakeCollection; }
            set
            {
                _BallmakeCollection = value;
                RaisePropertyChanged("BallmakeCollection");
            }
        }

        private ICollectionView _PackingUnitCollection;
        public ICollectionView PackingUnitCollection
        {
            get { return _PackingUnitCollection; }
            set
            {
                _PackingUnitCollection = value;
                RaisePropertyChanged("PackingUnitCollection");
            }
        }

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


        private ICollectionView _BatchCollection;
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

        #region RelayCommand Actions

        public RelayCommand<object> cmdBarcodeScan { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowBatch { get; private set; }
        public RelayCommand<IList> cmdProduct2 { get; private set; }
        public RelayCommand<IList> cmdInk2 { get; private set; }
        public RelayCommand<IList> cmdIld2 { get; private set; }
        public RelayCommand<IList> cmdWireMake { get; private set; }
        public RelayCommand<IList> cmdBallMake { get; private set; }
        public RelayCommand<IList> cmdPackingUnit { get; private set; }
        public RelayCommand<IList> cmdUnitcode { get; private set; }
        public RelayCommand<object> CommandInsertItem { get; private set; }
        public RelayCommand cmdGetBatchCollection { get; private set; }
        public RelayCommand cmdSelectionChanged { get; private set; }

        //BackSide
        public RelayCommand<IList> cmdProduct { get; private set; }
        public RelayCommand<IList> cmdInk { get; private set; }
        public RelayCommand<IList> cmdIld { get; private set; }
        public RelayCommand<IList> CommandMachine { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByByDocumentNumber { get; private set; }
        public RelayCommand cmdLoadSmallCartons { get; private set; }
        public RelayCommand cmdBatchDetailsReport { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }

        #endregion

        #region Constructor
        public EPR_T003_SampleCarton_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MC = new MultipleContext_EPR_T003();
            MCTemp = new MultipleContext_EPR_T003();
            MCTemp2 = new MultipleContext_EPR_T003();
            MasterEntity = new EPR_T003_A();
            LabelGeneratedEntity = new ObservableCollection<EPR_T003_B>();
            BackFlipEntity = new EPR_T003_A_Flip();
            PrintOption = "All";
            LabelStatus = "Unused";
            ReadOnly = false;
            IsHitTestVisible = true;
            EPR_T003_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Calculation);
            BackFlipEntity.FromDate = DateTime.Now;
            BackFlipEntity.ToDate = DateTime.Now;

            // EPR_T003_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Batch);
            //  LabelGeneratedEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForBatch);



            LoadInitialData();
        }
        public EPR_T003_SampleCarton_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MC = new MultipleContext_EPR_T003();
            MCTemp = new MultipleContext_EPR_T003();
            MCTemp2 = new MultipleContext_EPR_T003();
            MasterEntity = new EPR_T003_A();
            LabelGeneratedEntity = new ObservableCollection<EPR_T003_B>();
            BackFlipEntity = new EPR_T003_A_Flip();
            PrintOption = "All";
            LabelStatus = "Unused";
            ReadOnly = false;
            IsHitTestVisible = true;
            EPR_T003_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Calculation);
            BackFlipEntity.FromDate = DateTime.Now;
            BackFlipEntity.ToDate = DateTime.Now;

            // EPR_T003_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Batch);
            //  LabelGeneratedEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForBatch);



            LoadInitialData();
        }
        #endregion
        #region Abstract Command Actions
        protected override void OnSaveAction(InquiryActionResult<EPR_T003_A> result)
        {
            try
            {
                if (Validation() == true && isNewRecord == true)
                {

                    if (isNewRecord == true)
                    {
                        MasterEntity.XmlDataDocument_EPR_T003_B = obj.ObjectToXML(LabelGeneratedEntity);

                        MasterEntity = repository.SaveWithReturnDomainObject<EPR_T003_A>(MasterEntity, "SmallCarton", "Production");

                        if (MasterEntity.XmlDataDocument_EPR_T003_B != null)
                        {
                            MC.LabelGeneratedEntity = new ObservableCollection<EPR_T003_B>();
                            MC.LabelGeneratedEntity = (ObservableCollection<EPR_T003_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_EPR_T003_B, MC.LabelGeneratedEntity);
                            LabelGeneratedEntity.Clear();
                            LabelGeneratedEntity = MC.LabelGeneratedEntity;

                        }
                        else
                        {
                            MC.LabelGeneratedEntity = new ObservableCollection<EPR_T003_B>();
                            LabelGeneratedEntity.Clear();
                        }

                        isNewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 

                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Saved Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }

                }
                else if (Validation() == true && isNewRecord == false)
                {
                    MasterEntity.XmlDataDocument_EPR_T003_B = obj.ObjectToXML(LabelGeneratedEntity);

                    MasterEntity = repository.UpdateWithReturnDomainObject<EPR_T003_A>(MasterEntity, "SmallCarton", "Production");

                    if (MasterEntity.XmlDataDocument_EPR_T003_B != null)
                    {
                        MC.LabelGeneratedEntity = new ObservableCollection<EPR_T003_B>();
                        MC.LabelGeneratedEntity = (ObservableCollection<EPR_T003_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_EPR_T003_B, MC.LabelGeneratedEntity);
                        LabelGeneratedEntity.Clear();
                        LabelGeneratedEntity = MC.LabelGeneratedEntity;

                    }
                    else
                    {
                        MC.LabelGeneratedEntity = new ObservableCollection<EPR_T003_B>();
                        LabelGeneratedEntity.Clear();
                    }

                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Saved Successfully", this.Title);
                    showMessageService.ShowMessage();
                }

                ReadOnly = true;
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
            decimal? NoofBags = MasterEntity.tot_no_bags;
            isNewRecord = true;
            MasterEntity = new EPR_T003_A();
            BackFlipEntity = new EPR_T003_A_Flip();
            LabelGeneratedEntity = new ObservableCollection<EPR_T003_B>();
            DefaultValues();
            MasterEntity.tot_no_bags = NoofBags;
            var msg = new NotificationMessage("EPR_T003_SampleCarton_VM");
            Messenger.Default.Send<NotificationMessage>(msg);
            BackFlipEntity.FromDate = DateTime.Now;
            BackFlipEntity.ToDate = DateTime.Now;
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
                if (MCTemp.MasterEntityList.Count > 0 && MC.SettingsList.Count > 0)
                {
                    if (PrintOption == "All")
                    {
                        object[] objDataSource = new object[3];
                        string[] objDataSourceName = new string[3];

                        QRCodeService QRGenerator = new QRCodeService();
                        foreach (RptSmallCarton item in MCTemp.RptSmallCartonList)
                        {
                            if (MC.SettingsList[0].scan_source == "Barcode")
                            {
                                item.qr_batch1 = QRGenerator.RenderQrCodeForLabel(item.barcode, 15, "");
                                item.qr_batch2 = QRGenerator.RenderQrCodeForLabel(item.batch1, 15, "");
                                item.qr_batch3 = QRGenerator.RenderQrCodeForLabel(item.batch2, 15, "");
                            }
                            else if (MC.SettingsList[0].scan_source == "Batch")
                            {
                                item.qr_batch1 = QRGenerator.RenderQrCodeForLabel(item.batch_no, 15, "");
                                item.qr_batch2 = QRGenerator.RenderQrCodeForLabel(item.batch1, 15, "");
                                item.qr_batch3 = QRGenerator.RenderQrCodeForLabel(item.batch2, 15, "");
                            }
                        }

                        objDataSource[0] = MCTemp.RptSmallCartonList;
                        objDataSourceName[0] = "dsRptSmallCarton";

                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\" + MC.SettingsList[0].report_name, MC.SettingsList[0].report_name);
                    }
                    else if (PrintOption == "Selected")
                    {
                        int count = MCTemp.MasterEntityList.Count(x => x.check == true);

                        if (count > 0)
                        {
                            foreach (var k in MCTemp.RptSmallCartonList)
                            {
                                k.check = false;
                            }

                            foreach (var o in MCTemp.MasterEntityList)
                            {
                                if (o.check == true)
                                {
                                    foreach (var p in MCTemp.RptSmallCartonList)
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
                            foreach (RptSmallCarton item in MCTemp.RptSmallCartonList)
                            {
                                if (MC.SettingsList[0].scan_source == "Barcode")
                                {
                                    item.qr_batch1 = QRGenerator.RenderQrCodeForLabel(item.barcode, 15, "");
                                    item.qr_batch2 = QRGenerator.RenderQrCodeForLabel(item.batch1, 15, "");
                                    item.qr_batch3 = QRGenerator.RenderQrCodeForLabel(item.batch2, 15, "");
                                }
                                else if (MC.SettingsList[0].scan_source == "Batch")
                                {
                                    item.qr_batch1 = QRGenerator.RenderQrCodeForLabel(item.batch_no, 15, "");
                                    item.qr_batch2 = QRGenerator.RenderQrCodeForLabel(item.batch1, 15, "");
                                    item.qr_batch3 = QRGenerator.RenderQrCodeForLabel(item.batch2, 15, "");
                                }

                            }

                            objDataSource[0] = MCTemp.RptSmallCartonList.Where(x => x.check == true);
                            objDataSourceName[0] = "dsRptSmallCarton";

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
                else if (MCTemp.MasterEntityList.Count <= 0)
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
            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
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
        #region User Defined Methods
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialDataSampleCarton" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + "FS" + "!@" + MasterEntity.doc_cat + "!@" + "True";
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T003>(MC, Request, "SmallCarton", "Production", "LoadAll", 0, "");
                //MC = repositoryM.GetData<MultipleContext_EPR_T003>(MC, Request, "", "Reflection.BusinessLogic.EPR_T003BL");

                #region Command Initialization

                cmdBarcodeScan = new RelayCommand<object>(items => { if (items == null) { return; } InsertAllDataFromScannedBarcode(items); });
                cmdDeleteDataGridRowBatch = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Batch(cmdPara); });
                cmdProduct2 = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertItem2(cmdPara); });
                cmdInk2 = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertInk2(cmdPara); });
                cmdIld2 = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertIld2(cmdPara); });
                cmdWireMake = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertWireMake(cmdPara); });
                cmdBallMake = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertBallMake(cmdPara); });
                cmdPackingUnit = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertPackingUnit(cmdPara); });
                cmdUnitcode = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertUnitcode(cmdPara); });
                CommandInsertItem = new RelayCommand<object>(items => { if (items == null) { return; } InsertDataGridRow_Item(items, true, true, true); });
                cmdGetBatchCollection = new RelayCommand(() => { GetBatchCollection(); });
                cmdSelectionChanged = new RelayCommand(() => { SelectionChangedMethod(); });
                cmdLoadSmallCartons = new RelayCommand(() => { LoadSmallCartons(); });
                cmdBatchDetailsReport = new RelayCommand(() => { LoadBatchDetailsReport(); });
                cmdProduct = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertItem(cmdPara); });
                cmdInk = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertInk(cmdPara); });
                cmdIld = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertIld(cmdPara); });
                CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                #endregion
                ProductCollection2 = CollectionViewSource.GetDefaultView(MC.ItemList2);
                ProductCollection2.Filter = new Predicate<object>(Filter_ProductCollection2);

                InkCollection2 = CollectionViewSource.GetDefaultView(MC.InkList2);
                InkCollection2.Filter = new Predicate<object>(Filter_Ink2);

                IldCollection2 = CollectionViewSource.GetDefaultView(MC.IidList2);
                IldCollection2.Filter = new Predicate<object>(Filter_Ild2);

                WiremakeCollection = CollectionViewSource.GetDefaultView(MC.WireMakeList);
                WiremakeCollection.Filter = new Predicate<object>(Filter_Wiremake);

                BallmakeCollection = CollectionViewSource.GetDefaultView(MC.BallMakeList);
                BallmakeCollection.Filter = new Predicate<object>(Filter_Ballmake);

                PackingUnitCollection = CollectionViewSource.GetDefaultView(MC.PackingUnitList);
                PackingUnitCollection.Filter = new Predicate<object>(Filter_PackingUnit);

                UnitCollection = CollectionViewSource.GetDefaultView(MC.UnitList);
                UnitCollection.Filter = new Predicate<object>(Filter_Unit);

                ProductCollection = CollectionViewSource.GetDefaultView(MC.ItemList);
                ProductCollection.Filter = new Predicate<object>(Filter_ProductCollection);

                InkCollection = CollectionViewSource.GetDefaultView(MC.InkList);
                InkCollection.Filter = new Predicate<object>(Filter_Ink);

                IldCollection = CollectionViewSource.GetDefaultView(MC.IidList);
                IldCollection.Filter = new Predicate<object>(Filter_Ild);

                DefaultValues();

                if (MC.SettingsList.Count > 0)
                {
                    MasterEntity.tot_no_bags = MC.SettingsList[0].no_of_bags;
                    Scan_Source = MC.SettingsList[0].scan_source;
                    Scan_Length = MC.SettingsList[0].min_length;
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
            MasterEntity.carton_type = "Sample";
            MasterEntity.doc_type = "FS";
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
            MasterEntity.posting_period = "5";
            MasterEntity.tot_no_bags = 0;
            MasterEntity.net_wt = 0;
            MasterEntity.gross_wt = 0;
            MasterEntity.packing_type = "PRODUCTION";
            MasterEntity.free_sale = "Free";
            MasterEntity.ts_code = ts_code_vm;
        }
        private void InsertAllDataFromScannedBarcode(object InputValue)
        {
            try
            {
                EPR_T002_Flip POPUPEntityObject = null;
                barcode = InputValue.ToString();
                if (MasterEntity.tot_no_bags > 0 && MasterEntity.tot_no_bags > LabelGeneratedEntity.Count && MC.LabelGeneratedList != null)
                {
                    if (barcode.Length > Scan_Length) // condition change from Fix 9 to from DB
                    {
                        //Block  added to switch between Barcode and Batch Number as per specified in DB. Start

                        if (Scan_Source == "Barcode")
                        { barcode = barcode; }
                        else if (Scan_Source == "Batch" && MC.LabelGeneratedList.Where(X => X.batch_no == barcode).FirstOrDefault() != null)
                        {
                            barcode = MC.LabelGeneratedList.Where(X => X.batch_no == barcode).FirstOrDefault().barcode;
                        }
                        //Block  added to switch between Barcode and Batch Number as per specified in DB. End

                        var InputValueIfExists = MC.LabelGeneratedList.Where(X => X.barcode == barcode).FirstOrDefault();  //Checking Weather Barcode is Valid or Not By Checking in Business Entity
                        if (InputValueIfExists != null)
                        {
                            POPUPEntityObject = MC.LabelGeneratedList.Where(x => x.barcode.Equals(barcode, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; //If Barcode is Valid Get All the Information in PopupEntityObject

                            if (POPUPEntityObject != null)
                            {
                                if (POPUPEntityObject.carton_cons_stat != true)
                                {
                                    if (LabelGeneratedEntity.Count == 0)
                                    {
                                        MasterEntity.ItemCode = POPUPEntityObject.ItemCode;
                                        MasterEntity.ItemName = POPUPEntityObject.ItemName;
                                        MasterEntity.ink_id = Convert.ToInt32(POPUPEntityObject.ink_id);
                                        MasterEntity.ild_id = Convert.ToInt32(POPUPEntityObject.ild_id);
                                        MasterEntity.wire_make_id = Convert.ToInt32(POPUPEntityObject.wire_make);
                                        MasterEntity.ball_make_id = Convert.ToInt32(POPUPEntityObject.ball_make);
                                        MasterEntity.pack_style = Convert.ToInt32(POPUPEntityObject.pack_style);
                                        MasterEntity.unit_code = POPUPEntityObject.unit_code;
                                        MasterEntity.grade = POPUPEntityObject.grade;
                                        MasterEntity.cust_prod_code = POPUPEntityObject.CustomerProductName;
                                        MasterEntity.qty_per_bag = POPUPEntityObject.label_qty;
                                        MasterEntity.machine_id = POPUPEntityObject.machine_id;
                                        MasterEntity.machinecode = POPUPEntityObject.machinecode;
                                        MasterEntity.carton_pack_dt = POPUPEntityObject.prod_dt;
                                        BackFlipEntity.FromDate = POPUPEntityObject.prod_dt;
                                        machine_id = POPUPEntityObject.machine_id;
                                        machinecode = POPUPEntityObject.machinecode;
                                        MasterEntity.Ink = POPUPEntityObject.Ink;
                                        MasterEntity.Ild = POPUPEntityObject.Ild;
                                        MasterEntity.WireMake = POPUPEntityObject.WireMake;
                                        MasterEntity.BallMake = POPUPEntityObject.BallMake;
                                        MasterEntity.PackingUnit = POPUPEntityObject.PackingUnit;
                                        MasterEntity.PartyId = POPUPEntityObject.PartyId;
                                        MasterEntity.PartyNm = POPUPEntityObject.PartyNm;
                                        MasterEntity.net_wt += POPUPEntityObject.net_wt;

                                        LabelGeneratedEntity.Add(new EPR_T003_B()
                                        {
                                            batch_no = POPUPEntityObject.batch_no,
                                            cust_batch_no = POPUPEntityObject.cust_batch_no,
                                            qty = Convert.ToDecimal(POPUPEntityObject.label_qty),
                                            location_Id = AppSessionState.location_Id,
                                            comp_code = AppSessionState.comp_code,
                                            active = true,
                                            add_by = AppSessionState.UserID,
                                            fin_year = "16-17",
                                            posting_period = "2",
                                            doc_cat = "CP",
                                            doc_type = "SC",
                                            MachinePacCode = POPUPEntityObject.MachinePacCode,
                                            Shift = POPUPEntityObject.shift
                                        });
                                        barcode = "";
                                    }
                                    else if (LabelGeneratedEntity.Count > 0 && MasterEntity.ItemCode == POPUPEntityObject.ItemCode && MasterEntity.ink_id == POPUPEntityObject.ink_id &&
                                            MasterEntity.ild_id == POPUPEntityObject.ild_id &&
                                           MasterEntity.grade == POPUPEntityObject.grade)
                                    {

                                        int IndexOfExistBatch = LabelGeneratedEntity.IndexOf(LabelGeneratedEntity.Where(X => X.batch_no == POPUPEntityObject.batch_no && X.active == true).FirstOrDefault());

                                        if (IndexOfExistBatch == -1)
                                        {
                                            MasterEntity.net_wt += POPUPEntityObject.net_wt;

                                            LabelGeneratedEntity.Add(new EPR_T003_B()
                                            {
                                                batch_no = POPUPEntityObject.batch_no,
                                                cust_batch_no = POPUPEntityObject.cust_batch_no,
                                                qty = Convert.ToDecimal(POPUPEntityObject.label_qty),
                                                location_Id = AppSessionState.location_Id,
                                                comp_code = AppSessionState.comp_code,
                                                active = true,
                                                add_by = AppSessionState.UserID,
                                                fin_year = "16-17",
                                                posting_period = "2",
                                                doc_cat = "CP",
                                                doc_type = "SC",
                                                MachinePacCode = POPUPEntityObject.MachinePacCode,
                                                Shift = POPUPEntityObject.shift
                                            });
                                            barcode = "";
                                        }
                                        else
                                        {
                                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                            showMessageService.ButtonSetup = DialogButton.Ok;
                                            showMessageService.Caption = "Message";
                                            showMessageService.Text = String.Format("Batch/Barcode Scanned already Exist", this.Title);
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
                                        showMessageService.Text = String.Format("Scanned Barcode is Invalid.\n Product, Ink, Ild, Ballmake, Wiremake, Grade, Pack Style Does Not Match \n Please Scan the Correct Barcode", this.Title);
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
                                    showMessageService.Text = String.Format("Batch is Already Packed in Another Small Carton. So Not Allowed To add Again", this.Title);
                                    showMessageService.ShowMessage();
                                    if (showMessageService.ShowMessage() == DialogResult.Ok || showMessageService.ShowMessage() == DialogResult.Cancel)
                                    {
                                        barcode = "";
                                    }
                                }


                            }

                        }
                        //else
                        //{
                        //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        //    showMessageService.ButtonSetup = DialogButton.Ok;
                        //    showMessageService.Caption = "Message";
                        //    showMessageService.Text = String.Format("Invalid Barcode/Batch.\n  Please Make Sure That Batch You Are Scanning Must Exist in Label Generation\n Also Label Complete Status must be True", this.Title);
                        //    showMessageService.ShowMessage();
                        //    if (showMessageService.ShowMessage() == DialogResult.Ok || showMessageService.ShowMessage() == DialogResult.Cancel)
                        //    {
                        //        barcode = "";
                        //    }
                        //}

                    }
                }
                else if (MasterEntity.tot_no_bags == 0 && barcode != "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter No of Bags First and Then Scan", this.Title);
                    showMessageService.ShowMessage();
                    if (showMessageService.ShowMessage() == DialogResult.Ok || showMessageService.ShowMessage() == DialogResult.Cancel)
                    {
                        barcode = "";
                    }
                }
                else if (MasterEntity.tot_no_bags < LabelGeneratedEntity.Count && barcode != "") // must check <=  here but due to multiple executing of event and hence multiple executing of method will irritate him even when user scan correct barcode
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("No. Of Batches Cannot Exceed No. Of Bags", this.Title);
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
                barcode = "";
            }
        }
        void ModelUpdated_Calculation(object sender, EventArgs e)
        {
            try
            {
                if (sender.ToString() == "tot_no_bags" || sender.ToString() == "qty_per_bag")
                {
                    if (MasterEntity.tot_no_bags != null && MasterEntity.qty_per_bag != null)
                    {
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
        //        MasterEntity.tot_qty = MasterEntity.tot_no_bags * MasterEntity.qty_per_bag;
        //    }            
        //}

        //private void CollectionChangedNotifyForBatch(object sender, NotifyCollectionChangedEventArgs e)
        //{
        //    if (e.Action == NotifyCollectionChangedAction.Add)
        //    {
        //        MasterEntity.tot_qty = MasterEntity.tot_no_bags * MasterEntity.qty_per_bag;
        //    }

        //    if (e.Action == NotifyCollectionChangedAction.Replace)
        //    {

        //    }
        //    if (e.Action == NotifyCollectionChangedAction.Remove)
        //    {
        //        MasterEntity.tot_qty = MasterEntity.tot_no_bags * MasterEntity.qty_per_bag;
        //    }
        //    if (e.Action == NotifyCollectionChangedAction.Move)
        //    {
        //    }
        //}
        private void DeleteDataGridRow_Batch(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (i != -1)
                {
                    if (LabelGeneratedEntity[i].id == 0)
                    {
                        if (LabelGeneratedEntity.Count > i)
                        {
                            LabelGeneratedEntity.RemoveAt(i);
                        }
                        int count = LabelGeneratedEntity.Count;

                        decimal? wt = MasterEntity.net_wt / (LabelGeneratedEntity.Count + 1);
                        MasterEntity.net_wt -= wt;
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

        private void SelectionChangedMethod()
        {
            try
            {
                if (dgSelectedIndexLabel != -1 && LabelGeneratedEntity != null && dgSelectedIndexLabel < LabelGeneratedEntity.Count)
                {
                    if (LabelGeneratedEntity[dgSelectedIndexLabel].id == 0)
                    {
                        ReadOnly = false;
                        IsHitTestVisible = true;
                    }
                    else
                    {
                        ReadOnly = true;
                        IsHitTestVisible = false;
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
        private void GetBatchCollection()
        {
            try
            {
                if (MasterEntity.ItemCode != null && MasterEntity.ItemCode != "" && MasterEntity.ink_id != null && MasterEntity.ink_id != 0 &&
                        MasterEntity.ild_id != null && MasterEntity.ild_id != 0 && MasterEntity.grade != null && MasterEntity.grade != "" && MasterEntity.unit_code != null && MasterEntity.unit_code != "")
                {
                    var FilteredBatches = (from o in MC.LabelGeneratedList
                                           where o.ItemCode == MasterEntity.ItemCode && o.ink_id == MasterEntity.ink_id
                && o.ild_id == MasterEntity.ild_id && o.grade == MasterEntity.grade && o.unit_code == MasterEntity.unit_code
                                           select o).ToList();

                    BatchCollection = CollectionViewSource.GetDefaultView(FilteredBatches.ToList());
                    BatchCollection.Filter = new Predicate<object>(Filter_BatchList);
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Product, Grade , Ink, Ild and Unit before adding batch no ", this.Title);
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
        private void LoadSmallCartons()
        {
            try
            {
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
                //if (machine_id == null || machinecode == "All")
                //{
                //    machine_id = 0;
                //}
                //if (BackFlipEntity.grade == null)
                //{
                //    BackFlipEntity.grade = "All";
                //}
                BackFlipEntity.doc_type = "FS";

                if (LabelStatus == "Used")
                {
                    Label_used = true;
                }

                string Request = "LoadSmallCartons" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + BackFlipEntity.ItemCode
                                + "!@" + BackFlipEntity.ink_id + "!@" + BackFlipEntity.ild_id + "!@" + BackFlipEntity.grade + "!@" + BackFlipEntity.doc_type
                                + "!@" + Label_used + "!@" + Convert.ToDateTime(BackFlipEntity.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(BackFlipEntity.ToDate).ToString("MM/dd/yyyy") + "!@" + machine_id + "!@" + "PRODUCTION";

                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T003>(MCTemp, Request, "SmallCarton", "Production", "LoadAll", 0, BackFlipEntity.doc_type);
                // MCTemp = repositoryM.GetData<MultipleContext_EPR_T003>(MCTemp, Request, "", "Reflection.BusinessLogic.EPR_T003BL");
                if (MCTemp.MasterEntityList.Count > 0)
                {
                    FlipDataGridCollection = CollectionViewSource.GetDefaultView(MCTemp.MasterEntityList);
                    FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipDataGridCollection);
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

        private void InsertItem2(IList InputValue)
        {
            try
            {
                IList list = InputValue as IList;
                List<ADM_M022_P> GetSelectedItem = list.Cast<ADM_M022_P>().ToList();

                if (GetSelectedItem.Count > 0)
                {
                    MasterEntity.ItemCode = GetSelectedItem[0].ItemCode;
                    MasterEntity.ItemName = GetSelectedItem[0].ItemName;
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
        private void InsertInk2(IList InputValue)
        {
            try
            {
                IList list = InputValue as IList;
                List<ZADM_M006_P> GetSelectedInk = list.Cast<ZADM_M006_P>().ToList();

                if (GetSelectedInk.Count > 0)
                {
                    MasterEntity.ink_id = GetSelectedInk[0].ink_id;
                    MasterEntity.Ink = GetSelectedInk[0].ink;
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
        private void InsertIld2(IList InputValue)
        {
            try
            {
                IList list = InputValue as IList;
                List<ZADM_M007_P> GetSelectedIld = list.Cast<ZADM_M007_P>().ToList();

                if (GetSelectedIld.Count > 0)
                {
                    MasterEntity.ild_id = GetSelectedIld[0].ild_id;
                    MasterEntity.Ild = GetSelectedIld[0].ild;
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
        private void InsertWireMake(IList InputValue)
        {
            try
            {
                IList list = InputValue as IList;
                List<ADM_M032_P> GetSelectedwiremake = list.Cast<ADM_M032_P>().ToList();

                if (GetSelectedwiremake.Count > 0)
                {
                    MasterEntity.wire_make_id = GetSelectedwiremake[0].MakeCode;
                    MasterEntity.WireMake = GetSelectedwiremake[0].Make;
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
        private void InsertBallMake(IList InputValue)
        {
            try
            {
                IList list = InputValue as IList;
                List<ADM_M032_P> GetSelectedballmake = list.Cast<ADM_M032_P>().ToList();

                if (GetSelectedballmake.Count > 0)
                {
                    MasterEntity.ball_make_id = GetSelectedballmake[0].MakeCode;
                    MasterEntity.BallMake = GetSelectedballmake[0].Make;
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
        private void InsertPackingUnit(IList InputValue)
        {
            try
            {
                IList list = InputValue as IList;
                List<ZADM_M017_P> GetSelectedPackUnit = list.Cast<ZADM_M017_P>().ToList();

                if (GetSelectedPackUnit.Count > 0)
                {
                    MasterEntity.pack_style = GetSelectedPackUnit[0].id;
                    MasterEntity.PackingUnit = GetSelectedPackUnit[0].pkgunit;
                    MasterEntity.unit_code = GetSelectedPackUnit[0].unit_code;
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
        private void InsertUnitcode(IList InputValue)
        {
            try
            {
                IList list = InputValue as IList;
                List<ADM_M038_B_P> GetSelectedUnit = list.Cast<ADM_M038_B_P>().ToList();

                if (GetSelectedUnit.Count > 0)
                {
                    MasterEntity.unit_code = GetSelectedUnit[0].unit_code;

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
        private void InsertDataGridRow_Item(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                EPR_T002_Flip POPUPEntityObject = null;
                dgSelectedIndexLabel = dgSelectedIndexLabel;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.LabelGeneratedList.Where(x => x.batch_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<EPR_T002_Flip>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = LabelGeneratedEntity.Where(X => X.batch_no == POPUPEntityObject.batch_no).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = LabelGeneratedEntity.IndexOf(LabelGeneratedEntity.Where(X => X.batch_no == POPUPEntityObject.batch_no).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && LabelGeneratedEntity.Count == dgSelectedIndexLabel)
                    {
                        LabelGeneratedEntity.Add(new EPR_T003_B()
                        {
                            id = 0,
                            batch_no = POPUPEntityObject.batch_no,
                            qty = Convert.ToDecimal(POPUPEntityObject.label_qty),
                            cust_batch_no = POPUPEntityObject.cust_batch_no,
                            location_Id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            active = true,
                            add_by = AppSessionState.UserID,
                            fin_year = "16-17",
                            posting_period = "5",
                            doc_cat = "CP",
                            doc_type = "FS",
                            editby = AppSessionState.UserID,
                        });
                    }
                    else if (dgSelectedIndexLabel >= 0 && LabelGeneratedEntity.Count > dgSelectedIndexLabel) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (LabelGeneratedEntity[dgSelectedIndexLabel].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            LabelGeneratedEntity[dgSelectedIndexLabel].batch_no = POPUPEntityObject.batch_no;
                            LabelGeneratedEntity[dgSelectedIndexLabel].qty = Convert.ToDecimal(POPUPEntityObject.label_qty);
                            LabelGeneratedEntity[dgSelectedIndexLabel].cust_batch_no = POPUPEntityObject.cust_batch_no;
                            LabelGeneratedEntity[dgSelectedIndexLabel].location_Id = POPUPEntityObject.location_Id;
                            LabelGeneratedEntity[dgSelectedIndexLabel].comp_code = POPUPEntityObject.comp_code;
                            LabelGeneratedEntity[dgSelectedIndexLabel].active = true;
                            LabelGeneratedEntity[dgSelectedIndexLabel].add_by = POPUPEntityObject.add_by;
                            LabelGeneratedEntity[dgSelectedIndexLabel].fin_year = "16-17";
                            LabelGeneratedEntity[dgSelectedIndexLabel].posting_period = "5";
                            LabelGeneratedEntity[dgSelectedIndexLabel].doc_cat = "CP";
                            LabelGeneratedEntity[dgSelectedIndexLabel].doc_type = "FS";
                            LabelGeneratedEntity[dgSelectedIndexLabel].editby = AppSessionState.UserID;
                            //LabelGeneratedEntity[dgSelectedIndexLabel]. = POPUPEntityObject.comp_code;

                        }
                        else if (LabelGeneratedEntity[dgSelectedIndexLabel].batch_no != POPUPEntityObject.batch_no)
                        {
                            LabelGeneratedEntity[dgSelectedIndexLabel].batch_no = "";
                        }
                    }
                }


                #region Clear Empty Row
                EPR_T003_B newObj = new EPR_T003_B();
                for (int i = LabelGeneratedEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = LabelGeneratedEntity[i].ComparePropertiesTo(newObj);
                    if (LabelGeneratedEntity[i].ComparePropertiesTo(newObj) == true && LabelGeneratedEntity.Count > 1)
                    {
                        LabelGeneratedEntity.RemoveAt(i);
                        if (LabelGeneratedEntity.Count == 0)
                        {
                            LabelGeneratedEntity.Add(newObj);
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

        private bool Validation()
        {
            if (MasterEntity.tot_no_bags == null || MasterEntity.tot_no_bags < 1)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("You Must Enter No of Bags Greater Than 0", this.Title);
                showMessageService.ShowMessage();
                return false;
            }

            if (MasterEntity.qty_per_bag == null || MasterEntity.qty_per_bag <= 0)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("You Must Enter Qty per bag greater than 0", this.Title);
                showMessageService.ShowMessage();
                return false;
            }

            if (MasterEntity.tot_qty == null || MasterEntity.tot_qty <= 0)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("You Must Enter Total Qty Greater Than 0", this.Title);
                showMessageService.ShowMessage();
                return false;
            }

            if (MasterEntity.ItemCode == null || MasterEntity.ItemCode == "" || MasterEntity.ink_id == null || MasterEntity.ink_id == 0
                 || MasterEntity.ild_id == 0 || MasterEntity.ild_id == null || MasterEntity.unit_code == null || MasterEntity.unit_code == ""
                 || MasterEntity.pack_style == 0 || MasterEntity.pack_style == null || MasterEntity.grade == null || MasterEntity.tip_type == null)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Fields ItemCode, Ink, Ild, Unit, Packing Unit, Tip Type, Grade are Compulsory ", this.Title);
                showMessageService.ShowMessage();
                return false;
            }

            if (LabelGeneratedEntity.Count != MasterEntity.tot_no_bags && LabelGeneratedEntity.Count > 0)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("You Must Scan Exact No of Bags To No of Bags You Have Entered \n You Must Enter No of Bags Greater Than 0", this.Title);
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
                        LabelGeneratedEntity = MCTemp2.LabelGeneratedEntity;
                        isNewRecord = false;
                        SelectedTabControlIndex = 0;
                        ReadOnly = true;
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
        private void LoadBatchDetailsReport()
        {
            try
            {
                if (MCTemp.MasterEntityList != null && MCTemp.MasterEntityList.Count > 0 && MC.SettingsList.Count > 0)
                {
                    if (PrintOption == "All")
                    {
                        object[] objDataSource = new object[3];
                        string[] objDataSourceName = new string[3];

                        objDataSource[0] = MCTemp.RptSmallCartonList;
                        objDataSourceName[0] = "dsRptSmallCarton";

                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\" + MC.SettingsList[0].report_name2, MC.SettingsList[0].report_name2);
                    }
                    else if (PrintOption == "Selected")
                    {
                        int count = MCTemp.MasterEntityList.Count(x => x.check == true);

                        if (count > 0)
                        {
                            foreach (var o in MCTemp.MasterEntityList)
                            {
                                if (o.check == true)
                                {
                                    foreach (var p in MCTemp.RptSmallCartonList)
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

                            objDataSource[0] = MCTemp.RptSmallCartonList.Where(x => x.check == true);
                            objDataSourceName[0] = "dsRptSmallCarton";

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

        #region Filter Functions
        #region Product2

        private string _filterString_ProductCollection2;
        public string FilterString_ProductCollection2
        {
            get { return _filterString_ProductCollection2; }
            set
            {
                _filterString_ProductCollection2 = value;
                RaisePropertyChanged("FilterString_ProductCollection2");
                FilterCollection_ProductCollection2();
            }
        }
        private void FilterCollection_ProductCollection2()
        {
            if (_ProductCollection2 != null)
            {
                _ProductCollection2.Refresh();
            }
        }
        public bool Filter_ProductCollection2(object obj)
        {
            var data = obj as ADM_M022_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ProductCollection2))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_ProductCollection2.ToLower()) ||
                        data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_ProductCollection2.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion
        #region Ink2
        private string _filterString_Ink2;
        public string FilterString_Ink2
        {
            get { return _filterString_Ink2; }
            set
            {
                _filterString_Ink2 = value;
                RaisePropertyChanged("FilterString_Ink2");
                FilterCollection_Ink2();
            }
        }
        private void FilterCollection_Ink2()
        {
            if (_InkCollection2 != null)
            {
                _InkCollection2.Refresh();
            }
        }
        public bool Filter_Ink2(object obj)
        {
            var data = obj as ZADM_M006_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Ink2))
                {
                    return (data.ink != null && data.ink.ToString().ToLower().Contains(_filterString_Ink2.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion
        #region Ild2
        private string _filterString_Ild2;
        public string FilterString_Ild2
        {
            get { return _filterString_Ild2; }
            set
            {
                _filterString_Ild2 = value;
                RaisePropertyChanged("FilterString_Ild2");
                FilterCollection_Ild2();
            }
        }
        private void FilterCollection_Ild2()
        {
            if (_IldCollection2 != null)
            {
                _IldCollection2.Refresh();
            }
        }
        public bool Filter_Ild2(object obj)
        {
            var data = obj as ZADM_M007_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Ild2))
                {
                    return (data.ild != null && data.ild.ToString().ToLower().Contains(_filterString_Ild2.ToLower()) ||
                        data.tip_type != null && data.tip_type.ToString().ToLower().Contains(_filterString_Ild2.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion
        #region Wiremake
        private string _filterString_Wiremake;
        public string FilterString_Wiremake
        {
            get { return _filterString_Wiremake; }
            set
            {
                _filterString_Wiremake = value;
                RaisePropertyChanged("FilterString_Wiremake");
                FilterCollection_Wiremake();
            }
        }
        private void FilterCollection_Wiremake()
        {
            if (_WiremakeCollection != null)
            {
                _WiremakeCollection.Refresh();
            }
        }
        public bool Filter_Wiremake(object obj)
        {
            var data = obj as ADM_M032_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Wiremake))
                {
                    return (data.Make != null && data.Make.ToString().ToLower().Contains(_filterString_Wiremake.ToLower())
                        );
                }
                return true;
            }
            return false;
        }
        #endregion
        #region Ballmake
        private string _filterString_Ballmake;
        public string FilterString_Ballmake
        {
            get { return _filterString_Ballmake; }
            set
            {
                _filterString_Ballmake = value;
                RaisePropertyChanged("FilterString_Ballmake");
                FilterCollection_Ballmake();
            }
        }
        private void FilterCollection_Ballmake()
        {
            if (_BallmakeCollection != null)
            {
                _BallmakeCollection.Refresh();
            }
        }
        public bool Filter_Ballmake(object obj)
        {
            var data = obj as ADM_M032_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Ballmake))
                {
                    return (data.Make != null && data.Make.ToString().ToLower().Contains(_filterString_Ballmake.ToLower())
                        );
                }
                return true;
            }
            return false;
        }
        #endregion
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
                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterString_Unit.ToLower())
                        );
                }
                return true;
            }
            return false;
        }
        #endregion
        #region Packing Unit
        private string _filterString_PackingUnit;
        public string FilterString_PackingUnit
        {
            get { return _filterString_PackingUnit; }
            set
            {
                _filterString_PackingUnit = value;
                RaisePropertyChanged("FilterString_PackingUnit");
                FilterCollection_PackingUnit();
            }
        }
        private void FilterCollection_PackingUnit()
        {
            if (_PackingUnitCollection != null)
            {
                _PackingUnitCollection.Refresh();
            }
        }
        public bool Filter_PackingUnit(object obj)
        {
            var data = obj as ZADM_M017_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_PackingUnit))
                {
                    return (data.pkgunit != null && data.pkgunit.ToString().ToLower().Contains(_filterString_PackingUnit.ToLower()) ||
                        data.pkgqty != null && data.pkgqty.ToString().ToLower().Contains(_filterString_PackingUnit.ToLower()) ||
                        data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterString_PackingUnit.ToLower())
                        );
                }
                return true;
            }
            return false;
        }
        #endregion

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
                        data.show_ild != null && data.show_ild.ToString().ToLower().Contains(_filterString_Ild.ToLower()) ||
                        data.tip_type != null && data.tip_type.ToString().ToLower().Contains(_filterString_Ild.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region BackFlip

        private string _filterString_FlipDataGridCollection;
        public string filterString_FlipDataGridCollection
        {
            get { return _filterString_FlipDataGridCollection; }
            set
            {
                _filterString_FlipDataGridCollection = value;
                RaisePropertyChanged("filterString_FlipDataGridCollection");
                FilterCollection_FlipDataGridCollection();
            }
        }
        private void FilterCollection_FlipDataGridCollection()
        {
            if (_FlipDataGridCollection != null)
            {
                _FlipDataGridCollection.Refresh();
            }
        }
        public bool Filter_FlipDataGridCollection(object obj)
        {
            var data = obj as EPR_T003_A;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_FlipDataGridCollection))
                {
                    return (data.batch_no != null && data.batch_no.ToString().ToLower().Contains(_filterString_FlipDataGridCollection.ToLower())) ||
                           (data.carton_no != null && data.carton_no.ToString().ToLower().Contains(_filterString_FlipDataGridCollection.ToLower())) ||
                           (data.carton_pack_dt != null && data.carton_pack_dt.ToString().ToLower().Contains(_filterString_FlipDataGridCollection.ToLower())) ||
                           (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_FlipDataGridCollection.ToLower())) ||
                           (data.grade != null && data.grade.ToString().ToLower().Contains(_filterString_FlipDataGridCollection.ToLower())) ||
                           (data.Ink != null && data.Ink.ToString().ToLower().Contains(_filterString_FlipDataGridCollection.ToLower())) ||
                           (data.Ild != null && data.Ild.ToString().ToLower().Contains(_filterString_FlipDataGridCollection.ToLower())) ||
                           (data.tip_type != null && data.tip_type.ToString().ToLower().Contains(_filterString_FlipDataGridCollection.ToLower())) ||
                           (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterString_FlipDataGridCollection.ToLower())) ||
                           (data.PackingUnit != null && data.PackingUnit.ToString().ToLower().Contains(_filterString_FlipDataGridCollection.ToLower())) ||
                           (data.tot_no_bags != null && data.tot_no_bags.ToString().ToLower().Contains(_filterString_FlipDataGridCollection.ToLower())) ||
                           (data.qty_per_bag != null && data.qty_per_bag.ToString().ToLower().Contains(_filterString_FlipDataGridCollection.ToLower())) ||
                           (data.WireMake != null && data.WireMake.ToString().ToLower().Contains(_filterString_FlipDataGridCollection.ToLower())) ||
                           (data.BallMake != null && data.BallMake.ToString().ToLower().Contains(_filterString_FlipDataGridCollection.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Batch list

        private string _filterString_Batch;
        public string filterString_Batch
        {
            get { return _filterString_Batch; }
            set
            {
                _filterString_Batch = value;
                RaisePropertyChanged("filterString_Batch");
                FilterCollection_BatchCollection();
            }
        }
        private void FilterCollection_BatchCollection()
        {
            if (_BatchCollection != null)
            {
                _BatchCollection.Refresh();
            }
        }
        public bool Filter_BatchList(object obj)
        {
            var data = obj as EPR_T002_Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Batch))
                {
                    return (data.batch_no != null && data.batch_no.ToString().ToLower().Contains(_filterString_Batch.ToLower())) ||
                           (data.bal_qty_merge != null && data.bal_qty_merge.ToString().ToLower().Contains(_filterString_Batch.ToLower())) ||
                           (data.prod_dt != null && data.prod_dt.ToString().ToLower().Contains(_filterString_Batch.ToLower()));

                }
                return true;
            }
            return false;
        }


        #endregion
        #endregion
    }
}
