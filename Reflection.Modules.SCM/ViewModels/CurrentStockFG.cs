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
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using Reflection.Presentation.Services.Convertors;

namespace Reflection.Modules.SCM.ViewModels
{
    public class CurrentStockFG : WorkspaceViewModel<CurrentStock>
    {

        #region AutoSuggest TextBox Declaration Region
        //public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(SEL_T001_INQ_VM));
        //public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }


        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _ASDefault { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault
        {
            get { return _ASDefault; }
            set
            {
                if (_ASDefault != value)
                {
                    _ASDefault = value; RaisePropertyChanged("ASDefault");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASLocation { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASLocation
        {
            get { return _ASLocation; }
            set
            {
                if (_ASLocation != value)
                {
                    _ASLocation = value; RaisePropertyChanged("ASLocation");
                }
            }
        }          
        private AutoSuggestTextViewModel<dynamic> _ASItems { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASItems
        {
            get { return _ASItems; }
            set
            {
                if (_ASItems != value)
                {
                    _ASItems = value; RaisePropertyChanged("ASItems");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASUOM { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASUOM
        {
            get { return _ASUOM; }
            set
            {
                if (_ASUOM != value)
                {
                    _ASUOM = value; RaisePropertyChanged("ASUOM");
                }
            }
        }
            
        #endregion
        #region Variable Declaration
        WebServiceRepository<CurrentStock> repository = new WebServiceRepository<CurrentStock>();
        WebServiceRepository<MultipleContext_CurrentStock> repository_MC = new WebServiceRepository<MultipleContext_CurrentStock>();
        ObjectSerializationService obj = new ObjectSerializationService();
        private MultipleContext_CurrentStock _MC = new MultipleContext_CurrentStock();
        WebServiceRepository<List<MIS_SCM_StoreRpt>> repository_Store = new WebServiceRepository<List<MIS_SCM_StoreRpt>>();

        MultipleContext_CurrentStock MCTemp = new MultipleContext_CurrentStock();
        WebServiceRepository<MultipleContext_CurrentStock> repository_MC2 = new WebServiceRepository<MultipleContext_CurrentStock>();

        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
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
        private Dictionary<string, object> _GradeDictionaryParent;
        public Dictionary<string, object> GradeDictionaryParent
        {
            get { return _GradeDictionaryParent; }
            set
            {
                if (_GradeDictionaryParent != value)
                {
                    _GradeDictionaryParent = value;
                    RaisePropertyChanged("GradeDictionaryParent");
                }
            }
        }

        #endregion
        #region . ICollection .
        private ICollectionView _CategoryCollection;
        public ICollectionView CategoryCollection
        {
            get { return _CategoryCollection; }
            set { _CategoryCollection = value; RaisePropertyChanged("CategoryCollection"); }
        }

        private ICollectionView _ItemCollection;
        public ICollectionView ItemCollection
        {
            get { return _ItemCollection; }
            set { _ItemCollection = value; RaisePropertyChanged("ItemCollection"); }
        }
        private ICollectionView _GradeCollection;
        public ICollectionView GradeCollection
        {
            get { return _GradeCollection; }
            set { _GradeCollection = value; RaisePropertyChanged("GradeCollection"); }
        }
        private ICollectionView _uomCollection;
        public ICollectionView UomCollection
        {
            get { return _uomCollection; }
            set { _uomCollection = value; RaisePropertyChanged("UomCollection"); }
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


        private ICollectionView _PlantCollection;
        public ICollectionView PlantCollection
        {
            get { return _PlantCollection; }
            set { _PlantCollection = value; RaisePropertyChanged("PlantCollection"); }
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

        //private Dictionary<string, string> _ReportItemsDictionary;
        //public Dictionary<string, string> ReportItemsDictionary
        //{
        //    get { return _ReportItemsDictionary; }
        //    set
        //    {
        //        if (_ReportItemsDictionary != value)
        //        {
        //            _ReportItemsDictionary = value;
        //            RaisePropertyChanged("ReportItemsDictionary");
        //        }
        //    }
        //}

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

        private List<ADM_M045_P> _strListGrade;
        public List<ADM_M045_P> strListGrade
        {
            get { return _strListGrade; }
            set
            {
                if (_strListGrade != value)
                {
                    _strListGrade = value;
                    RaisePropertyChanged("strListGrade");
                }
            }
        }
        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> CmdAddLocation { get; private set; }
        public RelayCommand<object> CommandCategory { get; private set; }

        public RelayCommand<object> CommandItem { get; private set; }
        public RelayCommand<object> CommandUom { get; private set; }
        public RelayCommand<object> CommandParameter { get; private set; }
        public RelayCommand<object> CommandParameterVal { get; private set; }
        public RelayCommand<IList> CollectionChangedCommand { get; private set; }
        public RelayCommand<IList> SelectionChangedParaValCommand { get; private set; }
        public RelayCommand<object> LoadCommand { get; private set; }
        public RelayCommand<object> PrintCommand { get; private set; }
        public RelayCommand<object> ClearCommand { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        #endregion
        #region Constructor
        public CurrentStockFG(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new CurrentStock();
            MC = new MultipleContext_CurrentStock();
            _dsReport = new List<MIS_SCM_StoreRpt>();

            //ReportItemsDictionary = new Dictionary<string, string>();            
            // ReportItemsDictionary.Add("R004", "As On Statement For FG");

            ImpLocDictionary = new Dictionary<string, string>();
            ImpLocDictionary.Add("ALL", "ALL");
            ImpLocDictionary.Add("Local", "Local");
            ImpLocDictionary.Add("Import", "Import");

            LoadInitialData();
        }

        public CurrentStockFG(string ts_code,string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new CurrentStock();
            MC = new MultipleContext_CurrentStock();
            _dsReport = new List<MIS_SCM_StoreRpt>();

            //ReportItemsDictionary = new Dictionary<string, string>();            
            // ReportItemsDictionary.Add("R004", "As On Statement For FG");

            ImpLocDictionary = new Dictionary<string, string>();
            ImpLocDictionary.Add("ALL", "ALL");
            ImpLocDictionary.Add("Local", "Local");
            ImpLocDictionary.Add("Import", "Import");

            LoadInitialData();
        }
        #endregion
        #region load
        private void DisplayStockDetails()
        {
            try
            {
                string RequestParameter = "Report" + "!@" + MasterEntity.ReportCode + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + Convert.ToDateTime(MasterEntity.Date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(MasterEntity.Date).ToString("MM/dd/yyyy") + "!@" + MasterEntity.CatCode + "!@" + MasterEntity.SubCatCode + "!@" + "ALL" + "!@" + MasterEntity.ItemCode + "!@" + MasterEntity.unit_code + "!@" + "ALL" + "!@" + "ALL" + "!@" + "ALL" + "!@" + "ALL" + "!@" + "ALL" + "!@" + "ALL" + "!@" + "ALL" + "!@" + MasterEntity.grade_code;              
                MCTemp = repository_MC2.GetDataWithReturnDomainObject<MultipleContext_CurrentStock>(MCTemp, RequestParameter, "Current_Stock", "SCM", "", 0, "");

                if (MCTemp.StoreList.Count >= 0)
                {
                    DataGridCollection = CollectionViewSource.GetDefaultView(MCTemp.StoreList);
                    DataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid1);

                    if (MasterEntity.ItemCode != null)
                    {
                        var abc3 = from o in MCTemp.StoreList
                                   where o.ItemCode == MasterEntity.ItemCode
                                   select o;
                        MasterEntity.ts_code = ts_code_vm;
                        DataGridCollection = CollectionViewSource.GetDefaultView(abc3);
                        DataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid1);
                    }
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
               

                string RequestParameter = "Report" + "!@" + MasterEntity.ReportCode + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + Convert.ToDateTime(MasterEntity.Date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(MasterEntity.Date).ToString("MM/dd/yyyy") + "!@" + MasterEntity.CatCode + "!@" + MasterEntity.SubCatCode + "!@" + "ALL" + "!@" + MasterEntity.ItemCode + "!@" + MasterEntity.unit_code + "!@" + "ALL" + "!@" + "ALL" + "!@" + "ALL" + "!@" + "ALL" + "!@" + "ALL" + "!@" + "ALL" + "!@" + "ALL" + "!@" + MasterEntity.grade_code;               
                MCTemp = repository_MC2.GetDataWithReturnDomainObject<MultipleContext_CurrentStock>(MCTemp, RequestParameter, "Current_Stock", "SCM", "", 0, "");

                if (MCTemp.StoreList.Count >= 0)
                {
                    object[] objDataSource = new object[3];
                    string[] objDataSourceName = new string[3];

                    if (MasterEntity.ItemCode != null)
                    {
                        var abc4 = from o in MCTemp.StoreList
                                   where o.ItemCode == MasterEntity.ItemCode
                                   select o;

                        objDataSource[0] = abc4.ToList();
                    }
                    else
                    {
                        objDataSource[0] = MCTemp.StoreList;
                    }                  

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

            if (ReportCode == "R004")
            {
                returnReportName = "StockReportFG.rdlc";
            }
            return returnReportName;
        }
        private void ClearSelection()
        {
            MasterEntity = new CurrentStock();
            DefaultValues();

            MCTemp.StoreList.Clear();
            DataGridCollection = CollectionViewSource.GetDefaultView(MCTemp.StoreList);
            DataGridCollection.Refresh();

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
        #endregion
        #region insert
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
                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.CatCode = POPUPEntityObject.CatCode;
                    MasterEntity.CatName = POPUPEntityObject.CatName;
                }
            }
            catch (Exception ex) { }
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
        private void InsertUom(object InputValue)
        {
            string Request = "";
            ADM_M038_B_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UomDetails.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M038_B_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                    }

                }
            }
            catch (Exception ex) { }

            #endregion
            if (POPUPEntityObject != null)
            {
                MasterEntity.unit_code = POPUPEntityObject.unit_code;

            }
        }
        #endregion
        private void LoadInitialData()
        {
            try
            {
                List<ADM_M022_P> abc = new List<ADM_M022_P>();
               

                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString();
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_CurrentStock>(MC, Request, "Current_Stock", "SCM", "LoadAll", 0, "");

                #region Command Initialisation
                CmdAddLocation = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
                CommandCategory = new RelayCommand<object>(items => { if (items == null) { return; } InsertCategory(items); });

                CommandItem = new RelayCommand<object>(items => { if (items == null) { return; } InsertItem(items); });
                CommandUom = new RelayCommand<object>(items => { if (items == null) { return; } InsertUom(items); });

                LoadCommand = new RelayCommand<object>((items) => { DisplayStockDetails(); });
                PrintCommand = new RelayCommand<object>((items) => { DisplayReport(); });
                ClearCommand = new RelayCommand<object>((items) => { ClearSelection(); });
                //cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                #endregion

                ObjPlant = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                PlantCollection = CollectionViewSource.GetDefaultView(ObjPlant.ToList());
                PlantCollection.Filter = new Predicate<object>(FilterPlant);
                StringListPlant = ObjPlant.Select(x => x.location_Id).ToList();

                abc = (from o in MC.ItemList
                       where o.CatCode == "FG"
                       select o).ToList();

                ItemCollection = CollectionViewSource.GetDefaultView(abc.ToList());
                ItemCollection.Filter = new Predicate<object>(Filter_Item);
                StringListItem = abc.Select(x => x.ItemCode).ToList();

                UomCollection = CollectionViewSource.GetDefaultView(MC.UomDetails);
                UomCollection.Filter = new Predicate<object>(Filter_UOM);
                StringListUOM = MC.UomDetails.Select(x => x.unit_code.ToString()).ToList();

                DefaultValues();
                #region AutoSuggest Initialisation

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).LoctnNm);
                TheFilter = (o, prefix) => ((ADM_M003)o).location_Id.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase) || ((ADM_M003)o).LoctnNm.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase);                
                ASLocation = new AutoSuggestTextViewModel<dynamic>(ObjPlant.ToList(), TheFilter, SuggestedValue, "LoctnNm", true);
                ASLocation.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => ((ADM_M038_B_P)o).unit_code.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase) || ((ADM_M038_B_P)o).unit_name.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase);
                ASUOM = new AutoSuggestTextViewModel<dynamic>(MC.UomDetails, TheFilter, SuggestedValue, "unit_code", true);
                ASUOM.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_P)x).ItemCode);
                TheFilter = (o, prefix) => ((ADM_M022_P)o).ItemCode.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase) || ((ADM_M022_P)o).ItemName.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase);
                ASItems = new AutoSuggestTextViewModel<dynamic>(abc.ToList(), TheFilter, SuggestedValue, "ItemCode", true);
                ASItems.AutoSuggestVM.IsEmptyValueAllowed = true;

                //Grade
                var GradeListParent = (from o in MC.GradeDetails
                                       where o.grade_code != null
                                       select o).ToList();
                _strListGrade = GradeListParent;
                GradeDictionaryParent = _strListGrade.ToDictionary(X => X.grade_code.ToString(), X => (object)X.grade_code);

                #endregion             
            }
            catch (Exception ex)
            { }
        }
        private void DefaultValues()
        {
            MasterEntity.CatCode = "FG";

            var abc2 = from o in MC.CategoryList
                       where o.CatCode == MasterEntity.CatCode
                       select o;

            MasterEntity.CatName = abc2.ToList()[0].CatName;

            MasterEntity.stockcategory = "Plant";
            MasterEntity.Date = DateTime.Now;
            MasterEntity.location_Id = AppSessionState.location_Id;

            var abc1 = from o in ObjPlant
                       where o.location_Id == MasterEntity.location_Id
                       select o;

            MasterEntity.LoctnNm = abc1.ToList()[0].LoctnNm;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.ts_code = ts_code_vm;

            MasterEntity.ReportCode = "R004";
            MasterEntity.ReportName = "As On Statement For FG";

            //ReportItemsDictionary.Add("R004", "As On Statement For FG");

        }

        #region filter
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
        //Filter For Unit
        private string _filterString_UOM;
        public string FilterString_UOM
        {
            get { return _filterString_UOM; }
            set
            {
                _filterString_UOM = value;
                RaisePropertyChanged("FilterString_UOM");
                FilterCollection_UOM();
            }
        }
        private void FilterCollection_UOM()
        {
            if (_uomCollection != null)
            {
                _uomCollection.Refresh();
            }
        }
        public bool Filter_UOM(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_UOM))
                {
                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterString_UOM.ToLower()) ||
                           (data.unit_abbrv != null && data.unit_abbrv.ToString().ToLower().Contains(_filterString_UOM.ToLower()) ||
                            data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterString_UOM.ToLower())));
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
                           (data.posting_period != null && data.posting_period.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.sku_desc != null && data.sku_desc.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.Make != null && data.Make.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.Type != null && data.Type.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.Mat_Condition != null && data.Mat_Condition.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.Grade != null && data.Grade.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.ink != null && data.ink.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.ild != null && data.ild.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.quantity != null && data.quantity.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));


                }
                return true;
            }
            return false;
        }
        #endregion
        #region Abstract Command Actions
        protected override void OnSaveAction(InquiryActionResult<CurrentStock> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnCreateAction(InquiryActionResult<CurrentStock> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnRemoveAction(InquiryActionResult<CurrentStock> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDiscardAction(InquiryActionResult<CurrentStock> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnPrintAction(InquiryActionResult<CurrentStock> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFlipAction(InquiryActionResult<CurrentStock> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnHelpAction(InquiryActionResult<CurrentStock> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFevoriteAction(InquiryActionResult<CurrentStock> result)
        {
            throw new NotImplementedException();
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
        #endregion
    }
}
