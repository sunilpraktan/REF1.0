using Reflection.Modules.SCM.Views;
using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.BusinessEntity;
using Reflection.ReportingServices;
using System.Collections;
using Reflection.Presentation.Services;
using System.Data;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.WebServices.Gateway;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Reflection.BusinessEntity.SCM;
using Reflection.Presentation.Common;

namespace Reflection.Modules.SCM.ViewModels
{

    class MIS_FinStatement_VM : WorkspaceViewModel<MIS_FinStatement>
    {

        #region Declaration


        WebServiceRepository<MultipleContext_MIS_FinStatement> repository_MC = new WebServiceRepository<MultipleContext_MIS_FinStatement>();
        ObjectSerializationService obj = new ObjectSerializationService();
        WebServiceRepository<List<MIS_RptFinStatement>> repository = new WebServiceRepository<List<MIS_RptFinStatement>>();
        WebServiceRepository<UptoDateTotalTS> repository_UptoDate = new WebServiceRepository<UptoDateTotalTS>();

        MultipleContext_MIS_FinStatement _MC = new MultipleContext_MIS_FinStatement();
        public MultipleContext_MIS_FinStatement MC
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

        public string ts_code_vm { get; set; }
        MultipleContext_MIS_FinStatement _MCTemp = new MultipleContext_MIS_FinStatement();
        public MultipleContext_MIS_FinStatement MCTemp
        {
            get { return _MCTemp; }
            set
            {
                if (_MCTemp != value)
                {
                    _MCTemp = value;

                    RaisePropertyChanged("_MCTemp");
                }
            }
        }
        private MIS_FinStatement _ReportParameters;
        public MIS_FinStatement ReportParameters
        {
            get
            {

                return _ReportParameters;
            }
            set
            {
                _ReportParameters = value;
                RaisePropertyChanged("ReportParameters");
            }
        }

        private List<MIS_RptFinStatement> _dsReportUpdate;
        public List<MIS_RptFinStatement> dsReportUpdate
        {
            get { return _dsReportUpdate; }
            set
            {
                if (_dsReportUpdate != value)
                {
                    _dsReportUpdate = value;


                    RaisePropertyChanged("dsReportUpdate");

                }
            }
        }

        private MIS_RptFinStatement _dsReport;
        public MIS_RptFinStatement dsReport
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

        private MIS_RptFinStatement _dsReportImp;
        public MIS_RptFinStatement dsReportImp
        {
            get { return _dsReportImp; }
            set
            {
                if (_dsReportImp != value)
                {
                    _dsReportImp = value;


                    RaisePropertyChanged("dsReportImp");

                }
            }
        }
        private MIS_RptFinStatement _dsReportLoc;
        public MIS_RptFinStatement dsReportLoc
        {
            get { return _dsReportLoc; }
            set
            {
                if (_dsReportLoc != value)
                {
                    _dsReportLoc = value;


                    RaisePropertyChanged("dsReportLoc");

                }
            }
        }
        private UptoDateTotalTS _dsUptoDateImp;
        public UptoDateTotalTS dsUptoDateImp
        {
            get { return _dsUptoDateImp; }
            set
            {
                if (_dsUptoDateImp != value)
                {
                    _dsUptoDateImp = value;


                    RaisePropertyChanged("dsUptoDateImp");

                }
            }
        }

        private UptoDateTotalTS _dsUptoDateLoc;
        public UptoDateTotalTS dsUptoDateLoc
        {
            get { return _dsUptoDateLoc; }
            set
            {
                if (_dsUptoDateLoc != value)
                {
                    _dsUptoDateLoc = value;


                    RaisePropertyChanged("dsUptoDateLoc");

                }
            }
        }

        private UptoDateTS _dsPreviousImp;
        public UptoDateTS dsPreviousImp
        {
            get { return _dsPreviousImp; }
            set
            {
                if (_dsPreviousImp != value)
                {
                    _dsPreviousImp = value;


                    RaisePropertyChanged("dsPreviousImp");

                }
            }
        }

        private UptoDateTS _dsPreviousLoc;
        public UptoDateTS dsPreviousLoc
        {
            get { return _dsPreviousLoc; }
            set
            {
                if (_dsPreviousLoc != value)
                {
                    _dsPreviousLoc = value;


                    RaisePropertyChanged("dsPreviousLoc");

                }
            }
        }
        #endregion

        #region List
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


        #endregion

        #region Dictionary for ComboList
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

        private Dictionary<string, object> _MatConDictionary;
        public Dictionary<string, object> MatConDictionary
        {
            get { return _MatConDictionary; }
            set
            {
                if (_MatConDictionary != value)
                {
                    _MatConDictionary = value;
                    RaisePropertyChanged("MatConDictionary");
                }
            }
        }

        private Dictionary<string, object> _ImpLocDictionary;
        public Dictionary<string, object> ImpLocDictionary
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



        private Dictionary<string, object> _MakeDictionary;
        public Dictionary<string, object> MakeDictionary
        {
            get { return _MakeDictionary; }
            set
            {
                if (_MakeDictionary != value)
                {
                    _MakeDictionary = value;
                    RaisePropertyChanged("MakeDictionary");
                }
            }
        }

        private Dictionary<string, object> _CurUnCurDictionary;
        public Dictionary<string, object> CurUnCurDictionary
        {
            get { return _CurUnCurDictionary; }
            set
            {
                if (_CurUnCurDictionary != value)
                {
                    _CurUnCurDictionary = value;
                    RaisePropertyChanged("CurUnCurDictionary");
                }
            }
        }

        private Dictionary<string, object> _MachTypeDictionary;
        public Dictionary<string, object> MachTypeDictionary
        {
            get { return _MachTypeDictionary; }
            set
            {
                if (_MachTypeDictionary != value)
                {
                    _MachTypeDictionary = value;
                    RaisePropertyChanged("MachTypeDictionary");
                }
            }
        }

        #endregion

        #region ICollection

        private ICollectionView _CompanyCollection;
        public ICollectionView CompanyCollection
        {
            get { return _CompanyCollection; }
            set
            {
                _CompanyCollection = value;
                RaisePropertyChanged("CompanyCollection");
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

        private ICollectionView _uomCollection;
        public ICollectionView UomCollection
        {
            get { return _uomCollection; }
            set { _uomCollection = value; RaisePropertyChanged("UomCollection"); }
        }

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

        private ICollectionView _FinCollection;
        public ICollectionView FinCollection
        {
            get { return _FinCollection; }
            set { _FinCollection = value; RaisePropertyChanged("FinCollection"); }
        }

        private ICollectionView _PostCollection;
        public ICollectionView PostCollection
        {
            get { return _PostCollection; }
            set { _PostCollection = value; RaisePropertyChanged("PostCollection"); }
        }
        private ICollectionView _ItemsCollection;
        public ICollectionView ItemsCollection
        {
            get { return _ItemsCollection; }
            set { _ItemsCollection = value; RaisePropertyChanged("ItemsCollection"); }
        }
        private ICollectionView _MakeCollection;
        public ICollectionView MakeCollection
        {
            get { return _MakeCollection; }
            set { _MakeCollection = value; RaisePropertyChanged("MakeCollection"); }
        }

        private ICollectionView _TypeCollection;
        public ICollectionView TypeCollection
        {
            get { return _TypeCollection; }
            set { _TypeCollection = value; RaisePropertyChanged("TypeCollection"); }
        }

        private ICollectionView _MatConditionCollection;
        public ICollectionView MatConditionCollection
        {
            get { return _MatConditionCollection; }
            set { _MatConditionCollection = value; RaisePropertyChanged("MatConditionCollection"); }
        }
        #endregion

        #region StringList Variables


        private List<string> _srtListCompany;
        public List<string> StringListCompany
        {
            get { return _srtListCompany; }
            set
            {
                if (_srtListCompany != value)
                {
                    _srtListCompany = value;
                }
            }
        }
        private List<string> _strListPlant;
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

        private List<string> _stringListUOM;
        public List<string> StringListUOM
        {
            get { return _stringListUOM; }
            set
            {
                if (_stringListUOM != value)
                {
                    _stringListUOM = value;
                }
            }
        }

        private List<string> _StringListCat;
        public List<string> StringListCat
        {
            get { return _StringListCat; }
            set
            {
                if (_StringListCat != value)
                {
                    _StringListCat = value;
                }
            }
        }
        private List<string> _StringListSubCat;
        public List<string> StringListSubCat
        {
            get { return _StringListSubCat; }
            set
            {
                if (_StringListSubCat != value)
                {
                    _StringListSubCat = value;
                }
            }
        }

        //Fin year
        private List<string> _StringListFinYr;
        public List<string> StringListFinYr
        {
            get { return _StringListFinYr; }
            set
            {
                if (_StringListFinYr != value)
                {
                    _StringListFinYr = value;
                }
            }
        }
        //Post Period
        private List<string> _StringListPost;
        public List<string> StringListPost
        {
            get { return _StringListPost; }
            set
            {
                if (_StringListPost != value)
                {
                    _StringListPost = value;
                }
            }
        }
        //Item
        List<string> _stringListItems;
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
        //sku

        private List<string> _strListMake;
        public List<string> StringListMake
        {
            get { return _strListMake; }
            set
            {
                if (_strListMake != value)
                {
                    _strListMake = value;
                    RaisePropertyChanged("StringListMake");
                }
            }
        }

        private List<ADM_M030_P> _StrMatCon;
        public List<ADM_M030_P> StrMatCon
        {
            get { return _StrMatCon; }
            set
            {
                if (_StrMatCon != value)
                {
                    _StrMatCon = value;
                    RaisePropertyChanged("StrMatCon");
                }
            }
        }

        private List<ADM_M030_P> _StrType;
        public List<ADM_M030_P> StrType
        {
            get { return _StrType; }
            set
            {
                if (_StrType != value)
                {
                    _StrType = value;
                    RaisePropertyChanged("StrType");
                }
            }
        }
        private List<ADM_M030_P> _StrMake;
        public List<ADM_M030_P> StrMake
        {
            get { return _StrMake; }
            set
            {
                if (_StrMake != value)
                {
                    _StrMake = value;
                    RaisePropertyChanged("_StrMake");
                }
            }
        }
        #endregion

        #region RelayCommands      
        public RelayCommand<object> cmdCompanyChange { get; private set; }
        public RelayCommand<object> cmdPlantChange { get; private set; }
        public RelayCommand<object> cmdUnitChange { get; private set; }
        public RelayCommand<object> cmdCatChange { get; private set; }
        public RelayCommand<object> cmdSubCatChange { get; private set; }
        public RelayCommand cmdReport { get; private set; }
        public RelayCommand cmdClear { get; private set; }
        public RelayCommand<object> cmdMake { get; private set; }
        public RelayCommand<object> cmdFinYr { get; private set; }
        public RelayCommand<object> cmdPostPeriod { get; private set; }
        public RelayCommand CmdUpdateClosing { get; private set; }
        public RelayCommand CmdUpdateCurrStock { get; private set; }
        public RelayCommand<object> cmdItemChange { get; private set; }
        public RelayCommand cmdClearUpTodate { get; private set; }
        public RelayCommand cmdLoadUptodate { get; private set; }
        public RelayCommand cmdInsertTotal { get; private set; }

        #endregion

        #region Constructor
        public MIS_FinStatement_VM(string ts_code)
            : base()
        {
            this.ts_code_vm = ts_code;
            CursorControl.SetBusyState();
            MC = new MultipleContext_MIS_FinStatement();
            ReportParameters = new MIS_FinStatement();
            _dsReportUpdate = new List<MIS_RptFinStatement>();
            dsPreviousImp = new UptoDateTS();
            dsPreviousLoc = new UptoDateTS();
            dsUptoDateImp = new UptoDateTotalTS();
            dsUptoDateLoc = new UptoDateTotalTS();
            ReportItemsDictionary = new Dictionary<string, string>();
            CurUnCurDictionary = new Dictionary<string, object>();
            MachTypeDictionary = new Dictionary<string, object>();

            // ReportItemsDictionary.Add("R001", "Financial Statement");
            ReportItemsDictionary.Add("R002", "Financial Statement Group By Import/Local");
            ReportItemsDictionary.Add("R003", "Consumption Report Acc. To Machine");
            ReportItemsDictionary.Add("R004", "Financial Statement Up to Date");
            ReportItemsDictionary.Add("R009", "Daily Basis Consumption Report");
            ReportItemsDictionary.Add("R010", "Financial Statement WithOut Current/UnCurrent");
            ReportItemsDictionary.Add("R012", "Financial Statement WithOut Current/UnCurrent Report");
            ReportItemsDictionary.Add("R013", "Financial Stock Statement Report");

            CurUnCurDictionary.Add("All", "All");
            CurUnCurDictionary.Add("Current", "Current");
            CurUnCurDictionary.Add("UnCurrent", "UnCurrent");

            MachTypeDictionary.Add("All", "All");
            MachTypeDictionary.Add("LX", "LX");
            MachTypeDictionary.Add("PM", "PM");

            cmdCompanyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
            cmdPlantChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
            cmdUnitChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertUnit(items); });
            cmdCatChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertCat(items); });
            cmdSubCatChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertSubCat(items); });
            cmdReport = new RelayCommand(DisplayReport);
            cmdClear = new RelayCommand(ClearData);
            cmdMake = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertMake(cmdPara, false, true, true); });
            cmdFinYr = new RelayCommand<object>(items => { if (items == null) { return; } InsertFinYr(items); });
            cmdPostPeriod = new RelayCommand<object>(items => { if (items == null) { return; } InsertPostPeriod(items); });
            CmdUpdateClosing = new RelayCommand(Update_closing);
            CmdUpdateCurrStock = new RelayCommand(Update_CurrStock);
            cmdItemChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertItem(items); });

            cmdClearUpTodate = new RelayCommand(ClearUpTodate);
            cmdLoadUptodate = new RelayCommand(LoadUptodate);
            cmdInsertTotal = new RelayCommand(InsertTotal);

            LoadInitialData();
            DefaultValues();

        }
        private void ClearUpTodate()
        {

            try
            {
                dsReportImp = new MIS_RptFinStatement();
                dsReportLoc = new MIS_RptFinStatement();
                dsPreviousImp = new UptoDateTS();
                dsPreviousLoc = new UptoDateTS();
                dsUptoDateImp = new UptoDateTotalTS();
                dsUptoDateLoc = new UptoDateTotalTS();
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
        private void LoadUptodate()
        {

            try
            {
                //Check if Report not selected then give a Message.
                if (ReportParameters.ReportCode == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Report Type");
                    showMessageService.ShowMessage();
                }

                //Check if Fields are not Selected then assign it to 'All'.
                if (ReportParameters.ReportCode != null)
                {
                    if (ReportParameters.CatCode == null) { ReportParameters.CatCode = "All"; }
                    if (ReportParameters.CatName == null) { ReportParameters.CatName = "All"; }
                    if (ReportParameters.SubCatCode == null) { ReportParameters.SubCatCode = "All"; }
                    if (ReportParameters.SubCatName == null) { ReportParameters.SubCatName = "All"; }
                    if (ReportParameters.parametervalue == null) { ReportParameters.parametervalue = "All"; }
                    if (ReportParameters.value_code == null) { ReportParameters.value_code = "All"; }
                    if (ReportParameters.MatConditionCode == null) { ReportParameters.MatConditionCode = "All"; }
                    if (ReportParameters.MatConditionValue == null) { ReportParameters.MatConditionValue = "All"; }
                    if (ReportParameters.ImportLocalCode == null) { ReportParameters.ImportLocalCode = "All"; }
                    if (ReportParameters.ImportLocalValue == null) { ReportParameters.ImportLocalValue = "All"; }
                    if (ReportParameters.CurUnCur == null) { ReportParameters.CurUnCur = "All"; }
                    if (ReportParameters.mctype == null) { ReportParameters.mctype = "All"; }
                    if (ReportParameters.wire_type == null) { ReportParameters.wire_type = "All"; }
                    if (ReportParameters.TipType == null) { ReportParameters.TipType = "All"; }
                    if (ReportParameters.wire_size == null || ReportParameters.wire_size == "") { ReportParameters.wire_size = "All"; }
                }

                //Diaplay Selected Report.
                if (ReportParameters.ReportCode != null)
                {
                    string RequestParameter = "LoadUptodateTS" + "!@" + ReportParameters.ReportCode + "!@" + ReportParameters.comp_code + "!@" + ReportParameters.location_Id + "!@" + Convert.ToDateTime(ReportParameters.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParameters.ToDate).ToString("MM/dd/yyyy") + "!@" + ReportParameters.CatCode + "!@" + ReportParameters.SubCatCode + "!@" + ReportParameters.unit_code + "!@" + ReportParameters.value_code + "!@" + ReportParameters.ImportLocalCode + "!@" + ReportParameters.MatConditionCode + "!@" + ReportParameters.CurUnCur + "!@" + ReportParameters.Duration + "!@" + ReportParameters.Remark + "!@" + ReportParameters.posting_period + "!@" + ReportParameters.fin_year + "!@" + ReportParameters.mctype + "!@" + ReportParameters.wire_type + "!@" + ReportParameters.wire_size_id;
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_MIS_FinStatement>(MC, RequestParameter, "MIS_FinStatement", "SCM", "", 0, RequestParameter);

                    if (ReportParameters.ImportLocalCode == "10629")
                    {
                        if (MCTemp.FinReportData.Count() > 0)
                        {
                            dsReportImp = MCTemp.FinReportData[0];
                        }
                        else if (MCTemp.FinReportData.Count() == 0)
                        {
                            dsReportImp.OpenQty = 0; dsReportImp.OpenValue = 0; dsReportImp.PurQty = 0; dsReportImp.PurValue = 0; dsReportImp.DebitQty = 0;
                            dsReportImp.DebitValue = 0; dsReportImp.SalesQty = 0; dsReportImp.SalesValue = 0; dsReportImp.IssueQty = 0; dsReportImp.IssueValue = 0;
                            dsReportImp.ClosingQty = 0; dsReportImp.ClosingValue = 0; dsReportImp.ShortageQty = 0; dsReportImp.ShortageValue = 0; dsReportImp.RecieptQty = 0; dsReportImp.RecieptValue = 0;

                        }
                        if (MCTemp.PreviousUptoDateTS.Count() > 0)
                        {
                            dsPreviousImp = MCTemp.PreviousUptoDateTS[0];
                        }
                        else if (MCTemp.PreviousUptoDateTS.Count() == 0)
                        {
                            dsPreviousImp.OpenValue = 0; dsPreviousImp.PurQty = 0; dsPreviousImp.PurValue = 0; dsPreviousImp.DebitQty = 0;
                            dsPreviousImp.DebitValue = 0; dsPreviousImp.IssueQty = 0; dsPreviousImp.IssueValue = 0; dsPreviousImp.ReceiptQty = 0; dsPreviousImp.ReceiptValue = 0;
                            dsPreviousImp.SalesQty = 0; dsPreviousImp.SalesValue = 0; dsPreviousImp.ClosingQty = 0; dsPreviousImp.ClosingValue = 0; dsPreviousImp.ShortageQty = 0;
                            dsPreviousImp.ShortageValue = 0;
                        }
                    }
                    else if (ReportParameters.ImportLocalCode == "10628")
                    {
                        if (MCTemp.FinReportData.Count() > 0)
                        {
                            dsReportLoc = MCTemp.FinReportData[0];
                        }
                        else if (MCTemp.FinReportData.Count() == 0)
                        {
                            dsReportLoc.OpenQty = 0; dsReportLoc.OpenValue = 0; dsReportLoc.PurQty = 0; dsReportLoc.PurValue = 0; dsReportLoc.DebitQty = 0;
                            dsReportLoc.DebitValue = 0; dsReportLoc.SalesQty = 0; dsReportLoc.SalesValue = 0; dsReportLoc.IssueQty = 0; dsReportLoc.IssueValue = 0;
                            dsReportLoc.ClosingQty = 0; dsReportLoc.ClosingValue = 0; dsReportLoc.ShortageQty = 0; dsReportLoc.ShortageValue = 0; dsReportLoc.RecieptQty = 0; dsReportLoc.RecieptValue = 0;

                        }
                        if (MCTemp.PreviousUptoDateTS.Count() > 0)
                        {
                            dsPreviousLoc = MCTemp.PreviousUptoDateTS[0];
                        }
                        else if (MCTemp.PreviousUptoDateTS.Count() == 0)
                        {
                            dsPreviousLoc.OpenValue = 0; dsPreviousLoc.PurQty = 0; dsPreviousLoc.PurValue = 0; dsPreviousLoc.DebitQty = 0;
                            dsPreviousLoc.DebitValue = 0; dsPreviousLoc.IssueQty = 0; dsPreviousLoc.IssueValue = 0; dsPreviousLoc.ReceiptQty = 0; dsPreviousLoc.ReceiptValue = 0;
                            dsPreviousLoc.SalesQty = 0; dsPreviousLoc.SalesValue = 0; dsPreviousLoc.ClosingQty = 0; dsPreviousLoc.ClosingValue = 0; dsPreviousLoc.ShortageQty = 0;
                            dsPreviousLoc.ShortageValue = 0;
                        }
                    }
                    else if (ReportParameters.ImportLocalCode == "All" || ReportParameters.ImportLocalCode == "")
                    {
                        if (MCTemp.FinReportData.Count() > 0)
                        {
                            if (MCTemp.FinReportData.Count() == 1)
                            {
                                if (MCTemp.FinReportData[0].Type == "Import")
                                {
                                    dsReportImp = MCTemp.FinReportData[0];
                                }
                                if (MCTemp.FinReportData[0].Type == "Local")
                                {
                                    dsReportLoc = MCTemp.FinReportData[0];
                                }
                            }
                            if (MCTemp.FinReportData.Count() == 2)
                            {
                                if (MCTemp.FinReportData[0].Type == "Import")
                                {
                                    dsReportImp = MCTemp.FinReportData[0];
                                }
                                else if (MCTemp.FinReportData[0].Type == "Local")
                                {
                                    dsReportLoc = MCTemp.FinReportData[0];
                                }

                                if (MCTemp.FinReportData[1].Type == "Import")
                                {
                                    dsReportImp = MCTemp.FinReportData[1];
                                }
                                else if (MCTemp.FinReportData[1].Type == "Local")
                                {
                                    dsReportLoc = MCTemp.FinReportData[1];
                                }
                            }

                        }
                        else if (MCTemp.FinReportData.Count() == 0)
                        {
                            dsReportLoc.OpenQty = 0; dsReportLoc.OpenValue = 0; dsReportLoc.PurQty = 0; dsReportLoc.PurValue = 0; dsReportLoc.DebitQty = 0;
                            dsReportLoc.DebitValue = 0; dsReportLoc.SalesQty = 0; dsReportLoc.SalesValue = 0; dsReportLoc.IssueQty = 0; dsReportLoc.IssueValue = 0;
                            dsReportLoc.ClosingQty = 0; dsReportLoc.ClosingValue = 0; dsReportLoc.ShortageQty = 0; dsReportLoc.ShortageValue = 0; dsReportLoc.RecieptQty = 0; dsReportLoc.RecieptValue = 0;

                            dsReportImp.OpenQty = 0; dsReportImp.OpenValue = 0; dsReportImp.PurQty = 0; dsReportImp.PurValue = 0; dsReportImp.DebitQty = 0;
                            dsReportImp.DebitValue = 0; dsReportImp.SalesQty = 0; dsReportImp.SalesValue = 0; dsReportImp.IssueQty = 0; dsReportImp.IssueValue = 0;
                            dsReportImp.ClosingQty = 0; dsReportImp.ClosingValue = 0; dsReportImp.ShortageQty = 0; dsReportImp.ShortageValue = 0; dsReportImp.RecieptQty = 0; dsReportImp.RecieptValue = 0;

                        }

                        //if (MCTemp.PreviousUptoDateTS.Count() > 0)
                        // {
                        //     if (MCTemp.PreviousUptoDateTS[0].Type == "10628")
                        //     {
                        //         if (MCTemp.PreviousUptoDateTS[0].Type == "10628")
                        //         {
                        //             dsPreviousLoc = MCTemp.PreviousUptoDateTS[0];
                        //         }
                        //     }
                        //     else
                        //     {
                        //         dsPreviousImp = MCTemp.PreviousUptoDateTS[0];
                        //     }

                        //     if (MCTemp.PreviousUptoDateTS[1].Type == "10629")
                        //     {
                        //         if (MCTemp.PreviousUptoDateTS[1].Type == "10629")
                        //         {
                        //             dsPreviousImp = MCTemp.PreviousUptoDateTS[1];
                        //         }
                        //         else
                        //         {
                        //             dsPreviousLoc = MCTemp.PreviousUptoDateTS[1];
                        //         }
                        //     }


                        // }

                        if (MCTemp.PreviousUptoDateTS.Count() > 0)
                        {
                            if (MCTemp.PreviousUptoDateTS.Count() == 1)
                            {
                                if (MCTemp.PreviousUptoDateTS[0].Type == "10628")
                                {
                                    dsPreviousLoc = MCTemp.PreviousUptoDateTS[0];
                                }
                                else if (MCTemp.PreviousUptoDateTS[0].Type == "10629")
                                {
                                    dsPreviousImp = MCTemp.PreviousUptoDateTS[0];
                                }
                            }
                            else if (MCTemp.PreviousUptoDateTS.Count() == 2)
                            {
                                if (MCTemp.PreviousUptoDateTS[0].Type == "10628")
                                {
                                    dsPreviousLoc = MCTemp.PreviousUptoDateTS[0];
                                }
                                else if (MCTemp.PreviousUptoDateTS[0].Type == "10629")
                                {
                                    dsPreviousImp = MCTemp.PreviousUptoDateTS[0];
                                }
                                if (MCTemp.PreviousUptoDateTS[1].Type == "10629")
                                {
                                    dsPreviousImp = MCTemp.PreviousUptoDateTS[1];
                                }
                                else if (MCTemp.PreviousUptoDateTS[1].Type == "10628")
                                {
                                    dsPreviousLoc = MCTemp.PreviousUptoDateTS[1];
                                }
                            }


                        }
                        else if (MCTemp.PreviousUptoDateTS.Count() == 0)
                        {
                            dsPreviousLoc.OpenValue = 0; dsPreviousLoc.PurQty = 0; dsPreviousLoc.PurValue = 0; dsPreviousLoc.DebitQty = 0;
                            dsPreviousLoc.DebitValue = 0; dsPreviousLoc.IssueQty = 0; dsPreviousLoc.IssueValue = 0; dsPreviousLoc.ReceiptQty = 0; dsPreviousLoc.ReceiptValue = 0;
                            dsPreviousLoc.SalesQty = 0; dsPreviousLoc.SalesValue = 0; dsPreviousLoc.ClosingQty = 0; dsPreviousLoc.ClosingValue = 0; dsPreviousLoc.ShortageQty = 0;
                            dsPreviousLoc.ShortageValue = 0;

                            dsPreviousImp.OpenValue = 0; dsPreviousImp.PurQty = 0; dsPreviousImp.PurValue = 0; dsPreviousImp.DebitQty = 0;
                            dsPreviousImp.DebitValue = 0; dsPreviousImp.IssueQty = 0; dsPreviousImp.IssueValue = 0; dsPreviousImp.ReceiptQty = 0; dsPreviousImp.ReceiptValue = 0;
                            dsPreviousImp.SalesQty = 0; dsPreviousImp.SalesValue = 0; dsPreviousImp.ClosingQty = 0; dsPreviousImp.ClosingValue = 0; dsPreviousImp.ShortageQty = 0;
                            dsPreviousImp.ShortageValue = 0;
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
        private void InsertTotal()
        {
            try
            {
                if (ReportParameters.ImportLocalCode == "10628")
                {
                    if (dsUptoDateLoc != null)
                    {
                        dsUptoDateLoc.fin_year = ReportParameters.fin_year;
                        dsUptoDateLoc.posting_period = ReportParameters.posting_period;
                        dsUptoDateLoc.location_Id = ReportParameters.location_Id;
                        dsUptoDateLoc.ImportLocalCode = ReportParameters.ImportLocalCode;
                        dsUptoDateLoc.SubCatCode = ReportParameters.SubCatCode;
                        dsUptoDateLoc = repository_UptoDate.SaveWithReturnDomainObject<UptoDateTotalTS>(dsUptoDateLoc, "MIS_FinStatement_InsertTS", "SCM");
                    }
                }
                else if (ReportParameters.ImportLocalCode == "10629")
                {
                    if (dsUptoDateImp != null)
                    {
                        dsUptoDateImp.fin_year = ReportParameters.fin_year;
                        dsUptoDateImp.posting_period = ReportParameters.posting_period;
                        dsUptoDateImp.location_Id = ReportParameters.location_Id;
                        dsUptoDateImp.ImportLocalCode = ReportParameters.ImportLocalCode;
                        dsUptoDateImp.SubCatCode = ReportParameters.SubCatCode;
                        dsUptoDateImp = repository_UptoDate.SaveWithReturnDomainObject<UptoDateTotalTS>(dsUptoDateImp, "MIS_FinStatement_InsertTS", "SCM");

                    }
                }

                else if (ReportParameters.ImportLocalCode == "All" || ReportParameters.ImportLocalCode == "")
                {
                    if (dsUptoDateLoc != null && dsUptoDateImp != null)
                    {
                        dsUptoDateLoc.fin_year = ReportParameters.fin_year;
                        dsUptoDateLoc.posting_period = ReportParameters.posting_period;
                        dsUptoDateLoc.location_Id = ReportParameters.location_Id;
                        dsUptoDateLoc.ImportLocalCode = "10628";
                        dsUptoDateLoc.SubCatCode = ReportParameters.SubCatCode;

                        dsUptoDateImp.fin_year = ReportParameters.fin_year;
                        dsUptoDateImp.posting_period = ReportParameters.posting_period;
                        dsUptoDateImp.location_Id = ReportParameters.location_Id;
                        dsUptoDateImp.ImportLocalCode = "10629";
                        dsUptoDateImp.SubCatCode = ReportParameters.SubCatCode;

                        dsUptoDateLoc.XmlDataDocument_dsUptoDateImp = obj.ObjectToXML(dsUptoDateImp);
                        dsUptoDateLoc = repository_UptoDate.SaveWithReturnDomainObject<UptoDateTotalTS>(dsUptoDateLoc, "MIS_FinStatement_InsertTS", "SCM");

                    }
                }

                if (dsUptoDateLoc != null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Data Saved Successfully");
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

        private void InsertParty(object items, bool blNew, object sender)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region User Defined Function
        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString();
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_MIS_FinStatement>(MC, Request, "MIS_FinStatement", "SCM", "LoadAll", 0, "");

                //Loading  Data on Popups.

                UomCollection = CollectionViewSource.GetDefaultView(MC.UnitDetails.ToList());
                UomCollection.Filter = new Predicate<object>(FilterUom);
                StringListUOM = MC.UnitDetails.Select(x => x.unit_code).ToList();

                CategoryCollection = CollectionViewSource.GetDefaultView(MC.CategoryDetails.ToList());
                CategoryCollection.Filter = new Predicate<object>(FilterCategory);
                StringListCat = MC.CategoryDetails.Select(x => x.CatCode).ToList();

                SubCategoryCollection = CollectionViewSource.GetDefaultView(MC.SubCategoryDetails.ToList());
                SubCategoryCollection.Filter = new Predicate<object>(FilterSubCategory);
                StringListSubCat = MC.SubCategoryDetails.Select(x => x.SubCatCode).ToList();

                ObjComp = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                CompanyCollection = CollectionViewSource.GetDefaultView(ObjComp.ToList());
                CompanyCollection.Filter = new Predicate<object>(FilterCompany);
                StringListCompany = ObjComp.Select(x => x.comp_code).ToList();

                ObjPlant = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                PlantCollection = CollectionViewSource.GetDefaultView(ObjPlant.ToList());
                PlantCollection.Filter = new Predicate<object>(FilterPlant);
                StringListPlant = ObjPlant.Select(x => x.location_Id).ToList();

                //SKU

                List<ADM_M030_P> makelist = (from o in MC.ParamValueList
                                             where o.para_code == "1002" || o.para_code == "All"
                                             select o).ToList();
                MakeCollection = CollectionViewSource.GetDefaultView(makelist);
                MakeCollection.Filter = new Predicate<object>(FilterMake);
                StringListMake = makelist.Select(x => x.parametervalue).ToList();

                var Typelist = (from o in MC.ParamValueList
                                where o.para_code == "1001" || o.para_code == "All"
                                select o).ToList();
                _StrType = Typelist;
                ImpLocDictionary = _StrType.ToDictionary(X => X.value_code.ToString(), X => (object)X.parametervalue);

                var matconlist = (from o in MC.ParamValueList
                                  where o.para_code == "1003" || o.para_code == "All"
                                  select o).ToList();
                _StrMatCon = matconlist;
                MatConDictionary = _StrMatCon.ToDictionary(X => X.value_code.ToString(), X => (object)X.parametervalue);

                //Fin year and Posting period
                FinCollection = CollectionViewSource.GetDefaultView(MC.FinYear.ToList());
                FinCollection.Filter = new Predicate<object>(FilterFinYr);
                StringListFinYr = MC.FinYear.Select(x => x.fin_year).ToList();

                PostCollection = CollectionViewSource.GetDefaultView(MC.PostPeriod.ToList());
                PostCollection.Filter = new Predicate<object>(FilterPost);
                StringListPost = MC.PostPeriod.Select(x => x.posting_period).ToList();

                ItemsCollection = CollectionViewSource.GetDefaultView(MC.ItemDetails);
                ItemsCollection.Filter = new Predicate<object>(FilterItem);
                StringListItems = MC.ItemDetails.Select(x => x.ItemCode).ToList();


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
        private void ClearData()
        {

            try
            {
                ReportParameters = new MIS_FinStatement();
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
        private void Update_closing()
        {
            try
            {

                string RequestParameter = "UpdateClosing" + "!@" + ReportParameters.ReportCode + "!@" + ReportParameters.comp_code + "!@" + ReportParameters.location_Id + "!@" + Convert.ToDateTime(ReportParameters.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParameters.ToDate).ToString("MM/dd/yyyy") + "!@" + ReportParameters.CatCode + "!@" + ReportParameters.SubCatCode + "!@" + ReportParameters.unit_code + "!@" + ReportParameters.value_code + "!@" + ReportParameters.ImportLocalCode + "!@" + ReportParameters.MatConditionCode + "!@" + ReportParameters.CurUnCur + "!@" + ReportParameters.Duration + "!@" + ReportParameters.Remark + "!@" + ReportParameters.posting_period + "!@" + ReportParameters.fin_year + "!@" + ReportParameters.mctype + "!@" + ReportParameters.wire_type + "!@" + ReportParameters.wire_size_id + "!@" + ReportParameters.ItemCode;
                dsReportUpdate = repository.GetDataWithReturnDomainObject<List<MIS_RptFinStatement>>(dsReportUpdate, RequestParameter, "MIS_FinStatement", "SCM", "", 0, RequestParameter);
                if (dsReportUpdate[0].ItemCode == "Updated")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Closing Updated Sucessfully", this.Title);
                    showMessageService.ShowMessage();
                }
                else if (dsReportUpdate[0].ItemCode == "CantUpdate")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Sorry Updating Fails ", this.Title);
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
        private void Update_CurrStock()
        {
            try
            {

                string RequestParameter = "UpdateCurrStock" + "!@" + ReportParameters.ReportCode + "!@" + ReportParameters.comp_code + "!@" + ReportParameters.location_Id + "!@" + Convert.ToDateTime(ReportParameters.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParameters.ToDate).ToString("MM/dd/yyyy") + "!@" + ReportParameters.CatCode + "!@" + ReportParameters.SubCatCode + "!@" + ReportParameters.unit_code + "!@" + ReportParameters.value_code + "!@" + ReportParameters.ImportLocalCode + "!@" + ReportParameters.MatConditionCode + "!@" + ReportParameters.CurUnCur + "!@" + ReportParameters.Duration + "!@" + ReportParameters.Remark + "!@" + ReportParameters.posting_period + "!@" + ReportParameters.fin_year + "!@" + ReportParameters.mctype + "!@" + ReportParameters.wire_type + "!@" + ReportParameters.wire_size_id + "!@" + ReportParameters.ItemCode;
                dsReportUpdate = repository.GetDataWithReturnDomainObject<List<MIS_RptFinStatement>>(dsReportUpdate, RequestParameter, "MIS_FinStatement", "SCM", "", 0, RequestParameter);
                if (dsReportUpdate[0].ItemCode == "Updated")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Current Stock Updated Sucessfully", this.Title);
                    showMessageService.ShowMessage();
                }
                else if (dsReportUpdate[0].ItemCode == "CantUpdate")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Sorry Current Stock Updating Fails ", this.Title);
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

        private void DefaultValues()
        {

            ReportParameters.comp_code = AppSessionState.comp_code;
            ReportParameters.doc_cat = "";
            ReportParameters.doc_no = "";
            ReportParameters.doc_type = "";
            ReportParameters.Duration = "6";
            ReportParameters.fin_year = "17-18";
            ReportParameters.posting_period = "1";
            ReportParameters.location_Id = AppSessionState.location_Id;

            DateTime now = DateTime.Now;
            DateTime lastDayLastMonth = new DateTime(now.Year, now.Month, 1);
            ReportParameters.FromDate = lastDayLastMonth.AddDays(0);
            ReportParameters.ToDate = DateTime.Now;
        }
        private void InsertMake(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                string Request = "";
                ADM_M030_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {

                            POPUPEntityObject = MC.ParamValueList.Where(x => x.parametervalue.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
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

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    ReportParameters.value_code = POPUPEntityObject.value_code;
                    ReportParameters.parametervalue = POPUPEntityObject.parametervalue;
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
        private void InsertItem(object InputValue)
        {
            string stringItems = "";
            string stringItemsNm = "";

            ReportParameters.ItemCode = "";
            foreach (ADM_M022_P temp in MC.ItemDetails)
            {
                if (temp.Select == true)
                {
                    stringItems = stringItems + "," + temp.ItemCode;
                    stringItemsNm = stringItemsNm + "," + temp.ItemName;

                }
            }
            ReportParameters.ItemCode = stringItems.ToString().TrimStart(new char[] { ',' });
            ReportParameters.ItemName = stringItemsNm.ToString().TrimStart(new char[] { ',' });


        }
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
                        { POPUPEntityObject = ObjComp.Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M002>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null)
                {

                    ReportParameters.comp_code = POPUPEntityObject.comp_code;
                    ReportParameters.CompName = POPUPEntityObject.CompName;
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
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null)
                {

                    ReportParameters.location_Id = POPUPEntityObject.location_Id;
                    ReportParameters.LoctnNm = POPUPEntityObject.LoctnNm;

                }
            }

            catch (Exception ex)
            {

                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }

        }
        private void InsertUnit(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UnitDetails.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null)
                {

                    ReportParameters.unit_code = POPUPEntityObject.unit_code;
                    ReportParameters.unit_name = POPUPEntityObject.unit_name;

                }
            }

            catch (Exception ex)
            {

                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }

        }
        private void InsertCat(object InputValue)
        {

            string stringCatCode = "";
            string stringCatName = "";
            ReportParameters.PartyId = "";
            foreach (ADM_M018_P temp in MC.CategoryDetails)
            {
                if (temp.Select == true)
                {
                    stringCatCode = stringCatCode + "," + temp.CatCode;
                    stringCatName = stringCatName + "," + temp.CatName;
                }
            }
            ReportParameters.CatCode = stringCatCode.ToString().TrimStart(new char[] { ',' });
            ReportParameters.CatName = stringCatName.ToString().TrimStart(new char[] { ',' });

        }
        private void InsertSubCat(object InputValue)
        {

            string stringSubCatCode = "";
            string stringSubCatName = "";
            ReportParameters.PartyId = "";
            foreach (ADM_M019_P temp in MC.SubCategoryDetails)
            {
                if (temp.Select == true)
                {
                    stringSubCatCode = stringSubCatCode + "," + temp.SubCatCode;
                    stringSubCatName = stringSubCatName + "," + temp.SubCatName;
                }
            }
            ReportParameters.SubCatCode = stringSubCatCode.ToString().TrimStart(new char[] { ',' });
            ReportParameters.SubCatName = stringSubCatName.ToString().TrimStart(new char[] { ',' });

        }

        //Fin yr
        private void InsertFinYr(object InputValue)
        {
            string Request = "";
            ACC_M001A_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.FinYear.Where(x => x.fin_year.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M001A_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null)
                {

                    ReportParameters.fin_year = POPUPEntityObject.fin_year;
                    ReportParameters.post_year = POPUPEntityObject.post_year;
                }
            }

            catch (Exception ex)
            {

                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }

        }
        //Posting Period
        private void InsertPostPeriod(object InputValue)
        {
            string Request = "";
            ACC_M001A_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.PostPeriod.Where(x => x.posting_period.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M001A_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null)
                {

                    ReportParameters.posting_period = POPUPEntityObject.posting_period;
                    ReportParameters.short_desc = POPUPEntityObject.short_desc;
                    ReportParameters.post_per = POPUPEntityObject.post_per;
                }
            }

            catch (Exception ex)
            {

                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }

        }

        private void DisplayReport()
        {
            CursorControl.SetBusyState();

            try
            {
                //Check if Report not selected then give a Message.
                if (ReportParameters.ReportCode == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Report Type");
                    showMessageService.ShowMessage();
                }

                //Check if Fields are not Selected then assign it to 'All'.
                if (ReportParameters.ReportCode != null)
                {
                    if (ReportParameters.CatCode == null) { ReportParameters.CatCode = "All"; }
                    if (ReportParameters.CatName == null) { ReportParameters.CatName = "All"; }
                    if (ReportParameters.SubCatCode == null) { ReportParameters.SubCatCode = "All"; }
                    if (ReportParameters.SubCatName == null) { ReportParameters.SubCatName = "All"; }
                    if (ReportParameters.parametervalue == null) { ReportParameters.parametervalue = "All"; }
                    if (ReportParameters.value_code == null) { ReportParameters.value_code = "All"; }
                    if (ReportParameters.MatConditionCode == null) { ReportParameters.MatConditionCode = "All"; }
                    if (ReportParameters.MatConditionValue == null) { ReportParameters.MatConditionValue = "All"; }
                    if (ReportParameters.ImportLocalCode == null) { ReportParameters.ImportLocalCode = "All"; }
                    if (ReportParameters.ImportLocalValue == null) { ReportParameters.ImportLocalValue = "All"; }
                    if (ReportParameters.CurUnCur == null) { ReportParameters.CurUnCur = "All"; }
                    if (ReportParameters.mctype == null) { ReportParameters.mctype = "All"; }
                    if (ReportParameters.ItemCode == null) { ReportParameters.ItemCode = "All"; }
                    if (ReportParameters.ItemName == null) { ReportParameters.ItemName = "All"; }

                }

                //Diaplay Selected Report.
                if (ReportParameters.ReportCode != null)
                {
                    string RequestParameter = "Report" + "!@" + ReportParameters.ReportCode + "!@" + ReportParameters.comp_code + "!@" + ReportParameters.location_Id + "!@" + Convert.ToDateTime(ReportParameters.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParameters.ToDate).ToString("MM/dd/yyyy") + "!@" + ReportParameters.CatCode + "!@" + ReportParameters.SubCatCode + "!@" + ReportParameters.unit_code + "!@" + ReportParameters.value_code + "!@" + ReportParameters.ImportLocalCode + "!@" + ReportParameters.MatConditionCode + "!@" + ReportParameters.CurUnCur + "!@" + ReportParameters.Duration + "!@" + ReportParameters.Remark + "!@" + ReportParameters.posting_period + "!@" + ReportParameters.fin_year + "!@" + ReportParameters.mctype + "!@" + ReportParameters.wire_type + "!@" + ReportParameters.wire_size_id + "!@" + ReportParameters.ItemCode;
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_MIS_FinStatement>(MC, RequestParameter, "MIS_FinStatement", "SCM", "", 0, RequestParameter);

                    object[] objDataSource = new object[4];
                    string[] objDataSourceName = new string[4];
                    objDataSource[0] = MCTemp.FinReportData;

                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == ReportParameters.comp_code).ToList();
                    objDataSource[1] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == ReportParameters.location_Id).ToList();
                    objDataSource[2] = Result;

                    objDataSource[3] = MCTemp.CurrrentUptoDateTS;

                    objDataSourceName[0] = "dsMIS_FinStatementRptEntity";
                    objDataSourceName[1] = "dsCompany";
                    objDataSourceName[2] = "dsLocation";
                    objDataSourceName[3] = "dsCurrrentUptoDateTS";


                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\MIS\\SCM\\" + GetReportFile(ReportParameters.ReportCode), getParametersList(), "");

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
                result.Add("ReportName", ReportParameters.ReportName);
                result.Add("comp_code", ReportParameters.comp_code);
                result.Add("location_Id", ReportParameters.location_Id);
                result.Add("SubCatCode", ReportParameters.SubCatCode);
                result.Add("CatCode", ReportParameters.CatCode);
                result.Add("SubCatName", ReportParameters.SubCatName);
                result.Add("CatName", ReportParameters.CatName);
                result.Add("unit_code", ReportParameters.unit_code);
                result.Add("doc_no", ReportParameters.doc_no);
                result.Add("parametervalue", ReportParameters.parametervalue);
                result.Add("MatCondition", ReportParameters.MatConditionValue);
                result.Add("ImportLocal", ReportParameters.ImportLocalValue);
                result.Add("CurUnCur", ReportParameters.CurUnCur);
                result.Add("FromDate", Convert.ToString(ReportParameters.FromDate));
                result.Add("ToDate", Convert.ToString(ReportParameters.ToDate));
                result.Add("mctype", ReportParameters.mctype);
                result.Add("short_desc", ReportParameters.short_desc);
                result.Add("ItemCode", ReportParameters.ItemCode);
                result.Add("ItemName", ReportParameters.ItemName);


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

        //Getting Selected Report File
        private string GetReportFile(string ReportCode)
        {
            string returnReportName = "";
            //if (ReportCode == "R001")
            //{ returnReportName = "FinancialStatement.rdlc"; }
            //else 
            //if (ReportCode == "R002")
            //{ returnReportName = "FinStatmntImportLocal.rdlc"; }    
            if (ReportCode == "R002")
            { returnReportName = "FinStatmntITypewise.rdlc"; }
            else if (ReportCode == "R003")
            { returnReportName = "AccToMachConsmptn.rdlc"; }
            else if (ReportCode == "R004")
            { returnReportName = "FinStatmntUpToDate.rdlc"; }
            else if (ReportCode == "R009")
            { returnReportName = "DailyBasisConsmptRpt.rdlc"; }
            else if (ReportCode == "R010")
            { returnReportName = "FinStmtITypewiseW_O_Cur_Uncurr.rdlc"; }
            else if (ReportCode == "R012")
            { returnReportName = "FinStmtITypewiseW_O_Cur_Uncurr_WO_sku.rdlc"; }
            else if (ReportCode == "R013")
            { returnReportName = "FinancialStockStmt.rdlc"; }

            return returnReportName;


        }

        #endregion

        #region . Filter .

        #region Company Filter
        private string _filterString_Company;
        public string FilterString_Company
        {
            get { return _filterString_Company; }
            set
            {
                _filterString_Company = value;
                RaisePropertyChanged("FilterString_Company");
                FilterCollectionCompany();
            }
        }
        private void FilterCollectionCompany()
        {
            if (_CompanyCollection != null)
            {
                _CompanyCollection.Refresh();
            }
        }
        public bool FilterCompany(object obj)
        {
            var data = obj as ADM_M002;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Company))
                {
                    return (data.comp_code != null && data.comp_code.ToString().ToLower().Contains(_filterString_Company.ToLower()) ||
                            (data.CompName != null && data.CompName.ToString().ToLower().Contains(_filterString_Company.ToLower()))
                        );
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Plant Filter
        private string _filterString_plant;
        public string FilterString_plant
        {
            get { return _filterString_plant; }
            set
            {
                _filterString_plant = value;
                RaisePropertyChanged("FilterString_plant");
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
        #endregion

        #region UOM Filter
        private string _filterStringUom;
        public string FilterStringUom
        {
            get { return _filterStringUom; }
            set
            {
                _filterStringUom = value;
                RaisePropertyChanged("FilterStringUom");
                FilterCollectionUom();
            }
        }
        private void FilterCollectionUom()
        {
            if (_uomCollection != null)
            {
                _uomCollection.Refresh();
            }
        }
        public bool FilterUom(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringUom))
                {
                    return (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterStringUom.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Category Filter
        private string _filterStringCat;
        public string FilterStringCat
        {
            get { return _filterStringCat; }
            set
            {
                _filterStringCat = value;
                RaisePropertyChanged("FilterStringCat");
                FilterCollectionCat();
            }
        }
        private void FilterCollectionCat()
        {
            if (_CategoryCollection != null)
            {
                _CategoryCollection.Refresh();
            }
        }
        public bool FilterCategory(object obj)
        {
            var data = obj as ADM_M018_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringCat))
                {
                    return (data.CatName != null && data.CatName.ToString().ToLower().Contains(_filterStringCat.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region SubCategory Filter
        private string _filterStringSubCat;
        public string FilterStringSubCat
        {
            get { return _filterStringSubCat; }
            set
            {
                _filterStringSubCat = value;
                RaisePropertyChanged("FilterStringSubCat");
                FilterCollectionSubCat();
            }
        }
        private void FilterCollectionSubCat()
        {
            if (_SubCategoryCollection != null)
            {
                _SubCategoryCollection.Refresh();
            }
        }
        public bool FilterSubCategory(object obj)
        {
            var data = obj as ADM_M019_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringSubCat))
                {
                    return (data.SubCatName != null && data.SubCatName.ToString().ToLower().Contains(_filterStringSubCat.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For Make
        private string _filterStringMake;
        public string FilterStringMake
        {
            get { return _filterStringMake; }
            set
            {
                _filterStringMake = value;
                RaisePropertyChanged("FilterStringMake");
                FilterCollectionMake();
            }
        }
        private void FilterCollectionMake()
        {
            if (_MakeCollection != null)
            {
                _MakeCollection.Refresh();
            }
        }

        public bool FilterMake(object obj)
        {
            var data = obj as ADM_M030_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringMake))
                {
                    return (data.parametervalue != null && data.parametervalue.ToString().ToLower().Contains(_filterStringMake.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Financial Year Filter
        private string _filterStringFinYr;
        public string FilterStringFinYr
        {
            get { return _filterStringFinYr; }
            set
            {
                _filterStringFinYr = value;
                RaisePropertyChanged("FilterStringFinYr");
                FilterCollectionFinYr();
            }
        }
        private void FilterCollectionFinYr()
        {
            if (_FinCollection != null)
            {
                _FinCollection.Refresh();
            }
        }
        public bool FilterFinYr(object obj)
        {
            var data = obj as ACC_M001A_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringFinYr))
                {
                    return (data.post_year.ToString() != null && data.post_year.ToString().ToLower().Contains(_filterStringFinYr.ToLower())) ||
                        (data.fin_year.ToString() != null && data.fin_year.ToString().ToLower().Contains(_filterStringFinYr.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Posting Period Filter
        private string _filterStringPost;
        public string FilterStringPost
        {
            get { return _filterStringPost; }
            set
            {
                _filterStringPost = value;
                RaisePropertyChanged("FilterStringPost");
                FilterCollectionPost();
            }
        }
        private void FilterCollectionPost()
        {
            if (_PostCollection != null)
            {
                _PostCollection.Refresh();
            }
        }
        public bool FilterPost(object obj)
        {
            var data = obj as ACC_M001A_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringPost))
                {
                    return (data.short_desc.ToString() != null && data.short_desc.ToString().ToLower().Contains(_filterStringPost.ToLower())) ||
                        (data.posting_period.ToString() != null && data.posting_period.ToString().ToLower().Contains(_filterStringPost.ToLower()));
                }
                return true;
            }
            return false;
        }


        #endregion

        #region Item Filter
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
            var data = obj as ADM_M022_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Item))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_Item.ToLower()) ||
                            (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_Item.ToLower()))
                        );
                }
                return true;
            }
            return false;
        }
        #endregion
        #endregion

        #region . Command Action .
        protected override void OnSaveAction(InquiryActionResult<MIS_FinStatement> result)
        {

        }
        protected override void OnCreateAction(InquiryActionResult<MIS_FinStatement> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<MIS_FinStatement> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<MIS_FinStatement> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<MIS_FinStatement> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<MIS_FinStatement> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<MIS_FinStatement> result)
        {
        }
        protected override void OnPrintAction(InquiryActionResult<MIS_FinStatement> result)
        {

        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<MIS_FinStatement> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MIS_FinStatement> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MIS_FinStatement> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MIS_FinStatement> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MIS_FinStatement> result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
