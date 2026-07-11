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


namespace Reflection.Modules.Production.ViewModels
{
    public class PPC_T002VM : WorkspaceViewModel<PPC_T002_A>
    {
        bool blNew = true;
        WebServiceRepository<PPC_T002_A> repository = new WebServiceRepository<PPC_T002_A>();
        WebServiceRepository<MultipleContext_PPC_T002> repositoryM = new WebServiceRepository<MultipleContext_PPC_T002>();
        MultipleContext_PPC_T002 MCTemp = new MultipleContext_PPC_T002();

        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }

        private ICollectionView _dataGridCollection;
        private int _dgSelectedIndex;
        private string _filterString;        
        private string _filterStringMachine;
        private string _filterStringJobCart;


        #region ICollection
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }

        private ICollectionView _CollectionMachine;
        public ICollectionView CollectionMachine
        {
            get { return _CollectionMachine; }
            set { _CollectionMachine = value; RaisePropertyChanged("CollectionMachine"); }
        }       

        private ICollectionView _CollectionJobCart;
        public ICollectionView CollectionJobCart
        {
            get { return _CollectionJobCart; }
            set { _CollectionJobCart = value; RaisePropertyChanged("CollectionJobCart"); }
        }
       
        #endregion

        #region RelayCommand
        public RelayCommand<IList> SelectionChangedCommand
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandDetails
        {
            get;
            private set;
        }    
        public RelayCommand<IList> SelectionChangedCommandMachine
        {
            get;
            private set;
        }       
        public RelayCommand<IList> SelectionChangedCommandJobCart
        {
            get;
            private set;
        }

        public RelayCommand<IList> CellChangedCommand
        {
            get;
            private set;
        }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        #endregion

        #region PPC_T002_A
        private List<PPC_T002_A> _SelectedList;
        public List<PPC_T002_A> SelectedList
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
        private PPC_T002_A _SelectedPPC_T002_A;
        public PPC_T002_A SelectedPPC_T002_A
        {
            get
            {
                //this.ErrorExist = _SelectedPPC_T002_A.HasErrors;
                return _SelectedPPC_T002_A;
            }
            set
            {
                if (_SelectedPPC_T002_A != value)
                {
                    _SelectedPPC_T002_A = value;
                    //this.ErrorExist = _SelectedPPC_T002_A.HasErrors;
                    RaisePropertyChanged("SelectedPPC_T002_A");
                    value.BeginEdit();
                }
            }
        }
        #endregion

        #region PPC_T002_A
        private static ObservableCollection<PPC_T002_A> _GoodsDetails = new ObservableCollection<PPC_T002_A>();
        public ObservableCollection<PPC_T002_A> GoodsDetails
        {
            get { return _GoodsDetails; }
            set
            {
                if (_GoodsDetails != value)
                {
                    _GoodsDetails = value;

                    RaisePropertyChanged("GoodsDetails");
                }
            }
        }


        #endregion     

        #region ZADM_M013 poup Machine
        private List<ZADM_M013_PopUp> _SelectedMCList;
        public List<ZADM_M013_PopUp> SelectedMCList
        {
            get { return _SelectedMCList; }
            set
            {
                if (_SelectedMCList != value)
                {
                    _SelectedMCList = value;
                    RaisePropertyChanged("SelectedMCList");
                }
            }
        }
        #endregion

        #region PPC_T001_PopUp  JobCart
        private List<PPC_T001_PopUp> _SelectedJobCartList;
        public List<PPC_T001_PopUp> SelectedJobCartList
        {
            get { return _SelectedJobCartList; }
            set
            {
                if (_SelectedJobCartList != value)
                {
                    _SelectedJobCartList = value;
                    RaisePropertyChanged("SelectedJobCartList");
                }
            }
        }
        #endregion

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

        MultipleContext_PPC_T002 _MC = new MultipleContext_PPC_T002();
        public MultipleContext_PPC_T002 MC
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

        #region 
        public PPC_T002VM(string ts_code)
            : base()
        {
            this.ts_code_vm = ts_code;
            SelectedList = new List<PPC_T002_A>();
            SelectedPPC_T002_A = new PPC_T002_A();           
            SelectedMCList = new List<ZADM_M013_PopUp>();
            SelectedJobCartList = new List<PPC_T001_PopUp>();
            GoodsDetails = new ObservableCollection<PPC_T002_A>();

            MC = new MultipleContext_PPC_T002();
           
            SelectedPPC_T002_A.ValidateAsync().Wait();


            SelectedPPC_T002_A.client = AppSessionState.client;
            SelectedPPC_T002_A.entrydt = DateTime.Now.Date;    
          LoadInitialData();
        }
        public PPC_T002VM(string ts_code,string doc_no)
            : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            SelectedList = new List<PPC_T002_A>();
            SelectedPPC_T002_A = new PPC_T002_A();
            SelectedMCList = new List<ZADM_M013_PopUp>();
            SelectedJobCartList = new List<PPC_T001_PopUp>();
            GoodsDetails = new ObservableCollection<PPC_T002_A>();
            MC = new MultipleContext_PPC_T002();
            SelectedPPC_T002_A.ValidateAsync().Wait();
            SelectedPPC_T002_A.entrydt = DateTime.Now.Date;
            SelectedPPC_T002_A.client = AppSessionState.client;
            LoadInitialData();
        }
        #endregion

        private void GetSelectedList(IList DataList)
        {
            IList list = DataList as IList;
            List<PPC_T002_A> tSelectedItemsList = list.Cast<PPC_T002_A>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                SelectedPPC_T002_A = (PPC_T002_A)tSelectedItemsList[0];               
                GoodsDetails = new ObservableCollection<PPC_T002_A>();                            
                GoodsDetails = new ObservableCollection<PPC_T002_A>(tSelectedItemsList);                
                blNew = false;
                SelectedPPC_T002_A.ts_code = ts_code_vm;
            }
        }
        private void GetSelectedGoodDetails(IList IssueList)
        {
            try
            {
                IList list = IssueList as IList;
                List<PPC_T002_A> SelectedItemsList2 = list.Cast<PPC_T002_A>().ToList();
                if (SelectedItemsList2.Count > 0)
                {
                    SelectedPPC_T002_A = (PPC_T002_A)SelectedItemsList2[0];
                    string supplierid = "";
                    supplierid = SelectedPPC_T002_A.entrydt.ToString() + "@" + AppSessionState.comp_code.ToString() + "@" + AppSessionState.location_Id;
                    MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_PPC_T002>(MCTemp, "PPC_T002_A_Data", "ProductionEntryMultiple", "Production", "LoadAll_Details", 0, supplierid);
                    MC.GoodsDetails = MCTemp.GoodsDetails;
                    GoodsDetails = MC.GoodsDetails;//new ObservableCollection<PPC_T002_A>();
                    blNew = false;
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
        private void GetSelectedMachine(IList MachineList)
        {
            try
            {
                IList list = MachineList as IList;
                List<ZADM_M013_PopUp> SelectedMachineTemp = list.Cast<ZADM_M013_PopUp>().ToList();

                if (SelectedMachineTemp.Count > 0 && dgSelectedIndex != -1)
                {
                    var q = GoodsDetails.Where(X => X.machine_id == SelectedMachineTemp[0].machine_id).FirstOrDefault();

                    if (q != null)
                    {
                        if (GoodsDetails.Count() > dgSelectedIndex)
                        {
                            GoodsDetails[dgSelectedIndex].machine_id = SelectedMachineTemp[0].machine_id;
                            GoodsDetails[dgSelectedIndex].MachineCode = SelectedMachineTemp[0].machinecode;
                            
                            GoodsDetails[dgSelectedIndex].add_by = AppSessionState.UserID;
                            GoodsDetails[dgSelectedIndex].location_Id = AppSessionState.location_Id;
                            GoodsDetails[dgSelectedIndex].comp_code  = AppSessionState.comp_code;
                            GoodsDetails[dgSelectedIndex].client = AppSessionState.client;
                            GoodsDetails[dgSelectedIndex].entrydt = SelectedPPC_T002_A.entrydt;                            
                        }
                    }
                    else
                    {
                        if (GoodsDetails.Count() <= dgSelectedIndex)
                        {
                            GoodsDetails.Add(new PPC_T002_A() { machine_id = SelectedMachineTemp[0].machine_id, MachineCode = SelectedMachineTemp[0].machinecode });
                        }
                        else
                        {
                            GoodsDetails[dgSelectedIndex].machine_id = SelectedMachineTemp[0].machine_id;
                            GoodsDetails[dgSelectedIndex].MachineCode = SelectedMachineTemp[0].machinecode;

                            GoodsDetails[dgSelectedIndex].add_by = AppSessionState.UserID;
                            GoodsDetails[dgSelectedIndex].location_Id = Convert.ToString(AppSessionState.location_Id);
                            GoodsDetails[dgSelectedIndex].comp_code = AppSessionState.comp_code;
                            GoodsDetails[dgSelectedIndex].client = AppSessionState.client;
                            GoodsDetails[dgSelectedIndex].entrydt = SelectedPPC_T002_A.entrydt;
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
        private void GetSelectedJobCart(IList JobCartList)
        {
            try
            {
                IList list = JobCartList as IList;
                List<PPC_T001_PopUp> SelectedJobCartTemp = list.Cast<PPC_T001_PopUp>().ToList();

                if (SelectedJobCartTemp.Count > 0 && dgSelectedIndex != -1)
                {
                    var q = GoodsDetails.Where(X => X.jobcard == SelectedJobCartTemp[0].doc_no).FirstOrDefault();

                    if (q != null)
                    {
                        if (GoodsDetails.Count() > dgSelectedIndex)
                        {
                            GoodsDetails[dgSelectedIndex].jobcard = SelectedJobCartTemp[0].doc_no;
                            GoodsDetails[dgSelectedIndex].prod_qty = SelectedJobCartTemp[0].jc_qty;
                            GoodsDetails[dgSelectedIndex].bal_qty = SelectedJobCartTemp[0].bal_qty;
                            GoodsDetails[dgSelectedIndex].itemcode = SelectedJobCartTemp[0].ItemCode;
                            //GoodsDetails[dgSelectedIndex].unit = SelectedJobCartTemp[0].unit;
                            GoodsDetails[dgSelectedIndex].unit_name = SelectedJobCartTemp[0].unit_name;
                            GoodsDetails[dgSelectedIndex].itemdesc = SelectedJobCartTemp[0].description;
                            GoodsDetails[dgSelectedIndex].sku = SelectedJobCartTemp[0].sku;

                            GoodsDetails[dgSelectedIndex].rejtn_qty = 0;
                            GoodsDetails[dgSelectedIndex].usable_prod_qty = GoodsDetails[dgSelectedIndex].prod_qty - GoodsDetails[dgSelectedIndex].rejtn_qty;
                        }
                    }
                    else
                    {
                        if (GoodsDetails.Count() <= dgSelectedIndex)
                        {
                            GoodsDetails.Add(new PPC_T002_A() { jobcard = SelectedJobCartTemp[0].doc_no });
                        }
                        else
                        {                           
                            GoodsDetails[dgSelectedIndex].jobcard = SelectedJobCartTemp[0].doc_no;
                            GoodsDetails[dgSelectedIndex].prod_qty = SelectedJobCartTemp[0].jc_qty;
                            GoodsDetails[dgSelectedIndex].bal_qty = SelectedJobCartTemp[0].bal_qty;
                            GoodsDetails[dgSelectedIndex].itemcode = SelectedJobCartTemp[0].ItemCode;
                            //GoodsDetails[dgSelectedIndex].unit = SelectedJobCartTemp[0].unit;
                            GoodsDetails[dgSelectedIndex].unit_name = SelectedJobCartTemp[0].unit_name;
                            GoodsDetails[dgSelectedIndex].itemdesc = SelectedJobCartTemp[0].description;
                            GoodsDetails[dgSelectedIndex].sku = SelectedJobCartTemp[0].sku;

                            GoodsDetails[dgSelectedIndex].rejtn_qty = 0;
                            GoodsDetails[dgSelectedIndex].usable_prod_qty = GoodsDetails[dgSelectedIndex].prod_qty - GoodsDetails[dgSelectedIndex].rejtn_qty;
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
        private void GetSelectedQuantity()
        {
            try
            {
                GoodsDetails[dgSelectedIndex].usable_prod_qty = GoodsDetails[dgSelectedIndex].prod_qty - GoodsDetails[dgSelectedIndex].rejtn_qty;               
               
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
                    Request = SelectedPPC_T002_A.client + "!@" + SelectedPPC_T002_A.comp_code + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }
        private void LoadInitialData()
        {
            try
            {
                string company = AppSessionState.comp_code.ToString() + "@" + AppSessionState.location_Id.ToString();

                MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_PPC_T002>(MC, "PPC_T002_A_Data", "ProductionEntryMultiple", "Production", "LoadAll", 0, company);
                SelectedList = MC.Details;
                //SelectedPPC_T002_A.plant = SelectedList[0].plant;

                #region Command Initialisation
                SelectionChangedCommand = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }
                    GetSelectedList(items);
                });
                SelectionChangedCommandDetails = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }
                //GetSelectedGoodDetails(items);
                GetSelectedList(items);

                });

                SelectionChangedCommandMachine = new RelayCommand<IList>(
               items =>
               {
                   if (items == null)
                   {
                       return;
                   }

                   GetSelectedMachine(items);
               });

                SelectionChangedCommandJobCart = new RelayCommand<IList>(
              items =>
              {
                  if (items == null)
                  {
                      return;
                  }

                  GetSelectedJobCart(items);
              });

                CellChangedCommand = new RelayCommand<IList>(
                    items =>
                    {
                        if (items == null)
                        {
                            return;
                        }

                        GetSelectedQuantity();
                    });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                #endregion
                GoodsDetails = new ObservableCollection<PPC_T002_A>();             

                CollectionMachine = CollectionViewSource.GetDefaultView(MC.Machine);
                CollectionMachine.Filter = new Predicate<object>(FilterMachine);

                CollectionJobCart = CollectionViewSource.GetDefaultView(MC.JobCart);
                CollectionJobCart.Filter = new Predicate<object>(FilterJobCart);

                DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
                DataGridCollection.Filter = new Predicate<object>(Filter);
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

        #region · Command Actions ·      

        protected override void OnSaveAction(InquiryActionResult<PPC_T002_A> result)
        {
            try
            {
                this.SelectedPPC_T002_A.EndEdit();
                ObjectSerializationService objSer = new ObjectSerializationService();                    
                        //SelectedPPC_T002_A.PlantName = AppSessionState.Location;    
                        if (blNew == true )
                        {
                            SelectedPPC_T002_A.XmlDataDocument_PPC_T002 = objSer.ObjectToXML(GoodsDetails);                           
                            SelectedPPC_T002_A = repository.SaveWithReturnDomainObject<PPC_T002_A>(SelectedPPC_T002_A, "ProductionEntryMultiple", "Production");
                            SelectedList.Add(SelectedPPC_T002_A);
                            _dataGridCollection.Refresh();
                            blNew = false;                           
                        }
                        else if (blNew == false)
                        {
                            if (ValidateControls() == true)
                            { 
                                SelectedPPC_T002_A.XmlDataDocument_PPC_T002 = objSer.ObjectToXML(GoodsDetails);
                                SelectedPPC_T002_A = repository.UpdateWithReturnDomainObject<PPC_T002_A>(SelectedPPC_T002_A, "ProductionEntryMultiple", "Production");
                                SelectedList.Add(SelectedPPC_T002_A);                                
                                _dataGridCollection.Refresh();
                            }
                            else
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Please Select Atleast One Record", this.Title);
                                showMessageService.ShowMessage();
                            }
                        }
                        _dataGridCollection.Refresh();                   
               

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
        protected override void  OnCreateAction(InquiryActionResult<PPC_T002_A> result)
        {
            blNew = true;

            GoodsDetails = new ObservableCollection<PPC_T002_A>();
            GoodsDetails.Clear();

            _dataGridCollection.Refresh();
            SelectedPPC_T002_A = new PPC_T002_A();
            SelectedPPC_T002_A.entrydt = DateTime.Now.Date;
            SelectedPPC_T002_A.ValidateAsync().Wait();
            SelectedPPC_T002_A.ts_code = ts_code_vm;
            SelectedPPC_T002_A.client = AppSessionState.client;
        }
        protected override void OnRemoveAction(InquiryActionResult<PPC_T002_A> result)
        {
            if (ValidateControls() == true)
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
                    this.SelectedPPC_T002_A.EndEdit();
                    ObjectSerializationService objSer = new ObjectSerializationService();
                    SelectedPPC_T002_A.XmlDataDocument_PPC_T002 = objSer.ObjectToXML(GoodsDetails);
                    string xdoc = objSer.ObjectToXML(SelectedPPC_T002_A);
                    string response = repository.Delete(xdoc, "ProductionEntryMultiple", "Production");
                    SelectedList = new List<PPC_T002_A>();
                   // SelectedList.Add(SelectedPPC_T002_A);
                   // GoodsDetails.Clear();
                    GoodsDetails = new ObservableCollection<PPC_T002_A>(SelectedList);
                    _dataGridCollection.Refresh();
                    SelectedPPC_T002_A.entrydt = DateTime.Now.Date;
                }
            }
            else
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Record for Delete", this.Title);
                showMessageService.ShowMessage();
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<PPC_T002_A> result)
        {
            SelectedPPC_T002_A.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<PPC_T002_A> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<PPC_T002_A> result)
        {
            SelectedList = SelectedList;
            SelectedPPC_T002_A = SelectedPPC_T002_A;
        }
        protected override void OnHelpAction(InquiryActionResult<PPC_T002_A> result)
        {
            SelectedList = SelectedList;
            SelectedPPC_T002_A = SelectedPPC_T002_A;
        }
        protected override void OnPrintAction(InquiryActionResult<PPC_T002_A> result)
        {
            SelectedList = SelectedList;
            SelectedPPC_T002_A = SelectedPPC_T002_A;

            // MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PPC_T002_A>(MC, "PUR_T002_A_Data", "PurchaseOrder", "CRM", "PurchaseOrder", 0, "");
            //MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_PPC_T002>(MCTemp, "PPC_T002_A_Data", "ILDChart", "Production", "RPTINK", AppSessionState.LocationID, SelectedPPC_T002_A.entrydt.ToString());
            //RPTDetails = MCTemp.RPTINK;
            //object objDS = new object();
            //objDS = MCTemp.RPTINK;
            //ReportManager ReportManager = new ReportingServices.ReportManager();
            //if (SelectedPPC_T002_A.ReportType == "Ink Chart")
            //{
            //    //Ink chart
            //    ReportManager.DisplayReport(objDS, "DSILDInk", "\\Production\\Rpt_ILD_Ink.rdlc");
            //}           
        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<PPC_T002_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<PPC_T002_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<PPC_T002_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<PPC_T002_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<PPC_T002_A> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Filters For Machine
        private void FilterCollectionMachine()
        {
            if (_CollectionMachine != null)
            {
                _CollectionMachine.Refresh();
            }
        }
        public string FilterStringMachine
        {
            get { return _filterStringMachine; }
            set
            {
                _filterStringMachine = value;
                RaisePropertyChanged("FilterStringMachine");
                FilterCollectionMachine();
            }
        }
        public bool FilterMachine(object obj)
        {
            var data = obj as ZADM_M013_PopUp;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringMachine))
                {
                    return (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterStringMachine.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For JobCart
        private void FilterCollectionJobCart()
        {
            if (_CollectionJobCart != null)
            {
                _CollectionJobCart.Refresh();
            }
        }
        public string FilterStringJobCart
        {
            get { return _filterStringJobCart; }
            set
            {
                _filterStringJobCart = value;
                RaisePropertyChanged("FilterStringJobCart");
                FilterCollectionJobCart();
            }
        }
        public bool FilterJobCart(object obj)
        {
            var data = obj as PPC_T001_PopUp;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringJobCart))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterStringJobCart.ToLower()));
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
            var data = obj as PPC_T002_A;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.entryno != null && data.entryno.ToString().ToLower().Contains(_filterString.ToLower())) ||
                            (data.entrydt != null && data.entrydt.ToString().ToLower().Contains(_filterString.ToLower())) ||
                            (data.entrytype != null && data.entrytype.ToString().ToLower().Contains(_filterString.ToLower())) ||
                            (data.type != null && data.type.ToString().ToLower().Contains(_filterString.ToLower())) ||
                            (data.MachineCode != null && data.MachineCode.ToString().ToLower().Contains(_filterString.ToLower())) ||
                            (data.jobcard != null && data.jobcard.ToString().ToLower().Contains(_filterString.ToLower())) ||
                            (data.fromdate != null && data.fromdate.ToString().ToLower().Contains(_filterString.ToLower())) ||
                            (data.todate != null && data.todate.ToString().ToLower().Contains(_filterString.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        private bool ValidateControls()
        {
            int cnt = 0;
            try
            {
                if (GoodsDetails.Count > 0)
                {
                    foreach (var item in GoodsDetails)
                    {
                        if (item.Select == true)
                        {
                            cnt = cnt + 1;
                        }
                    }
                    if (cnt == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

       
    }
}
