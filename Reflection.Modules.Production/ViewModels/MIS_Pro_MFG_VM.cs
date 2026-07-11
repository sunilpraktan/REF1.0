using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.BusinessEntity.Production;
using Reflection.WebServices.Gateway;
using Reflection.BusinessEntity;
using Reflection.Presentation.Services;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using GalaSoft.MvvmLight.Command;
using System.Windows.Data;
using Reflection.ReportingServices;
using Reflection.Presentation.Common;

namespace Reflection.Modules.Production.ViewModels
{
    class MIS_Pro_MFG_VM : WorkspaceViewModel<MIS_Pro_MFGEntity>
    {
        #region Declaration

        bool blNew = true;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        WebServiceRepository<MultipleContext_MIS_Pro_MFG> repository_MC = new WebServiceRepository<MultipleContext_MIS_Pro_MFG>();
        ObjectSerializationService obj = new ObjectSerializationService();
        //Report Repository
        WebServiceRepository<List<Rpt_MIS_Pro_MFG>> repository = new WebServiceRepository<List<Rpt_MIS_Pro_MFG>>();
        MultipleContext_MIS_Pro_MFG _MC = new MultipleContext_MIS_Pro_MFG();
        public MultipleContext_MIS_Pro_MFG MC
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

        private MIS_Pro_MFGEntity _ReportParametersEntity;
        public MIS_Pro_MFGEntity ReportParametersEntity
        {
            get
            {
                return _ReportParametersEntity;
            }
            set
            {
                _ReportParametersEntity = value;
                RaisePropertyChanged("ReportParametersEntity");
            }
        }

        public List<ADM_M002> _ObjComp = new List<ADM_M002>();
        private List<ADM_M002> ObjComp
        {
            get { return _ObjComp; }
            set
            {
                if (_ObjComp != value)
                {
                    _ObjComp = value;
                }
            }
        }

        public List<ADM_M003> _ObjPlant = new List<ADM_M003>();
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

        private List<Rpt_MIS_Pro_MFG> _dsReport;
        public List<Rpt_MIS_Pro_MFG> dsReport
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

        #endregion

        #region Dictionaries

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

        private Dictionary<string, object> _compDictionaryParent;
        public Dictionary<string, object> CompDictionaryParent
        {
            get { return _compDictionaryParent; }
            set
            {
                if (_compDictionaryParent != value)
                {
                    _compDictionaryParent = value;
                    RaisePropertyChanged("CompDictionaryParent");
                }
            }
        }

        private Dictionary<string, object> _plantDictionaryParent;
        public Dictionary<string, object> PlantDictionaryParent
        {
            get { return _plantDictionaryParent; }
            set
            {
                if (_plantDictionaryParent != value)
                {
                    _plantDictionaryParent = value;
                    RaisePropertyChanged("PlantDictionaryParent");
                }
            }
        }

        private Dictionary<string, object> _unitDictionaryParent;
        public Dictionary<string, object> UnitDictionaryParent
        {
            get { return _unitDictionaryParent; }
            set
            {
                if (_unitDictionaryParent != value)
                {
                    _unitDictionaryParent = value;
                    RaisePropertyChanged("UnitDictionaryParent");
                }
            }
        }

        private Dictionary<string, object> _TipTypeDictionary;
        public Dictionary<string, object> TipTypeDictionary
        {
            get { return _TipTypeDictionary; }
            set
            {
                if (_TipTypeDictionary != value)
                {
                    _TipTypeDictionary = value;
                    RaisePropertyChanged("TipTypeDictionary");
                }
            }
        }

        private Dictionary<string, object> _WireTyDictionaryParent;
        public Dictionary<string, object> WireTyDictionaryParent
        {
            get { return _WireTyDictionaryParent; }
            set
            {
                if (_WireTyDictionaryParent != value)
                {
                    _WireTyDictionaryParent = value;
                    RaisePropertyChanged("WireTyDictionaryParent");
                }
            }
        }

        private Dictionary<string, object> _BallTyDictionaryParent;
        public Dictionary<string, object> BallTyDictionaryParent
        {
            get { return _BallTyDictionaryParent; }
            set
            {
                if (_BallTyDictionaryParent != value)
                {
                    _BallTyDictionaryParent = value;
                    RaisePropertyChanged("BallTyDictionaryParent");
                }
            }
        }

        private Dictionary<string, object> _ILDDictionaryParent;
        public Dictionary<string, object> ILDDictionaryParent
        {
            get { return _ILDDictionaryParent; }
            set
            {
                if (_ILDDictionaryParent != value)
                {
                    _ILDDictionaryParent = value;
                    RaisePropertyChanged("ILDDictionaryParent");
                }
            }
        }

        private Dictionary<string, object> _InkDictionaryParent;
        public Dictionary<string, object> InkDictionaryParent
        {
            get { return _InkDictionaryParent; }
            set
            {
                if (_InkDictionaryParent != value)
                {
                    _InkDictionaryParent = value;
                    RaisePropertyChanged("InkDictionaryParent");
                }
            }
        }

        private Dictionary<string, object> _BlankDictionary;
        public Dictionary<string, object> BlankDictionary
        {
            get { return _BlankDictionary; }
            set
            {
                if (_BlankDictionary != value)
                {
                    _BlankDictionary = value;
                    RaisePropertyChanged("BlankDictionary");
                }
            }
        }

        private Dictionary<string, object> _empDictionaryParent;
        public Dictionary<string, object> EmpDictionaryParent
        {
            get { return _empDictionaryParent; }
            set
            {
                if (_empDictionaryParent != value)
                {
                    _empDictionaryParent = value;
                    RaisePropertyChanged("EmpDictionaryParent");
                }
            }
        }
        #endregion

        #region String List variables

        private List<ADM_M003> _strListPlant;
        public List<ADM_M003> StrListPlant
        {
            get { return _strListPlant; }
            set
            {
                if (_strListPlant != value)
                {
                    _strListPlant = value;
                    RaisePropertyChanged("StrListPlant");
                }
            }
        }

        private List<ADM_M002> _strListCompany;
        public List<ADM_M002> StrListCompany
        {
            get { return _strListCompany; }
            set
            {
                if (_strListCompany != value)
                {
                    _strListCompany = value;
                    RaisePropertyChanged("StrListCompany");
                }
            }
        }

        private List<string> _stringListItems;
        public List<string> StringListItems
        {
            get { return _stringListItems; }
            set
            {
                if (_stringListItems != value)
                {
                    _stringListItems = value;
                }
            }
        }

        private List<ADM_M038_B_P> _strListUnit;
        public List<ADM_M038_B_P> StrListUnit
        {
            get { return _strListUnit; }
            set
            {
                if (_strListUnit != value)
                {
                    _strListUnit = value;
                    RaisePropertyChanged("StrListUnit");
                }
            }
        }

        private List<ZADM_M010_P> _strListTipType;
        public List<ZADM_M010_P> StrListTipType
        {
            get { return _strListTipType; }
            set
            {
                if (_strListTipType != value)
                {
                    _strListTipType = value;
                    RaisePropertyChanged("StrListTipType");
                }
            }
        }

        private List<ZADM_M004_P> _strListWireTy;
        public List<ZADM_M004_P> strListWireTy
        {
            get { return _strListWireTy; }
            set
            {
                if (_strListWireTy != value)
                {
                    _strListWireTy = value;
                    RaisePropertyChanged("strListWireTy");
                }
            }
        }

        private List<ZADM_M002_P> _strListBallTy;
        public List<ZADM_M002_P> strListBallTy
        {
            get { return _strListBallTy; }
            set
            {
                if (_strListBallTy != value)
                {
                    _strListBallTy = value;
                    RaisePropertyChanged("strListBallTy");
                }
            }
        }

        private List<ZADM_M007_P> _strListILD;
        public List<ZADM_M007_P> strListILD
        {
            get { return _strListILD; }
            set
            {
                if (_strListILD != value)
                {
                    _strListILD = value;
                    RaisePropertyChanged("strListILD");
                }
            }
        }

        private List<ZADM_M006_P> _strListInk;
        public List<ZADM_M006_P> strListInk
        {
            get { return _strListInk; }
            set
            {
                if (_strListInk != value)
                {
                    _strListInk = value;
                    RaisePropertyChanged("_strListInk");
                }
            }
        }

        private List<ZADM_M010_P> _strListBlank;
        public List<ZADM_M010_P> strListBlank
        {
            get { return _strListBlank; }
            set
            {
                if (_strListBlank != value)
                {
                    _strListBlank = value;
                    RaisePropertyChanged("strListBlank");
                }
            }
        }

        private List<ADM_M024_P> _strListEmployee;
        public List<ADM_M024_P> StringListEmployee
        {
            get { return _strListEmployee; }
            set
            {
                if (_strListEmployee != value)
                {
                    _strListEmployee = value;
                    RaisePropertyChanged("StringListEmployee");
                }
            }
        }

        #endregion

        #region Collections

        private ICollectionView _ItemsCollection;
        public ICollectionView ItemsCollection
        {
            get { return _ItemsCollection; }
            set { _ItemsCollection = value; RaisePropertyChanged("ItemsCollection"); }
        }

        #endregion

        #region RelayCommands      
        public RelayCommand cmdReport { get; private set; }
        public RelayCommand<object> cmdItemChange { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }

        #endregion

        #region Constructor

        public MIS_Pro_MFG_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            CursorControl.SetBusyState();
            MC = new MultipleContext_MIS_Pro_MFG();
            ReportParametersEntity = new MIS_Pro_MFGEntity();
            _dsReport = new List<Rpt_MIS_Pro_MFG>();

            ReportItemsDictionary = new Dictionary<string, string>();
            ReportItemsDictionary.Add("R001", "MachineWise Production");
            
            LoadInitialData();
            DefaultValues();

        }
        public MIS_Pro_MFG_VM(string ts_code,string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            CursorControl.SetBusyState();
            MC = new MultipleContext_MIS_Pro_MFG();
            ReportParametersEntity = new MIS_Pro_MFGEntity();
            _dsReport = new List<Rpt_MIS_Pro_MFG>();

            ReportItemsDictionary = new Dictionary<string, string>();
            ReportItemsDictionary.Add("R001", "MachineWise Production");

            LoadInitialData();
            DefaultValues();

        }

        #endregion

        #region User Defined Function
        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString();
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_MIS_Pro_MFG>(MC, Request, "MIS_Pro_MFG", "Production", "LoadAll", 0, "");

                #region Command Initialisation
                cmdItemChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertItem(items); });
                cmdReport = new RelayCommand(DisplayReport);
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                #endregion
                //items
                ItemsCollection = CollectionViewSource.GetDefaultView(MC.ItemDetails);
                ItemsCollection.Filter = new Predicate<object>(FilterItem);

                //Company
                ObjComp = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CompListParent = (from o in ObjComp
                                      where o.comp_code != null
                                      select o).ToList();
                _strListCompany = CompListParent;
                CompDictionaryParent = _strListCompany.ToDictionary(X => X.comp_code.ToString(), X => (object)X.CompName);

                // Plant or Location
                ObjPlant = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var PlantListParent = (from o in ObjPlant
                                       where o.location_Id != null
                                       select o).ToList();
                _strListPlant = PlantListParent;
                PlantDictionaryParent = _strListPlant.ToDictionary(X => X.location_Id.ToString(), X => (object)X.LoctnNm);

                //Unit
                var UnitListParent = (from o in MC.UnitDetails
                                      where o.unit_code != null
                                      select o).ToList();
                _strListUnit = UnitListParent;
                UnitDictionaryParent = _strListUnit.ToDictionary(X => X.unit_code.ToString(), X => (object)X.unit_code);


                //TipType
                var TipTypeListParent = (from o in MC.TipTypes
                                      where o.tip_type != null
                                      select o).ToList();
                _strListTipType = TipTypeListParent;
                TipTypeDictionary = _strListTipType.ToDictionary(X => X.tip_type.ToString(), X => (object)X.tip_type);

                //Wire
                var WireListParent = (from o in MC.WireTypeDetails
                                      where o.wire_type_id.ToString() != null
                                      select o).ToList();
                _strListWireTy = WireListParent;
                WireTyDictionaryParent = _strListWireTy.ToDictionary(X => X.wire_type_id.ToString(), X => (object)X.wire_type);

                //BallType
                var BallTyListParent = (from o in MC.BallTypeDetails
                                        where o.ball_type_id.ToString() != null
                                        select o).ToList();
                _strListBallTy = BallTyListParent;
                BallTyDictionaryParent = _strListBallTy.ToDictionary(X => X.ball_type_id.ToString(), X => (object)X.ball_type);

                //ILD
                var ILDListParent = (from o in MC.ILDDetails
                                     where o.ild != null
                                     select o).ToList();
                _strListILD = ILDListParent;
                ILDDictionaryParent = _strListILD.ToDictionary(X => X.ild.ToString(), X => (object)X.ild);

                //Ink
                var InkListParent = (from o in MC.InkDetails
                                     where o.ink.ToString() != null
                                     select o).ToList();
                _strListInk = InkListParent;
                InkDictionaryParent = _strListInk.ToDictionary(X => X.ink.ToString(), X => (object)X.ink);

                //Blank
                var BlankListParent = (from o in MC.BlankDetails
                                       where o.blank.ToString() != null
                                       select o).ToList();
                _strListBlank = BlankListParent;
                BlankDictionary = _strListBlank.ToDictionary(X => X.blank.ToString(), X => (object)X.blank.ToString());

                //Employee
                var EmpListParent = (from o in MC.Employee
                                     where o.EmpId != null
                                     select o).ToList();
                _strListEmployee = EmpListParent;
                EmpDictionaryParent = _strListEmployee.ToDictionary(X => X.EmpId.ToString(), X => (object)X.EmpName);
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
            ReportParametersEntity.ts_code = ts_code_vm;
            ReportParametersEntity.comp_code = AppSessionState.comp_code;
            //ReportParametersEntity.fin_year = AppSessionState.FinYear;
            ReportParametersEntity.location_Id = AppSessionState.location_Id;

            DateTime now = DateTime.Now;
            DateTime lastDayLastMonth = new DateTime(now.Year, now.Month, 1);
            ReportParametersEntity.FromDate = lastDayLastMonth.AddDays(-30);
            ReportParametersEntity.ToDate = DateTime.Now;
        }
        private void InsertItem(object InputValue)
        {
            string stringItems = "";
            string stringItemsNm = "";

            ReportParametersEntity.ItemCode = "";
            foreach (ZADM_M010_P temp in MC.ItemDetails)
            {
                if (temp.Select == true)
                {
                    stringItems = stringItems + "," + temp.prod_id;
                    stringItemsNm = stringItemsNm + "," + temp.prodnm;
                }
            }
            ReportParametersEntity.ItemCode = stringItems.ToString().TrimStart(new char[] { ',' });
            ReportParametersEntity.ItemName = stringItemsNm.ToString().TrimStart(new char[] { ',' });

        }
        private void DisplayReport()
        {
            CursorControl.SetBusyState();
            try
            {
                if (ReportParametersEntity.ReportCode.ToString() == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Report Type");
                    showMessageService.ShowMessage();
                }

                if (ReportParametersEntity.ReportCode.ToString() != "")
                {   
                    if (ReportParametersEntity.ItemCode == null) { ReportParametersEntity.ItemCode = "All"; }
                    if (ReportParametersEntity.ItemName == null) { ReportParametersEntity.ItemName = "All"; }
                    if (ReportParametersEntity.EmpId == null) { ReportParametersEntity.EmpId = "All"; }                                   
                    if (ReportParametersEntity.TipType == null) { ReportParametersEntity.TipType = "All"; }                    
                    if (ReportParametersEntity.description == null) { ReportParametersEntity.description = "All"; }
                    if (ReportParametersEntity.wire_type == null) { ReportParametersEntity.wire_type = "All"; }
                    if (ReportParametersEntity.ball_type == null) { ReportParametersEntity.ball_type = "All"; }
                    if (ReportParametersEntity.ild == null) { ReportParametersEntity.ild = "All"; }
                    if (ReportParametersEntity.ink == null) { ReportParametersEntity.ink = "All"; }
                    if (ReportParametersEntity.Blank == null) { ReportParametersEntity.Blank = "All"; }
                    if (ReportParametersEntity.unit_code == null) { ReportParametersEntity.unit_code = "All"; }
                }
                ReportParametersEntity = ReportParametersEntity;
                if (ReportParametersEntity.ReportCode.ToString() != "")
                {
                    string RequestParameter = "Report" + "!@" + ReportParametersEntity.ReportCode + "!@" + ReportParametersEntity.location_Id + "!@"  + ReportParametersEntity.comp_code + "!@" + ReportParametersEntity.ItemCode + "!@" + ReportParametersEntity.unit_code + "!@" + Convert.ToDateTime(ReportParametersEntity.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParametersEntity.ToDate).ToString("MM/dd/yyyy") + "!@" + ReportParametersEntity.TipType + "!@" + ReportParametersEntity.Blank + "!@" + ReportParametersEntity.wire_type + "!@" + ReportParametersEntity.ball_type + "!@" + ReportParametersEntity.ild + "!@" + ReportParametersEntity.ink ;
                    dsReport = repository.GetDataWithReturnDomainObject<List<Rpt_MIS_Pro_MFG>>(dsReport, RequestParameter, "MIS_Pro_MFG", "Production", "", 0, RequestParameter);

                    //object[] objDataSource = new object[6];
                    //string[] objDataSourceName = new string[6];


                    //objDataSource[0] = dsReport;

                    //List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    //var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == ReportParametersEntity.comp_code).ToList();
                    //objDataSource[1] = CmpResult;

                    //List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    //var Result = TempList.Where(loc => loc.location_Id == ReportParametersEntity.location_Id).ToList();
                    //objDataSource[2] = Result;
                    
                    //objDataSourceName[0] = "dsRpt_MIS_Pro_MFG";
                    //objDataSourceName[1] = "dsCompany";
                    //objDataSourceName[2] = "dsLocation";
                   
                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(dsReport, "dsRpt_MIS_Pro_MFG", "\\MIS\\Production\\" + GetReportFile(ReportParametersEntity.ReportCode), getParametersList());
                    //ReportManager.DisplayReport(objDataSource, "dsRpt_MIS_Pro_MFG", objDataSourceName, "\\MIS\\Production\\" + GetReportFile(ReportParametersEntity.ReportCode), getParametersList());
                    //ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\MIS\\Production\\" + GetReportFile(ReportParametersEntity.ReportCode), getParametersList());
                }
            }
            catch(Exception ex)
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
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {    
                result.Add("FromDate", Convert.ToString(ReportParametersEntity.FromDate));
                result.Add("ToDate", Convert.ToString(ReportParametersEntity.ToDate));
                result.Add("ItemCode", ReportParametersEntity.ItemCode);
                result.Add("ItemName", ReportParametersEntity.ItemName);
                result.Add("location_Id", ReportParametersEntity.location_Id);
                result.Add("comp_code", ReportParametersEntity.comp_code);
                result.Add("unit_code", ReportParametersEntity.unit_code);              
                result.Add("TipType", ReportParametersEntity.TipType);
                result.Add("wire_type", ReportParametersEntity.wire_type);
                result.Add("ball_type", ReportParametersEntity.ball_type);
                result.Add("ink", ReportParametersEntity.ink);
                result.Add("ild", ReportParametersEntity.ild);
                result.Add("ReportName", ReportParametersEntity.ReportName);
                result.Add("Blank", ReportParametersEntity.Blank);               
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
            if (ReportCode == "R001")
            { returnReportName = "ItemWiseProduction.rdlc"; }
          
            return returnReportName;
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
                    Request = ReportParametersEntity.client + "!@" + ReportParametersEntity.comp_code + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }

        #endregion

        #region Filters

        private string _filterString_Item;
        public string FilterString_Item
        {
            get { return _filterString_Item; }
            set
            {
                _filterString_Item = value;
                RaisePropertyChanged("FilterString_Item");
                FilterCollectionItem();
            }
        }
        private void FilterCollectionItem()
        {
            if (_ItemsCollection != null)
            {
                _ItemsCollection.Refresh();
            }
        }
        public bool FilterItem(object obj)
        {
            var data = obj as ZADM_M010_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Item))
                {
                    return (data.prod_id!= null && data.prod_id.ToString().ToLower().Contains(_filterString_Item.ToLower()) ||
                            (data.prodnm != null && data.prodnm.ToString().ToLower().Contains(_filterString_Item.ToLower()))
                        );
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Abstaract Class Implementation

        protected override void OnCreateAction(InquiryActionResult<MIS_Pro_MFGEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDiscardAction(InquiryActionResult<MIS_Pro_MFGEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFevoriteAction(InquiryActionResult<MIS_Pro_MFGEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFlipAction(InquiryActionResult<MIS_Pro_MFGEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnHelpAction(InquiryActionResult<MIS_Pro_MFGEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnPrintAction(InquiryActionResult<MIS_Pro_MFGEntity> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<MIS_Pro_MFGEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnSaveAction(InquiryActionResult<MIS_Pro_MFGEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<MIS_Pro_MFGEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MIS_Pro_MFGEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MIS_Pro_MFGEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MIS_Pro_MFGEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MIS_Pro_MFGEntity> result)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
