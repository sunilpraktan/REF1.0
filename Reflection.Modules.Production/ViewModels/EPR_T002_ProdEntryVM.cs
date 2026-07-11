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
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.BusinessEntity;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.Production.ViewModels
{
    public class EPR_T002_ProdEntryVM : WorkspaceViewModel<EPR_T002>
    {
        #region Variable Declaration
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        bool isNewRecord = true;
        bool Flag = false;

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

        WebServiceRepository<List<EPR_T002_Flip>> repository = new WebServiceRepository<List<EPR_T002_Flip>>();
        WebServiceRepository<MultipleContext_EPR_T002> repositoryM = new WebServiceRepository<MultipleContext_EPR_T002>();

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

        private ObservableCollection<EPR_T002_Flip> _MasterEntity;
        //Data source for Items DataGrid
        public ObservableCollection<EPR_T002_Flip> MasterEntity
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

        private List<EPR_T002_Flip> _TobeSaveEntity = new List<EPR_T002_Flip>();
        //Data source for Items DataGrid
        public List<EPR_T002_Flip> TobeSaveEntity
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
        
        #region ICollection For Popup
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
        #endregion
        #region RelayCommand Actions
        public RelayCommand<object> cmdBarcodeScan { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowBatch { get; private set; }

        // BackFlip
        public RelayCommand<IList> CommandMachine { get; private set; }
        public RelayCommand<IList> CommandBPkgUnit { get; private set; }
        public RelayCommand<IList> CommandItem { get; private set; }
        public RelayCommand<IList> CommandInk { get; private set; }
        public RelayCommand<IList> CommandIld { get; private set; }
        public RelayCommand CommandLoadLabelGenration { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        #endregion
        #region Constructor
        public EPR_T002_ProdEntryVM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new ObservableCollection<EPR_T002_Flip>();
            MC = new MultipleContext_EPR_T002();
            MCTemp = new MultipleContext_EPR_T002();
            SelectedEPR_T002 = new EPR_T002();
            LabelStatus = "Unused";

            SelectedEPR_T002.client = AppSessionState.client;
            
            LoadInitialData();
        }
        public EPR_T002_ProdEntryVM(string ts_code,string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new ObservableCollection<EPR_T002_Flip>();
            MC = new MultipleContext_EPR_T002();
            MCTemp = new MultipleContext_EPR_T002();
            SelectedEPR_T002 = new EPR_T002();
            LabelStatus = "Unused";
            SelectedEPR_T002.client = AppSessionState.client;
            SelectedEPR_T002.user_source1 = AppSessionState.UserSource1;
            SelectedEPR_T002.user_source2 = AppSessionState.UserSource2;
            SelectedEPR_T002.userid = AppSessionState.UserID;
            LoadInitialData();
        }
        #endregion

        #region UserDefinedFunctions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialDataForPE" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id;
                MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T002>(MC, Request, "LabelGenerationMaster", "Production", "LoadAll", 0, "");
                // MC = repositoryM.GetData<MultipleContext_EPR_T002>(MC, Request, "", "Reflection.BusinessLogic.EPR_T002BL");

                #region Command Initialization
                cmdBarcodeScan = new RelayCommand<object>(items => { if (items == null) { return; } InsertAllDataFromScannedBarcode(items); });
                cmdDeleteDataGridRowBatch = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Batch(cmdPara); });
                CommandMachine = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertMachine(cmdPara); });
                CommandBPkgUnit = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertBPkgUnit(cmdPara); });
                CommandItem = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertItem(cmdPara); });
                CommandInk = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertInk(cmdPara); });
                CommandIld = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertIld(cmdPara); });
                CommandLoadLabelGenration = new RelayCommand(() => { LoadLabelGenerationDetails(); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                #endregion
                BShiftCollection = CollectionViewSource.GetDefaultView(MC.ShiftList);

                MachineCollection = CollectionViewSource.GetDefaultView(MC.MachineList);
                MachineCollection.Filter = new Predicate<object>(Filter_Machine);

                BPkgUnitCollection = CollectionViewSource.GetDefaultView(MC.BPkgUnitList);
                BPkgUnitCollection.Filter = new Predicate<object>(Filter_BPkgUnit);

                ItemCollection = CollectionViewSource.GetDefaultView(MC.ItemList);
                ItemCollection.Filter = new Predicate<object>(Filter_ItemCode);

                InkCollection = CollectionViewSource.GetDefaultView(MC.InkList);
                InkCollection.Filter = new Predicate<object>(Filter_Ink);

                IldCollection = CollectionViewSource.GetDefaultView(MC.IldList);
                IldCollection.Filter = new Predicate<object>(Filter_Ild);

                if (MC.SettingsList.Count > 0)
                {
                    //MasterEntity.tot_no_bags = MC.SettingsList[0].no_of_bags;
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
        private void InsertAllDataFromScannedBarcode(object InputValue)
        {
            try
            {
                EPR_T002_Flip POPUPEntityObject = null;
                barcode = InputValue.ToString();

                if (barcode.Length > Scan_Length && MC.LabelGenBackFlipList != null)
                {
                    if (Scan_Source == "Barcode")
                    { barcode = barcode; }
                    else if (Scan_Source == "Batch" && MC.LabelGenBackFlipList.Where(X => X.batch_no == barcode).FirstOrDefault() != null)
                    {
                        barcode = MC.LabelGenBackFlipList.Where(X => X.batch_no == barcode).FirstOrDefault().barcode;
                    }
                    var InputValueIfExists = MC.LabelGenBackFlipList.Where(X => X.barcode == barcode).FirstOrDefault();  //Checking Weather Barcode is Valid or Not By Checking in Business Entity
                    if (InputValueIfExists != null)
                    {
                        POPUPEntityObject = MC.LabelGenBackFlipList.Where(x => x.barcode.Equals(barcode, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; //If Barcode is Valid Get All the Information in PopupEntityObject

                        if (POPUPEntityObject != null)
                        {
                            if (POPUPEntityObject.prod_entry_stat != true)
                            {
                                if (MasterEntity.Count >= 0)
                                {
                                    int IndexOfExistBatch = MasterEntity.IndexOf(MasterEntity.Where(X => X.batch_no == POPUPEntityObject.batch_no && X.active == true).FirstOrDefault());

                                    if (IndexOfExistBatch == -1)
                                    {
                                        if (Date == null)
                                        {
                                            Date = POPUPEntityObject.prod_dt;
                                            MasterEntity.Add(POPUPEntityObject);
                                            barcode = "";
                                        }
                                        else if (POPUPEntityObject.prod_dt == Date)
                                        {
                                            MasterEntity.Add(POPUPEntityObject);
                                            barcode = "";
                                        }
                                        else if (POPUPEntityObject.prod_dt != Date)
                                        {
                                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                            showMessageService.ButtonSetup = DialogButton.Ok;
                                            showMessageService.Caption = "Message";
                                            showMessageService.Text = String.Format("Scanned barcode/batch Does not produced On Selected Production date", this.Title);
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
                                        showMessageService.Text = String.Format("Batch/Barcode Scanned already Exist On Form", this.Title);
                                        showMessageService.ShowMessage();

                                        if (showMessageService.ShowMessage() == DialogResult.Ok || showMessageService.ShowMessage() == DialogResult.Cancel)
                                        {
                                            barcode = "";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Production Entry is Already Done", this.Title);
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
            catch(Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
                barcode = "";
            }
        }
        private void DeleteDataGridRow_Batch(object InputValue)
        {
            int i = (int)InputValue;
            if (MasterEntity.Count > i)
            {
                MasterEntity.RemoveAt(i);
            }
        }
        private void RemoveRefDoc()
        {
            try
            {
                string BatchList = "";
                foreach (var item in MasterEntity)
                {
                    BatchList = BatchList + "," + item.batch_no;
                }
                BatchList = BatchList.ToString().TrimStart(new char[] { ',' });
                MC.LabelGenBackFlipList.RemoveAll(X => BatchList.Contains(X.batch_no));
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
                bool Label_used = false;
                bool ProdEntryFlag = true; // Always true for getting data of production entry done records
                if (SelectedEPR_T002.machine_id == null || SelectedEPR_T002.machinecode == "All")
                {
                    SelectedEPR_T002.machine_id = 0;
                }
                if (SelectedEPR_T002.pack_style == null || SelectedEPR_T002.PackingUnit == "All")
                {
                    SelectedEPR_T002.pack_style = 0;
                }
                if (SelectedEPR_T002.ItemCode == null || SelectedEPR_T002.ItemCode == "")
                {
                    SelectedEPR_T002.ItemCode = "All";
                }
                if (SelectedEPR_T002.conversion == null)
                {
                    SelectedEPR_T002.conversion = "All";
                }
                if (SelectedEPR_T002.shift == null)
                {
                    SelectedEPR_T002.shift = "All";
                }
                if (SelectedEPR_T002.ink_id == null || SelectedEPR_T002.Ink == "All")
                {
                    SelectedEPR_T002.ink_id = 0;
                }
                if (SelectedEPR_T002.ild_id == null || SelectedEPR_T002.Ild == "All")
                {
                    SelectedEPR_T002.ild_id = 0;
                }
                if (SelectedEPR_T002.grade == null)
                {
                    SelectedEPR_T002.grade = "All";
                }

                if (LabelStatus == "Used")
                {
                    Label_used = true;
                }


                string Request = "LoadLGDetails" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + SelectedEPR_T002.machine_id + "!@" + SelectedEPR_T002.pack_style + "!@" + SelectedEPR_T002.ItemCode
                        + "!@" + SelectedEPR_T002.conversion + "!@" + SelectedEPR_T002.shift + "!@" + SelectedEPR_T002.ink_id + "!@" + SelectedEPR_T002.ild_id + "!@" + SelectedEPR_T002.prod_dt + "!@" + SelectedEPR_T002.grade + "!@" + Label_used + "!@" + "LG" + "!@" + ProdEntryFlag;

                MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T002>(MCTemp, Request, "LabelGenerationMaster", "Production", "LoadAll", 0, "");

                if (MCTemp.LabelGenBackFlipList.Count >= 0)
                {
                    BackFlipCollection = CollectionViewSource.GetDefaultView(MCTemp.LabelGenBackFlipList);
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
            try
            {

                IList list = InputValue as IList;
                List<ZADM_M013_P> GetSelectedMachine = list.Cast<ZADM_M013_P>().ToList();

                if (GetSelectedMachine.Count > 0)
                {
                    SelectedEPR_T002.machine_id = GetSelectedMachine[0].machine_id;
                    SelectedEPR_T002.machinecode = GetSelectedMachine[0].machinecode;
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
        private void InsertBPkgUnit(IList InputValue)
        {
            try
            {

                IList list = InputValue as IList;
                List<ZADM_M017_P> GetSelectedPkgUnit = list.Cast<ZADM_M017_P>().ToList();

                if (GetSelectedPkgUnit.Count > 0)
                {
                    SelectedEPR_T002.pack_style = GetSelectedPkgUnit[0].id;
                    SelectedEPR_T002.PackingUnit = GetSelectedPkgUnit[0].pkgunit;
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
                    SelectedEPR_T002.ItemCode = GetSelectedItem[0].ItemCode;
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
                    SelectedEPR_T002.ink_id = GetSelectedInk[0].ink_id;
                    SelectedEPR_T002.Ink = GetSelectedInk[0].ink;
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
                    SelectedEPR_T002.ild_id = GetSelectedIld[0].ild_id;
                    SelectedEPR_T002.Ild = GetSelectedIld[0].ild;
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
        #endregion

        #region · Command Actions ·
        protected override void OnSaveAction(InquiryActionResult<EPR_T002> result)
        {
            try
            {
                TobeSaveEntity = new List<EPR_T002_Flip>();

                if (MasterEntity.Count > 0)
                {
                    foreach (var o in MasterEntity)  //First Selected Rows Will be Added To New Collection
                    {                 
                            TobeSaveEntity.Add(o);                     
                    }

                    string reader = repository.Update<List<EPR_T002_Flip>>(TobeSaveEntity, "LabelGenerationMaster", "Production");

                    int intreader = Convert.ToInt32(reader);

                    if (intreader > 0) // intreader is always greater than 0 if data is saved
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Saved Successfully", this.Title);
                        showMessageService.ShowMessage();

                        foreach (var item in MasterEntity)
                        {
                            if (item.doc_no != null && item.doc_no != "")
                            {
                                foreach (var p in MC.LabelGenBackFlipList)
                                {
                                    if (item.batch_no == p.batch_no)
                                    {
                                        p.prod_entry_stat = true;
                                    }
                                }
                            }
                        }
                        RemoveRefDoc();
                        MasterEntity.Clear();
                        var msg = new NotificationMessage("EPR_T002_ProdEntryVM");
                        Messenger.Default.Send<NotificationMessage>(msg);

                    }
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Scan At Least One Label", this.Title);
                    showMessageService.ShowMessage();
                }


                //string AllBatches = "";
                //if (isNewRecord == true)
                //{
                //    foreach (var item in MasterEntity)
                //    {
                //        if (AllBatches == "")
                //        {
                //            AllBatches = item.batch_no;
                //        }
                //        else
                //        {
                //            AllBatches += "," + item.batch_no;
                //        }
                //    }

                //    string reader = repository.Update<string>(AllBatches, "LabelGenerationMaster", "Production");
                //    int intreader = Convert.ToInt32(reader);

                //    if (intreader > 0)
                //    {
                //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //        showMessageService.ButtonSetup = DialogButton.Ok;
                //        showMessageService.Caption = "Message";
                //        showMessageService.Text = String.Format("Production Entry is Saved Successfully", this.Title);
                //        showMessageService.ShowMessage();

                //        foreach (var item in MasterEntity)
                //        {
                //            if (item.doc_no != null && item.doc_no != "")
                //            {
                //                foreach (var p in MC.LabelGenBackFlipList)
                //                {
                //                    if (item.batch_no == p.batch_no)
                //                    {
                //                        p.prod_entry_stat = true;
                //                    }
                //                }
                //            }
                //        }

                //        MasterEntity.Clear();
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
        protected override void OnCreateAction(InquiryActionResult<EPR_T002> result)
        {
            MasterEntity = new ObservableCollection<EPR_T002_Flip>();
            Date = null;
            var msg = new NotificationMessage("EPR_T002_ProdEntryVM");
            Messenger.Default.Send<NotificationMessage>(msg);
            SelectedEPR_T002.ts_code = ts_code_vm;
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
            LoadInitialData();
        }
        protected override void OnHelpAction(InquiryActionResult<EPR_T002> result)
        {
        }
        protected override void OnPrintAction(InquiryActionResult<EPR_T002> result)
        {           
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
            var data = obj as EPR_T002_Flip;
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
                        (data.blank_wt != null && data.blank_wt.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.entry_dt != null && data.entry_dt.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.prod_dt != null && data.prod_dt.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
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

        #endregion
    }
}
