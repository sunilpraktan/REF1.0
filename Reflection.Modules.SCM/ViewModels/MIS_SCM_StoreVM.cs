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
    class MIS_SCM_StoreVM : WorkspaceViewModel<MIS_SCM_StoreEntity>
    {

        #region Declaration

        bool blNew = true;
        WebServiceRepository<MultipleContext_MIS_SCM_Store> repository_MC = new WebServiceRepository<MultipleContext_MIS_SCM_Store>();
        ObjectSerializationService obj = new ObjectSerializationService();
        WebServiceRepository<List<MIS_SCM_StoreRpt>> repository = new WebServiceRepository<List<MIS_SCM_StoreRpt>>();
        public string ts_code_vm { get; set; }
        MultipleContext_MIS_SCM_Store _MC = new MultipleContext_MIS_SCM_Store();
        public MultipleContext_MIS_SCM_Store MC
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
        MultipleContext_MIS_SCM_Store _MCTemp = new MultipleContext_MIS_SCM_Store();
        public MultipleContext_MIS_SCM_Store MCTemp
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
        private MIS_SCM_StoreEntity _ReportParameters;
        public MIS_SCM_StoreEntity ReportParameters
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

        private Dictionary<string, string> _TipTypeDictionary;
        public Dictionary<string, string> TipTypeDictionary
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

        #endregion

        #region ICollection

        private ICollectionView _PartyCollection;
        public ICollectionView PartyCollection
        {
            get { return _PartyCollection; }
            set { _PartyCollection = value; RaisePropertyChanged("PartyCollevtion"); }
        }
        private ICollectionView _ItemsCollection;
        public ICollectionView ItemsCollection
        {
            get { return _ItemsCollection; }
            set { _ItemsCollection = value; RaisePropertyChanged("ItemsCollection"); }
        }
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
        private ICollectionView _ParameterCollection;
        public ICollectionView ParameterCollection
        {
            get { return _ParameterCollection; }
            set { _ParameterCollection = value; RaisePropertyChanged("ParameterCollection"); }
        }
        #endregion

        #region StringList Variables

        List<string> _stringListParty;
        public List<string> StringListParty
        {
            get { return _stringListParty; }
            set
            {
                if (_stringListParty != value)
                {
                    _stringListParty = value;
                }
            }
        }
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
        private List<string> _stringListParameter;
        public List<string> StringListParameter
        {
            get { return _stringListParameter; }
            set
            {
                if (_stringListParameter != value)
                {
                    _stringListParameter = value;
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

        #endregion

        #region RelayCommands      
        public RelayCommand<object> cmdCompanyChange { get; private set; }
        public RelayCommand<object> cmdPlantChange { get; private set; }
        public RelayCommand<object> cmdUnitChange { get; private set; }
        public RelayCommand<object> cmdCatChange { get; private set; }
        public RelayCommand<object> cmdSubCatChange { get; private set; }
        public RelayCommand<object> cmdPartyChange { get; private set; }
        public RelayCommand<object> cmdItemChange { get; private set; }
        public RelayCommand cmdReport { get; private set; }
        public RelayCommand<object> cmdMake { get; private set; }
        public RelayCommand<object> cmdFinYr { get; private set; }
        public RelayCommand<object> cmdPostPeriod { get; private set; }
        public RelayCommand CommandForClearData { get; private set; }
        public RelayCommand CmdUpdateClosing { get; private set; }
        public RelayCommand<object> cmdParameter { get; private set; }


        #endregion

        #region Constructor
        public MIS_SCM_StoreVM(string ts_code)
            : base()
        {
            this.ts_code_vm = ts_code;
            CursorControl.SetBusyState();
            MC = new MultipleContext_MIS_SCM_Store();
            ReportParameters = new MIS_SCM_StoreEntity();
            _dsReport = new List<MIS_SCM_StoreRpt>();
            ReportItemsDictionary = new Dictionary<string, string>();

            TipTypeDictionary = new Dictionary<string, string>();
            TipTypeDictionary.Add("T02", "OBI");
            TipTypeDictionary.Add("T03", "GBI");

            ReportItemsDictionary.Add("R001", "Stock Report");
            ReportItemsDictionary.Add("R002", "Reorder Level Report");
            ReportItemsDictionary.Add("R003", "As On Statement");           
            ReportItemsDictionary.Add("R004", "As On Statement For FG");
            ReportItemsDictionary.Add("R005", "Perodic Stock Statement");

            cmdCompanyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
            cmdPlantChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
            cmdUnitChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertUnit(items); });
            cmdCatChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertCat(items); });
            cmdSubCatChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertSubCat(items); });
            cmdPartyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertParty(items, blNew); });
            cmdItemChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertItem(items); });                      
            cmdFinYr = new RelayCommand<object>(items => { if (items == null) { return; } InsertFinYr(items); });
            cmdPostPeriod = new RelayCommand<object>(items => { if (items == null) { return; } InsertPostPeriod(items); });
            cmdParameter = new RelayCommand<object>(items => { if (items == null) { return; } InsertParameter(items); });

            CommandForClearData = new RelayCommand(ClearData);
            cmdReport = new RelayCommand(DisplayReport);
            CmdUpdateClosing = new RelayCommand(Update_closing);
            DefaultValues();
            LoadInitialData();
            
        }

        private void ClearData()
        {

            try
            {
                ReportParameters = new MIS_SCM_StoreEntity();
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
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_MIS_SCM_Store>(MC, Request, "MIS_SCM_Store", "SCM", "LoadAll", 0, "");

                //Loading  Data on Popups.
                ObjPlant = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                PlantCollection = CollectionViewSource.GetDefaultView(ObjPlant.ToList());
                PlantCollection.Filter = new Predicate<object>(FilterPlant);
                StringListPlant = ObjPlant.Select(x => x.location_Id).ToList();

                ObjComp = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                CompanyCollection = CollectionViewSource.GetDefaultView(ObjComp.ToList());
                CompanyCollection.Filter = new Predicate<object>(FilterCompany);
                StringListCompany = ObjComp.Select(x => x.comp_code).ToList();

                //Load Data on Party
                PartyCollection = CollectionViewSource.GetDefaultView(MC.PartyMaster);
                PartyCollection.Filter = new Predicate<object>(FilterParty);
                StringListParty = MC.PartyMaster.Select(x => x.PartyId).ToList();
                
                //Items
                ItemsCollection = CollectionViewSource.GetDefaultView(MC.ItemDetails);
                ItemsCollection.Filter = new Predicate<object>(FilterItem);
                StringListItems = MC.ItemDetails.Select(x => x.ItemCode).ToList();
                
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
                                     where o.ild_id.ToString() != null
                                     select o).ToList();
                _strListILD = ILDListParent;
                ILDDictionaryParent = _strListILD.ToDictionary(X => X.ild_id.ToString(), X => (object)X.ild);

                //Ink
                var InkListParent = (from o in MC.InkDetails
                                     where o.ink_id.ToString() != null
                                     select o).ToList();
                _strListInk = InkListParent;
                InkDictionaryParent = _strListInk.ToDictionary(X => X.ink_id.ToString(), X => (object)X.ink);


                CategoryCollection = CollectionViewSource.GetDefaultView(MC.CategoryDetails.ToList());
                CategoryCollection.Filter = new Predicate<object>(FilterCategory);
                StringListCat = MC.CategoryDetails.Select(x => x.CatCode).ToList();

                SubCategoryCollection = CollectionViewSource.GetDefaultView(MC.SubCategoryDetails.ToList());
                SubCategoryCollection.Filter = new Predicate<object>(FilterSubCategory);
                StringListSubCat = MC.SubCategoryDetails.Select(x => x.SubCatCode).ToList();

                UomCollection = CollectionViewSource.GetDefaultView(MC.UnitDetails.ToList());
                UomCollection.Filter = new Predicate<object>(FilterUom);
                StringListUOM = MC.UnitDetails.Select(x => x.unit_code).ToList();

                //Fin year and Posting period
                FinCollection = CollectionViewSource.GetDefaultView(MC.FinYear.ToList());
                FinCollection.Filter = new Predicate<object>(FilterFinYr);
                StringListFinYr = MC.FinYear.Select(x => x.fin_year).ToList();

                PostCollection = CollectionViewSource.GetDefaultView(MC.PostPeriod.ToList());
                PostCollection.Filter = new Predicate<object>(FilterPost);
                StringListPost = MC.PostPeriod.Select(x => x.posting_period).ToList();

                ParameterCollection = CollectionViewSource.GetDefaultView(MC.ParamValueList.ToList());
                ParameterCollection.Filter = new Predicate<object>(FilterParameter);
                StringListParameter = MC.ParamValueList.Select(x => x.value_code).ToList();

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
            ReportParameters.location_Id = AppSessionState.location_Id;

            DateTime now = DateTime.Now;
            DateTime lastDayLastMonth = new DateTime(now.Year, now.Month, 1);
            ReportParameters.FromDate = lastDayLastMonth.AddDays(0);
            ReportParameters.ToDate = DateTime.Now;
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
        //private void InsertUnit(object InputValue)
        //{

        //    string stringUnitCode = "";
        //    string stringUnitname = "";
        //    ReportParameters.PartyId = "";
        //    foreach (ADM_M038_B_P temp in MC.UnitDetails)
        //    {
        //        if (temp.Select == true)
        //        {
        //            stringUnitCode = stringUnitCode + "," + temp.unit_code;
        //            stringUnitname = stringUnitname + "," + temp.unit_name;
        //        }
        //    }
        //    ReportParameters.unit_code = stringUnitCode.ToString().TrimStart(new char[] { ',' });
        //    ReportParameters.unit_name = stringUnitname.ToString().TrimStart(new char[] { ',' });

        //}

        private void InsertUnit(object InputValue)
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
            ReportParameters.SubCatCode = "";
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

        private void InsertParty(object InputValue, bool OverrideValue)
        {

            string stringParty = "";
            string stringPartyNm = "";
            ReportParameters.PartyId = "";
            foreach (ADM_M028_P temp in MC.PartyMaster)
            {
                if (temp.Select == true)
                {
                    stringParty = stringParty + "," + temp.PartyId;
                    stringPartyNm = stringPartyNm + "," + temp.PartyNm;
                }
            }
            ReportParameters.PartyId = stringParty.ToString().TrimStart(new char[] { ',' });
            ReportParameters.PartyNm = stringPartyNm.ToString().TrimStart(new char[] { ',' });

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
        private void InsertParameter(object InputValue)
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
                        { POPUPEntityObject = MC.ParamValueList.Where(x => x.value_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M030_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null)
                {

                    ReportParameters.value_code = POPUPEntityObject.value_code;
                    ReportParameters.parametervalue = POPUPEntityObject.parametervalue;

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
                if (ReportParameters.ReportCode != null)
                {
                   
                    string RequestParameter = "Report" + "!@" + ReportParameters.ReportCode + "!@" + ReportParameters.comp_code + "!@" + ReportParameters.location_Id + "!@" + Convert.ToDateTime(ReportParameters.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParameters.ToDate).ToString("MM/dd/yyyy") + "!@" + ReportParameters.CatCode + "!@" + ReportParameters.SubCatCode + "!@" + ReportParameters.PartyId + "!@" + ReportParameters.ItemCode + "!@" + ReportParameters.unit_code + "!@" + ReportParameters.posting_period + "!@" + ReportParameters.fin_year + "!@" + ReportParameters.wire_type + "!@" + ReportParameters.ball_type + "!@" + ReportParameters.TipType + "!@" + ReportParameters.ink + "!@" + ReportParameters.ild + "!@" + ReportParameters.value_code;
                  
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_MIS_SCM_Store>(MCTemp, RequestParameter, "MIS_SCM_Store", "SCM", "", 0, "");

                    object[] objDataSource = new object[3];
                    string[] objDataSourceName = new string[3];

                    objDataSource[0] = MCTemp.StoreList;

                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == ReportParameters.comp_code).ToList();
                    objDataSource[1] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == ReportParameters.location_Id).ToList();
                    objDataSource[2] = Result;

                    objDataSourceName[0] = "dsMIS_SCM_StoreRpt";
                    objDataSourceName[1] = "dsCompany";
                    objDataSourceName[2] = "dsLocation";

                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Store\\" + GetReportFile(ReportParameters.ReportCode), getParametersList(), "");

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
        private void Update_closing()
        {

            try
            {
                
                string RequestParameter = "UpdateClosing" + "!@" + ReportParameters.comp_code + "!@" + ReportParameters.location_Id;
                dsReport = repository.GetDataWithReturnDomainObject<List<MIS_SCM_StoreRpt>>(dsReport, RequestParameter, "MIS_SCM_Store", "SCM", "", 0, RequestParameter);

                
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
                if (ReportParameters.ReportCode == "R005")
                {
                    result.Add("ReportNm", ReportParameters.ReportName);
                    result.Add("comp_code", ReportParameters.comp_code);
                    result.Add("location_Id", ReportParameters.location_Id);
                    result.Add("FromDate", Convert.ToString(ReportParameters.FromDate));
                    result.Add("ToDate", Convert.ToString(ReportParameters.ToDate));
                    result.Add("SubCatName", ReportParameters.SubCatName);
                    result.Add("CatName", ReportParameters.CatName);


                }
                else
                {
                    result.Add("ReportNm", ReportParameters.ReportName);
                    result.Add("comp_code", ReportParameters.comp_code);
                    result.Add("location_Id", ReportParameters.location_Id);
                    result.Add("PartyNm", ReportParameters.PartyNm);
                    result.Add("ItemName", ReportParameters.ItemName);
                    result.Add("unit_code", ReportParameters.unit_code);
                    result.Add("SubCatName", ReportParameters.SubCatName);
                    result.Add("CatName", ReportParameters.CatName);
                    result.Add("ball_type", ReportParameters.ball_type);
                    result.Add("wire_type", ReportParameters.wire_type);
                    result.Add("TipType", ReportParameters.TipType);
                    result.Add("ink", ReportParameters.ink);
                    result.Add("ild", ReportParameters.ild);

                    result.Add("FromDate", Convert.ToString(ReportParameters.FromDate));
                    result.Add("ToDate", Convert.ToString(ReportParameters.ToDate));
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
            return result;
        }

        //Getting Selected Report File
        private string GetReportFile(string ReportCode)
        {
            string returnReportName = "";
          
            if (ReportCode == "R001")
            {
                returnReportName = "CurrentStockReport.rdlc";
            }
           else if (ReportCode == "R002")
            {
                returnReportName = "ReorderLevel.rdlc";
            }
            else if (ReportCode == "R003")
            {
                returnReportName = "StockReport.rdlc";
            }          
            else if (ReportCode == "R004")
            {
                returnReportName = "StockReportFG.rdlc";
            }
            else if (ReportCode == "R005")
            {
                returnReportName = "PerodicStockStatement.rdlc";
            }
            return returnReportName;
        }

        #endregion

       

        #region  Party Filter
        private string _filterString_party;
        public string FilterString_party
        {
            get { return _filterString_party; }
            set
            {
                _filterString_party = value;
                RaisePropertyChanged("FilterString_party");
                FilterCollectionParty();
            }
        }
        private void FilterCollectionParty()
        {
            if (_PartyCollection != null)
            {
                _PartyCollection.Refresh();
            }
        }
        public bool FilterParty(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_party))
                {
                    return (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_party.ToLower()) ||
                        (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_party.ToLower())));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region
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

        #region parametervalue Filter
        private string _filterStringParameter;
        public string FilterStringParameter
        {
            get { return _filterStringParameter; }
            set
            {
                _filterStringParameter = value;
                RaisePropertyChanged("FilterStringParameter");
                FilterCollectionParameter();
            }
        }
        private void FilterCollectionParameter()
        {
            if (_ParameterCollection != null)
            {
                _ParameterCollection.Refresh();
            }
        }
        public bool FilterParameter(object obj)
        {
            var data = obj as ADM_M030_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringParameter))
                {
                    return (data.value_code != null && data.value_code.ToString().ToLower().Contains(_filterStringParameter.ToLower())) ||
                            (data.parametervalue != null && data.parametervalue.ToString().ToLower().Contains(_filterStringParameter.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion
        #endregion

        #region . Command Action .

        protected override void OnSaveAction(InquiryActionResult<MIS_SCM_StoreEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnCreateAction(InquiryActionResult<MIS_SCM_StoreEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnRemoveAction(InquiryActionResult<MIS_SCM_StoreEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDiscardAction(InquiryActionResult<MIS_SCM_StoreEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnPrintAction(InquiryActionResult<MIS_SCM_StoreEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFlipAction(InquiryActionResult<MIS_SCM_StoreEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnHelpAction(InquiryActionResult<MIS_SCM_StoreEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFevoriteAction(InquiryActionResult<MIS_SCM_StoreEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<MIS_SCM_StoreEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MIS_SCM_StoreEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MIS_SCM_StoreEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MIS_SCM_StoreEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MIS_SCM_StoreEntity> result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}
