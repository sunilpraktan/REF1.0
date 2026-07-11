using GalaSoft.MvvmLight.Command;
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
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity.Finance;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using System.Windows;
using System.Reflection;
using System.IO;
using GalaSoft.MvvmLight.Ioc;
using Reflection.Presentation.Core.VirtualDesktops;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.ReflectionSystem;
using Reflection.ReportingServices;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.MM.ViewModels
{
    public class MM_M0007_VM : WorkspaceViewModel<ADM_M022>
    {
        #region AutoSuggest TextBox Declaration Region 

        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(MM_M0007_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _AS_COMPANY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_COMPANY
        {
            get { return _AS_COMPANY; }
            set
            {
                if (_AS_COMPANY != value)
                {
                    _AS_COMPANY = value; RaisePropertyChanged("AS_COMPANY");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_LOCATION { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_LOCATION
        {
            get { return _AS_LOCATION; }
            set
            {
                if (_AS_LOCATION != value)
                {
                    _AS_LOCATION = value; RaisePropertyChanged("AS_LOCATION");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASValuationClass { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASValuationClass
        {
            get { return _ASValuationClass; }
            set
            {
                if (_ASValuationClass != value)
                {
                    _ASValuationClass = value; RaisePropertyChanged("ASValuationClass");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_PRICE_INDICATOR { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_PRICE_INDICATOR
        {
            get { return _AS_PRICE_INDICATOR; }
            set
            {
                if (_AS_PRICE_INDICATOR != value)
                {
                    _AS_PRICE_INDICATOR = value; RaisePropertyChanged("AS_PRICE_INDICATOR");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASFltrt_Category { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASFltrt_Category
        {
            get { return _ASFltrt_Category; }
            set
            {
                if (_ASFltrt_Category != value)
                {
                    _ASFltrt_Category = value; RaisePropertyChanged("ASFltrt_Category");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASAccountingGroup { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASAccountingGroup
        {
            get { return _ASAccountingGroup; }
            set
            {
                if (_ASAccountingGroup != value)
                {
                    _ASAccountingGroup = value; RaisePropertyChanged("ASAccountingGroup");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASReconAcc { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASReconAcc
        {
            get { return _ASReconAcc; }
            set
            {
                if (_ASReconAcc != value)
                {
                    _ASReconAcc = value; RaisePropertyChanged("ASReconAcc");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASMaterialGroup { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASMaterialGroup
        {
            get { return _ASMaterialGroup; }
            set
            {
                if (_ASMaterialGroup != value)
                {
                    _ASMaterialGroup = value; RaisePropertyChanged("ASMaterialGroup");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASTaxIndicator { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTaxIndicator
        {
            get { return _ASTaxIndicator; }
            set
            {
                if (_ASTaxIndicator != value)
                {
                    _ASTaxIndicator = value; RaisePropertyChanged("ASTaxIndicator");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASBUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBUnit
        {
            get { return _ASBUnit; }
            set
            {
                if (_ASBUnit != value)
                {
                    _ASBUnit = value; RaisePropertyChanged("ASBUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASIUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASIUnit
        {
            get { return _ASIUnit; }
            set
            {
                if (_ASIUnit != value)
                {
                    _ASIUnit = value; RaisePropertyChanged("ASIUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASSUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSUnit
        {
            get { return _ASSUnit; }
            set
            {
                if (_ASSUnit != value)
                {
                    _ASSUnit = value; RaisePropertyChanged("ASSUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASStkUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASStkUnit
        {
            get { return _ASStkUnit; }
            set
            {
                if (_ASStkUnit != value)
                {
                    _ASStkUnit = value; RaisePropertyChanged("ASStkUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASControlKey { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASControlKey
        {
            get { return _ASControlKey; }
            set
            {
                if (_ASControlKey != value)
                {
                    _ASControlKey = value; RaisePropertyChanged("ASControlKey");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASCertificateType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCertificateType
        {
            get { return _ASCertificateType; }
            set
            {
                if (_ASCertificateType != value)
                {
                    _ASCertificateType = value; RaisePropertyChanged("ASCertificateType");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASQmSystem { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASQmSystem
        {
            get { return _ASQmSystem; }
            set
            {
                if (_ASQmSystem != value)
                {
                    _ASQmSystem = value; RaisePropertyChanged("ASQmSystem");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASExportGroup { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASExportGroup
        {
            get { return _ASExportGroup; }
            set
            {
                if (_ASExportGroup != value)
                {
                    _ASExportGroup = value; RaisePropertyChanged("ASExportGroup");
                }
            }
        }

        #endregion

        #region . Declaration .
        bool isNewRecord = true;
        string ts_code_vm = null;

        WebServiceRepository<ADM_M022> repository = new WebServiceRepository<ADM_M022>();
        WebServiceRepository<MultipleContext_ADM_M022> repository_MC = new WebServiceRepository<MultipleContext_ADM_M022>();
        WebServiceRepository<MultipleContext_ADM_M022> repository_MCTemp = new WebServiceRepository<MultipleContext_ADM_M022>();

        ObjectSerializationService obj = new ObjectSerializationService();

        private MultipleContext_ADM_M022 _MC = new MultipleContext_ADM_M022();
        public MultipleContext_ADM_M022 MC
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

        private MultipleContext_ADM_M022 _MCTemp = new MultipleContext_ADM_M022();
        public MultipleContext_ADM_M022 MCTemp
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

        private ADM_M022 _MasterEntity;
        public ADM_M022 MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value;
                    RaisePropertyChanged("MasterEntity");
                    value.BeginEdit();
                }
            }
        }

        private bool _MoveFlag;   //movement type enable disable
        public bool MoveFlag
        {
            get { return _MoveFlag; }
            set { _MoveFlag = value; RaisePropertyChanged("MoveFlag"); }
        }

        private bool _EnableFlag;
        public bool EnableFlag
        {
            get { return _EnableFlag; }
            set { _EnableFlag = value; RaisePropertyChanged("EnableFlag"); }
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

        private List<COM_T003> _AttachmentCollection;
        public List<COM_T003> AttachmentCollection
        {
            get { return _AttachmentCollection; }
            set
            {
                if (_AttachmentCollection != value)
                {
                    _AttachmentCollection = value;
                    RaisePropertyChanged("AttachmentCollection");
                }
            }
        }
        private List<PRICE_INDICATOR> _PRICE_INDICATOR_LIST;
        public List<PRICE_INDICATOR> PRICE_INDICATOR_LIST
        {
            get { return _PRICE_INDICATOR_LIST; }
            set
            {
                if (_PRICE_INDICATOR_LIST != value)
                {
                    _PRICE_INDICATOR_LIST = value;
                    RaisePropertyChanged("PRICE_INDICATOR_LIST");
                }
            }
        }
        private STD_REQ_PARA_BE _REQ_PARA;
        public STD_REQ_PARA_BE REQ_PARA
        {
            get { return _REQ_PARA; }
            set
            {
                if (_REQ_PARA != value)
                {
                    _REQ_PARA = value;

                    RaisePropertyChanged("REQ_PARA");
                }
            }
        }
        #endregion

        #region . StringList .

        private List<STD_LIST_BE> _FlipGridData;
        public List<STD_LIST_BE> FlipGridData
        {
            get { return _FlipGridData; }
            set
            {
                if (_FlipGridData != value)
                {
                    _FlipGridData = value;
                    RaisePropertyChanged("FlipGridData");
                }
            }
        }

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

        private List<string> _StringListProduct;
        public List<string> StringListProduct
        {
            get { return _StringListProduct; }
            set
            {
                if (_StringListProduct != value)
                {
                    _StringListProduct = value;
                }
            }
        }

        private List<string> _StringListCommodity;
        public List<string> StringListCommodity
        {
            get { return _StringListCommodity; }
            set
            {
                if (_StringListCommodity != value)
                {
                    _StringListCommodity = value;
                }
            }
        }

        private List<string> _StringListMaterial;
        public List<string> StringListMaterial
        {
            get { return _StringListMaterial; }
            set
            {
                if (_StringListMaterial != value)
                {
                    _StringListMaterial = value;
                }
            }
        }

        private List<string> _StringListAsset;
        public List<string> StringListAsset
        {
            get { return _StringListAsset; }
            set
            {
                if (_StringListAsset != value)
                {
                    _StringListAsset = value;
                }
            }
        }

        private List<string> _StringListUnit;
        public List<string> StringListUnit
        {
            get { return _StringListUnit; }
            set
            {
                if (_StringListUnit != value)
                {
                    _StringListUnit = value;
                }
            }
        }

        private List<string> _StringListRgGroup;
        public List<string> StringListRgGroup
        {
            get { return _StringListRgGroup; }
            set
            {
                if (_StringListRgGroup != value)
                {
                    _StringListRgGroup = value;
                }
            }
        }

        private List<string> _StringListParty;
        public List<string> StringListParty
        {
            get { return _StringListParty; }
            set
            {
                if (_StringListParty != value)
                {
                    _StringListParty = value;
                }
            }
        }

        #endregion

        #region . ICollection .

        private ICollectionView _BACKFLIP_COLLECTION;
        public ICollectionView BACKFLIP_COLLECTION
        {
            get { return _BACKFLIP_COLLECTION; }
            set { _BACKFLIP_COLLECTION = value; RaisePropertyChanged("BACKFLIP_COLLECTION"); }
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

        private ICollectionView _ItemTypeCollection;
        public ICollectionView ItemTypeCollection
        {
            get { return _ItemTypeCollection; }
            set { _ItemTypeCollection = value; RaisePropertyChanged("ItemTypeCollection"); }
        }

        private ICollectionView _SubItemTypeCollection;
        public ICollectionView SubItemTypeCollection
        {
            get { return _SubItemTypeCollection; }
            set { _SubItemTypeCollection = value; RaisePropertyChanged("SubItemTypeCollection"); }
        }

        private ICollectionView _ProductCollection;
        public ICollectionView ProductCollection
        {
            get { return _ProductCollection; }
            set { _ProductCollection = value; RaisePropertyChanged("ProductCollection"); }
        }

        private ICollectionView _CommodityCollection;
        public ICollectionView CommodityCollection
        {
            get { return _CommodityCollection; }
            set { _CommodityCollection = value; RaisePropertyChanged("CommodityCollection"); }
        }

        private ICollectionView _MaterialCollection;
        public ICollectionView MaterialCollection
        {
            get { return _MaterialCollection; }
            set { _MaterialCollection = value; RaisePropertyChanged("MaterialCollection"); }
        }

        private ICollectionView _AssetCollection;
        public ICollectionView AssetCollection
        {
            get { return _AssetCollection; }
            set { _AssetCollection = value; RaisePropertyChanged("AssetCollection"); }
        }

        private ICollectionView _UnitCollection;
        public ICollectionView UnitCollection
        {
            get { return _UnitCollection; }
            set { _UnitCollection = value; RaisePropertyChanged("UnitCollection"); }
        }

        private ICollectionView _RgGroupCollection;
        public ICollectionView RgGroupCollection
        {
            get { return _RgGroupCollection; }
            set { _RgGroupCollection = value; RaisePropertyChanged("RgGroupCollection"); }
        }

        private ICollectionView _PartyCollection;
        public ICollectionView PartyCollection
        {
            get { return _PartyCollection; }
            set { _PartyCollection = value; RaisePropertyChanged("PartyCollection"); }
        }



        #endregion

        #region . Relay Command Declaration .

        //public RelayCommand<object> cmdInsertCompany { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }

        public RelayCommand<object> cmdInsertReconAccount { get; private set; }
        public RelayCommand<object> cmdInsertAccountingGroup { get; private set; }
        public RelayCommand<object> cmdInsertValuationClass { get; private set; }
        public RelayCommand<object> cmdInsertCategory { get; private set; }
        public RelayCommand<object> cmdInsertSubCategory { get; private set; }
        public RelayCommand<object> cmdInsertItemType { get; private set; }
        public RelayCommand<object> cmdInsertSubItemType { get; private set; }
        public RelayCommand<object> cmdInsertProduct { get; private set; }
        public RelayCommand<object> cmdInsertCommodity { get; private set; }
        public RelayCommand<object> cmdInsertMaterial { get; private set; }
        public RelayCommand<object> cmdInsertAsset { get; private set; }
        public RelayCommand<object> cmdInsertUnit { get; private set; }
        public RelayCommand<object> cmdInsertWeightUnit { get; private set; }
        public RelayCommand<object> cmdInsertVolumeUnit { get; private set; }
        public RelayCommand<object> cmdInsertPurchaseUnit { get; private set; }
        public RelayCommand<object> cmdInsertRgGroup { get; private set; }
        public RelayCommand<object> cmdInsertMaterialGroup { get; private set; }
        public RelayCommand<object> cmdInsertTaxIndicator { get; private set; }
        public RelayCommand<object> cmdInsertParty { get; private set; }
        // public RelayCommand CmdLoad { get; private set; }
        public RelayCommand<object> cmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> ButtonClickCommand { get; private set; }
        public RelayCommand<object> cmdLoadBackFlip { get; private set; }
        public RelayCommand ExportCommand { get; private set; }
        #endregion

        #region . Constructor .
        public MM_M0007_VM(string ts_code) : base()
        {
            ts_code_vm = ts_code;
            MasterEntity = new ADM_M022();
            FlipGridData = new List<STD_LIST_BE>();
            PRICE_INDICATOR_LIST = new List<PRICE_INDICATOR>();
            REQ_PARA = new STD_REQ_PARA_BE();
            MasterEntity.ValidateAsync().Wait();
            LoadEnums();
            #region . Relay Command Initialisation .
        
            //cmdInsertCompany = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCompany(cmdPara); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            cmdInsertReconAccount = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertReconAccount(cmdPara); });
            cmdInsertAccountingGroup = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertAccountingGroup(cmdPara); });
            cmdInsertValuationClass = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertValuationClass(cmdPara); });
            cmdInsertCategory = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCategory(cmdPara); });
            cmdInsertSubCategory = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSubCategory(cmdPara); });
            cmdInsertItemType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItemType(cmdPara); });
            cmdInsertSubItemType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSubItemType(cmdPara); });
            cmdInsertProduct = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertProduct(cmdPara); });
            cmdInsertCommodity = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCommodity(cmdPara); });
            cmdInsertMaterial = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertMaterial(cmdPara); });
            cmdInsertAsset = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertAsset(cmdPara); });
            cmdInsertUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUnit(cmdPara); });
            cmdInsertWeightUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertWeightUnit(cmdPara); });
            cmdInsertVolumeUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertVolumeUnit(cmdPara); });
            cmdInsertPurchaseUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertPurchaseUnit(cmdPara); });
            cmdInsertRgGroup = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertRgGroup(cmdPara); });
            cmdInsertMaterialGroup = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertMaterialGroup(cmdPara); });
            cmdInsertTaxIndicator = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertTaxIndicator(cmdPara); });
            cmdInsertParty = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertParty(cmdPara); });
            //  CmdLoad = new RelayCommand(() => { AddBackflipdataonLoad(); });
            cmdLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
            ButtonClickCommand = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } ViewDocument(cmdPara); });
            cmdLoadBackFlip = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadBackFlipData(cmdPara); });
            ExportCommand = new RelayCommand(ExportCommandPrint);
            #endregion

            MoveFlag = false;
            LoadInitialData();
        }

        private void LoadEnums()
        {
            PRICE_INDICATOR PRICE_OBJ = new PRICE_INDICATOR();
            PRICE_OBJ.ind_price = "S";
            PRICE_OBJ.ind_name = "Standard";
            PRICE_INDICATOR_LIST.Add(PRICE_OBJ);
            PRICE_INDICATOR PRICE_OBJ2 = new PRICE_INDICATOR();
            PRICE_OBJ2.ind_price = "M";
            PRICE_OBJ2.ind_name = "Mooving Average";
            PRICE_INDICATOR_LIST.Add(PRICE_OBJ2);
            PRICE_INDICATOR PRICE_OBJ3 = new PRICE_INDICATOR();
            PRICE_OBJ3.ind_price = "F";
            PRICE_OBJ3.ind_name = "FIFO Method";
            PRICE_INDICATOR_LIST.Add(PRICE_OBJ3);
            PRICE_INDICATOR PRICE_OBJ4 = new PRICE_INDICATOR();
            PRICE_OBJ4.ind_price = "L";
            PRICE_OBJ4.ind_name = "LIFO Method";
            PRICE_INDICATOR_LIST.Add(PRICE_OBJ4);


        }
        #endregion

        #region . User Defined Function .
        private void ViewDocument(object InputValue)
        {
            try
            {

                AppSessionState.ViewTitle = "Material - Quality View";
                AppSessionState.TransValue = MasterEntity.ItemCode;
                AppSessionState.TransParameter = "No";
                AppSessionState.ViewOtherRecordAllowed = false;
                AppSessionState.TransactionCode = "QM20";

                if (!string.IsNullOrWhiteSpace(MasterEntity.ItemCode))
                {
                    string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.QMS.dll");
                    Assembly assembly = Assembly.LoadFile(path1);
                    Type type = assembly.GetType("Reflection.Modules.QMS.Views.QMS_M0001");
                    if (type != null)
                    {
                        dynamic instance = Activator.CreateInstance(type, "QM20", MasterEntity.ItemCode);
                        SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
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

        private void InsertCategory(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M018_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
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
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M018_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.CatCode = POPUPEntityObject.CatCode;
                    MasterEntity.CatName = POPUPEntityObject.CatName;
                    if(MasterEntity.CatCode=="SE")
                    {
                        MasterEntity.Stockble = false;
                        MasterEntity.StockUnt = false;
                    }

                    //if (POPUPEntityObject.CatCode != "" || POPUPEntityObject.CatCode != null)
                    //{
                    //    var abc = from data in MC.SubCategoryList
                    //              where data.CatCode == POPUPEntityObject.CatCode
                    //              select data;

                    //    SubCategoryCollection = CollectionViewSource.GetDefaultView(abc.ToList());
                    //    SubCategoryCollection.Filter = new Predicate<object>(Filter_SubCategory);
                    //    StringListSubCategory = MC.SubCategoryList.Select(x => x.SubCatCode).ToList();

                    //}
                    //else
                    //{
                    //    SubCategoryCollection = CollectionViewSource.GetDefaultView(MC.SubCategoryList.ToList());
                    //    SubCategoryCollection.Filter = new Predicate<object>(Filter_SubCategory);
                    //    StringListSubCategory = MC.SubCategoryList.Select(x => x.SubCatCode).ToList();
                    //}
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
        private void InsertSubCategory(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M019_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
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
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M019_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.SubCatCode = POPUPEntityObject.SubCatCode;
                    MasterEntity.SubCatName = POPUPEntityObject.SubCatName;


                    //if (POPUPEntityObject.SubCatCode != "All")
                    //{
                    //    var myItem = (from o in MC.ItemTypeList
                    //                  where o.SubCatCode == POPUPEntityObject.SubCatCode
                    //                  select o).ToList();

                    //    ItemTypeCollection = CollectionViewSource.GetDefaultView(myItem.ToList());
                    //    ItemTypeCollection.Filter = new Predicate<object>(Filter_ItemType);
                    //    StringListItemType = MC.ItemTypeList.Select(x => x.ItemTypeCd).ToList();
                    //}
                    //else
                    //{
                    //    ItemTypeCollection = CollectionViewSource.GetDefaultView(MC.ItemTypeList.ToList());
                    //    ItemTypeCollection.Filter = new Predicate<object>(Filter_ItemType);
                    //    StringListItemType = MC.ItemTypeList.Select(x => x.ItemTypeCd).ToList();

                    //}
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
        private void InsertItemType(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M015_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ItemTypeList.Where(x => x.ItemTypeCd.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M015_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M015_P>().ToList()[0];
                    }

                }
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.ItemTypeCd = POPUPEntityObject.ItemTypeCd;
                    MasterEntity.ItemTypeNm = POPUPEntityObject.ItemTypeNm;

                    if (POPUPEntityObject.ItemTypeCd != "" || POPUPEntityObject.ItemTypeCd != null)
                    {
                        var myItem = (from o in MC.SubItemTypeList
                                      where o.ItemTypeCd == POPUPEntityObject.ItemTypeCd
                                      select o).ToList();

                        SubItemTypeCollection = CollectionViewSource.GetDefaultView(myItem);
                        SubItemTypeCollection.Filter = new Predicate<object>(Filter_SubItemType);
                        StringListSubItemType = myItem.Select(x => x.SubItemTpCd).ToList();
                    }
                    else
                    {
                        SubItemTypeCollection = CollectionViewSource.GetDefaultView(MC.SubItemTypeList);
                        SubItemTypeCollection.Filter = new Predicate<object>(Filter_SubItemType);
                        StringListSubItemType = MC.SubItemTypeList.Select(x => x.SubItemTpCd).ToList();

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
        private void InsertSubItemType(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M016_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.SubItemTypeList.Where(x => x.SubItemTpCd.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M016_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M016_P>().ToList()[0];
                    }

                }
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.SubItemTpCd = POPUPEntityObject.SubItemTpCd;
                    MasterEntity.SubItemTpNm = POPUPEntityObject.SubItemTpNm;

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
        private void InsertProduct(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M020_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ProductList.Where(x => x.ProdNmCd.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M020_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M020_P>().ToList()[0];
                    }

                }
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.ProdNmCd = POPUPEntityObject.ProdNmCd;
                    MasterEntity.ProdNm = POPUPEntityObject.ProdNm;

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
        private void InsertCommodity(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M014_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.CommodityList.Where(x => x.CommCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M014_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M014_P>().ToList()[0];
                    }

                }
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.CommCode = POPUPEntityObject.CommCode;
                    MasterEntity.CommName = POPUPEntityObject.CommName;

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
        private void InsertMaterial(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M021_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.MaterialList.Where(x => x.MateCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M021_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M021_P>().ToList()[0];
                    }

                }
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.MateCode = POPUPEntityObject.MateCode;
                    MasterEntity.MateName = POPUPEntityObject.MateName;
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
        private void InsertAsset(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M017_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.AssetList.Where(x => x.AssetCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M017_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M017_P>().ToList()[0];
                    }

                }
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.AssetCode = POPUPEntityObject.AssetCode;
                    MasterEntity.AssetNm = POPUPEntityObject.AssetNm;
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
        private void InsertUnit(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UnitList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.unit_code = POPUPEntityObject.unit_code;
                    MasterEntity.unit_name = POPUPEntityObject.unit_name;
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
        private void InsertWeightUnit(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UnitList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.weight_unit = POPUPEntityObject.unit_code;
                    MasterEntity.Weightunit_name = POPUPEntityObject.unit_name;
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
        private void InsertVolumeUnit(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UnitList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.volume_unit = POPUPEntityObject.unit_code;
                    MasterEntity.Volumeunit_name = POPUPEntityObject.unit_name;
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
        private void InsertPurchaseUnit(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UnitList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.purchase_unit = POPUPEntityObject.unit_code;
                    MasterEntity.Purchesunit_name = POPUPEntityObject.unit_name;
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
        private void InsertRgGroup(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M023_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.RgGroupList.Where(x => x.RgCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M023_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M023_P>().ToList()[0];
                    }

                }
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.RgCode = POPUPEntityObject.RgCode;
                    MasterEntity.RgName = POPUPEntityObject.RgName;
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
        private void InsertParty(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M028_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.PartyList.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M028_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                    }

                }
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.PartyId = POPUPEntityObject.PartyId;
                    MasterEntity.PartyNm = POPUPEntityObject.PartyNm;
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

        private void InsertValuationClass(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M003_V POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ValuationClassList.Where(x => x.value_class.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ACC_M003_V>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_V>().ToList()[0];
                    }
                }
                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    MasterEntity.value_class = POPUPEntityObject.value_class;
                    MasterEntity.value_class_desc = POPUPEntityObject.value_class_desc;
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
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                DefaultValues();
                MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                LoadInitialData();
                
                //Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            { //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); 
            }
        }
        //private void InsertCompany(object InputValue)
        //{
        //    try
        //    {
        //        string Request = "";
        //        ADM_M0002 POPUPEntityObject = null;
        //        #region Command Parameter Read Section
        //        try
        //        {
        //            if (InputValue.GetType() == typeof(string) && InputValue != null)
        //            {
        //                Request = InputValue.ToString();
        //                if (Request.Length > 0)
        //                {
        //                    try
        //                    { POPUPEntityObject = MC.COMPANY_LIST.Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
        //                    catch (Exception ex) { }
        //                }
        //            }
        //            else if (InputValue != null)
        //            {
        //                POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M0002>().ToList()[0];
        //            }
        //        }
        //        catch (Exception ex) { }

        //        #endregion
        //        if (POPUPEntityObject != null)
        //        {
        //            //if (MasterEntity.comp_code != POPUPEntityObject.comp_code)
        //            //{
        //            MasterEntity.comp_code = POPUPEntityObject.comp_code;
        //            LoadInitialData();
        //            MasterEntity.comp_code = POPUPEntityObject.comp_code;

        //            List<ADM_M0003> LOC_LIST_OBJ = MC.LOCATION_LIST.Where(item => item.comp_code == MasterEntity.comp_code).ToList();
        //            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
        //            TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
        //            AS_LOCATION = new AutoSuggestTextViewModel<dynamic>(LOC_LIST_OBJ, TheFilter, SuggestedValue, "location_id", true);
        //            AS_LOCATION.AutoSuggestVM.IsEmptyValueAllowed = true;
        //            if (LOC_LIST_OBJ.Count == 1)
        //            {
        //                MasterEntity.location_Id = LOC_LIST_OBJ[0].location_id;
        //            }
        //            else
        //            {
        //                MasterEntity.location_Id = null;
        //            }
        //        }
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
        //    }
        //}
        private void InsertAccountingGroup(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M003_H POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.AccountingGroupList.Where(x => x.acc_group.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ACC_M003_H>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_H>().ToList()[0];
                    }
                }
                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    MasterEntity.acc_group = POPUPEntityObject.acc_group;
                    MasterEntity.group_desc = POPUPEntityObject.group_desc;
                    MasterEntity.acc_group_type = POPUPEntityObject.acc_group_type;
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
        private void InsertReconAccount(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M003_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ReconAccountList.Where(x => x.gl_code.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ACC_M003_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_P>().ToList()[0];
                    }
                }
                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    MasterEntity.recon_acc = POPUPEntityObject.gl_code;
                    MasterEntity.gl_name = POPUPEntityObject.gl_name;
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
        private void InsertMaterialGroup(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M052_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.MaterialGroup.Where(x => x.gst_item_group.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M052_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M052_P>().ToList()[0];
                    }
                }
                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    MasterEntity.gst_item_group = POPUPEntityObject.gst_item_group;
                    MasterEntity.gst_item_group_Nm = POPUPEntityObject.gst_item_group_Nm;
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
        private void InsertTaxIndicator(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M013_A_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.TaxCategory.Where(x => x.tax_cat_code.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ACC_M013_A_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M013_A_P>().ToList()[0];
                    }
                }
                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    MasterEntity.tax_cat_code = POPUPEntityObject.tax_cat_code;
                    MasterEntity.tax_indicator_desc = POPUPEntityObject.tax_indicator_desc;
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
        
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                STD_LIST_BE ParameterEntityObject = null;

                if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList()[0];
                        isNewRecord = false;

                        //string Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.ItemCode + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                        string Request = "LoadDocumentByDocumentNumber" + "!@" + AppSessionState.client + "!@" + ParameterEntityObject.comp_code + "!@" + ParameterEntityObject.location_id + "!@!@!@" + ParameterEntityObject.item_code;
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M022>(MC, Request, "ItemMaster", "Administration", "LoadDocumentByDocumentNumber", 0, "");


                        MasterEntity = MCTemp.MasterEntity[0];


                        AttachmentCollection = MC.AttachmentList;

                        if (MC.AttachmentList != null)
                        {
                            AttachmentCollection = MC.AttachmentList;
                        }
                        else
                        {
                            MC.AttachmentList = new List<COM_T003>();
                        }

                        SelectedTabControlIndex = 0;
                        SetPopupSuggestionDataAfterLoad();
                        var msg = new NotificationMessage("MM_M0007_VM");
                        Messenger.Default.Send<NotificationMessage>(msg);
                        MoveFlag = true;
                        EnableFlag = true;
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
        private void LoadBackFlipData(object InputValue)
        {
            try
            {
                //string Request = "LoadBackFlipData" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + REQ_PARA.location_Id + "!@" + (REQ_PARA.doc_cat ?? "SO") + "!@" + (Utilities.NullIf(REQ_PARA.doc_type_user) ?? "") + "!@" + (Utilities.NullIf(REQ_PARA.t_status) ?? "") + "!@" + REQ_PARA.active + "!@" + (Utilities.NullIf(REQ_PARA.EmpId) ?? AppSessionState.EmpId) + "!@" + Utilities.NullIf(REQ_PARA.PartyId) + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code + "!@" + Convert.ToDateTime(REQ_PARA.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQ_PARA.ToDate).ToString("MM/dd/yyyy") + "!@" + AppSessionState.UserID + "!@" + MasterEntity.ts_code;
                string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + REQ_PARA.location_id + "!@" + REQ_PARA.cat_code + "!@" + REQ_PARA.item_subcat + "!@" + REQ_PARA.active;
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, Request, "ItemMaster", "Administration", "LoadAll", 0, "");

                FlipGridData = MCTemp.BACK_FLIP_LIST.ToList();
                BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(FlipGridData);
                BACKFLIP_COLLECTION.Filter = new Predicate<object>(Filter_BackFlip);

               
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

        private void SetPopupSuggestionDataAfterLoad()
        {
            ASValuationClass.AutoSuggestVM.Suggestion = MC.ValuationClassList.Find(x => x.value_class == MasterEntity.value_class);
            ASAccountingGroup.AutoSuggestVM.Suggestion = MC.AccountingGroupList.Find(x => x.acc_group == MasterEntity.acc_group);
            ASReconAcc.AutoSuggestVM.Suggestion = MC.ReconAccountList.Find(x => x.gl_code == MasterEntity.recon_acc);
            ASMaterialGroup.AutoSuggestVM.Suggestion = MC.MaterialGroup.Find(x => x.gst_item_group == MasterEntity.gst_item_group_Nm);
            ASTaxIndicator.AutoSuggestVM.Suggestion = MC.TaxCategory.Find(x => x.tax_cat_code == MasterEntity.tax_indicator_desc);
        }
        #endregion

        private void LoadInitialData()
        {
            string Request = "LoadInitialData" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id;
            MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M022>(MC, Request, "ItemMaster", "Administration", "LoadInitialData", 0, "");

            #region Autosuggest Initiallisation 

            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_V)x).value_class);
            TheFilter = (o, prefix) => (((ACC_M003_V)o).value_class ?? "").ToString().ToLower().Contains(prefix.ToLower());
            ASValuationClass = new AutoSuggestTextViewModel<dynamic>(MC.ValuationClassList, TheFilter, SuggestedValue, "value_class", true);
            ASValuationClass.AutoSuggestVM.IsEmptyValueAllowed = true;

            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_H)x).acc_group);
            TheFilter = (o, prefix) => (((ACC_M003_H)o).acc_group ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_H)o).group_desc.ToString() ?? "").ToLower().Contains(prefix.ToLower());
            ASAccountingGroup = new AutoSuggestTextViewModel<dynamic>(MC.AccountingGroupList, TheFilter, SuggestedValue, "acc_group", true);
            ASAccountingGroup.AutoSuggestVM.IsEmptyValueAllowed = true;

            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_P)x).gl_code);
            TheFilter = (o, prefix) => (((ACC_M003_P)o).gl_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_P)o).gl_name.ToString() ?? "").ToLower().Contains(prefix.ToLower());
            ASReconAcc = new AutoSuggestTextViewModel<dynamic>(MC.ReconAccountList, TheFilter, SuggestedValue, "gl_code", true);
            ASReconAcc.AutoSuggestVM.IsEmptyValueAllowed = true;

            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M052_P)x).gst_item_group);
            TheFilter = (o, prefix) => (((ADM_M052_P)o).gst_item_group ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M052_P)o).gst_item_group_Nm.ToString() ?? "").ToLower().Contains(prefix.ToLower());
            ASMaterialGroup = new AutoSuggestTextViewModel<dynamic>(MC.MaterialGroup, TheFilter, SuggestedValue, "gst_item_group_Nm", true);
            ASMaterialGroup.AutoSuggestVM.IsEmptyValueAllowed = true;

            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M013_A_P)x).tax_cat_code);
            TheFilter = (o, prefix) => (((ACC_M013_A_P)o).tax_cat_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M013_A_P)o).tax_indicator_desc.ToString() ?? "").ToLower().Contains(prefix.ToLower());
            ASTaxIndicator = new AutoSuggestTextViewModel<dynamic>(MC.TaxCategory, TheFilter, SuggestedValue, "tax_cat_code", true);
            ASTaxIndicator.AutoSuggestVM.IsEmptyValueAllowed = true;

            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
            TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || ((((ADM_M038_B_P)o).unit_name ?? "").ToString() ?? "").ToLower().Contains(prefix.ToLower());
            ASBUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitList, TheFilter, SuggestedValue, "base_unit", true);
            ASBUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
            TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M038_B_P)o).unit_name.ToString() ?? "").ToLower().Contains(prefix.ToLower());
            ASIUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitList, TheFilter, SuggestedValue, "issue_unit", true);
            ASIUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
            TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || ((((ADM_M038_B_P)o).unit_name ?? "").ToString() ?? "").ToLower().Contains(prefix.ToLower());
            ASSUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitList, TheFilter, SuggestedValue, "sales_unit", true);
            ASSUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
            TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || ((((ADM_M038_B_P)o).unit_name ?? "").ToString() ?? "").ToLower().Contains(prefix.ToLower());
            ASStkUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitList, TheFilter, SuggestedValue, "stock_unit", true);
            ASStkUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

            SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M051)x).control_key);
            TheFilter = (o, prefix) => (((SYS_M051)o).control_key ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M051)o).control_key_desc.ToString() ?? "").ToLower().Contains(prefix.ToLower());
            ASControlKey = new AutoSuggestTextViewModel<dynamic>(MC.ControlKeyMaster, TheFilter, SuggestedValue, "control_key", true);
            ASControlKey.AutoSuggestVM.IsEmptyValueAllowed = true;

            SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M042_P)x).certi_tp);
            TheFilter = (o, prefix) => (((QMS_M042_P)o).certi_tp ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((QMS_M042_P)o).certi_desc.ToString() ?? "").ToLower().Contains(prefix.ToLower());
            ASCertificateType = new AutoSuggestTextViewModel<dynamic>(MC.CertificateType, TheFilter, SuggestedValue, "certi_tp", true);
            ASCertificateType.AutoSuggestVM.IsEmptyValueAllowed = true;

            SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M041_P)x).target_qm_sys);
            TheFilter = (o, prefix) => (((QMS_M041_P)o).target_qm_sys ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((QMS_M041_P)o).qm_sys_desc.ToString() ?? "").ToLower().Contains(prefix.ToLower());
            ASQmSystem = new AutoSuggestTextViewModel<dynamic>(MC.QMSystemMaster, TheFilter, SuggestedValue, "target_qm_sys", true);
            ASQmSystem.AutoSuggestVM.IsEmptyValueAllowed = true;

            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_B)x).item_group_code);
            TheFilter = (o, prefix) => (((ADM_M022_B)o).item_group_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M022_B)o).item_group_desc.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((ADM_M022_B)o).prod_desc.ToString() ?? "").ToLower().Contains(prefix.ToLower());
            ASExportGroup = new AutoSuggestTextViewModel<dynamic>(MC.ItemGroupExport, TheFilter, SuggestedValue, "item_group_code", true);
            ASExportGroup.AutoSuggestVM.IsEmptyValueAllowed = true;

            SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRICE_INDICATOR)x).ind_price);
            TheFilter = (o, prefix) => (((PRICE_INDICATOR)o).ind_price ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PRICE_INDICATOR)o).ind_name.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((PRICE_INDICATOR)o).ind_price.ToString() ?? "").ToLower().Contains(prefix.ToLower());
            AS_PRICE_INDICATOR = new AutoSuggestTextViewModel<dynamic>(PRICE_INDICATOR_LIST, TheFilter, SuggestedValue, "ind_price", true);
            AS_PRICE_INDICATOR.AutoSuggestVM.IsEmptyValueAllowed = false; AS_PRICE_INDICATOR.AutoSuggestVM.IsFreeTextAllowed = false;

            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M018_P)x).CatCode);
            TheFilter = (o, prefix) => ((ADM_M018_P)o).CatCode.ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M018_P)o).CatName.ToString() ?? "").ToLower().Contains(prefix.ToLower());
            ASFltrt_Category = new AutoSuggestTextViewModel<dynamic>(MC.CategoryList, TheFilter, SuggestedValue, "CatCode", true);
            ASFltrt_Category.AutoSuggestVM.IsEmptyValueAllowed = true;

            #endregion

            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0002)x).comp_code);
            TheFilter = (o, prefix) => (((ADM_M0002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0002)o).comp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
            AS_COMPANY = new AutoSuggestTextViewModel<dynamic>(MC.COMPANY_LIST, TheFilter, SuggestedValue, "comp_code", true);
            AS_COMPANY.AutoSuggestVM.IsEmptyValueAllowed = true;

            List<ADM_M0003> LOC_LIST_OBJ = MC.LOCATION_LIST.Where(item => item.comp_code == AppSessionState.OBJ_COMPANY.comp_code).ToList();
            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
            TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
            AS_LOCATION = new AutoSuggestTextViewModel<dynamic>(LOC_LIST_OBJ, TheFilter, SuggestedValue, "location_id", true);
            AS_LOCATION.AutoSuggestVM.IsEmptyValueAllowed = true;
            if (LOC_LIST_OBJ.Count == 1)
            {
                MasterEntity.location_Id = LOC_LIST_OBJ[0].location_id;
            }
            else
            {
                MasterEntity.location_Id = null;
            }

            CategoryCollection = CollectionViewSource.GetDefaultView(MC.CategoryList);
            CategoryCollection.Filter = new Predicate<object>(Filter_Category);
            StringListCategory = MC.CategoryList.Select(x => x.CatCode.ToString()).ToList();

            ProductCollection = CollectionViewSource.GetDefaultView(MC.ProductList);
            ProductCollection.Filter = new Predicate<object>(Filter_Product);
            StringListProduct = MC.ProductList.Select(x => x.ProdNmCd.ToString()).ToList();

            CommodityCollection = CollectionViewSource.GetDefaultView(MC.CommodityList);
            CommodityCollection.Filter = new Predicate<object>(Filter_Commodity);
            StringListCommodity = MC.CommodityList.Select(x => x.CommCode.ToString()).ToList();

            MaterialCollection = CollectionViewSource.GetDefaultView(MC.MaterialList);
            MaterialCollection.Filter = new Predicate<object>(Filter_Material);
            StringListMaterial = MC.MaterialList.Select(x => (x.MateCode ?? "").ToString()).ToList();

            AssetCollection = CollectionViewSource.GetDefaultView(MC.AssetList);
            AssetCollection.Filter = new Predicate<object>(Filter_Asset);
            StringListAsset = MC.AssetList.Select(x => x.AssetCode.ToString()).ToList();

            UnitCollection = CollectionViewSource.GetDefaultView(MC.UnitList);
            UnitCollection.Filter = new Predicate<object>(Filter_Unit);
            StringListUnit = MC.UnitList.Select(x => x.unit_code.ToString()).ToList();

            RgGroupCollection = CollectionViewSource.GetDefaultView(MC.RgGroupList);
            RgGroupCollection.Filter = new Predicate<object>(Filter_RgGroup);
            StringListRgGroup = MC.RgGroupList.Select(x => x.RgCode.ToString()).ToList();

            PartyCollection = CollectionViewSource.GetDefaultView(MC.PartyList);
            PartyCollection.Filter = new Predicate<object>(Filter_Party);
            StringListParty = MC.PartyList.Select(x => x.PartyId.ToString()).ToList();

            SubCategoryCollection = CollectionViewSource.GetDefaultView(MC.SubCategoryList.ToList());
            SubCategoryCollection.Filter = new Predicate<object>(Filter_SubCategory);
            StringListSubCategory = MC.SubCategoryList.Select(x => x.SubCatCode).ToList();

            ItemTypeCollection = CollectionViewSource.GetDefaultView(MC.ItemTypeList.ToList());
            ItemTypeCollection.Filter = new Predicate<object>(Filter_ItemType);
            StringListItemType = MC.ItemTypeList.Select(x => x.ItemTypeCd).ToList();

            DefaultValues();
        }
        private void DefaultValues()
        {
            MasterEntity.client = AppSessionState.client;
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;

            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.pr_required = true;
            MasterEntity.Stockble = true;
            MasterEntity.StockUnt = false;
            MasterEntity.active = true;

            REQ_PARA.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            REQ_PARA.active = true;
        }
        private bool Validation()
        {
            if (string.IsNullOrWhiteSpace(MasterEntity.comp_code))
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = String.Format("Please Select Company Code...", this.Title);
                showMessageService.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.location_Id))
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = String.Format("Please Select Location Code...", this.Title);
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.ItemName == null || MasterEntity.ItemName == "" || MasterEntity.ItemName.ToString().Trim().Length == 0)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter ItemName");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.CatCode == null || MasterEntity.CatCode == "" || MasterEntity.CatCode.ToString().Trim().Length == 0)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Category Code");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.unit_code == null || MasterEntity.unit_code == "" || MasterEntity.unit_code.ToString().Trim().Length == 0)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Unit Code");
                showMessageService.ShowMessage();
                return false;
            }
            //else if (MasterEntity.value_class == null || MasterEntity.value_class == "" || MasterEntity.value_class.ToString().Trim().Length == 0)
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format("Please Enter Valuation Class");
            //    showMessageService.ShowMessage();
            //    return false;
            //}
            //else if (MasterEntity.acc_group == null || MasterEntity.acc_group == "" || MasterEntity.acc_group.ToString().Trim().Length == 0)
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format("Please Enter Accouting Group");
            //    showMessageService.ShowMessage();
            //    return false;
            //}
            //else if (MasterEntity.recon_acc == null || MasterEntity.recon_acc == "" || MasterEntity.recon_acc.ToString().Trim().Length == 0)
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format("Please Enter Reconcillation Ledger Account");
            //    showMessageService.ShowMessage();
            //    return false;
            //}
            //else if (MasterEntity.ProdNm == null || MasterEntity.ProdNm == "" || MasterEntity.ProdNm.ToString().Trim().Length == 0)
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format("Please Enter HSN Product Group");
            //    showMessageService.ShowMessage();
            //    return false;
            //}
            //else if (MasterEntity.ProdNmCd == null || MasterEntity.ProdNmCd == "" || MasterEntity.ProdNmCd.ToString().Trim().Length == 0)
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format("Please Enter HSN/SAC Code");
            //    showMessageService.ShowMessage();
            //    return false;
            //}
            //else if (MasterEntity.gst_item_group == null || MasterEntity.gst_item_group == "" || MasterEntity.gst_item_group.ToString().Trim().Length == 0)
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format("Please Enter GST Material Group");
            //    showMessageService.ShowMessage();
            //    return false;
            //}

            return true;
        }
        protected override void OnCreateAction(InquiryActionResult<ADM_M022> result)
        {
            isNewRecord = true;
            MasterEntity = new ADM_M022();
            PRICE_INDICATOR_LIST = new List<PRICE_INDICATOR>();
            EnableFlag = false;
            DefaultValues();
            MoveFlag = false;

            var msg = new NotificationMessage("MM_M0007_VM");
            Messenger.Default.Send<NotificationMessage>(msg);
        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M022> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M022> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M022> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M022> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M022> result)
        {
            try
            {
                ////string Request = "LoadBackFlipData" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + REQ_PARA.location_Id + "!@" + (REQ_PARA.doc_cat ?? "SO") + "!@" + (Utilities.NullIf(REQ_PARA.doc_type_user) ?? "") + "!@" + (Utilities.NullIf(REQ_PARA.t_status) ?? "") + "!@" + REQ_PARA.active + "!@" + (Utilities.NullIf(REQ_PARA.EmpId) ?? AppSessionState.EmpId) + "!@" + Utilities.NullIf(REQ_PARA.PartyId) + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code + "!@" + Convert.ToDateTime(REQ_PARA.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQ_PARA.ToDate).ToString("MM/dd/yyyy") + "!@" + AppSessionState.UserID + "!@" + MasterEntity.ts_code;
                //string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + REQ_PARA.comp_code + "!@" + REQ_PARA.location_id + "!@" + REQ_PARA.cat_code + "!@" + REQ_PARA.item_subcat + "!@" + REQ_PARA.active;
                //MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, Request, "ItemMaster", "Administration", "LoadAll", 0, "");


                string Request = "Items_Report" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.ItemCode;

                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M022>(MC, Request, "ItemMaster", "Administration", "LoadDocumentByDocumentNumber", 0, "");
                object[] objDataSource = new object[3];
                string[] objDataSourceName = new string[3];



                objDataSource[0] = MCTemp.MasterEntity;

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[1] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[2] = Result;



                objDataSourceName[0] = "dsRptItemS";
                objDataSourceName[1] = "dsCompany";
                objDataSourceName[2] = "dsLocation";


                ReportManager ReportManager = new ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Admin\\ItemDocument.rdlc", getParametersList(), "");
            }
            catch (Exception ex) { }
        }

        private void ExportCommandPrint()
        {
            try
            {
                //string Request = "Party_Report" + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                // string Request = AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id;

                //MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ADM_M024>(MCTemp, Request, "PartyMaster", "Administration", "", 0, "");
                // MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ADM_M024>(MCTemp, Request, "Employee_Master", "Administration", "LoadDocumentByDocumentNumber", 0, "");


                object[] objDataSource = new object[3];
                string[] objDataSourceName = new string[3];

                objDataSource[0] = MCTemp.BackflipList;

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[1] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[2] = Result;



                objDataSourceName[0] = "dsRptItemS";
                objDataSourceName[1] = "dsCompany";
                objDataSourceName[2] = "dsLocation";


                ReportManager ReportManager = new ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Admin\\ItemDetailsReport.rdlc", getParametersList(), "");
            }
            catch (Exception ex) { }
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M022> result)
        {

        }
        protected override void OnSaveAction(InquiryActionResult<ADM_M022> result)
        {
            try
            {
                if (Validation() == true)
                {
                    this.MasterEntity.EndEdit();
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ADM_M022>(MasterEntity, "ItemMaster", "Administration");
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ADM_M022>(MasterEntity, "ItemMaster", "Administration");
                    }
                    if (MasterEntity.ItemCode != null || MasterEntity.ItemCode.ToString() == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Saved Successfully");
                        showMessageService.ShowMessage();
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Can Not Saved Please Try Again");
                        showMessageService.ShowMessage();
                    }
                    isNewRecord = false;
                    MoveFlag = true;
                    EnableFlag = true;


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
            if (!string.IsNullOrEmpty(MasterEntity.ItemCode.ToString()))
            {
                //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.ItemCode.ToString().Replace("/", "--"), DocumentList = MCTemp.AttachmentList, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M022> result)
        {
            //throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M022> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M022> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M022> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M022> result)
        {
            throw new NotImplementedException();
        }

        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("prepare_by", AppSessionState.Name);
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

        #region . Filters .

        #region . Category .
        private string _filterStringCategory;
        public string filterStringCategory
        {
            get { return _filterStringCategory; }
            set
            {
                _filterStringCategory = value;
                RaisePropertyChanged("filterStringCategory");
                Filter_CategoryCollection();
            }
        }
        private void Filter_CategoryCollection()
        {
            if (CategoryCollection != null)
            {
                CategoryCollection.Refresh();
            }
        }
        public bool Filter_Category(object obj)
        {
            var data = obj as ADM_M018_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringCategory))
                {
                    return (data.CatCode != null && data.CatCode.ToString().ToLower().Contains(_filterStringCategory.ToLower())) ||
                           (data.CatName != null && data.CatName.ToString().ToLower().Contains(_filterStringCategory.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Sub Category .
        private string _filterStringSubCategory;
        public string filterStringSubCategory
        {
            get { return _filterStringSubCategory; }
            set
            {
                _filterStringSubCategory = value;
                RaisePropertyChanged("filterStringSubCategory");
                Filter_SubCategoryCollection();
            }
        }
        private void Filter_SubCategoryCollection()
        {
            if (SubCategoryCollection != null)
            {
                SubCategoryCollection.Refresh();
            }
        }
        public bool Filter_SubCategory(object obj)
        {
            var data = obj as ADM_M019_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringSubCategory))
                {
                    return (data.SubCatCode != null && data.SubCatCode.ToString().ToLower().Contains(_filterStringSubCategory.ToLower())) ||
                           (data.SubCatName != null && data.SubCatName.ToString().ToLower().Contains(_filterStringSubCategory.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . ItemType .
        private string _filterStringItemType;
        public string filterStringItemType
        {
            get { return _filterStringItemType; }
            set
            {
                _filterStringItemType = value;
                RaisePropertyChanged("filterStringItemType");
                Filter_ItemTypeCollection();
            }
        }
        private void Filter_ItemTypeCollection()
        {
            if (ItemTypeCollection != null)
            {
                ItemTypeCollection.Refresh();
            }
        }
        public bool Filter_ItemType(object obj)
        {
            var data = obj as ADM_M015_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringItemType))
                {
                    return (data.ItemTypeCd != null && data.ItemTypeCd.ToString().ToLower().Contains(_filterStringItemType.ToLower())) ||
                           (data.ItemTypeNm != null && data.ItemTypeNm.ToString().ToLower().Contains(_filterStringItemType.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . SubItemType .
        private string _filterStringSubItemType;
        public string filterStringSubItemType
        {
            get { return _filterStringSubItemType; }
            set
            {
                _filterStringSubItemType = value;
                RaisePropertyChanged("filterStringSubItemType");
                Filter_SubItemTypeCollection();
            }
        }
        private void Filter_SubItemTypeCollection()
        {
            if (SubItemTypeCollection != null)
            {
                SubItemTypeCollection.Refresh();
            }
        }
        public bool Filter_SubItemType(object obj)
        {
            var data = obj as ADM_M016_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringSubItemType))
                {
                    return (data.SubItemTpCd != null && data.SubItemTpCd.ToString().ToLower().Contains(_filterStringSubItemType.ToLower())) ||
                           (data.SubItemTpNm != null && data.SubItemTpNm.ToString().ToLower().Contains(_filterStringSubItemType.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Product .
        private string _filterStringProduct;
        public string filterStringProduct
        {
            get { return _filterStringProduct; }
            set
            {
                _filterStringProduct = value;
                RaisePropertyChanged("filterStringProduct");
                Filter_ProductCollection();
            }
        }
        private void Filter_ProductCollection()
        {
            if (ProductCollection != null)
            {
                ProductCollection.Refresh();
            }
        }
        public bool Filter_Product(object obj)
        {
            var data = obj as ADM_M020_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringProduct))
                {
                    return (data.ProdNmCd != null && data.ProdNmCd.ToString().ToLower().Contains(_filterStringProduct.ToLower())) ||
                           (data.hs_code != null && data.hs_code.ToString().ToLower().Contains(_filterStringProduct.ToLower())) ||
                           (data.ProdNmCd != null && data.ProdNmCd.ToString().ToLower().Contains(_filterStringProduct.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Commodity .
        private string _filterStringCommodity;
        public string filterStringCommodity
        {
            get { return _filterStringCommodity; }
            set
            {
                _filterStringCommodity = value;
                RaisePropertyChanged("filterStringCommodity");
                Filter_CommodityCollection();
            }
        }
        private void Filter_CommodityCollection()
        {
            if (CommodityCollection != null)
            {
                CommodityCollection.Refresh();
            }
        }
        public bool Filter_Commodity(object obj)
        {
            var data = obj as ADM_M014_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringCommodity))
                {
                    return (data.CommCode != null && data.CommCode.ToString().ToLower().Contains(_filterStringCommodity.ToLower())) ||
                           (data.CommName != null && data.CommName.ToString().ToLower().Contains(_filterStringCommodity.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Material .
        private string _filterStringMaterial;
        public string filterStringMaterial
        {
            get { return _filterStringMaterial; }
            set
            {
                _filterStringMaterial = value;
                RaisePropertyChanged("filterStringMaterial");
                Filter_MaterialCollection();
            }

        }
        private void Filter_MaterialCollection()
        {
            if (MaterialCollection != null)
            {
                MaterialCollection.Refresh();
            }
        }
        public bool Filter_Material(object obj)
        {
            var data = obj as ADM_M021_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringMaterial))
                {
                    return (data.MateCode != null && data.MateCode.ToString().ToLower().Contains(_filterStringMaterial.ToLower())) ||
                           (data.MateName != null && data.MateName.ToString().ToLower().Contains(_filterStringMaterial.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Asset .
        private string _filterStringAsset;
        public string filterStringAsset
        {
            get { return _filterStringAsset; }
            set
            {
                _filterStringAsset = value;
                RaisePropertyChanged("filterStringAsset");
                Filter_AssetCollection();
            }

        }
        private void Filter_AssetCollection()
        {
            if (AssetCollection != null)
            {
                AssetCollection.Refresh();
            }
        }
        public bool Filter_Asset(object obj)
        {
            var data = obj as ADM_M017_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringAsset))
                {
                    return (data.AssetCode != null && data.AssetCode.ToString().ToLower().Contains(_filterStringAsset.ToLower())) ||
                           (data.AssetNm != null && data.AssetNm.ToString().ToLower().Contains(_filterStringAsset.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Unit .
        private string _filterStringUnit;
        public string filterStringUnit
        {
            get { return _filterStringUnit; }
            set
            {
                _filterStringUnit = value;
                RaisePropertyChanged("filterStringUnit");
                Filter_UnitCollection();
            }

        }
        private void Filter_UnitCollection()
        {
            if (UnitCollection != null)
            {
                UnitCollection.Refresh();
            }
        }
        public bool Filter_Unit(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringUnit))
                {
                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterStringUnit.ToLower())) ||
                           (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterStringUnit.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . RgGroup .
        private string _filterStringRgGroup;
        public string filterStringRgGroup
        {
            get { return _filterStringRgGroup; }
            set
            {
                _filterStringRgGroup = value;
                RaisePropertyChanged("filterStringRgGroup");
                Filter_RgGroupCollection();
            }

        }
        private void Filter_RgGroupCollection()
        {
            if (RgGroupCollection != null)
            {
                RgGroupCollection.Refresh();
            }
        }
        public bool Filter_RgGroup(object obj)
        {
            var data = obj as ADM_M023_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringRgGroup))
                {
                    return (data.RgCode != null && data.RgCode.ToString().ToLower().Contains(_filterStringRgGroup.ToLower())) ||
                           (data.RgName != null && data.RgName.ToString().ToLower().Contains(_filterStringRgGroup.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Party .
        private string _filterStringParty;
        public string filterStringParty
        {
            get { return _filterStringParty; }
            set
            {
                _filterStringParty = value;
                RaisePropertyChanged("filterStringParty");
                Filter_PartyCollection();
            }

        }
        private void Filter_PartyCollection()
        {
            if (PartyCollection != null)
            {
                PartyCollection.Refresh();
            }
        }
        public bool Filter_Party(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringParty))
                {
                    return (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterStringParty.ToLower())) ||
                           (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterStringParty.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . BackFlipCollection .
        private string _filterStringBackFlip;
        public string filterStringBackFlip
        {
            get { return _filterStringBackFlip; }
            set
            {
                _filterStringBackFlip = value;
                RaisePropertyChanged("filterStringBackFlip");
                Filter_BackFlipCollection();
            }

        }
        private void Filter_BackFlipCollection()
        {
            if (BACKFLIP_COLLECTION != null)
            {
                BACKFLIP_COLLECTION.Refresh();
            }
        }
        public bool Filter_BackFlip(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringBackFlip))
                {
                    return (data.item_code != null && data.item_code.ToString().ToLower().Contains(_filterStringBackFlip.ToLower())) ||
                           (data.item_name != null && data.item_name.ToString().ToLower().Contains(_filterStringBackFlip.ToLower())) ||
                           (data.cat_code != null && data.cat_code.ToString().ToLower().Contains(_filterStringBackFlip.ToLower())) ||
                           (data.cat_name != null && data.cat_name.ToString().ToLower().Contains(_filterStringBackFlip.ToLower())) ||
                           (data.item_subcat != null && data.item_subcat.ToString().ToLower().Contains(_filterStringBackFlip.ToLower())) ||
                           (data.item_subcat_name != null && data.item_subcat_name.ToString().ToLower().Contains(_filterStringBackFlip.ToLower())) ||
                           (data.type_code != null && data.type_code.ToString().ToLower().Contains(_filterStringBackFlip.ToLower())) ||
                           (data.item_subtype_name != null && data.item_subtype_name.ToString().ToLower().Contains(_filterStringBackFlip.ToLower())) ||
                           (data.party_name != null && data.party_name.ToString().ToLower().Contains(_filterStringBackFlip.ToLower()));
                }
                return true;
            }
            return false;
        }


        #endregion

        #endregion


    }
}
