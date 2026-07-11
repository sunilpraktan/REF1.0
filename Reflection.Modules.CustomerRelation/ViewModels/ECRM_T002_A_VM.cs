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
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;
using Reflection.ReportingServices;
using System.Threading.Tasks;
using Reflection.Presentation.Common;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class ECRM_T002_A_VM : WorkspaceViewModel<ECRM_T002_A>
    {
        bool blNew = true;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        WebServiceRepository<ECRM_T002_A> repository = new WebServiceRepository<ECRM_T002_A>();
        WebServiceRepository<MultipleContext_ECRM_T002_A> repositoryM = new WebServiceRepository<MultipleContext_ECRM_T002_A>();
        MultipleContext_ECRM_T002_A MCTemp = new MultipleContext_ECRM_T002_A();
        MultipleContext_ECRM_T002_A MCQFR_No = new MultipleContext_ECRM_T002_A();

        private ICollectionView _dataGridCollection;

        private string _filterStringModel;
        private string _filterStringProdct;
        private string _filterStringParty;
        private string _filterStringILD;
        private string _filterStringINK;
        private string _filterStringPlant;
        private string _filterStringEmpRecv;
        private string _filterStringEmpHandl;

        private string _filterString;
        private int _dgSelectedIndex;

        private ObservableCollection<SalesInvoice_SingleReport> _dgReportMaster;
        public ObservableCollection<SalesInvoice_SingleReport> dgReportMaster
        {
            get { return _dgReportMaster; }
            set
            {
                if (_dgReportMaster != value)
                {
                    _dgReportMaster = value;


                    RaisePropertyChanged("dgReportMaster");

                }
            }
        }
        public List<ADM_M003> _ObjSupply = new List<ADM_M003>();
        private List<ADM_M003> ObjSupply
        {
            get { return _ObjSupply; }
            set
            {
                if (_ObjSupply != value)
                {
                    _ObjSupply = value;
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
        private SearchEntity _SearchEntityObject;
        public SearchEntity SearchEntityObject
        {
            get
            {
                return _SearchEntityObject;
            }
            set
            {
                if (_SearchEntityObject != value)
                {
                    _SearchEntityObject = value;
                    RaisePropertyChanged(nameof(SearchEntityObject));
                }
            }
        }
        #region ICollection
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }

        private ICollectionView _ModelCollection;
        public ICollectionView ModelCollection
        {
            get { return _ModelCollection; }
            set
            {
                _ModelCollection = value;

                RaisePropertyChanged("ModelCollection");
            }
        }
        private ICollectionView _ProdctCollection;
        public ICollectionView ProdctCollection
        {
            get { return _ProdctCollection; }
            set
            {
                _ProdctCollection = value;

                RaisePropertyChanged("ProdctCollection");
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
        private ICollectionView _ILDCollection;
        public ICollectionView ILDCollection
        {
            get { return _ILDCollection; }
            set
            {
                _ILDCollection = value;

                RaisePropertyChanged("ILDCollection");
            }
        }
        private ICollectionView _INKCollection;
        public ICollectionView INKCollection
        {
            get { return _INKCollection; }
            set
            {
                _INKCollection = value;

                RaisePropertyChanged("INKCollection");
            }
        }
        private ICollectionView _PlantCollection;
        public ICollectionView PlantCollection
        {
            get { return _PlantCollection; }
            set
            {
                _PlantCollection = value;

                RaisePropertyChanged("PlantCollection");
            }
        }
        private ICollectionView _EmpRecvCollection;
        public ICollectionView EmpRecvCollection
        {
            get { return _EmpRecvCollection; }
            set
            {
                _EmpRecvCollection = value;

                RaisePropertyChanged("EmpRecvCollection");
            }
        }
        private ICollectionView _EmpHandlCollection;
        public ICollectionView EmpHandlCollection
        {
            get { return _EmpHandlCollection; }
            set
            {
                _EmpHandlCollection = value;

                RaisePropertyChanged("EmpHandlCollection");
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

        private ICollectionView _MakeCollection;
        public ICollectionView MakeCollection
        {
            get { return _MakeCollection; }
            set
            {
                _MakeCollection = value;
                RaisePropertyChanged("MakeCollection");
            }
        }

        private ICollectionView _sales_orgCollection;
        public ICollectionView Salse_OrgCollection
        {
            get { return _sales_orgCollection; }
            set
            {
                _sales_orgCollection = value;
                RaisePropertyChanged("Salse_OrgCollection");
            }
        }

        private ICollectionView _salse_GroupCollection;
        public ICollectionView Salse_GroupCollection
        {
            get { return _salse_GroupCollection; }
            set
            {
                _salse_GroupCollection = value;
                RaisePropertyChanged("Salse_GroupCollection");
            }
        }
        private ICollectionView _unit_inv_qtyCollection;
        public ICollectionView unit_inv_qtyCollection
        {
            get { return _unit_inv_qtyCollection; }
            set
            {
                _unit_inv_qtyCollection = value;
                RaisePropertyChanged("unit_inv_qtyCollection");
            }
        }
        private ICollectionView _unit_defect_qtyCollection;
        public ICollectionView unit_defect_qtyCollection
        {
            get { return _unit_defect_qtyCollection; }
            set
            {
                _unit_defect_qtyCollection = value;
                RaisePropertyChanged("unit_defect_qtyCollection");
            }
        }
        private List<NotificationData> _NotificationDataCollection;
        public List<NotificationData> NotificationDataCollection
        {
            get { return _NotificationDataCollection; }
            set
            {
                if (_NotificationDataCollection != value)
                {
                    _NotificationDataCollection = value;
                    RaisePropertyChanged("NotificationDataCollection");
                }
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
        public RelayCommand<IList> SelectionChangedCommandModel
        {
            get;
            private set;
        }

        public RelayCommand<IList> SelectionChangedCommandProdct
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandParty
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandILD
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandINK
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandPlant
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandEmpRecv
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandEmpHandl
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandDefect_desc
        {
            get;
            private set;
        }
        public RelayCommand<object> CommandSalseOrg { get; private set; }
        public RelayCommand<object> CommandSalseGroup { get; private set; }
        public RelayCommand<object> CMDMake { get; private set; }
        public RelayCommand<object> CMDCustomerInk { get; private set; }
        public RelayCommand<IList> CMDUnitinvqty { get; private set; }
        public RelayCommand<IList> CMDUnitDefectqty { get; private set; }
        public RelayCommand<object> CommandLoadBackFlipData { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByByDocumentNumber { get; private set; }
        #endregion

        #region ECRM_T002_A
        private List<ECRM_T002_A> _SelectedList;
        public List<ECRM_T002_A> SelectedList
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
        private ECRM_T002_A _SelectedECRM_T002_A;
        public ECRM_T002_A SelectedECRM_T002_A
        {
            get
            {
                this.ErrorExist = _SelectedECRM_T002_A.HasErrors;
                return _SelectedECRM_T002_A;
            }
            set
            {
                if (_SelectedECRM_T002_A != value)
                {
                    _SelectedECRM_T002_A = value;
                    this.ErrorExist = _SelectedECRM_T002_A.HasErrors;
                    RaisePropertyChanged("SelectedECRM_T002_A");
                    value.BeginEdit();
                }
            }
        }
        #endregion

        #region ECRM_T002_B
        private static ObservableCollection<ECRM_T002_B> _QFRDetails = new ObservableCollection<ECRM_T002_B>();
        public ObservableCollection<ECRM_T002_B> QFRDetails
        {
            get { return _QFRDetails; }
            set
            {
                if (_QFRDetails != value)
                {
                    _QFRDetails = value;

                    RaisePropertyChanged("QFRDetails");
                }
            }
        }
        private List<ECRM_T002_B> _SelectedECRM_T002_B_List;
        public List<ECRM_T002_B> SelectedECRM_T002_B_List
        {
            get
            {
                return _SelectedECRM_T002_B_List;
            }
            set
            {
                _SelectedECRM_T002_B_List = value;
                RaisePropertyChanged("SelectedECRM_T002_B_List");
            }
        }

        #endregion

        #region ZADM_M009_P
        private List<ZADM_M009_P> _SelectedListOfModelList;
        public List<ZADM_M009_P> SelectedListOfModelList
        {
            get { return _SelectedListOfModelList; }
            set
            {
                if (_SelectedListOfModelList != value)
                {
                    _SelectedListOfModelList = value;
                    RaisePropertyChanged("SelectedListOfModelList");
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

        #region ADM_M028_P
        private List<ADM_M028_P> _SelectedListOfPartyList;
        public List<ADM_M028_P> SelectedListOfPartyList
        {
            get { return _SelectedListOfPartyList; }
            set
            {
                if (_SelectedListOfPartyList != value)
                {
                    _SelectedListOfPartyList = value;
                    RaisePropertyChanged("SelectedListOfPartyList");
                }
            }
        }



        #endregion
        #region ZADM_M007_P
        private List<ZADM_M007_P> _SelectedListOfILDList;
        public List<ZADM_M007_P> SelectedListOfILDList
        {
            get { return _SelectedListOfILDList; }
            set
            {
                if (_SelectedListOfILDList != value)
                {
                    _SelectedListOfILDList = value;
                    RaisePropertyChanged("SelectedListOfILDList");
                }
            }
        }
        #endregion
        #region ZADM_M006_P
        private List<ZADM_M006_P> _SelectedListOfINKList;
        public List<ZADM_M006_P> SelectedListOfINKList
        {
            get { return _SelectedListOfINKList; }
            set
            {
                if (_SelectedListOfINKList != value)
                {
                    _SelectedListOfINKList = value;
                    RaisePropertyChanged("SelectedListOfINKList");
                }
            }
        }
        #endregion
        #region ADM_M003_P
        private List<ADM_M003_P> _SelectedListOfPlantList;
        public List<ADM_M003_P> SelectedListOfPlantList
        {
            get { return _SelectedListOfPlantList; }
            set
            {
                if (_SelectedListOfPlantList != value)
                {
                    _SelectedListOfPlantList = value;
                    RaisePropertyChanged("SelectedListOfPlantList");
                }
            }
        }


        #endregion
        #region ADM_M024_P
        private List<ADM_M024_P> _SelectedListOfEmpRecvList;
        public List<ADM_M024_P> SelectedListOfEmpRecvList
        {
            get { return _SelectedListOfEmpRecvList; }
            set
            {
                if (_SelectedListOfEmpRecvList != value)
                {
                    _SelectedListOfEmpRecvList = value;
                    RaisePropertyChanged("SelectedListOfEmpRecvList");
                }
            }
        }

        private List<ADM_M001_A_P> _SalesOrganisationList;
        public List<ADM_M001_A_P> SalesOrganisationList
        {
            get
            {
                return _SalesOrganisationList;
            }
            set
            {
                _SalesOrganisationList = value;
                RaisePropertyChanged("SalesOrganisationList");
            }
        }

        private List<ADM_M001_H_P> _SalesGroupList;
        public List<ADM_M001_H_P> SalesGroupList
        {
            get
            {
                return _SalesGroupList;
            }
            set
            {
                _SalesGroupList = value;
                RaisePropertyChanged("SalesGroupList");
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
        private List<string> _strListSalesOrg;
        public List<string> StringListSalesOrg
        {
            get { return _strListSalesOrg; }
            set
            {
                if (_strListSalesOrg != value)
                {
                    _strListSalesOrg = value;
                }
            }
        }

        private List<string> _strListSalesGroup;
        public List<string> StringListSalesGroup
        {
            get { return _strListSalesGroup; }
            set
            {
                if (_strListSalesGroup != value)
                {
                    _strListSalesGroup = value;
                }
            }
        }

        private List<string> _StringListMake;
        public List<string> StringListMake
        {
            get { return _StringListMake; }
            set
            {
                if (_StringListMake != value)
                {
                    _StringListMake = value;
                }
            }
        }
        private List<string> _StringListCustInk;
        public List<string> StringListCustInk
        {
            get { return _StringListCustInk; }
            set
            {
                if (_StringListCustInk != value)
                {
                    _StringListCustInk = value;
                }
            }
        }

        MultipleContext_ECRM_T002_A _MC = new MultipleContext_ECRM_T002_A();
        public MultipleContext_ECRM_T002_A MC
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

        public ECRM_T002_A_VM(string ts_code)
            : base()
        {
            this.ts_code_vm = ts_code;
            SearchEntityObject = new SearchEntity();
            SelectedList = new List<ECRM_T002_A>();
            SelectedECRM_T002_A = new ECRM_T002_A();
            MC = new MultipleContext_ECRM_T002_A();
            QFRDetails = new ObservableCollection<ECRM_T002_B>();
            SelectedECRM_T002_B_List = new List<ECRM_T002_B>();
            MC.QFRDetails = new ObservableCollection<ECRM_T002_B>();
            SelectedListOfPartyList = new List<ADM_M028_P>();
            SelectedECRM_T002_A.doc_cat = "QF";
            SelectedECRM_T002_A.doc_type = "QF";
            SelectedECRM_T002_A.client = AppSessionState.client;
            SearchEntityObject.from_date = DateTime.Now.Date;
            SearchEntityObject.to_date = DateTime.Now.Date;
            SearchEntityObject.active = true;
            LoadInitialData();
        }
        public ECRM_T002_A_VM(string ts_code, string doc_no)
            : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            SearchEntityObject = new SearchEntity();
            SelectedList = new List<ECRM_T002_A>();
            SelectedECRM_T002_A = new ECRM_T002_A();
            MC = new MultipleContext_ECRM_T002_A();
            QFRDetails = new ObservableCollection<ECRM_T002_B>();
            SelectedECRM_T002_B_List = new List<ECRM_T002_B>();
            MC.QFRDetails = new ObservableCollection<ECRM_T002_B>();
            SelectedListOfPartyList = new List<ADM_M028_P>();
            SelectedECRM_T002_A.doc_cat = "QF";
            SelectedECRM_T002_A.doc_type = "QF";
            SelectedECRM_T002_A.client = AppSessionState.client;
            SearchEntityObject.from_date = DateTime.Now.Date;
            SearchEntityObject.to_date = DateTime.Now.Date;
            SearchEntityObject.active = true;
            LoadInitialData();
        }
        private void LoadInitialData()
        {
            try
            {
                #region Commands
                SelectionChangedCommand = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }
                GetSelectedQFR_Dtails(items);
            });
                SelectionChangedCommandModel = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedModelDetails(items);
                });
                SelectionChangedCommandProdct = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedProdctDetails(items);
                });
                SelectionChangedCommandParty = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedPartyDetails(items);
                });
                SelectionChangedCommandILD = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedILDDetails(items);
                });
                SelectionChangedCommandINK = new RelayCommand<IList>(
               items =>
               {
                   if (items == null)
                   {
                       return;
                   }

                   GetSelectedINKDetails(items);
               });
                SelectionChangedCommandPlant = new RelayCommand<IList>(
               items =>
               {
                   if (items == null)
                   {
                       return;
                   }

                   GetSelectedPlantDetails(items);
               });
                SelectionChangedCommandEmpRecv = new RelayCommand<IList>(
              items =>
              {
                  if (items == null)
                  {
                      return;
                  }

                  GetSelectedEmpRecvDetails(items);
              });
                SelectionChangedCommandEmpHandl = new RelayCommand<IList>(items =>{if (items == null){ return;} GetSelectedEmpHandlDetails(items);});
                SelectionChangedCommandDefect_desc = new RelayCommand<IList>(
             items =>
             {
                 if (items == null)
                 {
                     return;
                 }

                 GetSelectedDefect_descDetails(items);
             });
                CommandSalseOrg = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseOrg(items); });
                CommandSalseGroup = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseGroup(items); });
                CMDMake = new RelayCommand<object>(items => { if (items == null) { return; } InsertMake(items); });
                CMDCustomerInk = new RelayCommand<object>(items => { if (items == null) { return; } InsertInk(items); });
                CMDUnitinvqty = new RelayCommand<IList>(items => { if (items == null) { return; } InsertUnitinvqty(items); });
                CMDUnitDefectqty = new RelayCommand<IList>(items => { if (items == null) { return; } InsertUnitDefectqty(items); });
                CommandLoadBackFlipData = new RelayCommand<object>(items => { if (items == null) { return; } LoadBackFlipData(items); });
                CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                #endregion
                //MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T002_A>(MC, "ECRM_T002_A_Data", "Quality_Feedback", "CRM", "LoadAll", 0, "");
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.client + "!@" + AppSessionState.EmpId;
                MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T002_A>(MC, Request, "Quality_Feedback", "CRM", "LoadAll", 0, "");

                SelectedList = MC.QulityFeedback;

                SelectedECRM_T002_A.quality_feedback_date = DateTime.Now;
                DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                ModelCollection = CollectionViewSource.GetDefaultView(MC.Models);
                ModelCollection.Filter = new Predicate<object>(ModelFilter);

                ProdctCollection = CollectionViewSource.GetDefaultView(MC.Products);
                ProdctCollection.Filter = new Predicate<object>(ProdctFilter);

                PartyCollection = CollectionViewSource.GetDefaultView(MC.Parties);
                PartyCollection.Filter = new Predicate<object>(PartyFilter);

                ILDCollection = CollectionViewSource.GetDefaultView(MC.ILD);
                ILDCollection.Filter = new Predicate<object>(ILDFilter);

                INKCollection = CollectionViewSource.GetDefaultView(MC.INK);
                INKCollection.Filter = new Predicate<object>(INKFilter);

                //PlantCollection = CollectionViewSource.GetDefaultView(MC.Plants);
                //PlantCollection.Filter = new Predicate<object>(PlantFilter);
                ObjSupply = (List<ADM_M003>)AppSessionState.ADM_M003_List;

                PlantCollection = CollectionViewSource.GetDefaultView(ObjSupply.ToList());
                PlantCollection.Filter = new Predicate<object>(PlantFilter);

                EmpRecvCollection = CollectionViewSource.GetDefaultView(MC.Employees.ToList());
                EmpRecvCollection.Filter = new Predicate<object>(EmpRecvFilter);

                EmpHandlCollection = CollectionViewSource.GetDefaultView(MC.Employees.ToList());
                EmpHandlCollection.Filter = new Predicate<object>(EmpHandlFilter);

                Defect_descCollection = CollectionViewSource.GetDefaultView(MC.Defect);
                Defect_descCollection.Filter = new Predicate<object>(Defect_descFilter);

                MakeCollection = CollectionViewSource.GetDefaultView(MC.MakeMaster);
                MakeCollection.Filter = new Predicate<object>(MakeFilter);
                StringListMake = MC.MakeMaster.Select(x => x.Make).ToList();

                SalesOrganisationList = (List<ADM_M001_A_P>)AppSessionState.ADM_M001_A_List;
                Salse_OrgCollection = CollectionViewSource.GetDefaultView(SalesOrganisationList);
                Salse_OrgCollection.Filter = new Predicate<object>(Filter_SalesOrg);
                StringListSalesOrg = SalesOrganisationList.Select(x => x.so_code).ToList();
                if (SalesOrganisationList.Count != 0)
                {
                    if (SalesOrganisationList.Count == 1)
                    {
                        SelectedECRM_T002_A.so_code = SalesOrganisationList[0].so_code;
                        SelectedECRM_T002_A.sales_org = SalesOrganisationList[0].sales_org;
                    }
                }
                else
                {
                    SelectedECRM_T002_A.so_code = "";
                }
                SalesGroupList = (List<ADM_M001_H_P>)AppSessionState.ADM_M001_H_List;
                Salse_GroupCollection = CollectionViewSource.GetDefaultView(SalesGroupList);
                Salse_GroupCollection.Filter = new Predicate<object>(Filter_SalesGroup);
                StringListSalesGroup = SalesGroupList.Select(x => x.sg_code).ToList();

                if (SalesGroupList.Count != 0)
                {
                    if (SalesGroupList.Count == 1)
                    {
                        SelectedECRM_T002_A.sg_code = SalesGroupList[0].sg_code;
                        SelectedECRM_T002_A.sg_name = SalesGroupList[0].sg_name;
                    }
                }
                else
                {
                    SelectedECRM_T002_A.sg_code = "";
                }
                unit_inv_qtyCollection = CollectionViewSource.GetDefaultView(MC.UnitMaster.ToList());
                unit_inv_qtyCollection.Filter = new Predicate<object>(UnitFilter);

                unit_defect_qtyCollection = CollectionViewSource.GetDefaultView(MC.UnitMaster.ToList());
                unit_defect_qtyCollection.Filter = new Predicate<object>(UnitDefectFilter);

                NotificationDataCollection = MC.NotificationData;
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
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";
                string ParametersStringValue = "";
                ECRM_T002_A ParameterEntityObject = null;
                SelectedECRM_T002_A = new ECRM_T002_A();
                QFRDetails = new ObservableCollection<ECRM_T002_B>();


                if (((IEnumerable)ParameterObject).Cast<ECRM_T002_A>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ECRM_T002_A>().ToList()[0];
                    Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + ParameterEntityObject.quality_feedback_no;
                    blNew = false;
                    MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T002_A>(MCTemp, Request, "Quality_Feedback", "CRM", "", 0, Request);
                    SelectedECRM_T002_A = MCTemp.QulityFeedback[0];
                    QFRDetails = MCTemp.QFRDetails;
                }
                SelectedTabControlIndex = 0;
                SelectedECRM_T002_A.ts_code = ts_code_vm;
                //SetBusinessEntitiesAfterLoad(ParametersStringValue, "");
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
        #region . User Defined Function .
        private void GetSelectedQFR_Dtails(IList QFRDetailList)
        {
            try
            {
                IList list = QFRDetailList as IList;
                List<ECRM_T002_A> GetSelectedQFRDetails = list.Cast<ECRM_T002_A>().ToList();

                if (GetSelectedQFRDetails.Count > 0)
                {
                    SelectedECRM_T002_A = (ECRM_T002_A)GetSelectedQFRDetails[0];

                    MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T002_A>(MCTemp, "ECRM_T002_A_Data", "Quality_Feedback", "CRM", "QFR_Details", 0, SelectedECRM_T002_A.quality_feedback_no);


                    if (SelectedECRM_T002_A != null)
                    {
                        MC.QFRDetails = MCTemp.QFRDetails;
                        QFRDetails = MCTemp.QFRDetails;
                    }
                    SelectedTabControlIndex = 0;
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
        private void LoadBackFlipData(object Parameter)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LoadBackFlipData" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + Convert.ToDateTime(SearchEntityObject.from_date).ToString() + "!@" + Convert.ToDateTime(SearchEntityObject.to_date).ToString() + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code + "!@" + AppSessionState.EmpId + "!@" + SearchEntityObject.active;
                MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T002_A>(MCTemp, Request, "Quality_Feedback", "CRM", "LoadAll", 0, "");

                SelectedList = MCTemp.QulityFeedback.ToList();
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
        private void GetSelectedModelDetails(IList ModelList)
        {
            IList list = ModelList as IList;
            List<ZADM_M009_P> SelectedModelDetailsTemp = list.Cast<ZADM_M009_P>().ToList();
            if (SelectedModelDetailsTemp.Count > 0)
            {
                SelectedECRM_T002_A.model_id = SelectedModelDetailsTemp[0].model_id;
                SelectedECRM_T002_A.ModelNm = SelectedModelDetailsTemp[0].modelno;
            }
        }
        private void GetSelectedProdctDetails(IList ProdctList)
        {
            IList list = ProdctList as IList;
            List<ADM_M022_P_ESSEM> SelectedProdctDetailsTemp = list.Cast<ADM_M022_P_ESSEM>().ToList();
            if (SelectedProdctDetailsTemp.Count > 0)
            {
                SelectedECRM_T002_A.ItemCode = SelectedProdctDetailsTemp[0].ItemCode;
                SelectedECRM_T002_A.product_name = SelectedProdctDetailsTemp[0].ItemName;

            }
        }
        private void GetSelectedPartyDetails(IList PartyList)
        {
            IList list = PartyList as IList;
            List<ADM_M028_P> SelectedPartyDetailsTemp = list.Cast<ADM_M028_P>().ToList();
            if (SelectedPartyDetailsTemp.Count > 0)
            {
                SelectedECRM_T002_A.PartyId = SelectedPartyDetailsTemp[0].PartyId;
                SelectedECRM_T002_A.PartyNm = SelectedPartyDetailsTemp[0].PartyNm;
            }
        }
        private void GetSelectedILDDetails(IList ILDList)
        {
            IList list = ILDList as IList;
            List<ZADM_M007_P> SelectedILDDetailsTemp = list.Cast<ZADM_M007_P>().ToList();
            if (SelectedILDDetailsTemp.Count > 0)
            {
                SelectedECRM_T002_A.ild_id = SelectedILDDetailsTemp[0].ild_id;
                SelectedECRM_T002_A.ild = SelectedILDDetailsTemp[0].ild;
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
                    Request = SelectedECRM_T002_A.client + "!@" + SelectedECRM_T002_A.comp_code + "!@" + InputValue.ToString();
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
        private void GetSelectedINKDetails(IList INKList)
        {
            IList list = INKList as IList;
            List<ZADM_M006_P> SelectedINKDetailsTemp = list.Cast<ZADM_M006_P>().ToList();
            if (SelectedINKDetailsTemp.Count > 0)
            {
                SelectedECRM_T002_A.ink_id = SelectedINKDetailsTemp[0].ink_id;
                SelectedECRM_T002_A.ink = SelectedINKDetailsTemp[0].ink;
            }
        }
        private void InsertInk(object InputValue)
        {
            try
            {
                string Request = "";
                ZADM_M006_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.INK.Where(x => x.ink.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M006_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    SelectedECRM_T002_A.cust_ink_id = POPUPEntityObject.ink_id;
                    SelectedECRM_T002_A.cust_ink = POPUPEntityObject.ink;

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
        private void GetSelectedPlantDetails(IList PlantList)
        {
            IList list = PlantList as IList;
            List<ADM_M003> SelectedPlantDetailsTemp = list.Cast<ADM_M003>().ToList();
            if (SelectedPlantDetailsTemp.Count > 0)
            {
                SelectedECRM_T002_A.location_Id = SelectedPlantDetailsTemp[0].location_Id;
                SelectedECRM_T002_A.LoctnNm = SelectedPlantDetailsTemp[0].LoctnNm;
            }
        }
        private void GetSelectedEmpRecvDetails(IList EmpRecvList)
        {
            IList list = EmpRecvList as IList;
            List<ADM_M024_P> SelectedEmpRecvDetailsTemp = list.Cast<ADM_M024_P>().ToList();
            if (SelectedEmpRecvDetailsTemp.Count > 0)
            {
                SelectedECRM_T002_A.cmplnt_RecvBy_cd = SelectedEmpRecvDetailsTemp[0].EmpId;
                SelectedECRM_T002_A.cmplnt_RecvBy_Name = SelectedEmpRecvDetailsTemp[0].EmpName;
            }
        }
        private void GetSelectedEmpHandlDetails(IList EmpHandlList)
        {
            IList list = EmpHandlList as IList;
            List<ADM_M024_P> SelectedEmpHandlDetailsTemp = list.Cast<ADM_M024_P>().ToList();
            if (SelectedEmpHandlDetailsTemp.Count > 0)
            {

                SelectedECRM_T002_A.cmplnt_HandlBy_cd = SelectedEmpHandlDetailsTemp[0].EmpId;
                SelectedECRM_T002_A.cmplnt_HandlBy_Name = SelectedEmpHandlDetailsTemp[0].EmpName;
            }
        }
        private void InsertUnitinvqty(IList UnitinvList)
        {
            IList list = UnitinvList as IList;
            List<ADM_M038_B_P> SelectedUnitinvqtyDetailsTemp = list.Cast<ADM_M038_B_P>().ToList();
            if (SelectedUnitinvqtyDetailsTemp.Count > 0)
            {

                SelectedECRM_T002_A.unit_inv_qty = SelectedUnitinvqtyDetailsTemp[0].unit_code;
                //SelectedECRM_T002_A.cmplnt_HandlBy_Name = SelectedUnitinvqtyDetailsTemp[0].EmpName;
            }
        }
        private void InsertUnitDefectqty(IList UnitDefectList)
        {
            IList list = UnitDefectList as IList;
            List<ADM_M038_B_P> SelectedUnitDefectDetailsTemp = list.Cast<ADM_M038_B_P>().ToList();
            if (SelectedUnitDefectDetailsTemp.Count > 0)
            {

                SelectedECRM_T002_A.unit_defect_qty = SelectedUnitDefectDetailsTemp[0].unit_code;
                //SelectedECRM_T002_A.cmplnt_HandlBy_Name = SelectedUnitinvqtyDetailsTemp[0].EmpName;
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
                    var q = QFRDetails.Where(X => X.defect_description == SelectedDefect_descDetailsTemp[0].dfctdsc).FirstOrDefault();

                    if (q != null)
                    {
                        if (QFRDetails.Count() > dgSelectedIndex)
                        {
                            QFRDetails[dgSelectedIndex].active = true;
                            QFRDetails[dgSelectedIndex].defect_description = SelectedDefect_descDetailsTemp[0].dfctdsc;
                            QFRDetails[dgSelectedIndex].defect_id = SelectedDefect_descDetailsTemp[0].dfctcda;
                        }
                    }
                    else
                    {
                        if (QFRDetails.Count() <= dgSelectedIndex)
                        {
                            QFRDetails.Add(new ECRM_T002_B() { defect_description = SelectedDefect_descDetailsTemp[0].dfctdsc, defect_id = SelectedDefect_descDetailsTemp[0].dfctcda });
                        }
                        else
                        {
                            QFRDetails[dgSelectedIndex].defect_description = SelectedDefect_descDetailsTemp[0].dfctdsc;
                            QFRDetails[dgSelectedIndex].defect_id = SelectedDefect_descDetailsTemp[0].dfctcda;
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
        private void InsertSalseOrg(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M001_A_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.SalesOrg.Where(x => x.so_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_A_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    SelectedECRM_T002_A.so_code = POPUPEntityObject.so_code;
                    SelectedECRM_T002_A.sales_org = POPUPEntityObject.sales_org;
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
        private void InsertSalseGroup(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M001_H_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.SalesGroup.Where(x => x.sg_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_H_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    SelectedECRM_T002_A.sg_code = POPUPEntityObject.sg_code;
                    SelectedECRM_T002_A.sg_name = POPUPEntityObject.sg_name;
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
        private void InsertMake(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M032_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.MakeMaster.Where(x => x.Make.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M032_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    SelectedECRM_T002_A.ink_details = POPUPEntityObject.Make;

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
            if (SelectedECRM_T002_A.so_code == null || SelectedECRM_T002_A.so_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = String.Format("So Code Is Required", this.Title);
                showMessageService.ShowMessage();
                return false;
            }
            if (SelectedECRM_T002_A.sg_code == null || SelectedECRM_T002_A.sg_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = String.Format("SG Code Is Required", this.Title);
                showMessageService.ShowMessage();
                return false;
            }

            if (SelectedECRM_T002_A.location_Id == null || SelectedECRM_T002_A.location_Id == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = string.Format("QFR To is Required", this.Title);
                showMessageService.ShowMessage();
                return false;
            }

            if (SelectedECRM_T002_A.copy == true)
            {
                blNew = true;
            }
            return true;
        }

        private void NotifyMessage(string AlertName)
        {
            try
            {
                List<NotificationData> objNotifyData = new List<NotificationData>();
                objNotifyData = NotificationDataCollection.Where(x => x.alert_name == AlertName).ToList();
                foreach (NotificationData VarData in objNotifyData)
                {
                    List<KeyValuePair<string, string>> kvpList = new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("[EMP]",AppSessionState.Name),
                        new KeyValuePair<string, string>("[DOC]", SelectedECRM_T002_A.doc_name),
                        new KeyValuePair<string, string>("[DOCNO]", SelectedECRM_T002_A.quality_feedback_no),
                        new KeyValuePair<string, string>("[DOCDATE]", SelectedECRM_T002_A.quality_feedback_date.ToString()),
                        new KeyValuePair<string, string>("[CUST]","M/s: " +SelectedECRM_T002_A.PartyNm),
                        new KeyValuePair<string, string>("[Comp]","M/s: " +AppSessionState.CompanyName),
                        new KeyValuePair<string, string>("[Attn]",VarData.EmpName),
                    };

                    foreach (KeyValuePair<string, string> kvp in kvpList)
                    {
                        VarData.subject = VarData.subject.Replace(kvp.Key, kvp.Value);
                        VarData.msg_body = VarData.msg_body.Replace(kvp.Key, kvp.Value);
                    }
                    Task t = MailMessenger.SendMailAsync(AppSessionState.MailAccount, VarData.to_mail_id, VarData.cc_mail_id, VarData.bcc_mail_id, VarData.subject, VarData.msg_body, null);

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

        #region · Command Actions ·
        protected override void OnSaveAction(InquiryActionResult<ECRM_T002_A> result)
        {
            try
            {
                if (Validation() == true)
                {


                    SelectedECRM_T002_A.add_by = AppSessionState.UserID;
                    //SelectedECRM_T002_A.location_Id = AppSessionState.location_Id;           
                    SelectedECRM_T002_A.comp_code = AppSessionState.comp_code;
                    SelectedECRM_T002_A.client = AppSessionState.client;
                    //SelectedECRM_T002_A.fin_year = "15-16";
                    //SelectedECRM_T002_A.posting_period = "1";
                    ObjectSerializationService objSer = new ObjectSerializationService();
                    SelectedECRM_T002_A.XmlDataDocument_ECRM_T002_B = objSer.ObjectToXML(QFRDetails);

                    if (blNew == true)
                    {
                        SelectedECRM_T002_A = repository.SaveWithReturnDomainObject<ECRM_T002_A>(SelectedECRM_T002_A, "Quality_Feedback", "CRM");
                        SelectedList.Add(SelectedECRM_T002_A);
                        this.SelectedECRM_T002_A.EndEdit();
                        if (SelectedECRM_T002_A.quality_feedback_no != null || SelectedECRM_T002_A.quality_feedback_no != " " && NotificationDataCollection.FindIndex(f => f.alert_name == "OnInsert") >= 0)
                        {
                            NotifyMessage("OnInsert");
                        }
                        if (SelectedECRM_T002_A.quality_feedback_no != null || SelectedECRM_T002_A.quality_feedback_no !=" " && NotificationDataCollection.FindIndex(f => f.alert_name == "OnApproval") >= 0)
                        {
                            NotifyMessage("OnApproval");
                        }
                        blNew = false;
                    }
                    else if (blNew == false)
                    {
                        int y = 0;
                        if (SelectedECRM_T002_A.active == false)
                        {
                            y = 1;
                        }
                        SelectedECRM_T002_A = repository.UpdateWithReturnDomainObject<ECRM_T002_A>(SelectedECRM_T002_A, "Quality_Feedback", "CRM");
                        this.SelectedECRM_T002_A.EndEdit();
                       
                        if (y == 1)
                        {
                            SelectedECRM_T002_A = new ECRM_T002_A();
                        }
                    }
                    _dataGridCollection.Refresh();

                    if (SelectedECRM_T002_A.XmlDataDocument_ECRM_T002_B != null)
                    {
                        MC.QFRDetails = (ObservableCollection<ECRM_T002_B>)new ObjectSerializationService().XMLToObject(SelectedECRM_T002_A.XmlDataDocument_ECRM_T002_B, MC.QFRDetails);
                    }
                    else
                    {
                        MC.QFRDetails = new ObservableCollection<ECRM_T002_B>();
                    }
                    QFRDetails = MC.QFRDetails;

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
        protected override void OnCreateAction(InquiryActionResult<ECRM_T002_A> result)
        {

            blNew = true;
            SelectedECRM_T002_A = new ECRM_T002_A();
            //SelectedECRM_T002_A.ValidateAsync().Wait();
            QFRDetails = new ObservableCollection<ECRM_T002_B>();
            QFRDetails.Clear();
            _dataGridCollection.Refresh();
            SelectedECRM_T002_A.quality_feedback_date = DateTime.Now;
            SelectedECRM_T002_A.doc_cat = "QF";
            SelectedECRM_T002_A.doc_type = "QF";
            SelectedECRM_T002_A.client = AppSessionState.client;
            if (SalesOrganisationList.Count != 0)
            {
                if (SalesOrganisationList.Count == 1)
                {
                    SelectedECRM_T002_A.so_code = SalesOrganisationList[0].so_code;
                    SelectedECRM_T002_A.sales_org = SalesOrganisationList[0].sales_org;
                }
            }
            else
            {
                SelectedECRM_T002_A.so_code = null;
            }
            if (SalesGroupList.Count != 0)
            {
                if (SalesGroupList.Count == 1)
                {
                    SelectedECRM_T002_A.sg_code = SalesGroupList[0].sg_code;
                    SelectedECRM_T002_A.sg_name = SalesGroupList[0].sg_name;
                }
            }
            else
            {
                SelectedECRM_T002_A.sg_code = null;
            }

        }
        protected override void OnRemoveAction(InquiryActionResult<ECRM_T002_A> result)
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
                this.SelectedECRM_T002_A.CancelEdit();
                string response = repository.Delete(SelectedECRM_T002_A.quality_feedback_no, "Quality_Feedback", "CRM");
                SelectedList.Remove(SelectedECRM_T002_A);
                _dataGridCollection.Refresh();
                SelectedECRM_T002_A = new ECRM_T002_A();
                QFRDetails = new ObservableCollection<ECRM_T002_B>();

            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ECRM_T002_A> result)
        {
            SelectedECRM_T002_A.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ECRM_T002_A> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<ECRM_T002_A> result)
        {
            SelectedList = SelectedList;
            SelectedECRM_T002_A = SelectedECRM_T002_A;
        }
        protected override void OnHelpAction(InquiryActionResult<ECRM_T002_A> result)
        {
            SelectedList = SelectedList;
            SelectedECRM_T002_A = SelectedECRM_T002_A;
        }

        protected override void OnPrintAction(InquiryActionResult<ECRM_T002_A> result)
        {
            try
            {
                if (SelectedECRM_T002_A.quality_feedback_no != null && SelectedECRM_T002_A.quality_feedback_no != " ")
                {
                    string Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + SelectedECRM_T002_A.quality_feedback_no;
                    MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T002_A>(MCTemp, Request, "Quality_Feedback", "CRM", "", 0, "");

                    //MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T002_A>(MCTemp, "ECRM_T002_A_Data", "Quality_Feedback", "CRM", "QFR_Details", 0, SelectedECRM_T002_A.quality_feedback_no);
                    if (SelectedECRM_T002_A.report_type != "" && SelectedECRM_T002_A.report_type != null)
                    {
                        //if (SelectedECRM_T002_A.report_type == "Export")
                        //{
                        object[] objDataSource = new object[4];
                        string[] objDataSourceName = new string[4];

                        List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                        var Result = TempList.Where(loc => loc.location_Id == SelectedECRM_T002_A.location_Id).ToList();
                        objDataSource[2] = Result;

                        List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                        var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == SelectedECRM_T002_A.comp_code).ToList();
                        objDataSource[1] = CmpResult;

                        objDataSource[0] = MCTemp.QulityFeedback;
                        objDataSource[3] = MCTemp.QFRDetails;

                        objDataSourceName[2] = "dsLocation";
                        objDataSourceName[1] = "dsCompany";
                        objDataSourceName[0] = "dsECRM_T002_A";
                        objDataSourceName[3] = "dsECRM_T002_B";

                        ReportManager ReportManager = new ReportManager();
                        string ReportDisplayName = SelectedECRM_T002_A.PartyNm + "_" + SelectedECRM_T002_A.quality_feedback_no + "_" + SelectedECRM_T002_A.quality_feedback_date.Value.ToShortDateString();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\QualityFeedback1.rdlc", ReportDisplayName);
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Select Transaction Type...", this.Title);
                        showMessageService.ShowMessage();
                    }
                    //}
                    //else if (SelectedECRM_T002_A.report_type == "Local")
                    //{
                    //    object[] objDataSource = new object[4];
                    //    string[] objDataSourceName = new string[4];

                    //    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    //    var Result = TempList.Where(loc => loc.location_Id == SelectedECRM_T002_A.location_Id).ToList();
                    //    objDataSource[1] = Result;

                    //    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    //    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == SelectedECRM_T002_A.comp_code).ToList();
                    //    objDataSource[0] = CmpResult;

                    //    objDataSource[2] = MCTemp.QulityFeedback;
                    //    objDataSource[3] = MCTemp.QFRDetails;

                    //    objDataSourceName[1] = "dsLocation";
                    //    objDataSourceName[0] = "dsCompany";
                    //    objDataSourceName[2] = "ECRM_T002_AMaster";
                    //    objDataSourceName[3] = "ECRM_T002_BDetail";
                    //    ReportManager ReportManager = new ReportManager();
                    //    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\QualityFeedbackLocal.rdlc", "QualityFeedbackReport");
                    //}
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Select Quality feedback No.....", this.Title);
                    showMessageService.ShowMessage();

                }
                //if (MasterEntity.id > 0)
                // {
                //     MasterEntity = repository.SaveWithReturnDomainObject<ECRM_T001_A>(MasterEntity, "Sample_Analysis", "CRM");

                //     MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MC, "EPR_T001_Data", "Sample_Analysis", "CRM", "rptSampleAnalysis", 0, MasterEntity.sa_no);
                //     //dgReportMaster = MC.rptSalesAnalysis;
                //     //object objDS = new object();
                //     //objDS = MC.rptSalesAnalysis;

                //     ReportManager ReportManager = new ReportingServices.ReportManager();

                //    // ReportManager.DisplayReport(objDS, "dsSampleAnalysis", "\\CRM\\SampleAnalysis.rdlc");

                // }
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
        protected override void OnRefreshCommand(InquiryActionResult<ECRM_T002_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ECRM_T002_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ECRM_T002_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ECRM_T002_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ECRM_T002_A> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region "Filters"
        #region Filters For Model
        private void FilterCollectionModel()
        {
            if (_ModelCollection != null)
            {
                _ModelCollection.Refresh();
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
        public bool ModelFilter(object obj)
        {
            var data = obj as ZADM_M009_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringModel))
                {
                    return (
                        (data.basicmodel != null && data.basicmodel.ToString().ToLower().Contains(_filterStringModel.ToLower())) ||
                        (data.modelno != null && data.modelno.ToString().ToLower().Contains(_filterStringModel.ToLower())) ||
                        (data.modeldesc != null && data.modeldesc.ToString().ToLower().Contains(_filterStringModel.ToLower()))
                        );

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Prodct
        private void FilterCollectionProdct()
        {
            if (_ProdctCollection != null)
            {
                _ProdctCollection.Refresh();
            }

        }
        public string FilterStringProdct
        {
            get { return _filterStringProdct; }
            set
            {
                _filterStringProdct = value;
                RaisePropertyChanged("FilterStringProdct");
                FilterCollectionProdct();
            }
        }
        public bool ProdctFilter(object obj)
        {
            var data = obj as ADM_M022_P_ESSEM;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringProdct))
                {
                    return (
                        (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterStringProdct.ToLower())) ||
                        (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterStringProdct.ToLower()))

                        );

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Party
        private void FilterCollectionParty()
        {
            if (_PartyCollection != null)
            {
                _PartyCollection.Refresh();
            }

        }
        public string FilterStringParty
        {
            get { return _filterStringParty; }
            set
            {
                _filterStringParty = value;
                RaisePropertyChanged("FilterStringParty");
                FilterCollectionParty();
            }
        }
        public bool PartyFilter(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringParty))
                {
                    return (
                        (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterStringParty.ToLower())) ||
                        (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterStringParty.ToLower()))

                        );

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For ILD
        private void FilterCollectionILD()
        {
            if (_ILDCollection != null)
            {
                _ILDCollection.Refresh();
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
        public bool ILDFilter(object obj)
        {
            var data = obj as ZADM_M007_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringILD))
                {
                    return (
                        (data.ild != null && data.ild.ToString().ToLower().Contains(_filterStringILD.ToLower())) ||
                        (data.tip_type != null && data.tip_type.ToString().ToLower().Contains(_filterStringILD.ToLower()))

                        );

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For INK
        private void FilterCollectionINK()
        {
            if (_INKCollection != null)
            {
                _INKCollection.Refresh();
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
        public bool INKFilter(object obj)
        {
            var data = obj as ZADM_M006_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringINK))
                {
                    return (
                        (data.ink != null && data.ink.ToString().ToLower().Contains(_filterStringINK.ToLower()))

                        );

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Plant
        private void FilterCollectionPlant()
        {
            if (_PlantCollection != null)
            {
                _PlantCollection.Refresh();
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
        public bool PlantFilter(object obj)
        {
            var data = obj as ADM_M003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringPlant))
                {
                    return (
                        (data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterStringPlant.ToLower())) ||
                        (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterStringPlant.ToLower()))
                        );

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For EmpRecv
        private void FilterCollectionEmpRecv()
        {
            if (_EmpRecvCollection != null)
            {
                _EmpRecvCollection.Refresh();
            }

        }
        public string FilterStringEmpRecv
        {
            get { return _filterStringEmpRecv; }
            set
            {
                _filterStringEmpRecv = value;
                RaisePropertyChanged("FilterStringEmpRecv");
                FilterCollectionEmpRecv();
            }
        }
        public bool EmpRecvFilter(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringEmpRecv))
                {
                    return (
                        (data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterStringEmpRecv.ToLower())) ||
                        (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_filterStringEmpRecv.ToLower()))

                        );

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For EmpHandl
        private void FilterCollectionEmpHandl()
        {
            if (_EmpHandlCollection != null)
            {
                _EmpHandlCollection.Refresh();
            }

        }
        public string FilterStringEmpHandl
        {
            get { return _filterStringEmpHandl; }
            set
            {
                _filterStringEmpHandl = value;
                RaisePropertyChanged("FilterStringEmpHandl");
                FilterCollectionEmpHandl();
            }
        }
        public bool EmpHandlFilter(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringEmpHandl))
                {
                    return (
                         (data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterStringEmpHandl.ToLower())) ||
                         (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_filterStringEmpHandl.ToLower()))

                         );

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Defect_desc
        private string _filterStringDefect_desc;
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
                    return ((data.dfctdsc != null) && data.dfctdsc.ToLower().Contains(_filterStringDefect_desc.ToLower()));
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
            var data = obj as ECRM_T002_A;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.quality_feedback_no != null && data.quality_feedback_no.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    (data.quality_feedback_date != null && data.quality_feedback_date.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    (data.ModelNm != null && data.ModelNm.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    (data.product_name != null && data.product_name.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    (data.defected_qty != null && data.defected_qty.ToString().ToLower().Contains(_filterString.ToLower())
                   );

                }
                return true;
            }
            return false;
        }

        private string _filterString_SalesOrg;
        public string FilterString_SalesOrg
        {
            get { return _filterString_SalesOrg; }
            set
            {
                _filterString_SalesOrg = value;
                RaisePropertyChanged("FilterString_SalesOrg");
                FilterCollection_SalesOrg();
            }
        }
        private void FilterCollection_SalesOrg()
        {
            if (_sales_orgCollection != null)
            {
                _sales_orgCollection.Refresh();
            }
        }
        public bool Filter_SalesOrg(object obj)
        {
            var data = obj as ADM_M001_A_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_SalesOrg))
                {
                    return (data.so_code != null && data.so_code.ToString().ToLower().Contains(_filterString_SalesOrg.ToLower())) ||
                       (data.sales_org != null && data.sales_org.ToString().ToLower().Contains(_filterString_SalesOrg.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_SalesGroup;
        public string FilterString_SalesGroup
        {
            get { return _filterString_SalesGroup; }
            set
            {
                _filterString_SalesGroup = value;
                RaisePropertyChanged("FilterString_SalesGroup");
                FilterCollection_SalesGroup();
            }
        }
        private void FilterCollection_SalesGroup()
        {
            if (_salse_GroupCollection != null)
            {
                _salse_GroupCollection.Refresh();
            }
        }
        public bool Filter_SalesGroup(object obj)
        {
            var data = obj as ADM_M001_H_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_SalesGroup))
                {
                    return (data.sg_code != null && data.sg_code.ToString().ToLower().Contains(_filterString_SalesGroup.ToLower())) ||
                       (data.sg_name != null && data.sg_name.ToString().ToLower().Contains(_filterString_SalesGroup.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter For Make
        private string _FilterStringMake;
        public string FilterStringMake
        {
            get { return _FilterStringMake; }
            set
            {
                _FilterStringMake = value;
                RaisePropertyChanged("FilterStringMake");
                FilterMakeCollection();
            }
        }
        private void FilterMakeCollection()
        {
            if (_MakeCollection != null)
            {
                _MakeCollection.Refresh();
            }

        }
        public bool MakeFilter(object obj)
        {
            var data = obj as ADM_M032_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringMake))
                {
                    return (
                        (data.Make != null && data.Make.ToString().ToLower().Contains(_FilterStringMake.ToLower())) ||
                        (data.MakeCode.ToString() != null && data.MakeCode.ToString().ToLower().Contains(_FilterStringMake.ToLower())) ||
                        (data.make_type != null && data.make_type.ToString().ToLower().Contains(_FilterStringMake.ToLower()))
                        );
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For Unit
        private void FilterCollectionUnit()
        {
            if (_unit_inv_qtyCollection != null)
            {
                _unit_inv_qtyCollection.Refresh();
            }

        }
        private string _filterStringUnit;
        public string FilterStringUnit
        {
            get { return _filterStringUnit; }
            set
            {
                _filterStringUnit = value;
                RaisePropertyChanged("FilterStringUnit");
                FilterCollectionUnit();
            }
        }
        public bool UnitFilter(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringUnit))
                {
                    return (
                         (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterStringUnit.ToLower())) ||
                         (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterStringUnit.ToLower()))

                         );

                }
                return true;
            }
            return false;
        }

        #endregion
        #region Filters For Unit
        private void FilterCollectionUnitDefect()
        {
            if (_unit_defect_qtyCollection != null)
            {
                _unit_defect_qtyCollection.Refresh();
            }

        }
        private string _filterStringUnitDefect;
        public string FilterStringUnitDefect
        {
            get { return _filterStringUnitDefect; }
            set
            {
                _filterStringUnitDefect = value;
                RaisePropertyChanged("FilterStringUnitDefect");
                FilterCollectionUnitDefect();
            }
        }
        public bool UnitDefectFilter(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringUnitDefect))
                {
                    return (
                         (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterStringUnitDefect.ToLower())) ||
                         (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterStringUnitDefect.ToLower()))

                         );

                }
                return true;
            }
            return false;
        }

        

        #endregion

        #endregion


    }
}
