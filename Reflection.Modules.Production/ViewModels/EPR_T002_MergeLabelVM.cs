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
using Reflection.ReportingServices;

namespace Reflection.Modules.Production.ViewModels
{
    public class EPR_T002_MergeLabelVM : WorkspaceViewModel<EPR_T002>
    {
        #region Variable Declaration
            bool isNewRecord = true;
            WebServiceRepository<List<EPR_T002_Flip>> repository = new WebServiceRepository<List<EPR_T002_Flip>>();
            WebServiceRepository<MultipleContext_EPR_T002> repositoryM = new WebServiceRepository<MultipleContext_EPR_T002>();
            ObjectSerializationService obj = new ObjectSerializationService();
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
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

            private ObservableCollection<EPR_T002_Flip> _MasterEntity;
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

            private EPR_T002 _MasterObject;
            //Data source for Items DataGrid
            public EPR_T002 MasterObject
            {
                get
                {
                    return _MasterObject;
                }
                set
                {
                    if (_MasterObject != value)
                    {
                        _MasterObject = value;
                        RaisePropertyChanged("MasterObject");
                    }
                }
            }
        private  EPR_T002_Flip _MasterListObject;
        public EPR_T002_Flip MasterListObject
        {
            get
            {
                return _MasterListObject;
            }
            set
            {
                if (_MasterListObject != value)
                {
                    _MasterListObject = value;
                    RaisePropertyChanged("_MasterListObject");
                }
            }
        }
        private decimal? _QtyTobePacked;
            public decimal? QtyTobePacked
            {
                get
                {
                    return _QtyTobePacked;
                }
                set
                {
                    if (_QtyTobePacked != value)
                    {
                        _QtyTobePacked = value;
                        RaisePropertyChanged("QtyTobePacked");
                    }
                }
            }

            private decimal? _QtyPacked;
            public decimal? QtyPacked
            {
                get
                {
                    return _QtyPacked;
                }
                set
                {
                    if (_QtyPacked != value)
                    {
                        _QtyPacked = value;
                        RaisePropertyChanged("QtyPacked");
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
       
        #region ICollectionForPopup

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

        private ICollectionView _PartyCollection;
        public ICollectionView PartyCollection
        {
            get { return _PartyCollection; }
            set
            {
                _PartyCollection = value;
                RaisePropertyChanged("PartyCollection");
            }
        }

        private ICollectionView _MachineOperatorCollection;
        public ICollectionView MachineOperatorCollection
        {
            get { return _MachineOperatorCollection; }
            set
            {
                _MachineOperatorCollection = value;
                RaisePropertyChanged("MachineOperatorCollection");
            }
        }

        private ICollectionView _BMachineCollection;
        public ICollectionView BMachineCollection
        {
            get { return _BMachineCollection; }
            set
            {
                _BMachineCollection = value;
                RaisePropertyChanged("BMachineCollection");
            }
        }

        private ICollectionView _BItemCollection;
        public ICollectionView BItemCollection
        {
            get { return _BItemCollection; }
            set
            {
                _BItemCollection = value;
                RaisePropertyChanged("BItemCollection");
            }
        }

        private ICollectionView _BInkCollection;
        public ICollectionView BInkCollection
        {
            get { return _BInkCollection; }
            set
            {
                _BInkCollection = value;
                RaisePropertyChanged("BInkCollection");
            }
        }

        private ICollectionView _BIldCollection;
        public ICollectionView BIldCollection
        {
            get { return _BIldCollection; }
            set
            {
                _BIldCollection = value;
                RaisePropertyChanged("BIldCollection");
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
        #endregion
        #region RelayCommands
        public RelayCommand<IList> cmdItem { get; private set; }
        public RelayCommand<IList> cmdInk { get; private set; }
        public RelayCommand<IList> cmdIld { get; private set; }
        public RelayCommand<IList> cmdMachine { get; private set; }
        public RelayCommand<IList> cmdPkgUnit { get; private set; }
        public RelayCommand<IList> cmdParty { get; private set; }
        public RelayCommand<IList> cmdMOpeator { get; private set; }
        public RelayCommand cmdLoadIncompleteLabels { get; private set; }
        public RelayCommand cmdClearOneObject { get; private set; }
        
        // BackFlip
        public RelayCommand<IList> CommandBMachine { get; private set; }
        public RelayCommand<IList> CommandBPkgUnit { get; private set; }
        public RelayCommand<IList> CommandBItem { get; private set; }
        public RelayCommand<IList> CommandBInk { get; private set; }
        public RelayCommand<IList> CommandBIld { get; private set; }
        public RelayCommand CommandLoadLabelGenration { get; private set; }
        public RelayCommand CommandPrint2 { get; private set; }
        public RelayCommand<object> CommandCustomerProduct { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdDGCellDoubleClick { get; private set; }
        #endregion
        #region Constructor
        public EPR_T002_MergeLabelVM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MC = new MultipleContext_EPR_T002();
            MCTemp = new MultipleContext_EPR_T002();
            MCTemp2 = new MultipleContext_EPR_T002();
            SelectedEPR_T002 = new EPR_T002();
            MasterObject = new EPR_T002();
            MasterEntity = new ObservableCollection<EPR_T002_Flip>();
            PrintOption = "All";
            LabelStatus = "Unused";
            MasterObject.client = AppSessionState.client;
            SelectedEPR_T002.client = AppSessionState.client;
            
            EPR_T002_Flip.ModelEntityUpdated += new EventHandler(ModelUpdated_Calculation);

            LoadInitialData();
        }
        public EPR_T002_MergeLabelVM(string ts_code,string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MC = new MultipleContext_EPR_T002();
            MCTemp = new MultipleContext_EPR_T002();
            MCTemp2 = new MultipleContext_EPR_T002();
            SelectedEPR_T002 = new EPR_T002();
            MasterObject = new EPR_T002();
            MasterEntity = new ObservableCollection<EPR_T002_Flip>();
            PrintOption = "All";
            LabelStatus = "Unused";
            MasterObject.client = AppSessionState.client;
            SelectedEPR_T002.client = AppSessionState.client;
            EPR_T002_Flip.ModelEntityUpdated += new EventHandler(ModelUpdated_Calculation);

            LoadInitialData();
        }
        #endregion
        #region UserDefinedFunctions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialDataForMergeLabel" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + "ML"; ;
                MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T002>(MC, Request, "LabelGenerationMaster", "Production", "LoadAll", 0, "");

                #region Command Initialisation

                cmdItem = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertItem(cmdPara); });
                cmdInk = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertInk(cmdPara); });
                cmdIld = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertIld(cmdPara); });
                cmdMachine = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertMachine(cmdPara); });
                cmdPkgUnit = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertPkgUOM(cmdPara); });
                cmdParty = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertParty(cmdPara); });
                cmdMOpeator = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertM_Operator(cmdPara); });
                cmdLoadIncompleteLabels = new RelayCommand(() => { LoadIncompleteLabels(); });
                cmdClearOneObject = new RelayCommand(() => { ClearOneObjectMethod(); });

                //BackFlip
                CommandLoadLabelGenration = new RelayCommand(() => { LoadLabelGenerationDetails(); });
                CommandBMachine = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertBMachine(cmdPara); });
                CommandBPkgUnit = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertBPkgUnit(cmdPara); });
                CommandBItem = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertBItem(cmdPara); });
                CommandBInk = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertBInk(cmdPara); });
                CommandBIld = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertBIld(cmdPara); });
                CommandPrint2 = new RelayCommand(() => { Print2(); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdDGCellDoubleClick = new RelayCommand<object>(items => { if (items == null) { return; } AutoMergeQuantity(items); });
                CommandCustomerProduct = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCustomerProduct(cmdPara, false, true, true); });
                #endregion
                ItemCollection = CollectionViewSource.GetDefaultView(MC.ItemList);
                ItemCollection.Filter = new Predicate<object>(Filter_ItemCode);

                InkCollection = CollectionViewSource.GetDefaultView(MC.InkList);
                InkCollection.Filter = new Predicate<object>(Filter_Ink);

                IldCollection = CollectionViewSource.GetDefaultView(MC.IldList);
                IldCollection.Filter = new Predicate<object>(Filter_Ild);

                MachineCollection = CollectionViewSource.GetDefaultView(MC.MachineList);
                MachineCollection.Filter = new Predicate<object>(Filter_Machine);

                PkgUnitCollection = CollectionViewSource.GetDefaultView(MC.PkgUnitList);
                PkgUnitCollection.Filter = new Predicate<object>(Filter_PkgUnit);

                PartyCollection = CollectionViewSource.GetDefaultView(MC.PartyList);
                PartyCollection.Filter = new Predicate<object>(Filter_Party);

                MachineOperatorCollection = CollectionViewSource.GetDefaultView(MC.EmployeeList);
                MachineOperatorCollection.Filter = new Predicate<object>(Filter_MachineOperator);

                BMachineCollection = new CollectionViewSource { Source = MC.MachineList }.View;
                BMachineCollection.Filter = new Predicate<object>(Filter_BMachine);

                BItemCollection = new CollectionViewSource { Source = MC.ItemList }.View;
                BItemCollection.Filter = new Predicate<object>(Filter_BItemCode);

                BInkCollection = new CollectionViewSource { Source = MC.InkList }.View;
                BInkCollection.Filter = new Predicate<object>(Filter_BInk);

                BIldCollection = new CollectionViewSource { Source = MC.IldList }.View;
                BIldCollection.Filter = new Predicate<object>(Filter_BIld);

                BPkgUnitCollection = CollectionViewSource.GetDefaultView(MC.BPkgUnitList);
                BPkgUnitCollection.Filter = new Predicate<object>(Filter_BPkgUnit);

                ShiftCollection = CollectionViewSource.GetDefaultView(MC.ShiftList);

                GradeCollection2 = CollectionViewSource.GetDefaultView(MC.GradeList);

                CustomerProductCollection = CollectionViewSource.GetDefaultView(MC.CustomerProductList);
                CustomerProductCollection.Filter = new Predicate<object>(Filter_CustProduct);
                
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
        private void ClearOneObjectMethod()
        {
            MasterEntity = new ObservableCollection<EPR_T002_Flip>();      
            QtyPacked = 0;
            QtyTobePacked = 0;
            MasterObject.packing_qty = 0;
        }
        private void InsertItem(IList InputValue)
        {
            IList list = InputValue as IList;
            List<ADM_M022_P> GetSelectedItem = list.Cast<ADM_M022_P>().ToList();

            if (GetSelectedItem.Count > 0)
            {
                MasterObject.ItemCode = GetSelectedItem[0].ItemCode;
                MasterObject.ItemName = GetSelectedItem[0].ItemName;
            }
        }
        private void InsertInk(IList InputValue)
        {
            IList list = InputValue as IList;
            List<ZADM_M006_P> GetSelectedInk = list.Cast<ZADM_M006_P>().ToList();

            if (GetSelectedInk.Count > 0)
            {
                MasterObject.ink_id = GetSelectedInk[0].ink_id;
                MasterObject.Ink = GetSelectedInk[0].ink;
            }
        }
        private void InsertIld(IList InputValue)
        {
            IList list = InputValue as IList;
            List<ZADM_M007_P> GetSelectedIld = list.Cast<ZADM_M007_P>().ToList();

            if (GetSelectedIld.Count > 0)
            {
                MasterObject.ild_id = GetSelectedIld[0].ild_id;
                MasterObject.Ild = GetSelectedIld[0].ild;
            }
        }
        private void InsertMachine(IList InputValue)
        {
            int stringmachine_id = 0;
            string stringmachinecode = "";
            MasterObject.machinecode = "";
            foreach (ZADM_M013_P temp in MC.MachineList)
            {
                if (temp.Select == true)
                {
                    //stringmachine_id = stringmachine_id + "," + temp.machine_id;
                    stringmachinecode = stringmachinecode + "," + temp.machinecode;
                }
            }
            //SelectedEPR_T002.machine_id = stringmachine_id.ToString().TrimStart(new char[] { ',' });
            MasterObject.machinecode = stringmachinecode.ToString().TrimStart(new char[] { ',' });
            //IList list = InputValue as IList;
            //List<ZADM_M013_P> GetSelectedMachine = list.Cast<ZADM_M013_P>().ToList();

            //if (GetSelectedMachine.Count > 0)
            //{
            //    MasterObject.machine_id = GetSelectedMachine[0].machine_id;
            //    MasterObject.machinecode = GetSelectedMachine[0].machinecode;
            //}
        }
        private void InsertPkgUOM(IList InputValue)
        {
            IList list = InputValue as IList;
            List<ZADM_M017_P> GetSelectedPkgUnit = list.Cast<ZADM_M017_P>().ToList();

            if (GetSelectedPkgUnit.Count > 0)
            {
                MasterObject.pack_style = GetSelectedPkgUnit[0].id;
                MasterObject.packing_qty = Convert.ToDecimal(GetSelectedPkgUnit[0].pkgqty);
                MasterObject.PackingUnit = GetSelectedPkgUnit[0].pkgunit;
            }
        }
        private void InsertParty(IList InputValue)
        {
            IList list = InputValue as IList;
            List<ADM_M028_P> GetSelectedParty = list.Cast<ADM_M028_P>().ToList();

            if (GetSelectedParty.Count > 0)
            {
                MasterObject.PartyId = GetSelectedParty[0].PartyId;
                MasterObject.PartyNm = GetSelectedParty[0].PartyNm;
            }
        }
        private void InsertM_Operator(IList InputValue)
        {
            IList list = InputValue as IList;
            List<ADM_M024_P> GetSelectedMOperator = list.Cast<ADM_M024_P>().ToList();

            if (GetSelectedMOperator.Count > 0)
            {
                MasterObject.m_operator = GetSelectedMOperator[0].EmpId;
                MasterObject.OperatorNm = GetSelectedMOperator[0].EmpName;
            }
        }
        private void LoadIncompleteLabels()
        {
            try
            {
                //if (MasterObject.machine_id == null || MasterObject.machinecode == "All")
                //{
                //    MasterObject.machine_id = 0;
                //}
                //if (MasterObject.ItemCode == null || MasterObject.ItemCode == "")
                //{
                //    MasterObject.ItemCode = "All";
                //}
                //if (MasterObject.ink_id == null || MasterObject.Ink == "All")
                //{
                //    MasterObject.ink_id = 0;
                //}
                //if (MasterObject.ild_id == null || MasterObject.Ild == "All")
                //{
                //    MasterObject.ild_id = 0;
                //}
                //if (MasterObject.grade == null)
                //{
                //    MasterObject.grade = "All";
                //}

                string Request = "LoadForMergingLabel" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterObject.machinecode + "!@" + MasterObject.ItemCode
                         + "!@" + MasterObject.ink_id + "!@" + MasterObject.ild_id + "!@" + MasterObject.grade + "!@" + MasterObject.prod_dt + "!@" + MasterObject.entry_dt;

                MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T002>(MCTemp, Request, "LabelGenerationMaster", "Production", "LoadAll", 0, "");

                if (MCTemp.IncompleteLabelList.Count > 0)
                {
                    foreach (var o in MCTemp.IncompleteLabelList)
                    {
                        int IndexOfExistRow = MasterEntity.IndexOf(MasterEntity.Where(X => X.batch_no == o.batch_no).FirstOrDefault());

                        if (IndexOfExistRow == -1)
                        {
                            o.entry_dt = DateTime.Now;
                            o.add_by = AppSessionState.UserID;
                            o.editby = AppSessionState.UserID;
                            o.location_Id = AppSessionState.location_Id;
                            o.comp_code = AppSessionState.comp_code;
                            o.client = AppSessionState.client;
                            o.doc_cat = "ML";
                            o.doc_type = "ML";
                            o.active = true;
                            o.fin_year = "16-17";
                            o.posting_period = "2";

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
        private bool Validations()
        {
            try
            {
                string product = "";
                string grade = "";
                int? ink = 0;
                int? ild = 0;
                string unit = "";

                // Checking New Packing Style is Selected or Not
                if (MasterObject.pack_style == 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Packing Style for Merging Label", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }

                // Checking All Selected Rows Have Same product Grade ink Ild and UnitCode
                foreach (var o in MasterEntity)
                {
                    if (o.select == true && product == "" && grade == "" && ink == 0 && ild == 0 && unit == "")
                    {
                        product = o.ItemCode;
                        grade = o.grade;
                        ink = o.ink_id;
                        ild = o.ild_id;
                        unit = o.unit_code;
                    }
                    else if (o.select == true && (o.ItemCode != product || o.grade != grade || o.ink_id != ink || o.ild_id != ild || o.unit_code != unit))
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("All Selected Batch or Rows Must Have Same Product, Grade, Ink, Ild and Unit Code ", this.Title);
                        showMessageService.ShowMessage();
                        return false;
                    }

                    if(o.select == true && o.merge_qty > o.bal_qty_merge)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Merge Quantity Cannot Be Greater Than Balance Quantity \nFor Batch {0} at index {1}", o.batch_no,MasterEntity.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }
                }


                //Checking Total To Be Merge Quantity is Equal to Selected New Packing Style
                decimal? totalqty = MasterEntity.Where(x => x.select == true).Sum(x => x.merge_qty);

                if (Convert.ToDecimal(MasterObject.packing_qty) != totalqty)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Quantity To be Packed Must Be Equal To Total Quantity ", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
                return false;
            }
            
        }
        void ModelUpdated_Calculation(object sender, EventArgs e)
        {
            try
            {
                if (sender.ToString() == "merge_qty" || sender.ToString() == "select")
                {                  
                    QtyPacked = MasterEntity.Where(x => x.select == true).Sum(x => x.merge_qty);

                    if (MasterObject.packing_qty > 0)
                    {
                        QtyTobePacked = Convert.ToDecimal(MasterObject.packing_qty) - QtyPacked;
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

        //backflip

        //BackFlip
        private void LoadLabelGenerationDetails()
        {
            try
            {
                bool Label_used = false;

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

                if (LabelStatus == "Used")
                {
                    Label_used = true;
                }


                string Request = "LoadLGDetails" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + SelectedEPR_T002.machine_id + "!@" + SelectedEPR_T002.pack_style + "!@" + SelectedEPR_T002.ItemCode
                        + "!@" + SelectedEPR_T002.conversion + "!@" + SelectedEPR_T002.shift + "!@" + SelectedEPR_T002.ink_id + "!@" + SelectedEPR_T002.ild_id + "!@" + SelectedEPR_T002.prod_dt + "!@" + SelectedEPR_T002.grade + "!@" + Label_used + "!@" + "ML" + "!@" + "" + "!@" + SelectedEPR_T002.from_date.ToString()+ "!@" + SelectedEPR_T002.to_date.ToString() + "!@" + SelectedEPR_T002.entry_dt.ToString() + "!@" + SelectedEPR_T002.machinecode;

                MCTemp2 = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T002>(MCTemp2, Request, "LabelGenerationMaster", "Production", "LoadAll", 0, "");

                if (MCTemp2.LabelGenBackFlipList.Count >= 0)
                {
                    BackFlipCollection = CollectionViewSource.GetDefaultView(MCTemp2.LabelGenBackFlipList);
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
        private void InsertBMachine(IList InputValue)
        {
            try
            {
                int stringmachine_id = 0;
                string stringmachinecode = "";
                SelectedEPR_T002.machinecode = "";
                foreach (ZADM_M013_P temp in MC.MachineList)
                {
                    if (temp.Select == true)
                    {
                        //stringmachine_id = stringmachine_id + "," + temp.machine_id;
                        stringmachinecode = stringmachinecode + "," + temp.machinecode;
                    }
                }
                //SelectedEPR_T002.machine_id = stringmachine_id.ToString().TrimStart(new char[] { ',' });
                SelectedEPR_T002.machinecode = stringmachinecode.ToString().TrimStart(new char[] { ',' });

                
            }
            //try
            //{

            //    IList list = InputValue as IList;
            //    List<ZADM_M013_P> GetSelectedMachine = list.Cast<ZADM_M013_P>().ToList();

            //    if (GetSelectedMachine.Count > 0)
            //    {
            //        SelectedEPR_T002.machine_id = GetSelectedMachine[0].machine_id;
            //        SelectedEPR_T002.machinecode = GetSelectedMachine[0].machinecode;
            //    }
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
        private void InsertBItem(IList InputValue)
        {
            try
            {

                IList list = InputValue as IList;
                List<ADM_M022_P> GetSelectedItem = list.Cast<ADM_M022_P>().ToList();

                if (GetSelectedItem.Count > 0)
                {
                    SelectedEPR_T002.ItemCode = GetSelectedItem[0].ItemCode;
                    SelectedEPR_T002.ItemName = GetSelectedItem[0].ItemName;
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
        private void InsertBInk(IList InputValue)
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
        private void InsertBIld(IList InputValue)
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
        private void Print2()
        {
            try
            {
                if (MCTemp2.LabelGenBackFlipList != null && MCTemp2.LabelGenBackFlipList.Count > 0 && MC.SettingsList.Count > 0)
                {
                    if (PrintOption == "All")
                    {
                        object[] objDataSource = new object[3];
                        string[] objDataSourceName = new string[3];

                        QRCodeService QRGenerator = new QRCodeService();
                        foreach (RptLabelGen item in MCTemp2.RptLabelGenList)
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

                        objDataSource[0] = MCTemp2.RptLabelGenList;
                        objDataSourceName[0] = "dsRptLabelGen";

                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\" + MC.SettingsList[0].report2, MC.SettingsList[0].report2);
                    }
                    else if (PrintOption == "Selected")
                    {
                        int count = MCTemp2.LabelGenBackFlipList.Count(x => x.check == true);

                        if (count > 0)
                        {
                            foreach (var k in MCTemp2.RptLabelGenList)
                            {
                                k.check = false;
                            }

                            foreach (var o in MCTemp2.LabelGenBackFlipList)
                            {
                                if (o.check == true)
                                {
                                    foreach (var p in MCTemp2.RptLabelGenList)
                                    {
                                        if ((p.batch_no == o.batch_no || p.batch_no == o.cust_batch_no) && p.check != true)
                                        {
                                            p.check = true;
                                        }
                                    }
                                }
                            }

                            object[] objDataSource = new object[3];
                            string[] objDataSourceName = new string[3];

                            QRCodeService QRGenerator = new QRCodeService();
                            foreach (RptLabelGen item in MCTemp2.RptLabelGenList)
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

                            objDataSource[0] = MCTemp2.RptLabelGenList.Where(x => x.check == true);
                            objDataSourceName[0] = "dsRptLabelGen";

                            ReportManager ReportManager = new ReportManager();
                            ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\" + MC.SettingsList[0].report2, MC.SettingsList[0].report2);
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
                else if (MCTemp2.LabelGenBackFlipList == null || MCTemp2.LabelGenBackFlipList.Count <= 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Load the Data First...", this.Title);
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
        private void InsertCustomerProduct(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
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
                EPR_T002_Flip newObj = new EPR_T002_Flip();
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
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    //LoadLabelGenerationDetails(doc_no_vm);
                    
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
        private void AutoMergeQuantity(object InputValue)
        {
            try
            {
                if (MasterObject.packing_qty.HasValue)
                {
                    if (MasterListObject.bal_qty_merge > 0)
                    {
                        decimal? SumMergeQty = MasterEntity.Where(item => item.select == true).Sum(item => item.merge_qty);
                        decimal? RequiredQty = MasterObject.packing_qty - SumMergeQty;
                        if (RequiredQty > 0)
                        {
                            if (MasterListObject.bal_qty_merge <= RequiredQty)
                            {
                                MasterListObject.merge_qty = MasterListObject.bal_qty_merge;
                                //MasterListObject.bal_qty_merge = 0;
                                MasterListObject.select = true;
                            }
                            else
                            {
                                MasterListObject.merge_qty = RequiredQty;
                                //MasterListObject.bal_qty_merge = MasterListObject.bal_qty_merge - RequiredQty;
                                MasterListObject.select = true;
                            }
                        }
                    }
                }
                else
                {
                    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Select New Packing Unit", this.Title); sms.ShowMessage();
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
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
        #region CommandActions
        protected override void OnSaveAction(InquiryActionResult<EPR_T002> result)
        {
            try
            {
                TobeSaveEntity = new List<EPR_T002_Flip>();

                if (isNewRecord == true)
                {
                    foreach (var o in MasterEntity)  //First Selected Rows Will be Added To New Collection
                    {
                        if (o.select == true)
                        {
                            o.pack_style2 = MasterObject.pack_style;
                            o.packing_qty = Convert.ToDecimal(MasterObject.packing_qty);
                            o.PartyId2 = MasterObject.PartyId;
                            o.m_operator2 = MasterObject.m_operator;

                            TobeSaveEntity.Add(o);
                        }
                    }

                    if (TobeSaveEntity.Count > 0)   // If At Least One Row is Selected The Only It Will Save
                    {
                        if (Validations() == true)
                        {
                            string reader = repository.Save<List<EPR_T002_Flip>>(TobeSaveEntity, "MergeLabel", "Production");
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
        protected override void OnCreateAction(InquiryActionResult<EPR_T002> result)
        {
            MasterObject = new EPR_T002();
            MasterEntity = new ObservableCollection<EPR_T002_Flip>();
            SelectedEPR_T002 = new EPR_T002();
            QtyPacked = 0;
            QtyTobePacked = 0;
            MasterObject.packing_qty = 0;
            SelectedEPR_T002.ts_code = ts_code_vm;
            SelectedEPR_T002.client = AppSessionState.client;
            
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
                if (MCTemp2.LabelGenBackFlipList != null && MCTemp2.LabelGenBackFlipList.Count > 0 && MC.SettingsList.Count > 0)
                {
                    if (PrintOption == "All")
                    {
                        object[] objDataSource = new object[3];
                        string[] objDataSourceName = new string[3];

                        QRCodeService QRGenerator = new QRCodeService();
                        foreach (RptLabelGen item in MCTemp2.RptLabelGenList)
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

                        objDataSource[0] = MCTemp2.RptLabelGenList;
                        objDataSourceName[0] = "dsRptLabelGen";

                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\" + MC.SettingsList[0].report_name, MC.SettingsList[0].report_name);
                    }
                    else if (PrintOption == "Selected")
                    {
                        int count = MCTemp2.LabelGenBackFlipList.Count(x => x.check == true);

                        if (count > 0)
                        {
                            foreach (var k in MCTemp2.RptLabelGenList)
                            {
                                k.check = false;
                            }

                            foreach (var o in MCTemp2.LabelGenBackFlipList)
                            {
                                if (o.check == true)
                                {
                                    foreach (var p in MCTemp2.RptLabelGenList)
                                    {
                                        if ((p.batch_no == o.batch_no || p.batch_no == o.cust_batch_no) && p.check != true)
                                        {
                                            p.check = true;
                                        }
                                    }
                                }
                            }

                            object[] objDataSource = new object[3];
                            string[] objDataSourceName = new string[3];

                            QRCodeService QRGenerator = new QRCodeService();
                            foreach (RptLabelGen item in MCTemp2.RptLabelGenList)
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

                            objDataSource[0] = MCTemp2.RptLabelGenList.Where(x => x.check == true);
                            objDataSourceName[0] = "dsRptLabelGen";

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
                else if (MCTemp2.LabelGenBackFlipList == null || MCTemp2.LabelGenBackFlipList.Count <= 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Load the Data First...", this.Title);
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
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_ItemCode.ToLower())) ||
                        (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_ItemCode.ToLower()));
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
                    return (data.machine_id != null && data.machine_id.ToString().ToLower().Contains(_filterString_Machine.ToLower())) ||
                        (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterString_Machine.ToLower()));
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

        #region Party
        private string _filterString_Party;
        public string FilterString_Party
        {
            get { return _filterString_Party; }
            set
            {
                _filterString_Party = value;
                RaisePropertyChanged("FilterString_Party");
                FilterCollection_Party();
            }
        }
        private void FilterCollection_Party()
        {
            if (_PartyCollection != null)
            {
                _PartyCollection.Refresh();
            }
        }
        public bool Filter_Party(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Party))
                {
                    return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_Party.ToLower()) ||
                        data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_Party.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region MachineOperator
        private string _filterString_MachineOperator;
        public string FilterString_MachineOperator
        {
            get { return _filterString_MachineOperator; }
            set
            {
                _filterString_MachineOperator = value;
                RaisePropertyChanged("FilterString_MachineOperator");
                FilterCollection_MachineOperator();
            }
        }
        private void FilterCollection_MachineOperator()
        {
            if (_MachineOperatorCollection != null)
            {
                _MachineOperatorCollection.Refresh();
            }
        }
        public bool Filter_MachineOperator(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_MachineOperator))
                {
                    return (data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterString_MachineOperator.ToLower()) ||
                        data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_filterString_MachineOperator.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        //backflip

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

        #region Product

        private string _filterString_BItemCode;
        public string FilterString_BItemCode
        {
            get { return _filterString_BItemCode; }
            set
            {
                _filterString_BItemCode = value;
                RaisePropertyChanged("FilterString_BItemCode");
                FilterCollection_BItemCode();
            }
        }
        private void FilterCollection_BItemCode()
        {
            if (_BItemCollection != null)
            {
                _BItemCollection.Refresh();
            }
        }
        public bool Filter_BItemCode(object obj)
        {
            var data = obj as ADM_M022_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_BItemCode))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_BItemCode.ToLower())) ||
                        (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_BItemCode.ToLower())); ;
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Ink
        private string _filterString_BInk;
        public string FilterString_BInk
        {
            get { return _filterString_BInk; }
            set
            {
                _filterString_BInk = value;
                RaisePropertyChanged("FilterString_BInk");
                FilterCollection_BInk();
            }
        }
        private void FilterCollection_BInk()
        {
            if (_BInkCollection != null)
            {
                _BInkCollection.Refresh();
            }
        }
        public bool Filter_BInk(object obj)
        {
            var data = obj as ZADM_M006_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_BInk))
                {
                    return (data.ink != null && data.ink.ToString().ToLower().Contains(_filterString_BInk.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Ild
        private string _filterString_BIld;
        public string FilterString_BIld
        {
            get { return _filterString_BIld; }
            set
            {
                _filterString_BIld = value;
                RaisePropertyChanged("FilterString_BIld");
                FilterCollection_BIld();
            }
        }
        private void FilterCollection_BIld()
        {
            if (_BIldCollection != null)
            {
                _BIldCollection.Refresh();
            }
        }
        public bool Filter_BIld(object obj)
        {
            var data = obj as ZADM_M007_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_BIld))
                {
                    return (data.ild != null && data.ild.ToString().ToLower().Contains(_filterString_BIld.ToLower()) ||
                        data.tip_type != null && data.tip_type.ToString().ToLower().Contains(_filterString_BIld.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Machine

        private string _filterString_BMachine;
        public string FilterString_BMachine
        {
            get { return _filterString_BMachine; }
            set
            {
                _filterString_BMachine = value;
                RaisePropertyChanged("FilterString_BMachine");
                FilterCollection_BMachine();
            }
        }
        private void FilterCollection_BMachine()
        {
            if (_BMachineCollection != null)
            {
                _BMachineCollection.Refresh();
            }
        }
        public bool Filter_BMachine(object obj)
        {
            var data = obj as ZADM_M013_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_BMachine))
                {
                    return (data.machine_id != null && data.machine_id.ToString().ToLower().Contains(_filterString_BMachine.ToLower())) ||
                        (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterString_BMachine.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Pkg Unit

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
                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterString_BPkgUnit.ToLower()) ||
                        data.pkgunit != null && data.pkgunit.ToString().ToLower().Contains(_filterString_BPkgUnit.ToLower()));
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
        #endregion
    }
}
