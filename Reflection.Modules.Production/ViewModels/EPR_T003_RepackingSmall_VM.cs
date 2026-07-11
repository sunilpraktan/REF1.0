using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Reflection.ReportingServices;
using Reflection.Presentation.Services;
using System.Windows.Data;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.Production.ViewModels
{
    class EPR_T003_RepackingSmall_VM : WorkspaceViewModel<EPR_T003_A>, INotifyPropertyChanged
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
        public RelayCommand<object> cmdCustProductName { get; private set; }
        public RelayCommand<object> cmdBarcodeScan { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowBatch { get; private set; }

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
        public RelayCommand cmdReport3 { get; private set; }

        #endregion

        #region Constructor
        public EPR_T003_RepackingSmall_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MC = new MultipleContext_EPR_T003();
            MCTemp = new MultipleContext_EPR_T003();
            MCTemp2 = new MultipleContext_EPR_T003();
            MCTemp3 = new MultipleContext_EPR_T003();

            MasterEntity = new EPR_T003_A();
            LabelGeneratedEntity = new ObservableCollection<EPR_T003_B>();
            BackFlipEntity = new EPR_T003_A_Flip();
            PrintOption = "All";
            LabelStatus = "Unused";
            EPR_T003_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Calculation);
            BackFlipEntity.FromDate = DateTime.Now;
            BackFlipEntity.ToDate = DateTime.Now;

            // EPR_T003_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Batch);
            //  LabelGeneratedEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForBatch);



            LoadInitialData();
        }
        public EPR_T003_RepackingSmall_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MC = new MultipleContext_EPR_T003();
            MCTemp = new MultipleContext_EPR_T003();
            MCTemp2 = new MultipleContext_EPR_T003();
            MCTemp3 = new MultipleContext_EPR_T003();

            MasterEntity = new EPR_T003_A();
            LabelGeneratedEntity = new ObservableCollection<EPR_T003_B>();
            BackFlipEntity = new EPR_T003_A_Flip();
            PrintOption = "All";
            LabelStatus = "Unused";
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
                    MasterEntity.AllMachine = "";
                    MasterEntity.AllShift = "";

                    foreach (var o in LabelGeneratedEntity)
                    {
                        if (MasterEntity.AllMachine == "")
                        {
                            MasterEntity.AllMachine = o.MachinePacCode.ToString();
                        }
                        else if (MasterEntity.AllMachine != o.MachinePacCode)
                        {
                            MasterEntity.AllMachine += "," + o.MachinePacCode.ToString();
                        }

                        if (MasterEntity.AllShift == "" || (MasterEntity.AllShift != o.Shift && MasterEntity.AllShift != "I&II" && o.Shift == "I&II"))
                        {
                            MasterEntity.AllShift = o.Shift;
                        }
                        else if (MasterEntity.AllShift != o.Shift && MasterEntity.AllShift != "I&II")
                        {
                            MasterEntity.AllShift += "," + o.Shift;
                        }
                    }
                    MasterEntity.XmlDataDocument_EPR_T003_B = obj.ObjectToXML(LabelGeneratedEntity);

                    if (isNewRecord == true)
                    {
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

                        // Now Updating Label Used Flag = true Locally in Collection
                        foreach (var item in LabelGeneratedEntity)
                        {
                            if (item.batch_no != null && item.batch_no != "")
                            {
                                foreach (var p in MC.LabelGeneratedList)
                                {
                                    if (item.batch_no == p.batch_no)
                                    {
                                        p.carton_cons_stat = true;
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

                }
                else if (Validation() == true && isNewRecord == false)
                {
                    MasterEntity.XmlDataDocument_EPR_T003_B = obj.ObjectToXML(LabelGeneratedEntity);

                    MasterEntity = repository.UpdateWithReturnDomainObject<EPR_T003_A>(MasterEntity, "SmallCarton", "Production");

                    if (MasterEntity.XmlDataDocument_EPR_T003_B != null)
                    {
                        MC.LabelGeneratedEntity = (ObservableCollection<EPR_T003_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_EPR_T003_B, MC.LabelGeneratedEntity);
                        LabelGeneratedEntity.Clear();
                        LabelGeneratedEntity = MC.LabelGeneratedEntity;

                    }
                    else
                    {
                        MC.LabelGeneratedEntity = new ObservableCollection<EPR_T003_B>();
                        LabelGeneratedEntity.Clear();
                    }

                    foreach (var item in LabelGeneratedEntity)
                    {
                        if (item.batch_no != null && item.batch_no != "")
                        {
                            foreach (var p in MC.LabelGeneratedList)
                            {
                                if (item.batch_no == p.batch_no)
                                {
                                    p.carton_cons_stat = true;
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
            decimal? NoofBags = MasterEntity.tot_no_bags;
            isNewRecord = true;
            MasterEntity = new EPR_T003_A();
            BackFlipEntity = new EPR_T003_A_Flip();
            LabelGeneratedEntity = new ObservableCollection<EPR_T003_B>();
            DefaultValues();
            MasterEntity.tot_no_bags = NoofBags;
            var msg = new NotificationMessage("EPR_T003_RepackingSmall_VM");
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
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + "SC" + "!@" + MasterEntity.doc_cat + "!@" + "All";
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T003>(MC, Request, "SmallCarton", "Production", "LoadAll", 0, "");
                // MC = repositoryM.GetData<MultipleContext_EPR_T003>(MC, Request, "", "Reflection.BusinessLogic.EPR_T003BL");

                #region Command Initialization
                cmdCustProductName = new RelayCommand<object>(items => { if (items == null) { return; } InsertCustProductName(items); });
                cmdBarcodeScan = new RelayCommand<object>(items => { if (items == null) { return; } InsertAllDataFromScannedBarcode(items); });

                cmdDeleteDataGridRowBatch = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Batch(cmdPara); });

                cmdLoadSmallCartons = new RelayCommand(() => { LoadSmallCartons(); });
                cmdBatchDetailsReport = new RelayCommand(() => { LoadBatchDetailsReport(); });
                cmdProduct = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertItem(cmdPara); });
                cmdInk = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertInk(cmdPara); });
                cmdIld = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertIld(cmdPara); });
                CommandMachine = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertMachine(cmdPara); });
                CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdReport3 = new RelayCommand(() => { LoadReport3(); });
                #endregion

                CustProductName = CollectionViewSource.GetDefaultView(MC.CustProdNameList);
                CustProductName.Filter = new Predicate<object>(Filter_CustProductName);
                StringListCustProduct = MC.CustProdNameList.Select(x => x.CustomerProductName).ToList();

                ProductCollection = CollectionViewSource.GetDefaultView(MC.ItemList);
                ProductCollection.Filter = new Predicate<object>(Filter_ProductCollection);

                InkCollection = CollectionViewSource.GetDefaultView(MC.InkList);
                InkCollection.Filter = new Predicate<object>(Filter_Ink);

                IldCollection = CollectionViewSource.GetDefaultView(MC.IidList);
                IldCollection.Filter = new Predicate<object>(Filter_Ild);

                MachineCollection = CollectionViewSource.GetDefaultView(MC.MachineList);
                MachineCollection.Filter = new Predicate<object>(Filter_Machine);

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
            MasterEntity.carton_type = "Small";
            MasterEntity.doc_type = "SC";
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
            MasterEntity.posting_period = "1";
            MasterEntity.tot_no_bags = 0;
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
                BackFlipEntity.doc_type = "SC";

                if (LabelStatus == "Used")
                {
                    Label_used = true;
                }

                string Request = "LoadSmallCartons" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + BackFlipEntity.ItemCode
                                + "!@" + BackFlipEntity.ink_id + "!@" + BackFlipEntity.ild_id + "!@" + BackFlipEntity.grade + "!@" + BackFlipEntity.doc_type
                                + "!@" + Label_used + "!@" + Convert.ToDateTime(BackFlipEntity.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(BackFlipEntity.ToDate).ToString("MM/dd/yyyy") + "!@" + machine_id + "!@" + "REPACKING";

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
        private void LoadReport3()
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
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\" + MC.SettingsList[0].report_name3, MC.SettingsList[0].report_name3);
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
                            ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\" + MC.SettingsList[0].report_name3, MC.SettingsList[0].report_name3);
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
        private void InsertMachine(IList InputValue)
        {
            try
            {

                IList list = InputValue as IList;
                List<ZADM_M013_P> GetSelectedMachine = list.Cast<ZADM_M013_P>().ToList();

                if (GetSelectedMachine.Count > 0)
                {
                    machine_id = GetSelectedMachine[0].machine_id;
                    machinecode = GetSelectedMachine[0].machinecode;
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
            if (LabelGeneratedEntity.Count != MasterEntity.tot_no_bags && LabelGeneratedEntity.Count > 0)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("You Must Scan Exact No of Bags To No of Bags You Have Entered \n You Must Enter No of Bags Greater Than 0", this.Title);
                showMessageService.ShowMessage();
                return false;
            }
            if (LabelGeneratedEntity.Count <= 0)
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
                        LabelGeneratedEntity = MCTemp2.LabelGeneratedEntity;
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
        private void LoadBatchDetailsReport()
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
                        Request = "SmallCartonBatchDetailsReport" + "!@" + Request;
                        MCTemp3 = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T003>(MCTemp3, Request, "SmallCarton", "Production", "LoadAll", 0, BackFlipEntity.doc_type);

                        object[] objDataSource = new object[3];
                        string[] objDataSourceName = new string[3];

                        objDataSource[0] = MCTemp3.RptSmallCartonList;

                        List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                        var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                        objDataSource[1] = CmpResult;

                        List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                        var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                        objDataSource[2] = Result;

                        objDataSourceName[0] = "dsRptSmallCarton";
                        objDataSourceName[1] = "dsCompany";
                        objDataSourceName[2] = "dsLocation";

                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\" + MC.SettingsList[0].report_name2, MC.SettingsList[0].report_name2);

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

                        Request = "SmallCartonBatchDetailsReport" + "!@" + Request;
                        MCTemp3 = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T003>(MCTemp3, Request, "SmallCarton", "Production", "LoadAll", 0, BackFlipEntity.doc_type);

                        object[] objDataSource = new object[3];
                        string[] objDataSourceName = new string[3];

                        objDataSource[0] = MCTemp3.RptSmallCartonList;

                        List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                        var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                        objDataSource[1] = CmpResult;

                        List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                        var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                        objDataSource[2] = Result;

                        objDataSourceName[0] = "dsRptSmallCarton";
                        objDataSourceName[1] = "dsCompany";
                        objDataSourceName[2] = "dsLocation";

                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\" + MC.SettingsList[0].report_name2, MC.SettingsList[0].report_name2);
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
        #region CustProductName
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
                        data.tip_type != null && data.tip_type.ToString().ToLower().Contains(_filterString_Ild.ToLower()));
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
                    return data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterString_Machine.ToLower());
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
        #endregion
    }
}
