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
    class MIS_SCM_Report3_VM : WorkspaceViewModel<ReportParameters>
    {

        #region Declaration

        bool blNew = true;
        WebServiceRepository<MultipleContext_MIS_SCM_Report1> repository_MC = new WebServiceRepository<MultipleContext_MIS_SCM_Report1>();
        ObjectSerializationService obj = new ObjectSerializationService();
        WebServiceRepository<List<MIS_SCM_ReportEntity>> repository = new WebServiceRepository<List<MIS_SCM_ReportEntity>>();
        public string ts_code_vm { get; set; }
        MultipleContext_MIS_SCM_Report1 _MC = new MultipleContext_MIS_SCM_Report1();
        public MultipleContext_MIS_SCM_Report1 MC
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
        private ReportParameters _ReportParametersEntity;
        public ReportParameters ReportParametersEntity
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

        private List<MIS_SCM_ReportEntity> _dsReport;
        public List<MIS_SCM_ReportEntity> dsReport
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

        #region Dictionary for MultiComboList
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
        private Dictionary<string, string> _OrderByDictionary;
        public Dictionary<string, string> OrderByDictionary
        {
            get { return _OrderByDictionary; }
            set
            {
                if (_OrderByDictionary != value)
                {
                    _OrderByDictionary = value;
                    RaisePropertyChanged("OrderByDictionary");
                }
            }
        }

        private Dictionary<string, string> _RptFormatDictionary;
        public Dictionary<string, string> RptFormatDictionary
        {
            get { return _RptFormatDictionary; }
            set
            {
                if (_RptFormatDictionary != value)
                {
                    _RptFormatDictionary = value;
                    RaisePropertyChanged("RptFormatDictionary");
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

        private Dictionary<string, object> _PartyDictionary;
        public Dictionary<string, object> PartyDictionary
        {
            get { return _PartyDictionary; }
            set
            {
                if (_PartyDictionary != value)
                {
                    _PartyDictionary = value;
                    RaisePropertyChanged("PartyDictionary");
                }
            }
        }


        private Dictionary<string, object> _PartyDictionaryParent;
        public Dictionary<string, object> PartyDictionaryParent
        {
            get { return _PartyDictionaryParent; }
            set
            {
                if (_PartyDictionaryParent != value)
                {
                    _PartyDictionaryParent = value;
                    RaisePropertyChanged("PartyDictionaryParent");
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


        private Dictionary<string, object> _machineDictionaryParent;
        public Dictionary<string, object> machineDictionaryParent
        {
            get { return _machineDictionaryParent; }
            set
            {
                if (_machineDictionaryParent != value)
                {
                    _machineDictionaryParent = value;
                    RaisePropertyChanged("machineDictionaryParent");
                }
            }
        }


        private Dictionary<string, object> _catDictionaryParent;
        public Dictionary<string, object> CatDictionaryParent
        {
            get { return _catDictionaryParent; }
            set
            {
                if (_catDictionaryParent != value)
                {
                    _catDictionaryParent = value;
                    RaisePropertyChanged("CatDictionaryParent");
                }
            }
        }


        private Dictionary<string, object> _subCatDictionaryParent;
        public Dictionary<string, object> SubCatDictionaryParent
        {
            get { return _subCatDictionaryParent; }
            set
            {
                if (_subCatDictionaryParent != value)
                {
                    _subCatDictionaryParent = value;
                    RaisePropertyChanged("SubCatDictionaryParent");
                }
            }
        }

        private Dictionary<string, object> _ItemTyDictionaryParent;
        public Dictionary<string, object> ItemTyDictionaryParent
        {
            get { return _ItemTyDictionaryParent; }
            set
            {
                if (_ItemTyDictionaryParent != value)
                {
                    _ItemTyDictionaryParent = value;
                    RaisePropertyChanged("ItemTyDictionaryParent");
                }
            }
        }

        private Dictionary<string, object> _SubItemTyDictionaryParent;
        public Dictionary<string, object> SubItemTyDictionaryParent
        {
            get { return _SubItemTyDictionaryParent; }
            set
            {
                if (_SubItemTyDictionaryParent != value)
                {
                    _SubItemTyDictionaryParent = value;
                    RaisePropertyChanged("SubItemTyDictionaryParent");
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

        private ICollectionView _uomCollection;
        public ICollectionView UomCollection
        {
            get { return _uomCollection; }
            set { _uomCollection = value; RaisePropertyChanged("UomCollection"); }
        }

        private ICollectionView _MakeCollection;
        public ICollectionView MakeCollection
        {
            get { return _MakeCollection; }
            set { _MakeCollection = value; RaisePropertyChanged("MakeCollection"); }
        }

        private ICollectionView _PlantCollection;
        public ICollectionView PlantCollection
        {
            get { return _PlantCollection; }
            set { _PlantCollection = value; RaisePropertyChanged("PlantCollection"); }
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
        private ICollectionView _DepartmentCollection;
        public ICollectionView DepartmentCollection
        {
            get { return _DepartmentCollection; }
            set { _DepartmentCollection = value; RaisePropertyChanged("DepartmentCollection"); }
        }
        private ICollectionView _MachineCollection;// Machine Collection
        public ICollectionView MachineCollection
        {
            get { return _MachineCollection; }
            set
            {
                _MachineCollection = value;
                RaisePropertyChanged("MachineCollection");
            }
        }

        private ICollectionView _SubCategoryCollection;
        public ICollectionView SubCategoryCollection
        {
            get { return _SubCategoryCollection; }
            set { _SubCategoryCollection = value; RaisePropertyChanged("SubCategoryCollection"); }
        }
        private ICollectionView _CategoryCollection;
        public ICollectionView CategoryCollection
        {
            get { return _CategoryCollection; }
            set { _CategoryCollection = value; RaisePropertyChanged("CategoryCollection"); }
        }


        #endregion

        #region StringList Variables
        private List<string> _stringListParty;
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

        //sku

        List<string> _strListMake;
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
        List<string> _StringListDepartment;
        public List<string> StringListDepartment
        {
            get { return _StringListDepartment; }
            set
            {
                if (_StringListDepartment != value)
                {
                    _StringListDepartment = value;
                }
            }
        }
        List<string> _stringListMachine;
        public List<string> StringListMachine
        {
            get { return _stringListMachine; }
            set
            {
                if (_stringListMachine != value)
                {
                    _stringListMachine = value;
                }
            }
        }

        private List<ADM_M018_P> _strListCategory;
        public List<ADM_M018_P> StrListCategory
        {
            get { return _strListCategory; }
            set
            {
                if (_strListCategory != value)
                {
                    _strListCategory = value;
                    RaisePropertyChanged("StrListCategory");
                }
            }
        }

        private List<ADM_M019_P> _strListSubCategory;
        public List<ADM_M019_P> StrListSubCategory
        {
            get { return _strListSubCategory; }
            set
            {
                if (_strListSubCategory != value)
                {
                    _strListSubCategory = value;
                    RaisePropertyChanged("StrListSubCategory");
                }
            }
        }

        private List<ADM_M015_P> _strListItemTy;
        public List<ADM_M015_P> StrListItemTy
        {
            get { return _strListItemTy; }
            set
            {
                if (_strListItemTy != value)
                {
                    _strListItemTy = value;
                    RaisePropertyChanged("StrListItemTy");
                }
            }
        }

        private List<ADM_M016_P> _strListSubItemTy;
        public List<ADM_M016_P> StrListSubItemTy
        {
            get { return _strListSubItemTy; }
            set
            {
                if (_strListSubItemTy != value)
                {
                    _strListSubItemTy = value;
                    RaisePropertyChanged("StrListSubItemTy");
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


        #endregion

        #region RelayCommands      
        public RelayCommand cmdReport { get; private set; }
        public RelayCommand cmdClear { get; private set; }
        public RelayCommand<object> cmdPartyChange { get; private set; }
        public RelayCommand<object> cmdItemChange { get; private set; }
        public RelayCommand<object> cmdMake { get; private set; }
        public RelayCommand<object> cmdMachine { get; private set; }
        public RelayCommand<object> cmdPlant { get; private set; }
        public RelayCommand<object> cmdCompanyChange { get; private set; }
        public RelayCommand<object> cmdUnitChange { get; private set; }
        public RelayCommand<object> cmdSubCatChange { get; private set; }
        public RelayCommand<object> cmdCatChange { get; private set; }
        public RelayCommand<object> CmdAddDepartment { get; private set; }

        #endregion

        #region Constructor
        public MIS_SCM_Report3_VM(string ts_code)
            : base()
        {
            this.ts_code_vm = ts_code;
            CursorControl.SetBusyState();
            MC = new MultipleContext_MIS_SCM_Report1();
            ReportParametersEntity = new ReportParameters();
            _dsReport = new List<MIS_SCM_ReportEntity>();
            ReportItemsDictionary = new Dictionary<string, string>();
            CatDictionaryParent = new Dictionary<string, object>();
            ReportItemsDictionary.Add("R001", "Material Issue");
            ReportItemsDictionary.Add("R002", "Material Receipt");
            ReportItemsDictionary.Add("R003", "Consumption Report MachineWise");
            ReportItemsDictionary.Add("R004", "Consumption Report ItemWise");
            ReportItemsDictionary.Add("R005", "Date Wise Machine Consumption");
            ReportItemsDictionary.Add("R006", "Date Wise Item Consumption");
            ReportItemsDictionary.Add("R007", "Material Issue Batch Wise");


            OrderByDictionary = new Dictionary<string, string>();
            OrderByDictionary.Add("01", "ItemWise");
            OrderByDictionary.Add("02", "PartyWise");

            RptFormatDictionary = new Dictionary<string, string>();
            RptFormatDictionary.Add("RF01", "Summary");
            RptFormatDictionary.Add("RF02", "Details");

            MachTypeDictionary = new Dictionary<string, object>();
            MachTypeDictionary.Add("LX", "LX");
            MachTypeDictionary.Add("PM", "PM");

            cmdPartyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertParty(items, blNew); });
            cmdItemChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertItem(items); });
            cmdMachine = new RelayCommand<object>(items => { if (items == null) { return; } InsertMachine(items); });
            cmdPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
            cmdCompanyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
            cmdUnitChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertUnit(items); });
            cmdMake = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertMake(cmdPara, false, true, true); });
            cmdSubCatChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertSubCat(items); });
            cmdCatChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertCat(items); });
            cmdReport = new RelayCommand(DisplayReport);
            cmdClear = new RelayCommand(ClearData);
            CmdAddDepartment = new RelayCommand<object>(items => { if (items == null) { return; } InsertDepartment(items); });
            DefaultValues();
            LoadInitialData();

        }
        private void ClearData()
        {

            try
            {
                ReportParametersEntity = new ReportParameters();
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

        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
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
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_MIS_SCM_Report1>(MC, Request, "MIS_SCM_Report3", "SCM", "LoadAll", 0, "");

                //Loading  data on Popups.

                PartyCollection = CollectionViewSource.GetDefaultView(MC.PartyMaster);
                PartyCollection.Filter = new Predicate<object>(FilterParty);

                ItemsCollection = CollectionViewSource.GetDefaultView(MC.ItemDetails);
                ItemsCollection.Filter = new Predicate<object>(FilterItem);

                var EmpListParent = (from o in MC.Employee
                                     where o.EmpId != null
                                     select o).ToList();
                _strListEmployee = EmpListParent;
                EmpDictionaryParent = _strListEmployee.ToDictionary(X => X.EmpId.ToString(), X => (object)X.EmpName);

                ObjComp = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CompListParent = (from o in ObjComp
                                      where o.comp_code != null
                                      select o).ToList();
                _strListCompany = CompListParent;
                CompDictionaryParent = _strListCompany.ToDictionary(X => X.comp_code.ToString(), X => (object)X.CompName);

                UomCollection = CollectionViewSource.GetDefaultView(MC.UnitDetails.ToList());
                UomCollection.Filter = new Predicate<object>(FilterUom);
                StringListUOM = MC.UnitDetails.Select(x => x.unit_code).ToList();


                ObjPlant = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                PlantCollection = CollectionViewSource.GetDefaultView(ObjPlant.ToList());
                PlantCollection.Filter = new Predicate<object>(FilterPlant);
                StringListPlant = ObjPlant.Select(x => x.location_Id).ToList();



                var LocWiseMachine = (from o in MC.machineDetails
                                      where o.location_Id == ReportParametersEntity.location_Id
                                      select o).ToList();
                MachineCollection = CollectionViewSource.GetDefaultView(LocWiseMachine.ToList());
                MachineCollection.Filter = new Predicate<object>(MachineFilter);
                StringListMachine = MC.machineDetails.Select(x => x.machinecode.ToString()).ToList();

                CategoryCollection = CollectionViewSource.GetDefaultView(MC.CategoryDetails.ToList());
                CategoryCollection.Filter = new Predicate<object>(FilterCategory);
                //var categoryListParent = (from o in MC.CategoryDetails
                //                          where o.CatCode.ToString() != null
                //                          select o).ToList();
                //_strListCategory = categoryListParent;
                //CatDictionaryParent = _strListCategory.ToDictionary(X => X.CatCode.ToString(), X => (object)X.CatName);


                SubCategoryCollection = CollectionViewSource.GetDefaultView(MC.SubCategoryDetails.ToList());
                SubCategoryCollection.Filter = new Predicate<object>(FilterSubCategory);
                StringListSubCat = MC.SubCategoryDetails.Select(x => x.SubCatCode).ToList();


                var ItemTyListParent = (from o in MC.ItemTyDetails
                                        where o.ItemTypeCd != null
                                        select o).ToList();
                _strListItemTy = ItemTyListParent;
                ItemTyDictionaryParent = _strListItemTy.ToDictionary(X => X.ItemTypeCd.ToString(), X => (object)X.ItemTypeNm);


                var SubItemTyListParent = (from o in MC.SubItemTyDetails
                                           where o.SubItemTpCd != null
                                           select o).ToList();
                _strListSubItemTy = SubItemTyListParent;
                SubItemTyDictionaryParent = _strListSubItemTy.ToDictionary(X => X.SubItemTpCd.ToString(), X => (object)X.SubItemTpNm);

                //SKU

                List<ADM_M030_P> makelist = (from o in MC.ParamValueList
                                             where o.para_code == "1002"
                                             select o).ToList();
                MakeCollection = CollectionViewSource.GetDefaultView(makelist);
                MakeCollection.Filter = new Predicate<object>(FilterMake);
                StringListMake = makelist.Select(x => x.parametervalue).ToList();

                var Typelist = (from o in MC.ParamValueList
                                where o.para_code == "1001"
                                select o).ToList();
                _StrType = Typelist;
                ImpLocDictionary = _StrType.ToDictionary(X => X.value_code.ToString(), X => (object)X.parametervalue);
                // TypeCollection = CollectionViewSource.GetDefaultView(Typelist.ToList());

                var matconlist = (from o in MC.ParamValueList
                                  where o.para_code == "1003"
                                  select o).ToList();
                _StrMatCon = matconlist;
                MatConDictionary = _StrMatCon.ToDictionary(X => X.value_code.ToString(), X => (object)X.parametervalue);
                // MatConditionCollection = CollectionViewSource.GetDefaultView(matconlist.ToList());

                ObjComp = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                CompanyCollection = CollectionViewSource.GetDefaultView(ObjComp.ToList());
                CompanyCollection.Filter = new Predicate<object>(FilterCompany);
                StringListCompany = ObjComp.Select(x => x.comp_code).ToList();

                DepartmentCollection = CollectionViewSource.GetDefaultView(MC.DepartmentDetails);
                DepartmentCollection.Filter = new Predicate<object>(FilterDepartment);
                StringListDepartment = MC.DepartmentDetails.Select(x => x.DeptName).ToList();


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

            ReportParametersEntity.comp_code = AppSessionState.comp_code;
            //ReportParametersEntity.fin_year = AppSessionState.FinYear;
            ReportParametersEntity.location_Id = AppSessionState.location_Id;

            DateTime now = DateTime.Now;
            DateTime lastDayLastMonth = new DateTime(now.Year, now.Month, 1);
            ReportParametersEntity.FromDate = lastDayLastMonth.AddDays(0);
            ReportParametersEntity.ToDate = DateTime.Now;
        }
        private void DisplayReport()
        {
            CursorControl.SetBusyState();
            try
            {
                //Check if Report not selected then give a Message.
                if (ReportParametersEntity.ReportCode == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Report Type");
                    showMessageService.ShowMessage();
                }




                if (ReportParametersEntity.ReportCode != null)
                {
                    string RequestParameter = "Report" + "!@" + ReportParametersEntity.ReportCode + "!@" + ReportParametersEntity.ItemCode + "!@" + ReportParametersEntity.PartyId + "!@" + ReportParametersEntity.location_Id + "!@" + ReportParametersEntity.comp_code + "!@" + Convert.ToDateTime(ReportParametersEntity.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParametersEntity.ToDate).ToString("MM/dd/yyyy") + "!@" + ReportParametersEntity.t_status + "!@" + ReportParametersEntity.unit_code + "!@" + ReportParametersEntity.machinecode + "!@" + ReportParametersEntity.CatCode + "!@" + ReportParametersEntity.SubCatCode + "!@" + ReportParametersEntity.ItemTypeCd + "!@" + ReportParametersEntity.SubItemTpCd + "!@" + ReportParametersEntity.EmpId + "!@" + ReportParametersEntity.value_code + "!@" + ReportParametersEntity.MatConditionCode + "!@" + ReportParametersEntity.ImportLocalCode + "!@" + ReportParametersEntity.ImportLocalValue + "!@" + ReportParametersEntity.mctype + "!@" + ReportParametersEntity.dept_code;

                    dsReport = repository.GetDataWithReturnDomainObject<List<MIS_SCM_ReportEntity>>(dsReport, RequestParameter, "MIS_SCM_Report3", "SCM", "", 0, RequestParameter);

                    object[] objDataSource = new object[3];
                    string[] objDataSourceName = new string[3];

                    objDataSource[0] = dsReport;

                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == ReportParametersEntity.comp_code).ToList();
                    objDataSource[1] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == ReportParametersEntity.location_Id).ToList();
                    objDataSource[2] = Result;


                    objDataSourceName[0] = "dsMIS_SCM_ReportEntity";
                    objDataSourceName[1] = "dsCompany";
                    objDataSourceName[2] = "dsLocation";

                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\MIS\\SCM\\" + GetReportFile(ReportParametersEntity.ReportCode), getParametersList(), "");

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
                result.Add("FromDate", Convert.ToString(ReportParametersEntity.FromDate));
                result.Add("ToDate", Convert.ToString(ReportParametersEntity.ToDate));
                result.Add("ItemCode", ReportParametersEntity.ItemCode);
                result.Add("PartyId", ReportParametersEntity.PartyId);
                result.Add("PartyNm", ReportParametersEntity.PartyNm);
                result.Add("doc_type", ReportParametersEntity.doc_type);
                result.Add("doc_cat", ReportParametersEntity.doc_cat);
                result.Add("t_status", ReportParametersEntity.t_status);
                result.Add("ReportName", ReportParametersEntity.ReportName);
                result.Add("doc_no", ReportParametersEntity.doc_no);
                result.Add("comp_code", ReportParametersEntity.comp_code);
                result.Add("location_Id", ReportParametersEntity.location_Id);
                result.Add("ItemName", ReportParametersEntity.ItemName);
                result.Add("EmpId", ReportParametersEntity.EmpId);
                result.Add("EmpName", ReportParametersEntity.EmpName);
                result.Add("unit_code", ReportParametersEntity.unit_code);
                result.Add("machinecode", ReportParametersEntity.machinecode);
                result.Add("CatCode", ReportParametersEntity.CatCode);
                result.Add("SubCatCode", ReportParametersEntity.SubCatCode);
                result.Add("SubCatName", ReportParametersEntity.SubCatName);
                result.Add("ItemTypeCd", ReportParametersEntity.ItemTypeCd);
                result.Add("SubItemTpCd", ReportParametersEntity.SubItemTpCd);
                result.Add("ImportLocalValue", ReportParametersEntity.ImportLocalValue);
                result.Add("MatConditionValue", ReportParametersEntity.MatConditionValue);
                result.Add("parametervalue", ReportParametersEntity.parametervalue);
                result.Add("mctype", ReportParametersEntity.mctype);


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
            { returnReportName = "ConsumptionRpt.rdlc"; }
            else if (ReportCode == "R002")
            { returnReportName = "ConsmptnMaterialReciept.rdlc"; }
            else if (ReportCode == "R003")
            { returnReportName = "MachineWiseConsumptionReport.rdlc"; }
            else if (ReportCode == "R004")
            { returnReportName = "ItemWiseConsumptionReport.rdlc"; }
            else if (ReportCode == "R005")
            { returnReportName = "MonthlyMachineWiseConsumptionReport.rdlc"; }
            else if (ReportCode == "R006")
            { returnReportName = "MonthlyItemWiseConsumptionReport.rdlc"; }
            else if (ReportCode == "R007")
            { returnReportName = "ConsumptionBatchRpt.rdlc"; }
            return returnReportName;
        }
        private void InsertParty(object InputValue, bool OverrideValue)
        {

            string stringParty = "";
            string stringPartyNm = "";
            ReportParametersEntity.PartyId = "";
            foreach (ADM_M028_P temp in MC.PartyMaster)
            {
                if (temp.Select == true)
                {
                    stringParty = stringParty + "," + temp.PartyId;
                    stringPartyNm = stringPartyNm + "," + temp.PartyNm;
                }
            }
            ReportParametersEntity.PartyId = stringParty.ToString().TrimStart(new char[] { ',' });
            ReportParametersEntity.PartyNm = stringPartyNm.ToString().TrimStart(new char[] { ',' });

        }
        private void InsertCompany(object InputValue)
        {
            try
            {

                string Request = "";
                ADM_M002 POPUPEntityObject = null;
                #region Command Parameter Read Section
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

                    ReportParametersEntity.comp_code = POPUPEntityObject.comp_code;
                    ReportParametersEntity.CompName = POPUPEntityObject.CompName;
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
                    ReportParametersEntity.value_code = POPUPEntityObject.value_code;
                    ReportParametersEntity.parametervalue = POPUPEntityObject.parametervalue;
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
        private void InsertCat(object InputValue)
        {

            string stringCatCode = "";
            string stringCatName = "";
            ReportParametersEntity.SubCatCode = "";
            foreach (ADM_M018_P temp in MC.CategoryDetails)
            {
                if (temp.Select == true)
                {
                    stringCatCode = stringCatCode + "," + temp.CatCode;
                    stringCatName = stringCatName + "," + temp.CatName;
                }
            }
            ReportParametersEntity.CatCode = stringCatCode.ToString().TrimStart(new char[] { ',' });
            ReportParametersEntity.CatName = stringCatName.ToString().TrimStart(new char[] { ',' });

        }

        private void InsertSubCat(object InputValue)
        {

            string stringSubCatCode = "";
            string stringSubCatName = "";
            ReportParametersEntity.SubCatCode = "";
            foreach (ADM_M019_P temp in MC.SubCategoryDetails)
            {
                if (temp.Select == true)
                {
                    stringSubCatCode = stringSubCatCode + "," + temp.SubCatCode;
                    stringSubCatName = stringSubCatName + "," + temp.SubCatName;
                }
            }
            ReportParametersEntity.SubCatCode = stringSubCatCode.ToString().TrimStart(new char[] { ',' });
            ReportParametersEntity.SubCatName = stringSubCatName.ToString().TrimStart(new char[] { ',' });

        }
        private void InsertMachine(object InputValue)
        {

            string stringMachineCode = "";
            ReportParametersEntity.machinecode = "";
            foreach (ZADM_M013_P temp in MC.machineDetails)
            {
                if (temp.Select == true)
                {
                    stringMachineCode = stringMachineCode + "," + temp.machinecode;
                }
            }
            ReportParametersEntity.machinecode = stringMachineCode.ToString().TrimStart(new char[] { ',' });
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
            }
            catch (Exception ex) { }

            #endregion

            if (POPUPEntityObject != null)
            {

                ReportParametersEntity.location_Id = POPUPEntityObject.location_Id;

                var LocWiseMachine = (from o in MC.machineDetails
                                      where o.location_Id == ReportParametersEntity.location_Id
                                      select o).ToList();


                MachineCollection = CollectionViewSource.GetDefaultView(LocWiseMachine.ToList());
                MachineCollection.Filter = new Predicate<object>(MachineFilter);
                MachineCollection.Refresh();
            }

        }
        private void InsertDepartment(object InputValue)
        {
            string Request = "";
            ADM_M025_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.DepartmentDetails.Where(x => x.DeptName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M025_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M025_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                ReportParametersEntity.dept_code = POPUPEntityObject.dept_code;
            }
        }
        private void InsertItem(object InputValue)
        {

            string stringItems = "";
            string stringItemsNm = "";

            ReportParametersEntity.ItemCode = "";
            foreach (ADM_M022_P temp in MC.ItemDetails)
            {
                if (temp.Select == true)
                {
                    stringItems = stringItems + "," + temp.ItemCode;
                    stringItemsNm = stringItemsNm + "," + temp.ItemName;

                }
            }
            ReportParametersEntity.ItemCode = stringItems.ToString().TrimStart(new char[] { ',' });
            ReportParametersEntity.ItemName = stringItemsNm.ToString().TrimStart(new char[] { ',' });

        }

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

                    ReportParametersEntity.unit_code = POPUPEntityObject.unit_code;
                    ReportParametersEntity.unit_name = POPUPEntityObject.unit_name;

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
        #endregion

        #region . Filter .
        private string _FilterStringDepartment;
        public string FilterStringDepartment
        {
            get { return _FilterStringDepartment; }
            set
            {
                _FilterStringDepartment = value;
                RaisePropertyChanged("FilterStringDepartment");
                FilterCollectionDept();
            }
        }
        private void FilterCollectionDept()
        {
            if (_DepartmentCollection != null)
            {
                _DepartmentCollection.Refresh();
            }
        }
        public bool FilterDepartment(object obj)
        {
            var data = obj as ADM_M025_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringDepartment))
                {
                    return (data.dept_code != null && data.dept_code.ToString().ToLower().Contains(_FilterStringDepartment.ToLower()) ||
                        (data.DeptName != null && data.DeptName.ToString().ToLower().Contains(_FilterStringDepartment.ToLower())));
                }
                return true;
            }
            return false;
        }
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
                    return data.parametervalue != null && data.parametervalue.ToString().ToLower().Contains(_filterStringMake.ToLower());
                }
                return true;
            }
            return false;
        }

        #region Filters For Machine
        private string _filterStringMachine;
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
        private void FilterCollectionMachine()
        {
            if (_MachineCollection != null)
            {
                _MachineCollection.Refresh();
            }
        }
        public bool MachineFilter(object obj)
        {
            var data = obj as ZADM_M013_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringMachine))
                {
                    return ((data.machinecode != null) && data.machinecode.ToLower().Contains(_filterStringMachine.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter string Plant
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

        #endregion

        #region . Command Action .
        protected override void OnSaveAction(InquiryActionResult<ReportParameters> result)
        {

        }
        protected override void OnCreateAction(InquiryActionResult<ReportParameters> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<ReportParameters> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<ReportParameters> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ReportParameters> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ReportParameters> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ReportParameters> result)
        {
        }
        protected override void OnPrintAction(InquiryActionResult<ReportParameters> result)
        {

        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<ReportParameters> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ReportParameters> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ReportParameters> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ReportParameters> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ReportParameters> result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }



}
