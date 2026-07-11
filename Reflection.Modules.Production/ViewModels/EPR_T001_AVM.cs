using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.BusinessEntity;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.ReportingServices;
using Reflection.BusinessEntity.Production;



namespace Reflection.Modules.Production.ViewModels
{
    public class EPR_T001_AVM : WorkspaceViewModel<EPR_T001>
    {///


        bool blNew = true;
        WebServiceRepository<EPR_T001> repository = new WebServiceRepository<EPR_T001>();
        WebServiceRepository<MultipleContext_EPR_T001> repositoryM = new WebServiceRepository<MultipleContext_EPR_T001>();
        WebServiceRepository<MultipleContext_EPR_T001> repository_MCTemp = new WebServiceRepository<MultipleContext_EPR_T001>();

        MultipleContext_EPR_T001 MCTemp = new MultipleContext_EPR_T001();

        private ICollectionView _dataGridCollection;
        private int _dgSelectedIndex;
        private string _filterString;
        private string _filterStringPlant;
        private string _filterStringMachineType;
        private string _filterStringMachine;
        private string _filterStringModel;
        private string _filterStringProduct;
        private string _filterStringBallDia;
        private string _filterStringBallMake;
        private string _filterStringWireMake;
        private string _filterStringBallType;
        private string _filterStringINK;
        private string _filterStringILD;
        private string _filterStringILD2;
        private string _filterStringProductionPlan;
        private string _filterStringCustomer;
        private string _filterStringWireSize;
        private string _filterStringUOM;

        #region ICollection
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }

        private ICollectionView _CollectionPlant;
        public ICollectionView CollectionPlant
        {
            get { return _CollectionPlant; }
            set { _CollectionPlant = value; RaisePropertyChanged("CollectionPlant"); }
        }

        private ICollectionView _CollectionMachineType;
        public ICollectionView CollectionMachineType
        {
            get { return _CollectionMachineType; }
            set { _CollectionMachineType = value; RaisePropertyChanged("CollectionMachineType"); }
        }

        private ICollectionView _CollectionMachine;
        public ICollectionView CollectionMachine
        {
            get { return _CollectionMachine; }
            set { _CollectionMachine = value; RaisePropertyChanged("CollectionMachine"); }
        }

        private ICollectionView _CollectionModel;
        public ICollectionView CollectionModel
        {
            get { return _CollectionModel; }
            set { _CollectionModel = value; RaisePropertyChanged("CollectionModel"); }
        }

        private ICollectionView _CollectionProduct;
        public ICollectionView CollectionProduct
        {
            get { return _CollectionProduct; }
            set { _CollectionProduct = value; RaisePropertyChanged("CollectionProduct"); }
        }

        private ICollectionView _CollectionBallDia;
        public ICollectionView CollectionBallDia
        {
            get { return _CollectionBallDia; }
            set { _CollectionBallDia = value; RaisePropertyChanged("CollectionBallDia"); }
        }

        private ICollectionView _CollectionBallMake;
        public ICollectionView CollectionBallMake
        {
            get { return _CollectionBallMake; }
            set { _CollectionBallMake = value; RaisePropertyChanged("CollectionBallMake"); }
        }

        private ICollectionView _CollectionWireMake;
        public ICollectionView CollectionWireMake
        {
            get { return _CollectionWireMake; }
            set { _CollectionWireMake = value; RaisePropertyChanged("CollectionWireMake"); }
        }

        private ICollectionView _CollectionBallType;
        public ICollectionView CollectionBallType
        {
            get { return _CollectionBallType; }
            set { _CollectionBallType = value; RaisePropertyChanged("CollectionBallType"); }
        }

        private ICollectionView _CollectionINK;
        public ICollectionView CollectionINK
        {
            get { return _CollectionINK; }
            set { _CollectionINK = value; RaisePropertyChanged("CollectionINK"); }
        }

        private ICollectionView _CollectionILD;
        public ICollectionView CollectionILD
        {
            get { return _CollectionILD; }
            set { _CollectionILD = value; RaisePropertyChanged("CollectionILD"); }
        }
        private ICollectionView _CollectionILD2;
        public ICollectionView CollectionILD2
        {
            get { return _CollectionILD2; }
            set { _CollectionILD2 = value; RaisePropertyChanged("CollectionILD2"); }
        }

        private ICollectionView _CollectionProductionPlan;
        public ICollectionView CollectionProductionPlan
        {
            get { return _CollectionProductionPlan; }
            set { _CollectionProductionPlan = value; RaisePropertyChanged("CollectionProductionPlan"); }
        }

        private ICollectionView _CollectionCustomer;
        public ICollectionView CollectionCustomer
        {
            get { return _CollectionCustomer; }
            set { _CollectionCustomer = value; RaisePropertyChanged("CollectionCustomer"); }
        }

        private ICollectionView _CollectionUOM;
        public ICollectionView CollectionUOM
        {
            get { return _CollectionUOM; }
            set { _CollectionUOM = value; RaisePropertyChanged("CollectionUOM"); }
        }


        private ICollectionView _CollectionWireSize;
        public ICollectionView CollectionWireSize
        {
            get { return _CollectionWireSize; }
            set { _CollectionWireSize = value; RaisePropertyChanged("CollectionWireSize"); }
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
        #endregion

        #region RelayCommand
        public RelayCommand<IList> SelectionChangedCommand
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandILDDetails
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandPlant
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandMachineType
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandMachine
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandModel
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandProduct
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandBallDia
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandBallMake
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandWireMake
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandBallType
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandINK
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandILD
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandILD2
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandProductionPlan
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandCustomer
        {
            get;
            private set;
        }

        public RelayCommand<string> SelectionChangedCommandConversion
        {
            get;
            private set;
        }

        public RelayCommand<IList> SelectionChangedCommandWireSize
        {
            get;
            private set;
        }
        public RelayCommand cmdFeedbackRpt
        {
            get;
            private set;
        }
        private RelayCommand _buttonClickCommand;
        public RelayCommand CommandForLoadBackFlip
        {
            get;
            private set;
        }
        public RelayCommand<object> CmdPkgUnit { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<IList> SelectionChangedCommandUOM { get; private set; }
        #endregion

        #region EPR_T001
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }

        private List<EPR_T001> _SelectedList;
        public List<EPR_T001> SelectedList
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

        private EPR_T001 _SelectedEPR_T001;
        public EPR_T001 SelectedEPR_T001
        {
            get
            {
                this.ErrorExist = _SelectedEPR_T001.HasErrors;
                return _SelectedEPR_T001;
            }
            set
            {
                if (_SelectedEPR_T001 != value)
                {
                    _SelectedEPR_T001 = value;
                    this.ErrorExist = _SelectedEPR_T001.HasErrors;
                    RaisePropertyChanged("SelectedEPR_T001");
                    value.BeginEdit();
                }
            }
        }

        private List<EPR_T001> _SelectedList_new;
        public List<EPR_T001> SelectedList_new
        {
            get { return _SelectedList_new; }
            set
            {
                if (_SelectedList_new != value)
                {
                    _SelectedList_new = value;
                    RaisePropertyChanged("_SelectedList_new");
                }
            }
        }

        private EPR_T001 _SelectedEPR_T001_New;
        public EPR_T001 SelectedEPR_T001_New
        {
            get
            {
                //this.ErrorExist = _SelectedEPR_T001.HasErrors;
                return _SelectedEPR_T001_New;
            }
            set
            {
                if (_SelectedEPR_T001_New != value)
                {
                    _SelectedEPR_T001_New = value;
                    //this.ErrorExist = _SelectedEPR_T001.HasErrors;
                    RaisePropertyChanged("SelectedEPR_T001_New");
                    value.BeginEdit();
                }
            }
        }
        #endregion

        #region EPR_T001
        private static ObservableCollection<EPR_T001> _GoodsDetails = new ObservableCollection<EPR_T001>();
        public ObservableCollection<EPR_T001> GoodsDetails
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

        #region RPT_EPR_T001
        private static ObservableCollection<RPT_EPR_T001> _RPTDetails = new ObservableCollection<RPT_EPR_T001>();
        public ObservableCollection<RPT_EPR_T001> RPTDetails
        {
            get { return _RPTDetails; }
            set
            {
                if (_RPTDetails != value)
                {
                    _RPTDetails = value;

                    RaisePropertyChanged("RPTDetails");
                }
            }
        }


        #endregion

        #region ADM_M003 poup Plant
        private List<ADM_M003_PopUp1> _SelectedPlantList;
        public List<ADM_M003_PopUp1> SelectedPalntList
        {
            get { return _SelectedPlantList; }
            set
            {
                if (_SelectedPlantList != value)
                {
                    _SelectedPlantList = value;
                    RaisePropertyChanged("SelectedPalntList");
                }
            }
        }
        #endregion

        #region ZADM_M013 poup Machine Type
        private List<ZADM_M013_P_machine_type> _SelectedMachineList;
        public List<ZADM_M013_P_machine_type> SelectedMachineList
        {
            get { return _SelectedMachineList; }
            set
            {
                if (_SelectedMachineList != value)
                {
                    _SelectedMachineList = value;
                    RaisePropertyChanged("SelectedMachineList");
                }
            }
        }
        #endregion

        #region ZADM_M013 poup Machine
        private List<ZADM_M013_P> _SelectedMCList;
        public List<ZADM_M013_P> SelectedMCList
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
        private List<ECRM_T002_AFeedbackRpt> _RptFeedback;
        public List<ECRM_T002_AFeedbackRpt> RptFeedback
        {
            get { return _RptFeedback; }
            set
            {
                if (_RptFeedback != value)
                {
                    _RptFeedback = value;
                    RaisePropertyChanged("RptFeedback");
                }
            }
        }
        #endregion

        #region ZADM_M009 poup Model
        private List<ZADM_M009_P> _SelectedModelList;
        public List<ZADM_M009_P> SelectedModelList
        {
            get { return _SelectedModelList; }
            set
            {
                if (_SelectedModelList != value)
                {
                    _SelectedModelList = value;
                    RaisePropertyChanged("SelectedModelList");
                }
            }
        }
        #endregion

        #region ADM_M022 poup Product
        private List<ADM_M022_P_ESSEM> _SelectedProductList;
        public List<ADM_M022_P_ESSEM> SelectedProductList
        {
            get { return _SelectedProductList; }
            set
            {
                if (_SelectedProductList != value)
                {
                    _SelectedProductList = value;
                    RaisePropertyChanged("SelectedProductList");
                }
            }
        }
        #endregion

        #region ZADM_M001_PopUp  BallDia
        private List<ZADM_M001_PopUp> _SelectedBallDiaList;
        public List<ZADM_M001_PopUp> SelectedBallDiaList
        {
            get { return _SelectedBallDiaList; }
            set
            {
                if (_SelectedBallDiaList != value)
                {
                    _SelectedBallDiaList = value;
                    RaisePropertyChanged("SelectedBallDiaList");
                }
            }
        }
        #endregion

        #region ADM_M032_P  BallMake
        private List<ADM_M032_P> _SelectedBallMakeList;
        public List<ADM_M032_P> SelectedBallMakeList
        {
            get { return _SelectedBallMakeList; }
            set
            {
                if (_SelectedBallMakeList != value)
                {
                    _SelectedBallMakeList = value;
                    RaisePropertyChanged("SelectedBallMakeList");
                }
            }
        }
        #endregion

        #region ADM_M032_P  WireMake
        private List<ADM_M032_P> _SelectedWireMakeList;
        public List<ADM_M032_P> SelectedWireMakeList
        {
            get { return _SelectedWireMakeList; }
            set
            {
                if (_SelectedWireMakeList != value)
                {
                    _SelectedWireMakeList = value;
                    RaisePropertyChanged("SelectedWireMakeList");
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
        #endregion

        #region ZADM_M002_P  BallType
        private List<ZADM_M002_P> _SelectedBallTypeList;
        public List<ZADM_M002_P> SelectedBallTypeList
        {
            get { return _SelectedBallTypeList; }
            set
            {
                if (_SelectedBallTypeList != value)
                {
                    _SelectedBallTypeList = value;
                    RaisePropertyChanged("SelectedBallTypeList");
                }
            }
        }
        #endregion

        #region ZADM_M006_P  INK
        private List<ZADM_M006_P> _SelectedINKList;
        public List<ZADM_M006_P> SelectedINKList
        {
            get { return _SelectedINKList; }
            set
            {
                if (_SelectedINKList != value)
                {
                    _SelectedINKList = value;
                    RaisePropertyChanged("SelectedINKList");
                }
            }
        }
        #endregion

        #region ZADM_M007_P  ILD
        private List<ZADM_M007_P> _SelectedILDList;
        public List<ZADM_M007_P> SelectedILDList
        {
            get { return _SelectedILDList; }
            set
            {
                if (_SelectedILDList != value)
                {
                    _SelectedILDList = value;
                    RaisePropertyChanged("SelectedILDList");
                }
            }
        }
        #endregion

        #region SEL_T001_P  Sales Order
        private List<SEL_T001_P> _SelectedSalesOrderList;
        public List<SEL_T001_P> SelectedSalesOrderList
        {
            get { return _SelectedSalesOrderList; }
            set
            {
                if (_SelectedSalesOrderList != value)
                {
                    _SelectedSalesOrderList = value;
                    RaisePropertyChanged("SelectedSalesOrderList");
                }
            }
        }
        #endregion

        #region ADM_M028_popup cutomer
        private List<ADM_M028_P> _SelectedCustomerList;
        public List<ADM_M028_P> SelectedCustomerList
        {
            get { return _SelectedCustomerList; }
            set
            {
                if (_SelectedCustomerList != value)
                {
                    _SelectedCustomerList = value;
                    RaisePropertyChanged("SelectedCustomerList");
                }
            }
        }
        private bool _post;
        public bool post
        {
            get { return _post; }
            set
            {
                if (_post != value)
                {
                    _post = value;
                    RaisePropertyChanged("post");
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
        #region StringLists

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
        #endregion
        MultipleContext_EPR_T001 _MC = new MultipleContext_EPR_T001();
        public MultipleContext_EPR_T001 MC
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
        public EPR_T001_AVM(string ts_code)
            : base()
        {
            this.ts_code_vm = ts_code;
            SelectedList = new List<EPR_T001>();
            SelectedEPR_T001 = new EPR_T001();
            SelectedPalntList = new List<ADM_M003_PopUp1>();
            SelectedMachineList = new List<ZADM_M013_P_machine_type>();
            SelectedMCList = new List<ZADM_M013_P>();
            SelectedModelList = new List<ZADM_M009_P>();
            SelectedProductList = new List<ADM_M022_P_ESSEM>();
            SelectedBallDiaList = new List<ZADM_M001_PopUp>();
            SelectedBallMakeList = new List<ADM_M032_P>();
            SelectedWireMakeList = new List<ADM_M032_P>();
            SelectedBallTypeList = new List<ZADM_M002_P>();
            SelectedINKList = new List<ZADM_M006_P>();
            SelectedILDList = new List<ZADM_M007_P>();
            SelectedSalesOrderList = new List<SEL_T001_P>();
            SelectedCustomerList = new List<ADM_M028_P>();
           

            SelectedList_new = new List<EPR_T001>();
            SelectedEPR_T001_New = new EPR_T001();

            GoodsDetails = new ObservableCollection<EPR_T001>();
            post = true;
            MC = new MultipleContext_EPR_T001();

            SelectedEPR_T001.ValidateAsync().Wait();
            
            SelectedEPR_T001.start_dt = DateTime.Now.Date;
            SelectedEPR_T001.machinecode = "Select";
            LoadInitialData();
        }
        public EPR_T001_AVM(string ts_code,string doc_no)
            : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            SelectedList = new List<EPR_T001>();
            SelectedEPR_T001 = new EPR_T001();
            SelectedPalntList = new List<ADM_M003_PopUp1>();
            SelectedMachineList = new List<ZADM_M013_P_machine_type>();
            SelectedMCList = new List<ZADM_M013_P>();
            SelectedModelList = new List<ZADM_M009_P>();
            SelectedProductList = new List<ADM_M022_P_ESSEM>();
            SelectedBallDiaList = new List<ZADM_M001_PopUp>();
            SelectedBallMakeList = new List<ADM_M032_P>();
            SelectedWireMakeList = new List<ADM_M032_P>();
            SelectedBallTypeList = new List<ZADM_M002_P>();
            SelectedINKList = new List<ZADM_M006_P>();
            SelectedILDList = new List<ZADM_M007_P>();
            SelectedSalesOrderList = new List<SEL_T001_P>();
            SelectedCustomerList = new List<ADM_M028_P>();

            SelectedList_new = new List<EPR_T001>();
            SelectedEPR_T001_New = new EPR_T001();

            GoodsDetails = new ObservableCollection<EPR_T001>();
            post = true;
            MC = new MultipleContext_EPR_T001();

            SelectedEPR_T001.ValidateAsync().Wait();

            SelectedEPR_T001.start_dt = DateTime.Now.Date;
            SelectedEPR_T001.machinecode = "Select";
            LoadInitialData();
        }

        #endregion
        private void GetSelectedConversion()
        {
            try
            {
                if (SelectedEPR_T001.machine_id == null || SelectedEPR_T001.machine_id == 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Select Machine First.", this.Title);
                    showMessageService.ShowMessage();
                }
            }
            catch (Exception)
            {

                // throw;
            }

        }

        private void GetSelectedList(IList DataList)
        {
            IList list = DataList as IList;
            List<EPR_T001> tSelectedItemsList = list.Cast<EPR_T001>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                SelectedEPR_T001 = (EPR_T001)tSelectedItemsList[0];
                //GoodsDetails = new ObservableCollection<EPR_T001>();
                blNew = false;
                SelectedEPR_T001.ts_code = ts_code_vm;
            }

            //Load Machine Details
            string request = "";
            request = AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + SelectedEPR_T001.machine_id + "!@" + SelectedEPR_T001.model_code;

            MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MCTemp, "EPR_T001_Data", "ConversionNote", "Production", "LoadPrevMachine", SelectedEPR_T001.id, request);
            SelectedList_new = MCTemp.ILDChart_New;
            IList list1 = SelectedList_new as IList;
            List<EPR_T001> GetSelectedILDTemp = list1.Cast<EPR_T001>().ToList();
            SelectedTabControlIndex = 0;
            if (GetSelectedILDTemp.Count > 0)
            {
                SelectedEPR_T001_New.machinecode = GetSelectedILDTemp[0].machinecode;
                SelectedEPR_T001_New.machine_id = GetSelectedILDTemp[0].machine_id;
                SelectedEPR_T001_New.start_dt = GetSelectedILDTemp[0].start_dt;
                SelectedEPR_T001_New.model_code = GetSelectedILDTemp[0].model_code;
                SelectedEPR_T001_New.model_id = GetSelectedILDTemp[0].model_id;
                SelectedEPR_T001_New.ItemCode = GetSelectedILDTemp[0].ItemCode;
                SelectedEPR_T001_New.ItemName = GetSelectedILDTemp[0].ItemName;
                SelectedEPR_T001_New.ink = GetSelectedILDTemp[0].ink;
                SelectedEPR_T001_New.ild = GetSelectedILDTemp[0].ild;
                SelectedEPR_T001_New.wire_make = GetSelectedILDTemp[0].wire_make;
                SelectedEPR_T001_New.ball_make = GetSelectedILDTemp[0].ball_make;
                SelectedEPR_T001_New.ball_dia = GetSelectedILDTemp[0].ball_dia;
                SelectedEPR_T001_New.PartyId = GetSelectedILDTemp[0].PartyId;
                SelectedEPR_T001_New.PartyName = GetSelectedILDTemp[0].PartyName;
                SelectedEPR_T001_New.conv = GetSelectedILDTemp[0].conv;
                //SelectedEPR_T001_New.tds_no = GetSelectedILDTemp[0].tds_no;
                //SelectedEPR_T001.MachineCode = GetSelectedILDTemp[0].MachineCode;
                //SelectedEPR_T001.machine_id = GetSelectedILDTemp[0].machine_id;
                //SelectedEPR_T001.start_dt = GetSelectedILDTemp[0].start_dt;
            }
            else
            {
                SelectedEPR_T001_New = new EPR_T001();
            }
        }

        private void GetSelectedPlant(IList PlantList)
        {
            IList list = PlantList as IList;
            List<ADM_M003_P> GetSelectedPlantTemp = list.Cast<ADM_M003_P>().ToList();

            if (GetSelectedPlantTemp.Count > 0)
            {
                SelectedEPR_T001.location_Id = Convert.ToString(GetSelectedPlantTemp[0].location_Id);
                SelectedEPR_T001.PlantName = GetSelectedPlantTemp[0].LoctnNm;
            }

        }

        private void GetSelectedMachineType(IList MachineTypeList)
        {
            IList list = MachineTypeList as IList;
            List<ZADM_M013_P_machine_type> GetSelectedMachineTypeTemp = list.Cast<ZADM_M013_P_machine_type>().ToList();

            if (GetSelectedMachineTypeTemp.Count > 0)
            {
                SelectedEPR_T001.MachineType = GetSelectedMachineTypeTemp[0].mctype;
            }

            var MachineList = (from o in MC.Machine
                               where o.mctype == SelectedEPR_T001.MachineType
                               select o).ToList();

            CollectionMachine = CollectionViewSource.GetDefaultView(MachineList);
            CollectionMachine.Filter = new Predicate<object>(FilterMachine);
        }

        private void GetSelectedMachine(IList MachineList)
        {
            try
            {
                IList list = MachineList as IList;
                List<ZADM_M013_P> GetSelectedMachineTemp = list.Cast<ZADM_M013_P>().ToList();

                if (SelectedEPR_T001.status == "Draft" || SelectedEPR_T001.status == "Open" || SelectedEPR_T001.status=="" || SelectedEPR_T001.status==null)
                {
            
                    if (GetSelectedMachineTemp.Count > 0)
                    {
                        SelectedEPR_T001.machine_id = GetSelectedMachineTemp[0].machine_id;
                        SelectedEPR_T001.machinecode = GetSelectedMachineTemp[0].machinecode;

                        //Load Machine Details
                        string request = "";
                        request = AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + SelectedEPR_T001.machine_id + "!@" + SelectedEPR_T001.machinecode;

                        MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MCTemp, "EPR_T001_Data", "ConversionNote", "Production", "LoadMachine", 0, request);
                        SelectedList_new = MCTemp.ILDChart_New;
                        IList list1 = SelectedList_new as IList;
                        List<EPR_T001> GetSelectedILDTemp = list1.Cast<EPR_T001>().ToList();

                        if (GetSelectedILDTemp.Count > 0)
                        {
                            SelectedEPR_T001_New.machinecode = GetSelectedILDTemp[0].machinecode;
                            SelectedEPR_T001_New.machine_id = GetSelectedILDTemp[0].machine_id;
                            SelectedEPR_T001_New.start_dt = GetSelectedILDTemp[0].start_dt;
                            SelectedEPR_T001_New.model_code = GetSelectedILDTemp[0].model_code;
                            SelectedEPR_T001_New.model_id = GetSelectedILDTemp[0].model_id;
                            SelectedEPR_T001_New.ItemCode = GetSelectedILDTemp[0].ItemCode;
                            SelectedEPR_T001_New.ItemName = GetSelectedILDTemp[0].ItemName;
                            SelectedEPR_T001_New.ink = GetSelectedILDTemp[0].ink;
                            SelectedEPR_T001_New.ild = GetSelectedILDTemp[0].ild;
                            SelectedEPR_T001_New.wire_make = GetSelectedILDTemp[0].wire_make;
                            SelectedEPR_T001_New.ball_make = GetSelectedILDTemp[0].ball_make;
                            SelectedEPR_T001_New.ball_dia = GetSelectedILDTemp[0].ball_dia;
                            //SelectedEPR_T001_New.tds_no = GetSelectedILDTemp[0].tds_no;
                            SelectedEPR_T001_New.PartyId = GetSelectedILDTemp[0].PartyId;
                            SelectedEPR_T001_New.PartyName = GetSelectedILDTemp[0].PartyName;
                            SelectedEPR_T001_New.conv = GetSelectedILDTemp[0].conv;
                            SelectedEPR_T001.pre_order_no = GetSelectedILDTemp[0].order_no;
                        }
                        else
                        {
                            SelectedEPR_T001_New = new EPR_T001();
                            SelectedEPR_T001.machine_id = GetSelectedMachineTemp[0].machine_id;
                            SelectedEPR_T001.machinecode = GetSelectedMachineTemp[0].machinecode;
                            //SelectedEPR_T001.pre_order_no = GetSelectedILDTemp[0].order_no;
                        }

                        _filterStringMachine = "";
                        RaisePropertyChanged("FilterStringMachine");
                        FilterCollectionMachine();
                    }
                }

                else
                {
                    
                        
                    MessageBox.Show("You an Change Machine Its already Running");
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

        private void GetSelectedModel(IList ModelList)
        {
            try
            {
                IList list = ModelList as IList;
                List<ZADM_M009_P> GetSelectedModelTemp = list.Cast<ZADM_M009_P>().ToList();

                if (GetSelectedModelTemp.Count > 0)
                {
                    SelectedEPR_T001.model_id = GetSelectedModelTemp[0].model_id;
                    SelectedEPR_T001.model_code = GetSelectedModelTemp[0].modelno;
                }
                if (GetSelectedModelTemp.Count > 0)
                {
                    var ProductList = (from o in MC.Product
                                       where o.Model_id == SelectedEPR_T001.model_id
                                       select o).ToList();
                    CollectionProduct = CollectionViewSource.GetDefaultView(ProductList);
                    CollectionProduct.Filter = new Predicate<object>(FilterProduct);
                    //Filter
                    //_filterStringModel = "";
                    //RaisePropertychanged("FilterStringModel");
                    //FilterCollectionModel();
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

        private void GetSelectedProduct(IList ProductList)
        {
            try
            {
                IList list = ProductList as IList;
                List<ADM_M022_P_ESSEM> GetSelectedProdTemp = list.Cast<ADM_M022_P_ESSEM>().ToList();

                if (GetSelectedProdTemp.Count > 0)
                {
                    SelectedEPR_T001.ItemCode = GetSelectedProdTemp[0].ItemCode;
                    SelectedEPR_T001.ItemName = GetSelectedProdTemp[0].ItemName;
                    SelectedEPR_T001.routing_no = GetSelectedProdTemp[0].routing_no;
                    SelectedEPR_T001.shank_len = Convert.ToString(GetSelectedProdTemp[0].shanklen);
                    SelectedEPR_T001.needle_dia = Convert.ToString(GetSelectedProdTemp[0].needledia);
                    SelectedEPR_T001.needle = Convert.ToString(GetSelectedProdTemp[0].needlelen);
                    SelectedEPR_T001.ball_dia = Convert.ToString(GetSelectedProdTemp[0].ball_dia);
                    SelectedEPR_T001.ball_type = GetSelectedProdTemp[0].ball_type;
                    if (SelectedEPR_T001.model_id == null || SelectedEPR_T001.model_id == 0)
                    {
                        SelectedEPR_T001.model_id = GetSelectedProdTemp[0].Model_id;
                        SelectedEPR_T001.model_code = GetSelectedProdTemp[0].ModelCode;
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

        private void GetSelectedBallDia(IList BallDiaList)
        {
            try
            {

                IList list = BallDiaList as IList;
                List<ZADM_M001_PopUp> GetSelectedBallDiaTemp = list.Cast<ZADM_M001_PopUp>().ToList();

                if (GetSelectedBallDiaTemp.Count > 0)
                {
                    SelectedEPR_T001.ball_dia = Convert.ToString(GetSelectedBallDiaTemp[0].Ball_dia);
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

        private void GetSelectedWireSize(IList WireSizeList)
        {
            try
            {

                IList list = WireSizeList as IList;
                List<ZADM_M003_P> GetSelectedWireSize = list.Cast<ZADM_M003_P>().ToList();

                if (GetSelectedWireSize.Count > 0)
                {
                    SelectedEPR_T001.wire_size = GetSelectedWireSize[0].wire_size;

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

        private void GetSelectedBallMake(IList BallMakeList)
        {
            try
            {
                IList list = BallMakeList as IList;
                List<ADM_M032_P> GetSelectedBallMakeTemp = list.Cast<ADM_M032_P>().ToList();

                if (GetSelectedBallMakeTemp.Count > 0)
                {
                    SelectedEPR_T001.ball_make = GetSelectedBallMakeTemp[0].Make;
                }

                //_filterStringBallMake = "";
                //RaisePropertychanged("FilterStringBallMake");
                //FilterCollectionBallMake();

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

        private void GetSelectedWireMake(IList WireMakeList)
        {
            try
            {

                IList list = WireMakeList as IList;
                List<ADM_M032_P> GetSelectedWireMakeTemp = list.Cast<ADM_M032_P>().ToList();

                if (GetSelectedWireMakeTemp.Count > 0)
                {
                    SelectedEPR_T001.wire_make = GetSelectedWireMakeTemp[0].Make;
                }
                //_filterStringWireMake = "";
                //RaisePropertychanged("FilterStringWireMake");
                //FilterCollectionWireMake();

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

        private void GetSelectedBallType(IList BallTypeList)
        {
            try
            {
                IList list = BallTypeList as IList;
                List<ZADM_M002_P> SelectedBallTypeTemp = list.Cast<ZADM_M002_P>().ToList();

                if (SelectedBallTypeTemp.Count > 0 && dgSelectedIndex != -1)
                {
                    var q = GoodsDetails.Where(X => X.ball_type == Convert.ToString(SelectedBallTypeTemp[0].ball_type)).FirstOrDefault();

                    if (q != null)
                    {
                        if (GoodsDetails.Count() > dgSelectedIndex)
                        {
                            GoodsDetails[dgSelectedIndex].ball_type = Convert.ToString(SelectedBallTypeTemp[0].ball_type);
                        }
                    }
                    else
                    {
                        if (GoodsDetails.Count() <= dgSelectedIndex)
                        {
                            GoodsDetails.Add(new EPR_T001() { ball_type = Convert.ToString(SelectedBallTypeTemp[0].ball_type) });
                        }
                        else
                        {
                            GoodsDetails[dgSelectedIndex].ball_type = Convert.ToString(SelectedBallTypeTemp[0].ball_type);

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

        private void GetSelectedINK(IList INKList)
        {
            try
            {
                IList list = INKList as IList;
                List<ZADM_M006_P> GetSelectedINKTemp = list.Cast<ZADM_M006_P>().ToList();

                if (GetSelectedINKTemp.Count > 0)
                {
                    SelectedEPR_T001.ink = GetSelectedINKTemp[0].ink;
                }
                //_filterStringINK = "";
                //RaisePropertychanged("FilterStringINK");
                //FilterCollectionINK();

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

        private void GetSelectedILD(IList ILDList)
        {
            try
            {
                IList list = ILDList as IList;
                List<ZADM_M007_P> GetSelectedILDTemp = list.Cast<ZADM_M007_P>().ToList();

                if (GetSelectedILDTemp.Count > 0)
                {
                    SelectedEPR_T001.ild = GetSelectedILDTemp[0].ild;
                   
                }
                //_filterStringILD = "";
                //RaisePropertychanged("FilterStringILD");
                //FilterCollectionILD();

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
        private void GetSelectedILD2(IList ILDList)
        {
            try
            {
                IList list = ILDList as IList;
                List<ZADM_M007_P> GetSelectedILDTemp = list.Cast<ZADM_M007_P>().ToList();

                if (GetSelectedILDTemp.Count > 0)
                {
                    SelectedEPR_T001.task_list_type = GetSelectedILDTemp[0].ild;

                }
                //_filterStringILD = "";
                //RaisePropertychanged("FilterStringILD");
                //FilterCollectionILD();

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

        private void GetSelectedProductionPlan(IList SOList)
        {
            try
            {
                IList list = SOList as IList;
                List<EPR_T004_A_P> GetSelectedSOTemp = list.Cast<EPR_T004_A_P>().ToList();

                if (GetSelectedSOTemp.Count > 0)
                {

                    SelectedEPR_T001.prod_plan = GetSelectedSOTemp[0].plan_no;
                    SelectedEPR_T001.ink = GetSelectedSOTemp[0].para1;
                    SelectedEPR_T001.ild = GetSelectedSOTemp[0].para5;
                    SelectedEPR_T001.ItemCode = GetSelectedSOTemp[0].ItemCode;
                    SelectedEPR_T001.ItemName = GetSelectedSOTemp[0].ItemName;
                    SelectedEPR_T001.machinecode = GetSelectedSOTemp[0].machine_no;
                    SelectedEPR_T001.unit_code = GetSelectedSOTemp[0].unit_code;
                    SelectedEPR_T001.qty = GetSelectedSOTemp[0].plan_qty;
                    SelectedEPR_T001.machine_id = Convert.ToInt32(GetSelectedSOTemp[0].machine_id);
                    if(!string.IsNullOrWhiteSpace(GetSelectedSOTemp[0].para4))
                    {
                        SelectedEPR_T001.model_id = Convert.ToInt32(GetSelectedSOTemp[0].para4);
                    }
                    SelectedEPR_T001.wire_make = GetSelectedSOTemp[0].para2;
                    SelectedEPR_T001.wire_size = Convert.ToDecimal(GetSelectedSOTemp[0].para8);
                    SelectedEPR_T001.ball_make = GetSelectedSOTemp[0].para3;
                    SelectedEPR_T001.ball_dia = GetSelectedSOTemp[0].para6;
                    SelectedEPR_T001.ball_type = GetSelectedSOTemp[0].para7;
                    SelectedEPR_T001.model_code = GetSelectedSOTemp[0].para9;
                    SelectedEPR_T001.pre_order_no = GetSelectedSOTemp[0].pre_order_no;

                    //Load Machine Details
                    string request = "";
                    request = AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + SelectedEPR_T001.machine_id + "!@" + SelectedEPR_T001.machinecode;

                    MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MCTemp, "EPR_T001_Data", "ConversionNote", "Production", "LoadMachine", 0, request);
                    SelectedList_new = MCTemp.ILDChart_New;
                    IList list1 = SelectedList_new as IList;
                    List<EPR_T001> GetSelectedILDTemp = list1.Cast<EPR_T001>().ToList();

                    if (GetSelectedILDTemp.Count > 0)
                    {
                        SelectedEPR_T001_New.machinecode = GetSelectedILDTemp[0].machinecode;
                        SelectedEPR_T001_New.machine_id = GetSelectedILDTemp[0].machine_id;
                        SelectedEPR_T001_New.start_dt = GetSelectedILDTemp[0].start_dt;
                        SelectedEPR_T001_New.model_code = GetSelectedILDTemp[0].model_code;
                        SelectedEPR_T001_New.model_id = GetSelectedILDTemp[0].model_id;
                        SelectedEPR_T001_New.ItemCode = GetSelectedILDTemp[0].ItemCode;
                        SelectedEPR_T001_New.ItemName = GetSelectedILDTemp[0].ItemName;
                        SelectedEPR_T001_New.ink = GetSelectedILDTemp[0].ink;
                        SelectedEPR_T001_New.ild = GetSelectedILDTemp[0].ild;
                        SelectedEPR_T001_New.wire_make = GetSelectedILDTemp[0].wire_make;
                        SelectedEPR_T001_New.ball_make = GetSelectedILDTemp[0].ball_make;
                        SelectedEPR_T001_New.ball_dia = GetSelectedILDTemp[0].ball_dia;
                        //SelectedEPR_T001_New.tds_no = GetSelectedILDTemp[0].tds_no;
                        SelectedEPR_T001_New.PartyId = GetSelectedILDTemp[0].PartyId;
                        SelectedEPR_T001_New.PartyName = GetSelectedILDTemp[0].PartyName;
                        SelectedEPR_T001_New.conv = GetSelectedILDTemp[0].conv;
                        SelectedEPR_T001.pre_order_no = GetSelectedILDTemp[0].order_no;
                    }
                    else
                    {
                        SelectedEPR_T001_New = new EPR_T001();
                        SelectedEPR_T001.machine_id = Convert.ToInt16(GetSelectedSOTemp[0].machine_id);
                        SelectedEPR_T001.machinecode = GetSelectedSOTemp[0].machine_no;
                        SelectedEPR_T001.pre_order_no = GetSelectedSOTemp[0].pre_order_no;
                    }

                    _filterStringMachine = "";
                    RaisePropertyChanged("FilterStringMachine");
                    FilterCollectionMachine();

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

        private void GetSelectedCustomer(IList CutomerList)
        {
            try
            {
                IList list = CutomerList as IList;
                List<ADM_M028_P> GetSelectedSOTemp = list.Cast<ADM_M028_P>().ToList();

                if (GetSelectedSOTemp.Count > 0)
                {
                    SelectedEPR_T001.PartyId = GetSelectedSOTemp[0].PartyId;
                    SelectedEPR_T001.PartyName = GetSelectedSOTemp[0].PartyNm;
                }
                _filterStringCustomer = "";
                RaisePropertyChanged("FilterStringCustomer");
                FilterCollectionCustomer();
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

        private void GetSelectedUOM(IList UOMList)
        {
            try
            {
                IList list = UOMList as IList;
                List<ADM_M038_B_P> GetSelectedUOM = list.Cast<ADM_M038_B_P>().ToList();

                if (GetSelectedUOM.Count > 0)
                {
                    SelectedEPR_T001.unit_code = GetSelectedUOM[0].unit_code;
                    //SelectedEPR_T001.unit_name = GetSelectedUOM[0].unit_name;
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

        private void LoadInitialData()
        {
            try
            {
                //SelectedEPR_T001.t_status = "Draft";
                string request = "";
                request = AppSessionState.comp_code + "!@" + AppSessionState.location_Id;

                //MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MC, "EPR_T001_Data", "ConversionNote", "Production", "LoadAllILD", 0, request);
                MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MC, "EPR_T001_Data", "ConversionNote", "Production", "LoadAll", 0, request);
                SelectedList = MC.ILDChart;

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
                SelectionChangedCommandILDDetails = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }
                    GetSelectedList(items);

                });

                SelectionChangedCommandPlant = new RelayCommand<IList>(
              items =>
              {
                  if (items == null)
                  {
                      return;
                  }

                  GetSelectedPlant(items);
              });

                SelectionChangedCommandMachineType = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }

                GetSelectedMachineType(items);
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

                SelectionChangedCommandModel = new RelayCommand<IList>(
              items =>
              {
                  if (items == null)
                  {
                      return;
                  }

                  GetSelectedModel(items);
              });

                SelectionChangedCommandProduct = new RelayCommand<IList>(
              items =>
              {
                  if (items == null)
                  {
                      return;
                  }

                  GetSelectedProduct(items);
              });

                SelectionChangedCommandBallDia = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }

                GetSelectedBallDia(items);
            });
                SelectionChangedCommandBallMake = new RelayCommand<IList>(
             items =>
             {
                 if (items == null)
                 {
                     return;
                 }

                 GetSelectedBallMake(items);
             });

                SelectionChangedCommandWireMake = new RelayCommand<IList>(
           items =>
           {
               if (items == null)
               {
                   return;
               }

               GetSelectedWireMake(items);
           });

                SelectionChangedCommandBallType = new RelayCommand<IList>(
          items =>
          {
              if (items == null)
              {
                  return;
              }

              GetSelectedBallType(items);
          });
                SelectionChangedCommandINK = new RelayCommand<IList>(
         items =>
         {
             if (items == null)
             {
                 return;
             }

             GetSelectedINK(items);
         });

                SelectionChangedCommandILD = new RelayCommand<IList>(
        items =>
        {
            if (items == null)
            {
                return;
            }

            GetSelectedILD(items);
        });
                SelectionChangedCommandILD2 = new RelayCommand<IList>(
             items =>
             {
                 if (items == null)
                 {
                     return;
                 }

                 GetSelectedILD2(items);
             });


                SelectionChangedCommandWireSize = new RelayCommand<IList>(
               items =>
               {
                   if (items == null)
                   {
                       return;
                   }
                   GetSelectedWireSize(items);
               });



                SelectionChangedCommandProductionPlan = new RelayCommand<IList>(
             items =>
             {
                 if (items == null)
                 {
                     return;
                 }

                 GetSelectedProductionPlan(items);
             });

                SelectionChangedCommandCustomer = new RelayCommand<IList>(
                  items =>
                  {
                      if (items == null)
                      {
                          return;
                      }

                      GetSelectedCustomer(items);
                  });

                SelectionChangedCommandConversion = new RelayCommand<string>(
               items =>
               {
                   if (items == null)
                   {
                       return;
                   }
                   GetSelectedConversion();
               });
                CmdPkgUnit = new RelayCommand<object>(items => { if (items == null) { return; } InsertPackingUnit(items); });

                cmdFeedbackRpt = new RelayCommand(() => { FeedbackReport(); });
                CommandForLoadBackFlip = new RelayCommand(Load);
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                SelectionChangedCommandUOM = new RelayCommand<IList>(items => {if (items == null) { return;} GetSelectedUOM(items);});

                #endregion

                GoodsDetails = new ObservableCollection<EPR_T001>();

                CollectionPlant = CollectionViewSource.GetDefaultView(MC.plant);
                CollectionPlant.Filter = new Predicate<object>(FilterPlant);

                CollectionMachineType = CollectionViewSource.GetDefaultView(MC.MachineType);
                CollectionMachineType.Filter = new Predicate<object>(FilterMachineType);

                CollectionMachine = CollectionViewSource.GetDefaultView(MC.Machine);
                CollectionMachine.Filter = new Predicate<object>(FilterMachine);

                CollectionModel = CollectionViewSource.GetDefaultView(MC.Model);
                CollectionModel.Filter = new Predicate<object>(FilterModel);

                CollectionProduct = CollectionViewSource.GetDefaultView(MC.Product);
                CollectionProduct.Filter = new Predicate<object>(FilterProduct);

                CollectionBallDia = CollectionViewSource.GetDefaultView(MC.BallDia);
                CollectionBallDia.Filter = new Predicate<object>(FilterBallDia);

                CollectionBallMake = CollectionViewSource.GetDefaultView(MC.BallMake);
                CollectionBallMake.Filter = new Predicate<object>(FilterBallMake);

                CollectionWireMake = CollectionViewSource.GetDefaultView(MC.WireMake);
                CollectionWireMake.Filter = new Predicate<object>(FilterWireMake);

                CollectionBallType = CollectionViewSource.GetDefaultView(MC.BallType);
                CollectionBallType.Filter = new Predicate<object>(FilterBallType);

                CollectionINK = CollectionViewSource.GetDefaultView(MC.INK);
                CollectionINK.Filter = new Predicate<object>(FilterINK);

                CollectionILD = CollectionViewSource.GetDefaultView(MC.ILD);
                CollectionILD.Filter = new Predicate<object>(FilterILD);

                List<ZADM_M007_P> ILD_LIST_OBJ = MC.ILD.Where(item => item.ild != null).ToList();
                CollectionILD2 = CollectionViewSource.GetDefaultView(ILD_LIST_OBJ);
                CollectionILD2.Filter = new Predicate<object>(FilterILD2);

                CollectionProductionPlan = CollectionViewSource.GetDefaultView(MC.ProductionPlan);
                CollectionProductionPlan.Filter = new Predicate<object>(FilterProductionPlanning);

                CollectionWireSize = CollectionViewSource.GetDefaultView(MC.WireSize);
                CollectionWireSize.Filter = new Predicate<object>(FilterWireSize);

                CollectionCustomer = CollectionViewSource.GetDefaultView(MC.Customer);
                CollectionCustomer.Filter = new Predicate<object>(FilterCustomer);

                DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
                DataGridCollection.Filter = new Predicate<object>(Filter);
                DataGridCollection.SortDescriptions.Add(new SortDescription("id", ListSortDirection.Descending));

                PkgUnitCollection = CollectionViewSource.GetDefaultView(MC.PkgUnitList);
                PkgUnitCollection.Filter = new Predicate<object>(Filter_PkgUnit);
                StringListPkgUOM = MC.PkgUnitList.Select(x => x.pkgunit).ToList();

                CollectionUOM = CollectionViewSource.GetDefaultView(MC.UOM);
                CollectionUOM.Filter = new Predicate<object>(FilterUOM);

                //SelectedList_new = MC.ILDChart_New;
                //IList list = SelectedList_new as IList;
                //List<EPR_T001> GetSelectedILDTemp = list.Cast<EPR_T001>().ToList();

                //if (GetSelectedILDTemp.Count > 0)
                //{
                //    SelectedEPR_T001_New.MachineCode = GetSelectedILDTemp[0].MachineCode;
                //    SelectedEPR_T001_New.machine_id = GetSelectedILDTemp[0].machine_id;
                //    SelectedEPR_T001_New.start_dt = GetSelectedILDTemp[0].start_dt;
                //    SelectedEPR_T001_New.ModelCode = GetSelectedILDTemp[0].ModelCode;
                //    SelectedEPR_T001_New.model_id = GetSelectedILDTemp[0].model_id;
                //    SelectedEPR_T001_New.item_code= GetSelectedILDTemp[0].item_code;
                //    SelectedEPR_T001_New.ink = GetSelectedILDTemp[0].ink;
                //    SelectedEPR_T001_New.ild = GetSelectedILDTemp[0].ild;
                //    SelectedEPR_T001_New.wire_make = GetSelectedILDTemp[0].wire_make;
                //    SelectedEPR_T001_New.ball_make = GetSelectedILDTemp[0].ball_make;
                //    SelectedEPR_T001_New.ball_dia = GetSelectedILDTemp[0].ball_dia;
                //    SelectedEPR_T001_New.tds_no = GetSelectedILDTemp[0].tds_no;

                //    SelectedEPR_T001.MachineCode = GetSelectedILDTemp[0].MachineCode;
                //    SelectedEPR_T001.machine_id = GetSelectedILDTemp[0].machine_id;
                //    SelectedEPR_T001.start_dt = GetSelectedILDTemp[0].start_dt;
                //}
                DefaultValues();
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
            try
            {
                //SelectedEPR_T001.doc_cat = "SO";
                SelectedEPR_T001.doc_type = "SO";
                SelectedEPR_T001.Type = "CN";
                SelectedEPR_T001.PlantName = AppSessionState.location_Id;
                SelectedEPR_T001.location_Id = AppSessionState.location_Id;
                SelectedEPR_T001.comp_code = AppSessionState.comp_code;
                SelectedEPR_T001.add_by = AppSessionState.UserID;
                SelectedEPR_T001.editby = AppSessionState.UserID;
                SelectedEPR_T001.active = true;
                SelectedEPR_T001.t_status = "001";
                SelectedEPR_T001.order_no = "";
                SelectedEPR_T001.start_dt = DateTime.Now.Date;
                SelectedEPR_T001.machinecode = "Select";
                SelectedEPR_T001.client = AppSessionState.client;
                SelectedEPR_T001.ts_code = ts_code_vm;
                SelectedEPR_T001.user_source1 = AppSessionState.UserSource1;
                SelectedEPR_T001.user_source2 = AppSessionState.UserSource2;
                SelectedEPR_T001.userid = AppSessionState.UserID;
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
        private void InsertPackingUnit(object InputValue)
        {
            try
            {
                string Request = "";
                ZADM_M017_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.PkgUnitList.Where(x => x.pkgunit.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M017_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    SelectedEPR_T001.pack_style = POPUPEntityObject.id;
                    SelectedEPR_T001.PackingUnit = POPUPEntityObject.pkgunit;
                    SelectedEPR_T001.Unit = POPUPEntityObject.unit_code;
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
        private void FeedbackReport()
        {
            if ((SelectedEPR_T001.prod_plan == null || SelectedEPR_T001.prod_plan == " ") && SelectedEPR_T001.PartyId == null || SelectedEPR_T001.PartyId == " ")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Select Either plann no. or Customer....", this.Title);
                showMessageService.ShowMessage();
            }
            else
            {
                if (SelectedEPR_T001.prod_plan != null && SelectedEPR_T001.prod_plan != " ")
                {
                    string Request = "LoadFeedbackRpt" + "!@" + SelectedEPR_T001.prod_plan + "!@" + SelectedEPR_T001.ItemCode + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code;
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MCTemp, Request, "ConversionNoteFeedback", "Production", "", 0, "FeedBack ");
                    RptFeedback = MCTemp.RptFeedback;

                    if (RptFeedback.Count > 0)
                    {
                        object[] objDataSource = new object[3];
                        string[] objDataSourceName = new string[3];

                        objDataSource[0] = MCTemp.RptFeedback;

                        objDataSourceName[0] = "dsFeedbackRpt";
                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\QualityFeedBack.rdlc", "FeedBack");
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Their is no feedback....", this.Title);
                        showMessageService.ShowMessage();
                    }
                }

                else if (SelectedEPR_T001.PartyId != null || SelectedEPR_T001.PartyId != " ")
                {
                    if (SelectedEPR_T001.ItemCode == null || SelectedEPR_T001.ItemCode == " ")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please select Product...", this.Title);
                        showMessageService.ShowMessage();
                    }
                    else
                    {
                        string Request = "LoadFeedbackRpt2" + "!@" + SelectedEPR_T001.PartyId + "!@" + SelectedEPR_T001.ItemCode + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code;
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MCTemp, Request, "ConversionNoteFeedback", "Production", "", 0, "FeedBack ");
                        RptFeedback = MCTemp.RptFeedback;
                        if (RptFeedback.Count > 0)
                        {
                            object[] objDataSource = new object[3];
                            string[] objDataSourceName = new string[3];

                            objDataSource[0] = MCTemp.RptFeedback;

                            objDataSourceName[0] = "dsFeedbackRpt";
                            ReportManager ReportManager = new ReportManager();
                            ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\QualityFeedBack.rdlc", "FeedBack");
                        }
                        else
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Their is no feedback....", this.Title);
                            showMessageService.ShowMessage();
                        }

                    }
                }
            }
        }

        private void Load()
        {

            if (SelectedEPR_T001.Fromdate != null && SelectedEPR_T001.ToDate != null)
            {
                if (SelectedEPR_T001.temp_status != null || SelectedEPR_T001.temp_status != " ")
                {
                    string Request = "LoadFromDateToDate" + "!@" + Convert.ToDateTime(SelectedEPR_T001.Fromdate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(SelectedEPR_T001.ToDate).ToString("MM/dd/yyyy") + "!@" + SelectedEPR_T001.temp_status + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code;
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MCTemp, Request, "ConversionNoteFeedback", "Production", "", 0, "FeedBack ");
                    SelectedList = MCTemp.ILDChart;
                    DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
                    DataGridCollection.Filter = new Predicate<object>(Filter);
                    DataGridCollection.SortDescriptions.Add(new SortDescription("id", ListSortDirection.Descending));
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Status....", this.Title);
                    showMessageService.ShowMessage();
                }
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
                    Request = SelectedEPR_T001.client + "!@" + SelectedEPR_T001.comp_code + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }
        #region · Command Actions ·

        protected override void OnSaveAction(InquiryActionResult<EPR_T001> result)
        {
            try
            {
                SelectedEPR_T001.ts_code = ts_code_vm;
                this.SelectedEPR_T001.EndEdit();
                ObjectSerializationService objSer = new ObjectSerializationService();

                //if (ValidateControls() == true)
                //{
                SelectedEPR_T001.Type = "CN";
                SelectedEPR_T001.add_by = AppSessionState.UserID;
                SelectedEPR_T001.location_Id = Convert.ToString(AppSessionState.location_Id);
                SelectedEPR_T001.comp_code = AppSessionState.comp_code;
                SelectedEPR_T001.client = AppSessionState.client;
                SelectedEPR_T001.PlantName = AppSessionState.location_Id;

                if (blNew == true)
                {

                    //SelectedEPR_T001.XmlDataDocument_EPR_T001 = objSer.ObjectToXML(GoodsDetails);
                    SelectedEPR_T001.XmlDataDocument_EPR_T001 = objSer.ObjectToXML(SelectedEPR_T001);
                    SelectedEPR_T001 = repository.SaveWithReturnDomainObject<EPR_T001>(SelectedEPR_T001, "ILDChart", "Production");
                    SelectedList.Add(SelectedEPR_T001);
                    _dataGridCollection.Refresh();

                    blNew = false;
                }
                else if (blNew == false)
                {
                    SelectedEPR_T001.XmlDataDocument_EPR_T001 = objSer.ObjectToXML(SelectedEPR_T001);
                    SelectedEPR_T001 = repository.UpdateWithReturnDomainObject<EPR_T001>(SelectedEPR_T001, "ILDChart", "Production");
                    //SelectedList.Add(SelectedEPR_T001);                     
                }
                //for (int i = 0; i < SelectedList.Count; i++)
                //{
                //    SelectedList[i].active = false;
                //}
                _dataGridCollection.Refresh();
                MessageBox.Show("Record Saved Successfully");
                //}
                //else
                //{
                //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //    showMessageService.ButtonSetup = DialogButton.Ok;
                //    showMessageService.Caption = "Message";
                //    showMessageService.Text = String.Format("Please Select Items", this.Title);
                //    showMessageService.ShowMessage();
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
        protected override void OnCreateAction(InquiryActionResult<EPR_T001> result)
        {
            blNew = true;

            GoodsDetails = new ObservableCollection<EPR_T001>();
            GoodsDetails.Clear();


            _dataGridCollection.Refresh();
            SelectedEPR_T001 = new EPR_T001();


            SelectedEPR_T001_New = new EPR_T001();
            
            SelectedEPR_T001_New.ValidateAsync().Wait();
            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<EPR_T001> result)
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

                this.SelectedEPR_T001.EndEdit();
                ObjectSerializationService objSer = new ObjectSerializationService();
                SelectedEPR_T001.Type = "CN";
                SelectedEPR_T001.XmlDataDocument_EPR_T001 = objSer.ObjectToXML(SelectedEPR_T001);
                string xdoc = objSer.ObjectToXML(SelectedEPR_T001);
                string response = repository.Delete(xdoc, "ILDChart", "Production");
                SelectedList.Remove(SelectedEPR_T001);
                SelectedEPR_T001 = new EPR_T001();
                GoodsDetails = new ObservableCollection<EPR_T001>();
                GoodsDetails.Clear();
                _dataGridCollection.Refresh();
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<EPR_T001> result)
        {
            SelectedEPR_T001.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<EPR_T001> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<EPR_T001> result)
        {
            SelectedList = SelectedList;
            SelectedEPR_T001 = SelectedEPR_T001;
        }
        protected override void OnHelpAction(InquiryActionResult<EPR_T001> result)
        {
            SelectedList = SelectedList;
            SelectedEPR_T001 = SelectedEPR_T001;
        }
        protected override void OnPrintAction(InquiryActionResult<EPR_T001> result)
        {
            if (SelectedEPR_T001.machine_id != null)
            {
                SelectedList = SelectedList;
                SelectedEPR_T001 = SelectedEPR_T001;
                string ReportName = "";

                string supplierid = "";
                supplierid = AppSessionState.comp_code.ToString() + "!@" + AppSessionState.location_Id + "!@" + SelectedEPR_T001.machine_id.ToString() + "!@" + SelectedEPR_T001.order_no + "!@" + SelectedEPR_T001.pre_order_no + "!@" + SelectedEPR_T001.ItemCode;

                MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MCTemp, "EPR_T001_Data", "ILDChart", "Production", "RPTConversion", 0, supplierid);

                object[] objDataSource = new object[5];
                string[] objDataSourceName = new string[5];
                //MC.Delivery_Note.Clear();
                //MC.Delivery_Note.Add(SelectedLOG_T001_A);          

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == SelectedEPR_T001.comp_code).ToList();
                objDataSource[0] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == SelectedEPR_T001.location_Id).ToList();
                var Result1 = MCTemp.RPTINK.Where(CN => CN.order_no == SelectedEPR_T001.order_no).ToList();
                var Result2 = MCTemp.RPTINK.Where(CN => CN.order_no == SelectedEPR_T001.pre_order_no).ToList();
                objDataSource[1] = Result;

                //objDataSource[2] = MCTemp.RPTINK;
                objDataSource[2] = Result1;
                objDataSource[3] = Result2;
                objDataSource[4] = MCTemp.Rptapproval;

                objDataSourceName[0] = "dsCompany";
                objDataSourceName[1] = "dsLocation";
                objDataSourceName[2] = "DSILDInk";
                objDataSourceName[3] = "DSILDInk1";
                objDataSourceName[4] = "dsRptapproval";


                ReportManager ReportManager = new ReportManager();

                string ReportDisplayName = SelectedEPR_T001.PartyName + "_" + SelectedEPR_T001.order_no;
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Production\\"+MC.DocumentTypes[0].report_name, getParametersList(), ReportDisplayName);
                //ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Production\\ConversionNote.rdlc", getParametersList(), "ConversionNote");
                
            }
            else
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Machine", this.Title);
                showMessageService.ShowMessage();
            }

        }
        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }
        protected override void OnRefreshCommand(InquiryActionResult<EPR_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<EPR_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<EPR_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<EPR_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<EPR_T001> result)
        {
            throw new NotImplementedException();
        }
        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                var filepath = new Uri(@"E:\Reflection_TFS\Client\Reflection.Shell\Reflection.Presentation.Resources\Images\Emp17.jpg");
                var path = filepath.AbsolutePath;
                result.Add("ImagePath", path);
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
            return result;
        }
        #endregion

        #region Filters For Plant
        private void FilterCollectionPlant()
        {
            if (_CollectionPlant != null)
            {
                _CollectionPlant.Refresh();
            }
        }
        public string FilterStringPlant
        {
            get { return _filterStringPlant; }
            set
            {
                _filterStringPlant = value;
                RaisePropertyChanged("FilterStringPlant");
                FilterCollectionPlant();
            }
        }
        public bool FilterPlant(object obj)
        {
            var data = obj as ADM_M003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringPlant))
                {
                    return (data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterStringPlant.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Machine Type
        private void FilterCollectionMachineType()
        {
            if (_CollectionMachineType != null)
            {
                _CollectionMachineType.Refresh();
            }
        }
        public string FilterStringMachineType
        {
            get { return _filterStringMachineType; }
            set
            {
                _filterStringMachineType = value;
                RaisePropertyChanged("FilterStringMachineType");
                FilterCollectionMachineType();
            }
        }
        public bool FilterMachineType(object obj)
        {
            var data = obj as ZADM_M013_P_machine_type;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringMachineType))
                {
                    return (data.mctype != null && data.mctype.ToString().ToLower().Contains(_filterStringMachineType.ToLower()));
                }
                return true;
            }
            return false;
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
            var data = obj as ZADM_M013_P;
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

        #region Filters For Model
        private void FilterCollectionModel()
        {
            if (_CollectionModel != null)
            {
                _CollectionModel.Refresh();
            }
        }
        public string FilterStringModel
        {
            get { return _filterStringModel; }
            set
            {
                _filterStringModel = value;
                RaisePropertyChanged("FilterStringModel");
                FilterCollectionModel();
            }
        }
        public bool FilterModel(object obj)
        {
            var data = obj as ZADM_M009_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringModel))
                {
                    return (data.modelno != null && data.modelno.ToString().ToLower().Contains(_filterStringModel.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Product
        private void FilterCollectionProduct()
        {
            if (_CollectionProduct != null)
            {
                _CollectionProduct.Refresh();
            }
        }
        public string FilterStringProduct
        {
            get { return _filterStringProduct; }
            set
            {
                _filterStringProduct = value;
                RaisePropertyChanged("FilterStringProduct");
                FilterCollectionProduct();
            }
        }
        public bool FilterProduct(object obj)
        {
            var data = obj as ADM_M022_P_ESSEM;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringProduct))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterStringProduct.ToLower()) ||
                            (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterStringProduct.ToLower())));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For BallDia
        private void FilterCollectionBallDia()
        {
            if (_CollectionBallDia != null)
            {
                _CollectionBallDia.Refresh();
            }
        }
        public string FilterStringBallDia
        {
            get { return _filterStringBallDia; }
            set
            {
                _filterStringBallDia = value;
                RaisePropertyChanged("FilterStringBallDia");
                FilterCollectionBallDia();
            }
        }
        public bool FilterBallDia(object obj)
        {
            var data = obj as ZADM_M001_PopUp;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringBallDia))
                {
                    return (data.Ball_dia != null && data.Ball_dia.ToString().ToLower().Contains(_filterStringBallDia.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For BallMake
        private void FilterCollectionBallMake()
        {
            if (_CollectionBallMake != null)
            {
                _CollectionBallMake.Refresh();
            }
        }
        public string FilterStringBallMake
        {
            get { return _filterStringBallMake; }
            set
            {
                _filterStringBallMake = value;
                RaisePropertyChanged("FilterStringBallMake");
                FilterCollectionBallMake();
            }
        }
        public bool FilterBallMake(object obj)
        {
            var data = obj as ADM_M032_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringBallMake))
                {
                    return (data.Make != null && data.Make.ToString().ToLower().Contains(_filterStringBallMake.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For WireMake
        private void FilterCollectionWireMake()
        {
            if (_CollectionWireMake != null)
            {
                _CollectionWireMake.Refresh();
            }
        }
        public string FilterStringWireMake
        {
            get { return _filterStringWireMake; }
            set
            {
                _filterStringWireMake = value;
                RaisePropertyChanged("FilterStringWireMake");
                FilterCollectionWireMake();
            }
        }
        public bool FilterWireMake(object obj)
        {
            var data = obj as ADM_M032_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringWireMake))
                {
                    return (data.Make != null && data.Make.ToString().ToLower().Contains(_filterStringWireMake.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For BallType
        private void FilterCollectionBallType()
        {
            if (_CollectionBallType != null)
            {
                _CollectionBallType.Refresh();
            }
        }
        public string FilterStringBallType
        {
            get { return _filterStringBallType; }
            set
            {
                _filterStringBallType = value;
                RaisePropertyChanged("FilterStringBallType");
                FilterCollectionBallType();
            }
        }
        public bool FilterBallType(object obj)
        {
            var data = obj as ZADM_M002_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringBallType))
                {
                    return (data.ball_type != null && data.ball_type.ToString().ToLower().Contains(_filterStringBallType.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For INK
        private void FilterCollectionINK()
        {
            if (_CollectionINK != null)
            {
                _CollectionINK.Refresh();
            }
        }
        public string FilterStringINK
        {
            get { return _filterStringINK; }
            set
            {
                _filterStringINK = value;
                RaisePropertyChanged("FilterStringINK");
                FilterCollectionINK();
            }
        }
        public bool FilterINK(object obj)
        {
            var data = obj as ZADM_M006_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringINK))
                {
                    return (data.ink != null && data.ink.ToString().ToLower().Contains(_filterStringINK.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For ILD
        private void FilterCollectionILD()
        {
            if (_CollectionILD != null)
            {
                _CollectionILD.Refresh();
            }
        }
        public string FilterStringILD
        {
            get { return _filterStringILD; }
            set
            {
                _filterStringILD = value;
                RaisePropertyChanged("FilterStringILD");
                FilterCollectionILD();
            }
        }
        public bool FilterILD(object obj)
        {
            var data = obj as ZADM_M007_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringILD))
                {
                    return (data.ild != null && data.ild.ToString().ToLower().Contains(_filterStringILD.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion
        #region Filters For ILD 2
        private void FilterCollectionILD2()
        {
            if (_CollectionILD2 != null)
            {
                _CollectionILD2.Refresh();
            }
        }
        public string FilterStringILD2
        {
            get { return _filterStringILD2; }
            set
            {
                _filterStringILD2 = value;
                RaisePropertyChanged("FilterStringILD2");
                FilterCollectionILD2();
            }
        }
        public bool FilterILD2(object obj)
        {
            var data = obj as ZADM_M007_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringILD2))
                {
                    return (data.ild != null && data.ild.ToString().ToLower().Contains(_filterStringILD2.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For SalesOrder
        private void FilterCollectionProductionPlan()
        {
            if (_CollectionProductionPlan != null)
            {
                _CollectionProductionPlan.Refresh();
            }
        }
        public string FilterStringProductionPlan
        {
            get { return _filterStringProductionPlan; }
            set
            {
                _filterStringProductionPlan = value;
                RaisePropertyChanged("FilterStringProductionPlan");
                FilterCollectionProductionPlan();
            }
        }
        public bool FilterProductionPlanning(object obj)
        {
            var data = obj as EPR_T004_A_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringProductionPlan))
                {
                    return (data.sales_order_no != null && data.sales_order_no.ToString().ToLower().Contains(_filterStringProductionPlan.ToLower())) ||
                     (data.plan_no != null && data.plan_no.ToString().ToLower().Contains(_filterStringProductionPlan.ToLower())) ||
                     (data.plan_date != null && data.plan_date.ToString().ToLower().Contains(_filterStringProductionPlan.ToLower())) ||
                     (data.machine_no != null && data.machine_no.ToString().ToLower().Contains(_filterStringProductionPlan.ToLower())) ||
                     (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterStringProductionPlan.ToLower())) ||
                     (data.para1 != null && data.para1.ToString().ToLower().Contains(_filterStringProductionPlan.ToLower())) ||
                     (data.para5 != null && data.para5.ToString().ToLower().Contains(_filterStringProductionPlan.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Customer
        private void FilterCollectionCustomer()
        {
            if (_CollectionCustomer != null)
            {
                _CollectionCustomer.Refresh();
            }
        }
        public string FilterStringCustomer
        {
            get { return _filterStringCustomer; }
            set
            {
                _filterStringCustomer = value;
                RaisePropertyChanged("FilterStringCustomer");
                FilterCollectionCustomer();
            }
        }
        public bool FilterCustomer(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringCustomer))
                {
                    return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterStringCustomer.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For UOM
        private void FilterCollectionUOM()
        {
            if (_CollectionUOM != null)
            {
                _CollectionUOM.Refresh();
            }
        }
        public string FilterStringUOM
        {
            get { return _filterStringUOM; }
            set
            {
                _filterStringUOM = value;
                RaisePropertyChanged("FilterStringUOM");
                FilterCollectionUOM();
            }
        }
        public bool FilterUOM(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringUOM))
                {
                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterStringUOM.ToLower()));
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
            var data = obj as EPR_T001;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.start_dt != null && data.start_dt.ToString().ToLower().Contains(_filterString.ToLower())) ||
                            (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterString.ToLower())) ||
                            (data.model_code != null && data.model_code.ToString().ToLower().Contains(_filterString.ToLower())) ||
                            (data.prod_plan != null && data.prod_plan.ToString().ToLower().Contains(_filterString.ToLower())) ||
                            (data.order_no != null && data.order_no.ToString().ToLower().Contains(_filterString.ToLower())) ||
                            (data.conv != null && data.conv.ToString().ToLower().Contains(_filterString.ToLower())) ||

                            // adding Ild and Ink

                           (data.ild != null && data.ild.ToString().ToLower().Contains(_filterString.ToLower()))||
                           (data.ink != null && data.ild.ToString().ToLower().Contains(_filterString.ToLower()));


                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For INK
        private void FilterCollectionWireSize()
        {
            if (_CollectionWireSize != null)
            {
                _CollectionWireSize.Refresh();
            }
        }
        public string FilterStringWireSize
        {
            get { return _filterStringWireSize; }
            set
            {
                _filterStringWireSize = value;
                RaisePropertyChanged("FilterStringWireSize");
                FilterCollectionWireSize();
            }
        }
        public bool FilterWireSize(object obj)
        {
            var data = obj as ZADM_M003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringINK))
                {
                    return (data.wire_size_id != null && data.wire_size_id.ToString().ToLower().Contains(_filterStringINK.ToLower())) ||
                        (data.wire_size != null && data.wire_size.ToString().ToLower().Contains(_filterStringINK.ToLower()));
                }
                return true;
            }
            return false;
        }
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
        #endregion
    }
}
