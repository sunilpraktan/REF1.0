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
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.WebServices.Gateway;
using Reflection.BusinessEntity.SCM;
using Reflection.Presentation.Common;

namespace Reflection.Modules.SCM.ViewModels
{

    class MIS_FinStatement_FG_VM : WorkspaceViewModel<MIS_FinStatement>
    {

        #region Declaration

        bool blNew = true;
        WebServiceRepository<MultipleContext_MIS_FinStatement> repository_MC = new WebServiceRepository<MultipleContext_MIS_FinStatement>();
        ObjectSerializationService obj = new ObjectSerializationService();
        WebServiceRepository<List<MIS_RptFinStatement>> repository = new WebServiceRepository<List<MIS_RptFinStatement>>();
        WebServiceRepository<UptoDateTotal> repository_UptoDate = new WebServiceRepository<UptoDateTotal>();
        public string ts_code_vm { get; set; }
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

        private UptoDateTotal _dsUptoDate;
        public UptoDateTotal dsUptoDate
        {
            get  { return _dsUptoDate; }
            set
            {
                if (_dsUptoDate != value)
                {
                    _dsUptoDate = value;


                    RaisePropertyChanged("dsUptoDate");

                }
            }
        }

        private UptoDateFG _dsPrevious;
        public UptoDateFG dsPrevious
        {
            get { return _dsPrevious; }
            set
            {
                if (_dsPrevious != value)
                {
                    _dsPrevious = value;


                    RaisePropertyChanged("dsPrevious");

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

        private Dictionary<string, object> _WireSzDictionaryParent;
        public Dictionary<string, object> WireSzDictionaryParent
        {
            get { return _WireSzDictionaryParent; }
            set
            {
                if (_WireSzDictionaryParent != value)
                {
                    _WireSzDictionaryParent = value;
                    RaisePropertyChanged("WireSzDictionaryParent");
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
        private ICollectionView _DataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _DataGridCollection; }
            set
            {
                _DataGridCollection = value;
                RaisePropertyChanged("DataGridCollection");
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
        private ICollectionView _WireSzCollection;
        public ICollectionView WireSzCollection
        {
            get { return _WireSzCollection; }
            set { _WireSzCollection = value; RaisePropertyChanged("WireSzCollection"); }
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

        private List<string> _StringListWireSz;
        public List<string> StringListWireSz
        {
            get { return _StringListWireSz; }
            set
            {
                if (_StringListWireSz != value)
                {
                    _StringListWireSz = value;
                }
            }
        }

        //Tip Type
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

        private List<ZADM_M003_P> _strListWireSz;
        public List<ZADM_M003_P> strListWireSz
        {
            get { return _strListWireSz; }
            set
            {
                if (_strListWireSz != value)
                {
                    _strListWireSz = value;
                    RaisePropertyChanged("_strListWireSz");
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
        public RelayCommand cmdLoadUptodate { get; private set; }
        public RelayCommand<object> cmdMake { get; private set; }
        public RelayCommand<object> cmdFinYr { get; private set; }
        public RelayCommand<object> cmdPostPeriod { get; private set; }
        public RelayCommand<object> cmdWireSize { get; private set; }
        public RelayCommand cmdClear { get; private set; }
        public RelayCommand cmdInsertTotal { get; private set; }
        public RelayCommand cmdClearUpTodate { get; private set; }


        #endregion

        #region Constructor
        public MIS_FinStatement_FG_VM(string ts_code)
            : base()
        {
            this.ts_code_vm = ts_code;
            CursorControl.SetBusyState();
            MC = new MultipleContext_MIS_FinStatement();
            ReportParameters = new MIS_FinStatement();
            dsReport = new MIS_RptFinStatement();
            dsPrevious = new UptoDateFG();
            dsUptoDate = new UptoDateTotal();
            ReportItemsDictionary = new Dictionary<string, string>();
            CurUnCurDictionary = new Dictionary<string, object>();
            MachTypeDictionary = new Dictionary<string, object>();
            ReportItemsDictionary.Add("R005", "Finish Goods Production And Stock Statement");
            ReportItemsDictionary.Add("R011", "Finish Goods Production And Stock Statement Report");
            ReportItemsDictionary.Add("R007", "Finish Goods Production And Stock Statement (Book)");
            ReportItemsDictionary.Add("R006", "CONSIGNEE STOCK STATEMENT");
            ReportItemsDictionary.Add("R008", "Production(MachineType Wise) Report");
            ReportItemsDictionary.Add("R012", "FG Reconsilation Report");


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
            cmdLoadUptodate = new RelayCommand(LoadUptodate);
            cmdClear = new RelayCommand(ClearData);
            cmdClearUpTodate = new RelayCommand(ClearUpTodate);
            cmdInsertTotal = new RelayCommand(InsertTotal);
            cmdMake = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertMake(cmdPara, false, true, true); });
            cmdFinYr = new RelayCommand<object>(items => { if (items == null) { return; } InsertFinYr(items); });
            cmdPostPeriod = new RelayCommand<object>(items => { if (items == null) { return; } InsertPostPeriod(items); });
            cmdWireSize = new RelayCommand<object>(items => { if (items == null) { return; } InsertWireSize(items); });

            LoadInitialData();
            DefaultValues();
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
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_MIS_FinStatement>(MC, Request, "MIS_FinStatement_FG", "SCM", "LoadAll", 0, "MIS_FinStatement_FG");

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
               
                //TipType
                var TipTypeListParent = (from o in MC.TipTypes
                                         where o.tip_type != null
                                         select o).ToList();
                _strListTipType = TipTypeListParent;
                TipTypeDictionary = _strListTipType.ToDictionary(X => X.tip_type.ToString(), X => (object)X.tip_type);

                //Wire Type
                var WireListParent = (from o in MC.WireTypeDetails
                                      where o.wire_type_id.ToString() != null
                                      select o).ToList();
                _strListWireTy = WireListParent;
                WireTyDictionaryParent = _strListWireTy.ToDictionary(X => X.wire_type.ToString(), X => (object)X.wire_type);

                //Wire Size
                WireSzCollection = CollectionViewSource.GetDefaultView(MC.WireSizeDetails.ToList());
                WireSzCollection.Filter = new Predicate<object>(FilterWireSz);
                StringListWireSz = MC.WireSizeDetails.Select(x => x.wire_size_id.ToString()).ToList();

               
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
       
        private void InsertTotal()
        {
            try
            {
                dsUptoDate.fin_year = ReportParameters.fin_year;
                dsUptoDate.posting_period = ReportParameters.posting_period;
                dsUptoDate.location_Id = ReportParameters.location_Id;
                dsUptoDate.wire_type = ReportParameters.wire_type;
                dsUptoDate.wire_size = ReportParameters.wire_size;
                dsUptoDate.wire_size_id = ReportParameters.wire_size_id;
                dsUptoDate = repository_UptoDate.SaveWithReturnDomainObject<UptoDateTotal>(dsUptoDate, "MIS_FinStatement_InsertFG", "SCM");

                if(dsUptoDate!=null)
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
        private void ClearUpTodate()
        {

            try
            {
                dsReport = new MIS_RptFinStatement();
                dsPrevious = new UptoDateFG();
                dsUptoDate = new UptoDateTotal();
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
        private void InsertWireSize(object InputValue)
        {
            
                string stringWireSzid = "";
                string stringWireSz = "";
               // ReportParameters.wire_size_id ="";
               ReportParameters.wire_size = "";
                foreach (ZADM_M003_P temp in MC.WireSizeDetails)
                {
                    if (temp.Select == true)
                    {
                        stringWireSzid = stringWireSzid + "," + temp.wire_size_id;
                        stringWireSz = stringWireSz + "," + temp.wire_size;
                    }
                }
                ReportParameters.wire_size_id = stringWireSzid.ToString().TrimStart(new char[] { ',' });
                ReportParameters.wire_size= stringWireSz.ToString().TrimStart(new char[] { ',' });
           

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
                    if (ReportParameters.wire_type == null) { ReportParameters.wire_type = "All"; }
                    if (ReportParameters.TipType == null) { ReportParameters.TipType = "All"; }
                    if (ReportParameters.wire_size == null || ReportParameters.wire_size == "") { ReportParameters.wire_size= "All"; }
                    if (ReportParameters.ItemCode == null) { ReportParameters.ItemCode = "All"; }
                    if (ReportParameters.ItemName == null) { ReportParameters.ItemName = "All"; }
                }

                //Diaplay Selected Report.
                if (ReportParameters.ReportCode != null)
                {
                    string RequestParameter = "Report" + "!@" + ReportParameters.ReportCode + "!@" + ReportParameters.comp_code + "!@" + ReportParameters.location_Id + "!@" + Convert.ToDateTime(ReportParameters.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParameters.ToDate).ToString("MM/dd/yyyy") + "!@" + ReportParameters.CatCode + "!@" + ReportParameters.SubCatCode + "!@" + ReportParameters.unit_code + "!@" + ReportParameters.value_code + "!@" + ReportParameters.ImportLocalCode + "!@" + ReportParameters.MatConditionCode + "!@" + ReportParameters.CurUnCur + "!@" + ReportParameters.Duration + "!@" + ReportParameters.Remark + "!@" + ReportParameters.posting_period + "!@" + ReportParameters.fin_year + "!@" + ReportParameters.mctype + "!@" + ReportParameters.wire_type + "!@" + ReportParameters.wire_size_id + "!@" + (ReportParameters.ItemCode ?? "");
                    // dsReport = repository.GetDataWithReturnDomainObject<List<MIS_RptFinStatement>>(dsReport, RequestParameter, "MIS_FinStatement", "SCM", "", 0, RequestParameter);
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_MIS_FinStatement>(MC, RequestParameter, "MIS_FinStatement", "SCM", "", 0, "MIS_FinStatement_FG");

                    object[] objDataSource = new object[4];
                    string[] objDataSourceName = new string[4];

                    objDataSource[0] = MCTemp.FinReportData;
                    DataGridCollection  = CollectionViewSource.GetDefaultView(MCTemp.FinReportData);

                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == ReportParameters.comp_code).ToList();
                    objDataSource[1] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == ReportParameters.location_Id).ToList();
                    objDataSource[2] = Result;
                    objDataSource[3] = MCTemp.UpToDateFGList;

                    objDataSourceName[0] = "dsMIS_FinStatementRptEntity";
                    objDataSourceName[1] = "dsCompany";
                    objDataSourceName[2] = "dsLocation";
                    objDataSourceName[3] = "dsUptoDateFG";


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
                    string RequestParameter = "LoadUptodate" + "!@" + ReportParameters.ReportCode + "!@" + ReportParameters.comp_code + "!@" + ReportParameters.location_Id + "!@" + Convert.ToDateTime(ReportParameters.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParameters.ToDate).ToString("MM/dd/yyyy") + "!@" + ReportParameters.CatCode + "!@" + ReportParameters.SubCatCode + "!@" + ReportParameters.unit_code + "!@" + ReportParameters.value_code + "!@" + ReportParameters.ImportLocalCode + "!@" + ReportParameters.MatConditionCode + "!@" + ReportParameters.CurUnCur + "!@" + ReportParameters.Duration + "!@" + ReportParameters.Remark + "!@" + ReportParameters.posting_period + "!@" + ReportParameters.fin_year + "!@" + ReportParameters.mctype + "!@" + ReportParameters.wire_type + "!@" + ReportParameters.wire_size_id;
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_MIS_FinStatement>(MC, RequestParameter, "MIS_FinStatement", "SCM", "", 0, "MIS_FinStatement_FG");


                    if (MCTemp.FinReportData.Count() > 0)
                       {
                        dsReport = MCTemp.FinReportData[0];
                       }
                    else if (MCTemp.FinReportData.Count() == 0)
                       {
                        dsReport.OpenQty = 0; dsReport.OpenValue = 0; dsReport.ProdQty = 0; dsReport.ProdValue = 0; dsReport.SalesRtnQty = 0;
                        dsReport.SalesRtnValue = 0; dsReport.SalesQty = 0; dsReport.SalesValue = 0; dsReport.SampleQty = 0; dsReport.SampleValue = 0;
                        dsReport.ClosingQty = 0; dsReport.ClosingValue = 0; dsReport.ShortageQty = 0; dsReport.ShortageValue = 0;

                       }
                    if (MCTemp.PreviousUptoDateFG.Count() > 0)
                       {
                        dsPrevious = MCTemp.PreviousUptoDateFG[0];
                       }
                    else if (MCTemp.PreviousUptoDateFG.Count() == 0)
                       {
                        dsPrevious.OpenValue = 0; dsPrevious.ProdQty = 0; dsPrevious.ProdValue = 0; dsPrevious.SalesRtnQty = 0;
                        dsPrevious.SalesRtnValue = 0; dsPrevious.SalesQty = 0; dsPrevious.SalesValue = 0; dsPrevious.SampleQty = 0;
                        dsPrevious.SampleValue = 0; dsPrevious.ClosingQty = 0; dsPrevious.ClosingValue = 0; dsPrevious.ShortageQty = 0;
                        dsPrevious.ShortageValue = 0;
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
                result.Add("short_desc", ReportParameters.short_desc);
                result.Add("parametervalue", ReportParameters.parametervalue);
                result.Add("MatCondition", ReportParameters.MatConditionValue);
                result.Add("ImportLocal", ReportParameters.ImportLocalValue);
                result.Add("CurUnCur", ReportParameters.CurUnCur);
                result.Add("FromDate", Convert.ToString(ReportParameters.FromDate));
                result.Add("ToDate", Convert.ToString(ReportParameters.ToDate));
                result.Add("mctype", ReportParameters.mctype);
                result.Add("wire_type", ReportParameters.wire_type);
                result.Add("TipType", ReportParameters.TipType);
                result.Add("wire_size", ReportParameters.wire_size);

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
 
            if (ReportCode == "R005")
            { returnReportName = "FinStatmntFG.rdlc"; }     
            else if (ReportCode == "R006")
            { returnReportName = "ConsigneeStockStemt.rdlc"; }
            else if (ReportCode == "R007")
            { returnReportName = "FinStatmntFG.rdlc"; }
            else if (ReportCode == "R008")
            { returnReportName = "Productin_FinStatmnt.rdlc"; }
            else if (ReportCode == "R011")
            { returnReportName = "FinStatmntFG_old.rdlc"; }
            else if (ReportCode == "R012")
            { returnReportName = "FGReconsilation.rdlc"; }

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
       
        #region Wire Size Filter
        private string _filterStringWireSz;
        public string FilterStringWireSz
        {
            get { return _filterStringWireSz; }
            set
            {
                _filterStringWireSz = value;
                RaisePropertyChanged("FilterStringWireSz");
                FilterCollectionWireSz();
            }
        }
        private void FilterCollectionWireSz()
        {
            if (_WireSzCollection != null)
            {
                _WireSzCollection.Refresh();
            }
        }
        public bool FilterWireSz(object obj)
        {
            var data = obj as ZADM_M003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringWireSz))
                {
                    return (data.wire_size_id.ToString() != null && data.wire_size_id.ToString().ToLower().Contains(_filterStringWireSz.ToLower())) ||
                        (data.wire_size.ToString() != null && data.wire_size.ToString().ToLower().Contains(_filterStringWireSz.ToLower()));
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
