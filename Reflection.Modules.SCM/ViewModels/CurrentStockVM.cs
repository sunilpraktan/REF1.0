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
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Reflection.ReportingServices;
using Reflection.BusinessEntity.SCM;

namespace Reflection.Modules.SCM.ViewModels
{
    public class CurrentStockVM : WorkspaceViewModel<CurrentStock>
    {
        WebServiceRepository<CurrentStock> repository = new WebServiceRepository<CurrentStock>();
        WebServiceRepository<MultipleContext_CurrentStock> repository_MC = new WebServiceRepository<MultipleContext_CurrentStock>();
        ObjectSerializationService obj = new ObjectSerializationService();
        private MultipleContext_CurrentStock _MC = new MultipleContext_CurrentStock();
        WebServiceRepository<List<MIS_SCM_StoreRpt>> repository_Store = new WebServiceRepository<List<MIS_SCM_StoreRpt>>();


        MultipleContext_MIS_SCM_Store MCTemp = new MultipleContext_MIS_SCM_Store();
        WebServiceRepository<MultipleContext_MIS_SCM_Store> repository_MC2 = new WebServiceRepository<MultipleContext_MIS_SCM_Store>();
        public MultipleContext_CurrentStock MC
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
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }

        #region . ICollection .
        private ICollectionView _CategoryCollection;
        public ICollectionView CategoryCollection
        {
            get { return _CategoryCollection; }
            set { _CategoryCollection = value; RaisePropertyChanged("CategoryCollection"); }
        }
        private ICollectionView _SubCategoryCollection;
        public ICollectionView SubCategoryCollection
        {
            get { return _SubCategoryCollection; }
            set { _SubCategoryCollection = value; RaisePropertyChanged("SubCategoryCollection"); }
        }

        private ICollectionView _ItemCollection;
        public ICollectionView ItemCollection
        {
            get { return _ItemCollection; }
            set { _ItemCollection = value; RaisePropertyChanged("ItemCollection"); }
        }
        private ICollectionView _ParameterCollection;
        public ICollectionView ParameterCollection
        {
            get { return _ParameterCollection; }
            set { _ParameterCollection = value; RaisePropertyChanged("ParameterCollection"); }
        }
        private ICollectionView _ParameterValCollection;
        public ICollectionView ParameterValCollection
        {
            get { return _ParameterValCollection; }
            set { _ParameterValCollection = value; RaisePropertyChanged("ParameterValCollection"); }
        }

        private List<ADM_M031_P> _SelectedParaValueCollection = new List<ADM_M031_P>();
        public List<ADM_M031_P> SelectedParaValueCollection
        {
            get { return _SelectedParaValueCollection; }
            set
            {
                if (_SelectedParaValueCollection != value)
                {
                    _SelectedParaValueCollection = value;
                    RaisePropertyChanged("SelectedParaValueCollection");
                }
            }
        }

        private int _ParadgSelectedIndex;
        public int ParadgSelectedIndex
        {
            get
            {
                return _ParadgSelectedIndex;
            }
            set
            {
                if (_ParadgSelectedIndex != value)
                {
                    _ParadgSelectedIndex = value;
                    RaisePropertyChanged("ParadgSelectedIndex");
                }
            }
        }
        private List<ADM_M031_P> _ParameterTemp = new List<ADM_M031_P>();
        public List<ADM_M031_P> ParameterTemp
        {
            get { return _ParameterTemp; }
            set
            {
                if (_ParameterTemp != value)
                {
                    _ParameterTemp = value;
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

        public List<ADM_M003> _ObjPlant;
        private List<ADM_M003> ObjPlant
        {
            get { return _ObjPlant; }
            set
            {
                if (_ObjPlant != value)
                {
                    _ObjPlant = value;
                }
            }
        }
        public List<ADM_M002> _ObjCompany;
        private List<ADM_M002> ObjCompany
        {
            get { return _ObjCompany; }
            set
            {
                if (_ObjCompany != value)
                {
                    _ObjCompany = value;
                }
            }
        }
       

        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set
            {
                _dataGridCollection = value;
                RaisePropertyChanged("DataGridCollection");
            }
        }
        private ICollectionView _TotalParameterCollection;
        public ICollectionView TotalParameterCollection
        {
            get { return _TotalParameterCollection; }
            set
            {
                _TotalParameterCollection = value;
                RaisePropertyChanged("TotalParameterCollection")
               ;
            }
        }

        private ICollectionView _PlantCollection;
        public ICollectionView PlantCollection
        {
            get { return _PlantCollection; }
            set { _PlantCollection = value; RaisePropertyChanged("PlantCollection"); }
        }
        private ICollectionView _CompCollection;
        public ICollectionView CompCollection
        {
            get { return _CompCollection; }
            set { _CompCollection = value; RaisePropertyChanged("CompCollection"); }
        }
        private ICollectionView _StoreCollection;
        public ICollectionView StoreCollection
        {
            get { return _StoreCollection; }
            set { _StoreCollection = value; RaisePropertyChanged("StoreCollection"); }
        }
        #endregion

        #region . Methods .
        private CurrentStock _MasterEntity;
        public CurrentStock MasterEntity
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

        private Dictionary<string, string> _ReportItemsDictionary;
        public Dictionary<string, string> ReportItemsDictionary
        {
            get { return _ReportItemsDictionary; }
            set
            {
                if (_ReportItemsDictionary != value)
                {
                    _ReportItemsDictionary = value;
                    RaisePropertyChanged("ReportItemsDictionary");
                }
            }
        }
        private Dictionary<string, string> _ImpLocDictionary;
        public Dictionary<string, string> ImpLocDictionary
        {
            get { return _ImpLocDictionary; }
            set
            {
                if (_ImpLocDictionary != value)
                {
                    _ImpLocDictionary = value;
                    RaisePropertyChanged("ImpLocDictionary");
                }
            }
        }

        #endregion

        #region . String AutoComplete .
        private List<string> _StringListCategory;
        public List<string> StringListCategory
        {
            get { return _StringListCategory; }
            set
            {
                if (_StringListCategory != value)
                {
                    _StringListCategory = value;
                }
            }
        }

        private List<string> _StringListSubCategory;
        public List<string> StringListSubCategory
        {
            get { return _StringListSubCategory; }
            set
            {
                if (_StringListSubCategory != value)
                {
                    _StringListSubCategory = value;
                }
            }
        }

        private List<string> _StringListItemType;
        public List<string> StringListItemType
        {
            get { return _StringListItemType; }
            set
            {
                if (_StringListItemType != value)
                {
                    _StringListItemType = value;
                }
            }
        }

        private List<string> _StringListSubItemType;
        public List<string> StringListSubItemType
        {
            get { return _StringListSubItemType; }
            set
            {
                if (_StringListSubItemType != value)
                {
                    _StringListSubItemType = value;
                }
            }
        }

        private List<string> _StringListItem;
        public List<string> StringListItem
        {
            get { return _StringListItem; }
            set
            {
                if (_StringListItem != value)
                {
                    _StringListItem = value;
                }
            }
        }


        private List<string> _StringListParameter;
        public List<string> StringListParameter
        {
            get { return _StringListParameter; }
            set
            {
                if (_StringListParameter != value)
                {
                    _StringListParameter = value;
                }
            }
        }

        private List<string> _StringListParameterVal;
        public List<string> StringListParameterVal
        {
            get { return _StringListParameterVal; }
            set
            {
                if (_StringListParameterVal != value)
                {
                    _StringListParameterVal = value;
                }
            }
        }
        List<string> _strListCompany;
        public List<string> StringListCompany
        {
            get { return _strListCompany; }
            set
            {
                if (_strListCompany != value)
                {
                    _strListCompany = value;
                }
            }
        }

        List<string> _strListPlant;
        public List<string> StringListPlant
        {
            get { return _strListPlant; }
            set
            {
                if (_strListPlant != value)
                {
                    _strListPlant = value;
                }
            }
        }
        List<string> _strListStore;
        public List<string> StringListStore
        {
            get { return _strListStore; }
            set
            {
                if (_strListStore != value)
                {
                    _strListStore = value;
                }
            }
        }
        private List<MIS_SCM_StoreRpt> _dsReport;
        public List<MIS_SCM_StoreRpt> dsReport
        {
            get { return _dsReport; }
            set
            {
                if (_dsReport != value)
                {
                    _dsReport = value;


                    RaisePropertyChanged("dsReport");

                }
            }
        }
        private List<string> _strListUOM;
        public List<string> StringListUOM
        {
            get { return _strListUOM; }
            set
            {
                if (_strListUOM != value)
                {
                    _strListUOM = value;
                }
            }
        }
        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> CmdAddLocation { get; private set; }
        public RelayCommand<object> CommandCategory { get; private set; }
        public RelayCommand<object> CommandSubCategory { get; private set; }
        public RelayCommand<object> CommandItemType { get; private set; }
        public RelayCommand<object> CommandSubItemType { get; private set; }
        public RelayCommand<object> CommandItem { get; private set; }
        public RelayCommand<object> CommandUom { get; private set; }
        public RelayCommand<object> CommandParameter { get; private set; }
        public RelayCommand<object> CommandParameterVal { get; private set; }
        public RelayCommand<IList> CollectionChangedCommand { get; private set; }
        public RelayCommand<IList> SelectionChangedParaValCommand { get; private set; }
        public RelayCommand LoadStockCommand { get; private set; }
        public RelayCommand LoadCommand { get; private set; }
        public RelayCommand PrintCommand { get; private set; }
        public RelayCommand PrintGridCommand { get; private set; }
        public RelayCommand ClearCommand { get; private set; }
        public RelayCommand<object> CmdAddComp { get; private set; }
        public RelayCommand<object> CmdAddStore { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }

        #endregion

        public CurrentStockVM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new CurrentStock();
            MC = new MultipleContext_CurrentStock();
            _dsReport = new List<MIS_SCM_StoreRpt>();
             
            //ReportItemsDictionary = new Dictionary<string, string>();
            //ReportItemsDictionary.Add("R003", "As On Statement");

            ImpLocDictionary = new Dictionary<string, string>();
            ImpLocDictionary.Add("ALL", "ALL");
            ImpLocDictionary.Add("Local", "Local");
            ImpLocDictionary.Add("Import", "Import");

            //  CollectionChangedCommand = new RelayCommand<IList>(
            //items => { if (items == null) { return; } CollectionChanged(items); });

            //  SelectionChangedParaValCommand = new RelayCommand<IList>(
            //  items => { if (items == null) { return; } GetSelectedParaValue(items); });

            LoadInitialData();
        }
        public CurrentStockVM(string ts_code,string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new CurrentStock();
            MC = new MultipleContext_CurrentStock();
            _dsReport = new List<MIS_SCM_StoreRpt>();

            //ReportItemsDictionary = new Dictionary<string, string>();
            //ReportItemsDictionary.Add("R003", "As On Statement");

            ImpLocDictionary = new Dictionary<string, string>();
            ImpLocDictionary.Add("ALL", "ALL");
            ImpLocDictionary.Add("Local", "Local");
            ImpLocDictionary.Add("Import", "Import");

            //  CollectionChangedCommand = new RelayCommand<IList>(
            //items => { if (items == null) { return; } CollectionChanged(items); });

            //  SelectionChangedParaValCommand = new RelayCommand<IList>(
            //  items => { if (items == null) { return; } GetSelectedParaValue(items); });

            LoadInitialData();
        }

        private void DisplayStock()
        {
            try
            {
                string RequestParameter = "LoadStockDetails" + "!@" + MasterEntity.storage_level + "!@" + MasterEntity.ItemCode + "!@" + MasterEntity.CatCode + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.SubCatCode + "!@" + MasterEntity.store_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_CurrentStock>(MC, RequestParameter, "Current_Stock", "SCM", "LoadAll", 0, "");
                if (MC.CurrentStockList.Count >= 0)
                {
                    DataGridCollection = CollectionViewSource.GetDefaultView(MC.CurrentStockList);
                    DataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);
                    DataGridCollection.Refresh();
                }
                else
                {
                    MC.CurrentStockList.Clear();
                    DataGridCollection = CollectionViewSource.GetDefaultView(MC.CurrentStockList);
                    DataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);
                    DataGridCollection.Refresh();
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
        private void DisplayPrint()
        {
            try
            {
                string RequestParameter = "LoadStockDetails" + "!@" + MasterEntity.stockcategory + "!@" + MasterEntity.ItemCode + "!@" + MasterEntity.CatCode + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code + "!@" + MasterEntity.SubCatCode + "!@" + MasterEntity.ItemTypeCd + "!@" + MasterEntity.SubItemTpCd;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_CurrentStock>(MC, RequestParameter, "Current_Stock", "SCM", "LoadAll", 0, "");

                object[] objDataSource = new object[3];
                string[] objDataSourceName = new string[3];

                objDataSource[1] = MC.CurrentStockList;

                objDataSourceName[1] = "dsCurrentStock";

                ReportManager ReportManager = new ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\SCM\\CurrentStock.rdlc", "CurrentStock");
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
        //Added by Priya
        private void DisplayStockDetails()
        {
            try
            {

                string RequestParameter = "Report" + "!@" + MasterEntity.ReportCode + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + Convert.ToDateTime(MasterEntity.Date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(MasterEntity.Date).ToString("MM/dd/yyyy") + "!@" + MasterEntity.CatCode + "!@" + MasterEntity.SubCatCode + "!@" + "ALL" + "!@" + MasterEntity.ItemCode + "!@" + MasterEntity.unit_code + "!@" + "ALL" + "!@" + "ALL" + "!@" + "ALL" + "!@" + "ALL" + "!@" + "ALL" + "!@" + "ALL" + "!@" + "ALL" + "!@" + MasterEntity.ImportLocalCode;
                MCTemp = repository_MC2.GetDataWithReturnDomainObject<MultipleContext_MIS_SCM_Store>(MCTemp, RequestParameter, "MIS_SCM_Store", "SCM", "", 0, "");

                if (MCTemp.StoreList.Count >= 0)
                {
                    DataGridCollection = CollectionViewSource.GetDefaultView(MCTemp.StoreList);
                    DataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid1);
                    DataGridCollection.Refresh();
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("No Data Available", this.Title);
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
        private void DisplayReport()
        {

            try
            {
                //Check if Report not selected then give a Message.

                //Diaplay Selected Report.
                string RequestParameter = "Report" + "!@" + MasterEntity.ReportCode + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + Convert.ToDateTime(MasterEntity.Date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(MasterEntity.Date).ToString("MM/dd/yyyy") + "!@" + MasterEntity.CatCode + "!@" + MasterEntity.SubCatCode + "!@" + "ALL" + "!@" + MasterEntity.ItemCode + "!@" + MasterEntity.unit_code + "!@" + "ALL" + "!@" + "ALL" + "!@" + "ALL" + "!@" + "ALL" + "!@" + "ALL" + "!@" + "ALL" + "!@" + "ALL" + "!@" + MasterEntity.ImportLocalCode;
                MCTemp = repository_MC2.GetDataWithReturnDomainObject<MultipleContext_MIS_SCM_Store>(MCTemp, RequestParameter, "MIS_SCM_Store", "SCM", "", 0, "");
                if (MCTemp.StoreList.Count >= 0)
                {
                    DataGridCollection = CollectionViewSource.GetDefaultView(MCTemp.StoreList);
                    DataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid1);
                    DataGridCollection.Refresh();
                }
                if (MCTemp.StoreList.Count >= 0)
                {
                    object[] objDataSource = new object[3];
                    string[] objDataSourceName = new string[3];

                    objDataSource[0] = MCTemp.StoreList;

                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                    objDataSource[1] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                    objDataSource[2] = Result;

                    objDataSourceName[0] = "dsMIS_SCM_StoreRpt";
                    objDataSourceName[1] = "dsCompany";
                    objDataSourceName[2] = "dsLocation";

                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\MIS\\SCM\\" + GetReportFile(MasterEntity.ReportCode), getParametersList(), "");
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("No Data Available", this.Title);
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
        private void DisplayGridReport()
        {

            try
            {
                if (MC.CurrentStockList.Count >= 0)
                {
                    object[] objDataSource = new object[1];
                    string[] objDataSourceName = new string[1];
                    MasterEntity.ReportCode = "GridReport";
                    objDataSource[0] = MC.CurrentStockList;

                    //List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    //var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                    //objDataSource[1] = CmpResult;

                    //List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    //var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                    //objDataSource[2] = Result;

                    objDataSourceName[0] = "dsCurrentStock";
                    //objDataSourceName[1] = "dsCompany";
                    //objDataSourceName[2] = "dsLocation";

                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\SCM\\" + GetReportFile(MasterEntity.ReportCode), "CurrentStock");

                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("No Data Available", this.Title);
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
        private Dictionary<string, string> getParametersList()
        {
            //Adding Parameters to display on Reports
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("ReportNm", MasterEntity.ReportName);
                result.Add("comp_code", MasterEntity.comp_code);
                result.Add("location_Id", MasterEntity.location_Id);
                result.Add("unit_code", MasterEntity.unit_code);
                result.Add("SubCatName", MasterEntity.SubCatName);
                result.Add("CatName", MasterEntity.CatName);
                result.Add("ToDate", Convert.ToString(MasterEntity.Date));


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
        private string GetReportFile(string ReportCode)
        {
            string returnReportName = "";

            if (ReportCode == "R003")
            {
                returnReportName = "StockReport.rdlc";
            }
            else if (ReportCode == "R004")
            {
                returnReportName = "StockReportFG.rdlc";
            }
            else if(ReportCode == "GridReport")
            {
                returnReportName = "CurrentStock.rdlc";
            }
            return returnReportName;
        }
        private void ClearSelection()
        {
            MasterEntity = new CurrentStock();
            DefaultValues(null);

            //CategoryCollection = CollectionViewSource.GetDefaultView(MC.CategoryList);
            //CategoryCollection.Refresh();

            //SubCategoryCollection = CollectionViewSource.GetDefaultView(MC.SubCategoryList);
            //SubCategoryCollection.Refresh();


            //ItemCollection = CollectionViewSource.GetDefaultView(MC.ItemList);
            //ItemCollection.Refresh();

        }
        //private void CollectionChanged(IList DataList)
        //{
        //    IList list = DataList as IList;
        //    int a = dgSelectedIndex;
        //    string[] TempSkuList = new string[100];
        //    List<string> TempParaValueList = new List<string>();
        //    try
        //    {
        //        //if (Pur_Req_Details[dgSelectedIndex].id == 0 && Pur_Req_Details.Count > 0 && dgSelectedIndex < Pur_Req_Details.Count)
        //        //{
        //            List<PUR_T001_B> SelectedRowlist = list.Cast<PUR_T001_B>().ToList();

        //            if (SelectedRowlist[0].StockUnt == true)
        //            {
        //                var paramlist = (from o in MC.ParameterList where o.SubCatCode == SelectedRowlist[0].SubCatCode select o).ToList();
        //                ParameterTemp = paramlist.ToList();

        //                if (paramlist.Count > 0 && Pur_Req_Details[dgSelectedIndex].sku != "" && Pur_Req_Details[dgSelectedIndex].sku != null)
        //                {
        //                    TempSkuList = Pur_Req_Details[dgSelectedIndex].sku.Split('/');

        //                    for (int i = 0; i < paramlist.Count; i++)
        //                    {
        //                        TempParaValueList = (from o in MC.ParamValueList where o.value_code == TempSkuList[i] select o.parametervalue).ToList();
        //                        if (TempParaValueList.Count > 0)
        //                        {
        //                            paramlist[i].parametervalue = TempParaValueList[0];
        //                        }
        //                    }

        //                    ParameterCollection = CollectionViewSource.GetDefaultView(paramlist.ToList());
        //                }
        //                else
        //                {
        //                    foreach (var o in ParameterTemp)
        //                    {
        //                        o.parametervalue = null; o.value_code = null;
        //                    }
        //                    ParameterCollection = CollectionViewSource.GetDefaultView(paramlist.ToList());
        //                }

        //                if (paramlist.Count > 0) //&& SelectedParaValueCollection.Count != paramlist.Count)
        //                {
        //                    SelectedParaValueCollection = new List<ADM_M031_P>();

        //                    for (int i = 0; i < paramlist.Count; i++)
        //                    {
        //                        SelectedParaValueCollection.Add(new ADM_M031_P()
        //                        {
        //                            // ItemCode = SelectedRowlist[0].ItemCode,
        //                            dgselectedindex = dgSelectedIndex,
        //                            //  value_code = SelectedParaValueList[0].value_code,
        //                            para_code = paramlist[i].para_code,
        //                            para_name = paramlist[i].para_name
        //                        });
        //                    }
        //                }
        //                if (Pur_Req_Details[dgSelectedIndex].sku_desc != null)
        //                {
        //                    SelectedParaValueCollection = ParameterCollection.Cast<ADM_M031_P>().ToList();

        //                    foreach (var o in SelectedParaValueCollection)
        //                    {
        //                        o.dgselectedindex = dgSelectedIndex;
        //                        foreach (var p in MC.ParamValueList)
        //                        {
        //                            if (o.para_code == p.para_code && o.parametervalue == p.parametervalue)
        //                            {
        //                                o.value_code = p.value_code;
        //                            }
        //                        }
        //                    }
        //                }

        //            }

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
        //private void GetSelectedParaValue(IList parameter)
        //{
        //    IList list = parameter as IList;
        //    List<ADM_M031_P> SelectedParaValueList = list.Cast<ADM_M031_P>().ToList();
        //    int a = ParadgSelectedIndex;
        //    int b = dgSelectedIndex;

        //    if (dgSelectedIndex != -1 && SelectedParaValueList.Count > 0 && Pur_Req_Details[dgSelectedIndex].StockUnt == true)
        //    {
        //        if (Pur_Req_Details[dgSelectedIndex].id == 0)
        //        {
        //            #region 
        //            if (SelectedParaValueList.Count > 0 && SelectedParaValueList[0].parametervalue != null && SelectedParaValueList[0].parametervalue != "")// && SelectedParaValueCollection.dgselectedindex.contains)
        //            {
        //                for (int i = 0; i < SelectedParaValueCollection.Count; i++)
        //                {
        //                    if (SelectedParaValueCollection[i].para_code == SelectedParaValueList[0].para_code && SelectedParaValueCollection[i].dgselectedindex == dgSelectedIndex)
        //                    {
        //                        SelectedParaValueCollection[i].parametervalue = SelectedParaValueList[0].parametervalue;

        //                        var paravaluetemp = (from o in MC.ParamValueList where o.para_code == SelectedParaValueCollection[i].para_code && o.parametervalue == SelectedParaValueCollection[i].parametervalue select o).ToList();

        //                        if (paravaluetemp.Count > 0)
        //                        {
        //                            SelectedParaValueCollection[i].value_code = paravaluetemp[0].value_code;
        //                        }
        //                    }
        //                }

        //                // SKU Description
        //                GetSkuDescription();

        //                //Function for calculating SKU
        //                CalculateSku();


        //            }
        //            #endregion
        //        }
        //        else if (Pur_Req_Details[dgSelectedIndex].id != 0)
        //        {

        //        }

        //    }


        //}       
        //private void CalculateSku()
        //{
        //    if (Pur_Req_Details[dgSelectedIndex].sku == null || Pur_Req_Details[dgSelectedIndex].sku == "")
        //    {
        //        for (int i = 0; i < SelectedParaValueCollection.Count; i++)
        //        {
        //            if (Pur_Req_Details[dgSelectedIndex].sku == "" || Pur_Req_Details[dgSelectedIndex].sku == null)
        //            {
        //                Pur_Req_Details[dgSelectedIndex].sku = SelectedParaValueCollection[i].value_code;
        //            }
        //            else
        //            {
        //                Pur_Req_Details[dgSelectedIndex].sku = Pur_Req_Details[dgSelectedIndex].sku + "/" + SelectedParaValueCollection[i].value_code;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Pur_Req_Details[dgSelectedIndex].sku = "";

        //        for (int i = 0; i < SelectedParaValueCollection.Count; i++)
        //        {
        //            if (Pur_Req_Details[dgSelectedIndex].sku == "" || Pur_Req_Details[dgSelectedIndex].sku == null)
        //            {
        //                Pur_Req_Details[dgSelectedIndex].sku = SelectedParaValueCollection[i].value_code;
        //            }
        //            else
        //            {
        //                Pur_Req_Details[dgSelectedIndex].sku = Pur_Req_Details[dgSelectedIndex].sku + "/" + SelectedParaValueCollection[i].value_code;
        //            }

        //        }
        //    }
        //}
        private void InsertCompany(object InputValue)
        {
            string Request = "";
            ADM_M002 POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = ObjCompany.Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M002>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M002>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            #endregion

            if (POPUPEntityObject != null)
            {
                MasterEntity.comp_code = POPUPEntityObject.comp_code;
                MasterEntity.CompName = POPUPEntityObject.CompName;
                
                if (POPUPEntityObject.comp_code != "" || POPUPEntityObject.comp_code != null)
                {
                    var myPlant = from data in ObjPlant
                              where data.comp_code == POPUPEntityObject.comp_code
                              select data;

                    PlantCollection = CollectionViewSource.GetDefaultView(myPlant.ToList());
                    PlantCollection.Filter = new Predicate<object>(FilterPlant);
                    StringListPlant = ObjPlant.Select(x => x.location_Id).ToList();

                }
                else
                {
                    PlantCollection = CollectionViewSource.GetDefaultView(ObjPlant.ToList());
                    PlantCollection.Filter = new Predicate<object>(FilterPlant);
                    StringListPlant = ObjPlant.Select(x => x.location_Id).ToList();
                }
            }

        }
        private void InsertPlant(object InputValue)
        {
            string Request = "";
            ADM_M003 POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = ObjPlant.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M003>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            #endregion

            if (POPUPEntityObject != null)
            {
                MasterEntity.location_Id = POPUPEntityObject.location_Id;
                MasterEntity.LoctnNm = POPUPEntityObject.LoctnNm;

                if (POPUPEntityObject.location_Id != "" || POPUPEntityObject.location_Id != null)
                {
                    var myStore = from data in MC.StoreLocation
                                  where data.location_Id == POPUPEntityObject.location_Id
                                  select data;

                    StoreCollection = CollectionViewSource.GetDefaultView(myStore.ToList());
                    StoreCollection.Filter = new Predicate<object>(FilterStore);
                    StringListStore = MC.StoreLocation.Select(x => x.store_code).ToList();

                }
                else
                {
                    StoreCollection = CollectionViewSource.GetDefaultView(MC.StoreLocation);
                    StoreCollection.Filter = new Predicate<object>(FilterStore);
                    StringListStore = MC.StoreLocation.Select(x => x.store_code).ToList();
                }
            }

        }
        private void InsertStore(object InputValue)
        {
            string Request = "";
            MM_M001_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.StoreLocation.Where(x => x.store_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<MM_M001_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_M001_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            #endregion

            if (POPUPEntityObject != null)
            {
                MasterEntity.store_code = POPUPEntityObject.store_code;
                MasterEntity.store_name = POPUPEntityObject.store_name;
            }

        }
        private void InsertCategory(object InputValue)
        {
            string Request = "";
            ADM_M018_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.CategoryList.Where(x => x.CatCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M018_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M018_P>().ToList()[0];
                    }

                }
            }
            catch (Exception ex) { }

            #endregion
            if (POPUPEntityObject != null)
            {
                MasterEntity.CatCode = POPUPEntityObject.CatCode;
                MasterEntity.CatName = POPUPEntityObject.CatName;
                if (POPUPEntityObject.CatCode != "All")
                {
                    var myItem = (from o in MC.SubCategoryList
                                  where o.CatCode == POPUPEntityObject.CatCode
                                  select o).ToList();
                    SubCategoryCollection = CollectionViewSource.GetDefaultView(myItem.ToList());
                    //SubCategoryCollection.Filter = new Predicate<object>(Filter_SubCategory);
                    StringListSubCategory = MC.SubCategoryList.Select(x => x.SubCatCode).ToList();
                }
                else
                {
                    SubCategoryCollection = CollectionViewSource.GetDefaultView(MC.SubCategoryList.ToList());
                    //  SubCategoryCollection.Filter = new Predicate<object>(Filter_SubCategory);
                    StringListSubCategory = MC.SubCategoryList.Select(x => x.SubCatCode).ToList();

                }
            }
        }
        private void InsertSubCategory(object InputValue)
        {
            string Request = "";
            ADM_M019_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.SubCategoryList.Where(x => x.SubCatCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M019_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M019_P>().ToList()[0];
                    }

                }
            }
            catch (Exception ex) { }

            #endregion
            if (POPUPEntityObject != null)
            {

                MasterEntity.SubCatCode = POPUPEntityObject.SubCatCode;
                MasterEntity.SubCatName = POPUPEntityObject.SubCatName;


            }
        }

        private void InsertItem(object InputValue)
        {
            string Request = "";
            ADM_M022_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ItemList.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M022_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_P>().ToList()[0];
                    }

                }
            }
            catch (Exception ex) { }

            #endregion
            if (POPUPEntityObject != null)
            {
                MasterEntity.ItemCode = POPUPEntityObject.ItemCode;
                MasterEntity.ItemName = POPUPEntityObject.ItemName;

            }
        }

        private void InsertParameter(object InputValue)
        {
            string Request = "";
            ADM_M031_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Parameter.Where(x => x.para_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M031_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M031_P>().ToList()[0];
                    }

                }
            }
            catch (Exception ex) { }

            #endregion
            if (POPUPEntityObject != null)
            {
                MasterEntity.para_code = POPUPEntityObject.para_code;
                MasterEntity.para_name = POPUPEntityObject.para_name;

            }
        }
        private void InsertParameterVal(object InputValue)
        {
            string Request = "";
            ADM_M030_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ParameterVal.Where(x => x.value_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M030_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M030_P>().ToList()[0];
                    }

                }
            }
            catch (Exception ex) { }

            #endregion
            if (POPUPEntityObject != null)
            {
                MasterEntity.value_code = POPUPEntityObject.value_code;
                MasterEntity.parametervalue = POPUPEntityObject.parametervalue;

            }
        }
        //private void WindowEvetCall(object InputValue)
        //{
        //    try
        //    {
        //        if (doc_no_vm != null && ts_code_vm != null)
        //        {
        //            LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
        //            isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
        //            AppSessionState.ViewOtherRecordAllowed = true;
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
        private void LoadInitialData()
        {
            try
            {

                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString();
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_CurrentStock>(MC, Request, "Current_Stock", "SCM", "LoadAll", 0, "");


                #region Command Initialisation
                CmdAddLocation = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
                CommandCategory = new RelayCommand<object>(items => { if (items == null) { return; } InsertCategory(items); });
                CommandSubCategory = new RelayCommand<object>(items => { if (items == null) { return; } InsertSubCategory(items); });
                CommandItem = new RelayCommand<object>(items => { if (items == null) { return; } InsertItem(items); });
                CommandParameter = new RelayCommand<object>(items => { if (items == null) { return; } InsertParameter(items); });
                CommandParameterVal = new RelayCommand<object>(items => { if (items == null) { return; } InsertParameterVal(items); });
                LoadCommand = new RelayCommand(() => { DisplayStockDetails(); });
                LoadStockCommand = new RelayCommand(() => { DisplayStock(); });
                PrintCommand = new RelayCommand(() => { DisplayReport(); });
                PrintGridCommand = new RelayCommand(() => { DisplayGridReport(); });
                ClearCommand = new RelayCommand(() => { ClearSelection(); });
                CmdAddComp = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
                CmdAddStore = new RelayCommand<object>(items => { if (items == null) { return; } InsertStore(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                #endregion

                ObjPlant = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                PlantCollection = CollectionViewSource.GetDefaultView(ObjPlant.ToList());
                PlantCollection.Filter = new Predicate<object>(FilterPlant);
                StringListPlant = ObjPlant.Select(x => x.location_Id).ToList();

                CategoryCollection = CollectionViewSource.GetDefaultView(MC.CategoryList);
                CategoryCollection.Filter = new Predicate<object>(Filter_Category);
                StringListCategory = MC.CategoryList.Select(x => x.CatCode).ToList();

                SubCategoryCollection = CollectionViewSource.GetDefaultView(MC.SubCategoryList);
                SubCategoryCollection.Filter = new Predicate<object>(Filter_SubCategory);
                StringListSubCategory = MC.SubCategoryList.Select(x => x.SubCatCode).ToList();

                ItemCollection = CollectionViewSource.GetDefaultView(MC.ItemList);
                ItemCollection.Filter = new Predicate<object>(Filter_Item);
                StringListItem = MC.ItemList.Select(x => x.ItemCode).ToList();

                ObjCompany = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                CompCollection = CollectionViewSource.GetDefaultView(ObjCompany.ToList());
                CompCollection.Filter = new Predicate<object>(FilterCompany);
                StringListCompany = ObjCompany.Select(x => x.comp_code).ToList();

                StoreCollection = CollectionViewSource.GetDefaultView(MC.StoreLocation);
                StoreCollection.Filter = new Predicate<object>(FilterStore);
                StringListStore = MC.StoreLocation.Select(x => x.store_code).ToList();



                DefaultValues(null);
            }
            catch (Exception ex)
            { }
        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
               if (doc_no_vm != null)
                {
                    DefaultValues(null);
                    MasterEntity.storage_level = "P";
                    MasterEntity.ItemCode = doc_no_vm;
                    MasterEntity.comp_code = AppSessionState.comp_code;
                    DisplayStock();
                }
                else
                {
                    DefaultValues(null);
                }
                //Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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
        private void DefaultValues(string doc_info)
        {
            MasterEntity.stockcategory = "Plant";
            MasterEntity.Date = DateTime.Now;
            //MasterEntity.location_Id = AppSessionState.location_Id;
            //MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.ReportCode = "R003";
            MasterEntity.ReportName = "As On Statement";
            MasterEntity.ItemCode = null;
            MasterEntity.stockcategory = null;
            MasterEntity.CatCode = null;
            MasterEntity.SubCatCode = null;
            MasterEntity.ItemTypeCd = null;
            MasterEntity.SubItemTpCd = null;
            MasterEntity.store_code = null;
            MasterEntity.stock_level = false;
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.comp_code = AppSessionState.comp_code;
        }

        #region filter
        private string _filterString_Company;
        public string FilterString_Company
        {
            get { return _filterString_Company; }
            set
            {
                _filterString_Company = value;
                RaisePropertyChanged("FilterString_Company");
                filterCompanyCollection();
            }
        }
        private void filterCompanyCollection()
        {
            if (_CompCollection != null)
            {
                _CompCollection.Refresh();
            }
        }
        public bool FilterCompany(object obj)
        {
            var data = obj as ADM_M002;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_Company))
                {
                    return (data.CompName != null && data.CompName.ToString().ToLower().Contains(FilterString_Company.ToLower()) ||
                        data.comp_code != null && data.comp_code.ToString().ToLower().Contains(FilterString_Company.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_plant;
        public string FilterString_plant
        {
            get { return _filterString_plant; }
            set
            {
                _filterString_plant = value;
                RaisePropertyChanged("FilterString_Item");
                filterPlantCollection();
            }
        }
        private void filterPlantCollection()
        {
            if (_PlantCollection != null)
            {
                _PlantCollection.Refresh();
            }
        }
        public bool FilterPlant(object obj)
        {
            var data = obj as ADM_M003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_plant))
                {
                    return (data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterString_plant.ToLower()) ||
                        data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString_plant.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_Store;
        public string FilterString_Store
        {
            get { return _filterString_Store; }
            set
            {
                _filterString_Store = value;
                RaisePropertyChanged("FilterString_Store");
                filterStoreCollection();
            }
        }
        private void filterStoreCollection()
        {
            if (_StoreCollection != null)
            {
                _StoreCollection.Refresh();
            }
        }
        public bool FilterStore(object obj)
        {
            var data = obj as MM_M001_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Store))
                {
                    return (data.store_code != null && data.store_code.ToString().ToLower().Contains(_filterString_Store.ToLower()) ||
                        data.store_name != null && data.store_name.ToString().ToLower().Contains(_filterString_Store.ToLower()));
                }
                return true;
            }
            return false;
        }


        private string _filterString_Category;
        public string FilterString_Category
        {
            get { return _filterString_Category; }
            set
            {
                _filterString_Category = value;
                RaisePropertyChanged("FilterString_Category");
                FilterCollection_Category();
            }
        }
        private void FilterCollection_Category()
        {
            if (_CategoryCollection != null)
            {
                _CategoryCollection.Refresh();
            }
        }
        public bool Filter_Category(object obj)
        {
            var data = obj as ADM_M018_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Category))
                {
                    return (data.CatCode != null && data.CatCode.ToString().ToLower().Contains(_filterString_Category.ToLower()) ||
                         data.CatName != null && data.CatName.ToString().ToLower().Contains(_filterString_Category.ToLower())
                        );
                }
                return true;
            }
            return false;
        }


        private string _filterString_SubCategory;
        public string FilterString_SubCategory
        {
            get { return _filterString_SubCategory; }
            set
            {
                _filterString_SubCategory = value;
                RaisePropertyChanged("FilterString_SubCategory");
                FilterCollection_SubCategory();
            }
        }
        private void FilterCollection_SubCategory()
        {
            if (_SubCategoryCollection != null)
            {
                _SubCategoryCollection.Refresh();
            }
        }
        public bool Filter_SubCategory(object obj)
        {
            var data = obj as ADM_M019_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_SubCategory))
                {
                    return (data.SubCatCode != null && data.SubCatCode.ToString().ToLower().Contains(_filterString_SubCategory.ToLower()) ||
                         data.SubCatName != null && data.SubCatName.ToString().ToLower().Contains(_filterString_SubCategory.ToLower())
                        );
                }
                return true;
            }
            return false;
        }


        private string _filterString_Item;
        public string FilterString_Item
        {
            get { return _filterString_Item; }
            set
            {
                _filterString_Item = value;
                RaisePropertyChanged("FilterString_Item");
                FilterCollection_Item();
            }
        }
        private void FilterCollection_Item()
        {
            if (_ItemCollection != null)
            {
                _ItemCollection.Refresh();
            }
        }
        public bool Filter_Item(object obj)
        {
            var data = obj as ADM_M022_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Item))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_Item.ToLower()) ||
                         data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_Item.ToLower())
                        );
                }
                return true;
            }
            return false;
        }


        private string _filterString_Paramter;
        public string FilterString_Paramter
        {
            get { return _filterString_Paramter; }
            set
            {
                _filterString_Paramter = value;
                RaisePropertyChanged("FilterString_Paramter");
                FilterCollection_Paramter();
            }
        }
        private void FilterCollection_Paramter()
        {
            if (_ParameterCollection != null)
            {
                _ParameterCollection.Refresh();
            }
        }
        public bool Filter_Parameter(object obj)
        {
            var data = obj as ADM_M031_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Paramter))
                {
                    return (data.para_code != null && data.para_code.ToString().ToLower().Contains(_filterString_Paramter.ToLower()) ||
                         data.para_name != null && data.para_name.ToString().ToLower().Contains(_filterString_Paramter.ToLower())
                        );
                }
                return true;
            }
            return false;
        }

        private string _filterString_Paramtervalue;
        public string FilterString_Paramtervalue
        {
            get { return _filterString_Paramtervalue; }
            set
            {
                _filterString_Paramtervalue = value;
                RaisePropertyChanged("FilterString_Paramtervalue");
                FilterCollection_Paramtervalue();
            }
        }
        private void FilterCollection_Paramtervalue()
        {
            if (_ParameterCollection != null)
            {
                _ParameterCollection.Refresh();
            }
        }
        public bool Filter_ParameterValue(object obj)
        {
            var data = obj as ADM_M030_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Paramtervalue))
                {
                    return (data.value_code != null && data.value_code.ToString().ToLower().Contains(_filterString_Paramtervalue.ToLower()) ||
                         data.parametervalue != null && data.parametervalue.ToString().ToLower().Contains(_filterString_Paramtervalue.ToLower())
                        );
                }
                return true;
            }
            return false;
        }










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
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }
        public bool Filter_FlipGrid(object obj)
        {
            var data = obj as CurrentStock;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_FlipGrid))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.store_code != null && data.store_code.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.stock_total != null && data.stock_total.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.stock_reserve != null && data.stock_reserve.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));


                }
                return true;
            }
            return false;
        }
        public bool Filter_FlipGrid1(object obj)
        {
            var data = obj as MIS_SCM_StoreRpt;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_FlipGrid))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.description != null && data.description.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           //(data.posting_period != null && data.posting_period.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.sku_desc != null && data.sku_desc.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.Make != null && data.Make.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.Type != null && data.Type.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.Mat_Condition != null && data.Mat_Condition.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.Grade != null && data.Grade.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.ink != null && data.ink.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.ild != null && data.ild.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.stock_total != null && data.stock_total.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.quantity != null && data.quantity.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));


                }
                return true;
            }
            return false;
        }
        #endregion

        protected override void OnSaveAction(InquiryActionResult<CurrentStock> result)
        {
        }
        protected override void OnCreateAction(InquiryActionResult<CurrentStock> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<CurrentStock> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<CurrentStock> result)
        {
            //SelectedSEL_T001.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<CurrentStock> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<CurrentStock> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<CurrentStock> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<CurrentStock> result)
        {

        }
        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<CurrentStock> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<CurrentStock> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<CurrentStock> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<CurrentStock> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<CurrentStock> result)
        {
            throw new NotImplementedException();
        }
    }

}
