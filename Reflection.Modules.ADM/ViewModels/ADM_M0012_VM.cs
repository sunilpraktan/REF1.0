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
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;

namespace Reflection.Modules.ADM.ViewModels
{
    public class ADM_M0012_VM : WorkspaceViewModel<ADM_M038_C>
    {
        bool blNew = true;
        WebServiceRepository<ADM_M038> repository_ADM_M038 = new WebServiceRepository<ADM_M038>();

        WebServiceRepository<ADM_M038_C> repository = new WebServiceRepository<ADM_M038_C>();//standard
        WebServiceRepository<ADM_M038_D> repository1 = new WebServiceRepository<ADM_M038_D>();//Intra
        WebServiceRepository<ADM_M038_E> repository2 = new WebServiceRepository<ADM_M038_E>();//Inter
        WebServiceRepository<MultipleContext_ADM_M038_C> repositoryM = new WebServiceRepository<MultipleContext_ADM_M038_C>();
        WebServiceRepository<MultipleContext_ADM_M038_D> repositoryD = new WebServiceRepository<MultipleContext_ADM_M038_D>();
        WebServiceRepository<MultipleContext_ADM_M038_E> repositoryE = new WebServiceRepository<MultipleContext_ADM_M038_E>();

        private ICollectionView _dataGridCollection;
        private string _filterString;
        private string _filterStringUnit;
        private string _filterStringMeasurCls;
        private string _filterStringItem;
        private string _filterStringIntra;
        private string _filterStringInter;
        void Model_ItemUpdated(object sender, EventArgs e)
        {
            this.ErrorExist = SelectedADM_M038_C.HasErrors;
        }



        #region ICollection
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }
        private ICollectionView _UnitCollection;
        public ICollectionView UnitCollection
        {
            get { return _UnitCollection; }
            set
            {
                _UnitCollection = value;

                RaisePropertyChanged("UnitCollection");
            }
        }
        private ICollectionView _DestiUnitCollection;
        public ICollectionView DestiUnitCollection
        {
            get { return _DestiUnitCollection; }
            set
            {
                _DestiUnitCollection = value;

                RaisePropertyChanged("DestiUnitCollection");
            }
        }
        private ICollectionView _MeasurClsCollection;
        public ICollectionView MeasurClsCollection
        {
            get { return _MeasurClsCollection; }
            set
            {
                _MeasurClsCollection = value;

                RaisePropertyChanged("MeasurClsCollection");
            }
        }
        private ICollectionView _ItemCollection;
        public ICollectionView ItemCollection
        {
            get { return _ItemCollection; }
            set
            {
                _ItemCollection = value;

                RaisePropertyChanged("ItemCollection");
            }
        }
        private ICollectionView _IntraCollection;
        public ICollectionView IntraCollection
        {
            get { return _IntraCollection; }
            set { _IntraCollection = value; RaisePropertyChanged("IntraCollection"); }
        }
        private ICollectionView _InterCollection;
        public ICollectionView InterCollection
        {
            get { return _InterCollection; }
            set { _InterCollection = value; RaisePropertyChanged("InterCollection"); }
        }


        #endregion

        #region RelayCommand
        public RelayCommand<IList> SelectionChangedCommand
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandIntra
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandInter
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandUnit
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandMeasurCls
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandItem
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandInterItem
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandInterDestiUnit
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandSorucUnit
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandInterSorucUnit
        {
            get;
            private set;
        }

        #endregion

        #region ADM_M038_A_P
        public ADM_M038_A_P _SelectedMeasurClsDtls { get; private set; }
        public ADM_M038_A_P SelectedMeasurClsDtls
        {
            get { return _SelectedMeasurClsDtls; }
            set
            {
                if (_SelectedMeasurClsDtls != value)
                {
                    _SelectedMeasurClsDtls = value;
                    RaisePropertyChanged("SelectedMeasurClsDtls");
                }
            }
        }

        private List<ADM_M038_A_P> _SelectedMeasurClsList;
        public List<ADM_M038_A_P> SelectedMeasurClsList
        {
            get { return _SelectedMeasurClsList; }
            set
            {
                if (_SelectedMeasurClsList != value)
                {
                    _SelectedMeasurClsList = value;
                    RaisePropertyChanged("SelectedMeasurClsList");

                }
            }
        }
        #endregion
        #region ADM_M038_B_PopUp_UOMConersion
        public ADM_M038_B_P _SelectedUnitDtls { get; private set; }
        public ADM_M038_B_P SelectedUnitDtls
        {
            get { return _SelectedUnitDtls; }
            set
            {
                if (_SelectedUnitDtls != value)
                {
                    _SelectedUnitDtls = value;
                    RaisePropertyChanged("SelectedUnitDtls");
                }
            }
        }
        private List<ADM_M038_B_P> _SelectedUnitList;
        public List<ADM_M038_B_P> SelectedUnitList
        {
            get { return _SelectedUnitList; }
            set
            {
                if (_SelectedUnitList != value)
                {
                    _SelectedUnitList = value;
                    RaisePropertyChanged("SelectedUnitList");

                }
            }
        }
        #endregion
        #region ADM_M038_C
        private List<ADM_M038_C> _SelectedList;
        public List<ADM_M038_C> SelectedList
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
        private ADM_M038_C _SelectedADM_M038_C;
        public ADM_M038_C SelectedADM_M038_C
        {
            get
            {
                this.ErrorExist = _SelectedADM_M038_C.HasErrors;
                return _SelectedADM_M038_C;
            }
            set
            {
                if (_SelectedADM_M038_C != value)
                {
                    _SelectedADM_M038_C = value;
                    this.ErrorExist = _SelectedADM_M038_C.HasErrors;
                    RaisePropertyChanged("SelectedADM_M038_C");
                    value.BeginEdit();
                }
            }
        }
        #endregion
        #region ADM_M038_D
        private List<ADM_M038_D> _SelectedIntraList;
        public List<ADM_M038_D> SelectedIntraList
        {
            get { return _SelectedIntraList; }
            set
            {
                if (_SelectedIntraList != value)
                {
                    _SelectedIntraList = value;
                    RaisePropertyChanged("SelectedIntraList");
                }
            }
        }
        private ADM_M038_D _SelectedADM_M038_D;
        public ADM_M038_D SelectedADM_M038_D
        {
            get
            {

                //this.ErrorExist = _SelectedADM_M038_D.HasErrors;
                return _SelectedADM_M038_D;
            }
            set
            {
                if (_SelectedADM_M038_D != value)
                {
                    _SelectedADM_M038_D = value;
                    this.ErrorExist = _SelectedADM_M038_D.HasErrors;
                    RaisePropertyChanged("SelectedADM_M038_D");
                    value.BeginEdit();
                }
            }
        }
        #endregion
        #region ADM_M038_E
        private List<ADM_M038_E> _SelectedInterList;
        public List<ADM_M038_E> SelectedInterList
        {
            get { return _SelectedInterList; }
            set
            {
                if (_SelectedInterList != value)
                {
                    _SelectedInterList = value;
                    RaisePropertyChanged("SelectedInterList");
                }
            }
        }
        private ADM_M038_E _SelectedADM_M038_E;
        public ADM_M038_E SelectedADM_M038_E
        {
            get
            {

                //this.ErrorExist = _SelectedADM_M038_E.HasErrors;
                return _SelectedADM_M038_E;
            }
            set
            {
                if (_SelectedADM_M038_E != value)
                {
                    _SelectedADM_M038_E = value;
                    this.ErrorExist = _SelectedADM_M038_E.HasErrors;
                    RaisePropertyChanged("SelectedADM_M038_E");
                    value.BeginEdit();
                }
            }
        }
        #endregion

        #region ADM_M022_P
        public ADM_M022_P _SelectedItemDtls { get; private set; }
        public ADM_M022_P SelectedItemDtls
        {
            get { return _SelectedItemDtls; }
            set
            {
                if (_SelectedItemDtls != value)
                {
                    _SelectedItemDtls = value;
                    RaisePropertyChanged("SelectedItemDtls");
                }
            }
        }
        private List<ADM_M022_P> _SelectedItemList;
        public List<ADM_M022_P> SelectedItemList
        {
            get { return _SelectedItemList; }
            set
            {
                if (_SelectedItemList != value)
                {
                    _SelectedItemList = value;
                    RaisePropertyChanged("SelectedItemList");

                }
            }
        }
        #endregion

        MultipleContext_ADM_M038_C _MC = new MultipleContext_ADM_M038_C();
        public MultipleContext_ADM_M038_C MC
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

        MultipleContext_ADM_M038_D _MCD = new MultipleContext_ADM_M038_D();
        public MultipleContext_ADM_M038_D MCD
        {
            get { return _MCD; }
            set
            {
                if (_MCD != value)
                {
                    _MCD = value;

                    RaisePropertyChanged("MCD");
                }
            }
        }
        MultipleContext_ADM_M038_E _MCE = new MultipleContext_ADM_M038_E();
        public MultipleContext_ADM_M038_E MCE
        {
            get { return _MCE; }
            set
            {
                if (_MCE != value)
                {
                    _MCE = value;

                    RaisePropertyChanged("MCE");
                }
            }
        }
        private int _selectedTabIndex;
        public int SelectedTabIndex
        {
            get { return _selectedTabIndex; }
            set
            {
                if (_selectedTabIndex != value)
                {
                    _selectedTabIndex = value;
                    RaisePropertyChanged("SelectedTabIndex");
                    LoadSelectedTab();
                    blNew = true;
                    SelectedADM_M038_C = new ADM_M038_C();
                    SelectedADM_M038_D = new ADM_M038_D();
                    SelectedADM_M038_E = new ADM_M038_E();
                }
            }
        }
        private int _SelectedTabControlIndex;
        public int SelectedTabControlIndex
        {
            get { return _SelectedTabControlIndex; }
            set { _SelectedTabControlIndex = value; RaisePropertyChanged("SelectedTabControlIndex"); }
        }
        public ADM_M0012_VM(string ts_code)
            : base()
        {
            ADM_M038_C.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            SelectedList = new List<ADM_M038_C>();
            SelectedIntraList = new List<ADM_M038_D>();
            SelectedInterList = new List<ADM_M038_E>();
            SelectedADM_M038_C = new ADM_M038_C();
            SelectedADM_M038_D = new ADM_M038_D();
            SelectedADM_M038_E = new ADM_M038_E();
            SelectedADM_M038_C.client = AppSessionState.client;
            SelectedADM_M038_D.client = AppSessionState.client;
            SelectedADM_M038_E.client = AppSessionState.client;
            ADM_M038 aDM_M_38 = new ADM_M038();
            SelectedUnitDtls = new ADM_M038_B_P();
            SelectedUnitList = new List<ADM_M038_B_P>();

            SelectedItemList = new List<ADM_M022_P>();
            SelectedADM_M038_C.ValidateAsync().Wait();
            MC = new MultipleContext_ADM_M038_C();
            MCD = new MultipleContext_ADM_M038_D();
            SelectionChangedCommand = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }
                GetSelectedList(items);
            });
            SelectionChangedCommandIntra = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }
                GetSelectedIntraList(items);
            });
            SelectionChangedCommandInter = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }
                GetSelectedInterList(items);
            });
            SelectionChangedCommandUnit = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }

                GetSelectedUnitDetails(items);
            });
            SelectionChangedCommandInterDestiUnit = new RelayCommand<IList>(
           items =>
           {
               if (items == null)
               {
                   return;
               }

               GetSelectedInterDestiUnit(items);
           });
            SelectionChangedCommandItem = new RelayCommand<IList>(
           items =>
           {
               if (items == null)
               {
                   return;
               }

               GetSelectedItemDetails(items);
           });
            SelectionChangedCommandInterItem = new RelayCommand<IList>(
           items =>
           {
               if (items == null)
               {
                   return;
               }

               GetSelectedInterItemDetails(items);
           });
            SelectionChangedCommandSorucUnit = new RelayCommand<IList>(
           items =>
           {
               if (items == null)
               {
                   return;
               }

               GetSelectedSorucUnit(items);
           });
            SelectionChangedCommandInterSorucUnit = new RelayCommand<IList>(
           items =>
           {
               if (items == null)
               {
                   return;
               }

               GetSelectedInterSorucUnit(items);
           });
            LoadInitialData();
        }
        private void GetSelectedList(IList DataList)
        {
            IList list = DataList as IList;
            List<ADM_M038_C> tSelectedItemsList = list.Cast<ADM_M038_C>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                SelectedADM_M038_C = (ADM_M038_C)tSelectedItemsList[0];
                blNew = false;
            }
            SelectedTabControlIndex = 0;
        }
        private void GetSelectedIntraList(IList IntraList)
        {
            IList list = IntraList as IList;
            List<ADM_M038_D> SelectedIntraList = list.Cast<ADM_M038_D>().ToList();
            if (SelectedIntraList.Count > 0)
            {
                SelectedADM_M038_D = (ADM_M038_D)SelectedIntraList[0];
                blNew = false;
            }
        }
        private void GetSelectedInterList(IList InterList)
        {
            IList list = InterList as IList;
            List<ADM_M038_E> SelectedInterList = list.Cast<ADM_M038_E>().ToList();
            if (SelectedInterList.Count > 0)
            {
                SelectedADM_M038_E = (ADM_M038_E)SelectedInterList[0];
                blNew = false;
            }
        }
        private void GetSelectedUnitDetails(IList UnitList)
        {
            IList list = UnitList as IList;
            List<ADM_M038_B_P> GetSelectedUnitDetailsTemp = list.Cast<ADM_M038_B_P>().ToList();
            if (GetSelectedUnitDetailsTemp.Count > 0)
            {
                SelectedADM_M038_C.unit_code = GetSelectedUnitDetailsTemp[0].unit_code;

                var myItem = (from o in SelectedMeasurClsList
                              where o.id == GetSelectedUnitDetailsTemp[0].class_id
                              select o).ToList();
                //get base unit code,class name,and unit code from Measurement class
                SelectedADM_M038_C.base_unit_code = myItem.ToList()[0].base_unit;
                SelectedADM_M038_C.base_unit = myItem.ToList()[0].base_unit;
                SelectedADM_M038_C.class_name = myItem.ToList()[0].class_name;
            }
        }
        private void GetSelectedInterDestiUnit(IList DesUnitList)
        {
            IList list = DesUnitList as IList;
            List<ADM_M038_B_P> GetSelectedUnitDetailsTemp = list.Cast<ADM_M038_B_P>().ToList();
            if (GetSelectedUnitDetailsTemp.Count > 0)
            {
                SelectedADM_M038_E.dest_base_unit_code = GetSelectedUnitDetailsTemp[0].unit_code;
            }
        }
        private void GetSelectedSorucUnit(IList SorucUnitList)
        {
            IList list = SorucUnitList as IList;
            List<ADM_M038_B_P> GetSelectedUnitDetailsTemp = list.Cast<ADM_M038_B_P>().ToList();
            if (GetSelectedUnitDetailsTemp.Count > 0)
            {
                SelectedADM_M038_D.source_unit_code = GetSelectedUnitDetailsTemp[0].unit_code;

                var myItem = (from o in SelectedMeasurClsList
                              where o.id == GetSelectedUnitDetailsTemp[0].class_id
                              select o).ToList();
                SelectedADM_M038_D.dest_base_unit_code = myItem.ToList()[0].base_unit;
            }
        }
        private void GetSelectedInterSorucUnit(IList SorucUnitList)
        {
            IList list = SorucUnitList as IList;
            List<ADM_M038_B_P> GetSelectedUnitDetailsTemp = list.Cast<ADM_M038_B_P>().ToList();
            if (GetSelectedUnitDetailsTemp.Count > 0)
            {
                SelectedADM_M038_E.source_base_unit_code = GetSelectedUnitDetailsTemp[0].unit_code;
            }
        }
        private void GetSelectedItemDetails(IList ItemList)
        {
            IList list = ItemList as IList;
            List<ADM_M022_P> GetSelectedItemDetailsTemp = list.Cast<ADM_M022_P>().ToList();
            if (GetSelectedItemDetailsTemp.Count > 0)
            {
                SelectedADM_M038_D.ItemCode = GetSelectedItemDetailsTemp[0].ItemCode;
            }
        }
        private void GetSelectedInterItemDetails(IList ItemList)
        {
            IList list = ItemList as IList;
            List<ADM_M022_P> GetSelectedItemDetailsTemp = list.Cast<ADM_M022_P>().ToList();
            if (GetSelectedItemDetailsTemp.Count > 0)
            {
                SelectedADM_M038_E.ItemCode = GetSelectedItemDetailsTemp[0].ItemCode;
            }
        }
        private void LoadSelectedTab()
        {
            try
            {
                if (SelectedTabIndex == 0)//Standard
                {

                    MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ADM_M038_C>(MC, "ADM_M038_C_Data", "UOM_Conversion", "Administration", "ADM_M038_CLoadAll", 0, "");//
                    SelectedList = MC.UOM_Convrsn_Stand;
                    SelectedMeasurClsList = MC.Measur_Cls;
                    DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
                    DataGridCollection.Filter = new Predicate<object>(Filter);

                    UnitCollection = CollectionViewSource.GetDefaultView(MC.UOM_Master);
                    UnitCollection.Filter = new Predicate<object>(UnitFilter);

                }
                else if (SelectedTabIndex == 1)//Intra
                {
                    MCD = repositoryD.GetDataWithReturnDomainObject<MultipleContext_ADM_M038_D>(MCD, "ADM_M038_D_Data", "UOM_Conversion", "Administration", "ADM_M038_DLoadAll", 0, "");
                    SelectedIntraList = MCD.UOM_Convrsn_Intra;

                    IntraCollection = CollectionViewSource.GetDefaultView(SelectedIntraList);
                    IntraCollection.Filter = new Predicate<object>(IntraFilter);

                    ItemCollection = CollectionViewSource.GetDefaultView(MCD.Items);
                    ItemCollection.Filter = new Predicate<object>(ItemFilter);

                    UnitCollection = CollectionViewSource.GetDefaultView(MCD.UOM_Master);
                    UnitCollection.Filter = new Predicate<object>(UnitFilter);
                    blNew = true;
                }
                else if (SelectedTabIndex == 2)//Inter
                {
                    MCE = repositoryE.GetDataWithReturnDomainObject<MultipleContext_ADM_M038_E>(MCE, "ADM_M038_E_Data", "UOM_Conversion", "Administration", "ADM_M038_ELoadAll", 0, "");
                    SelectedInterList = MCE.UOM_Convrsn_Inter;

                    InterCollection = CollectionViewSource.GetDefaultView(SelectedInterList);
                    InterCollection.Filter = new Predicate<object>(InterFilter);

                    ItemCollection = CollectionViewSource.GetDefaultView(MCE.Items);
                    ItemCollection.Filter = new Predicate<object>(ItemFilter);

                    List<ADM_M038_B_P> UOM_Master = (List<ADM_M038_B_P>)MCE.UOM_Master.Cast<ADM_M038_B_P>();
                    IEnumerable<ADM_M038_B_P> barEnumerable =
                            from data in UOM_Master
                            where data.is_base_unit == true
                            select data;
                    UnitCollection = CollectionViewSource.GetDefaultView(barEnumerable);
                    UnitCollection.Filter = new Predicate<object>(UnitFilter);
                    blNew = true;
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
                MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ADM_M038_C>(MC, "ADM_M038_C_Data", "UOM_Conversion", "Administration", "ADM_M038_CLoadAll", 0, "");//
                SelectedList = MC.UOM_Convrsn_Stand;
                SelectedMeasurClsList = MC.Measur_Cls;
                DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                UnitCollection = CollectionViewSource.GetDefaultView(MC.UOM_Master);

                UnitCollection.Filter = new Predicate<object>(UnitFilter);
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
        #region · Command Actions ·
        //protected override void OnExportAction(InquiryActionResult<ADM_M022> result)
        //{
        //    try
        //    {
        //        ExportToExcel<ADM_M022, List<ADM_M022>> export = new ExportToExcel<ADM_M022, List<ADM_M022>>();
        //        ICollectionView view = CollectionViewSource.GetDefaultView(DataGridCollection);
        //        export.dataToPrint = (List<ADM_M022>)view.SourceCollection;
        //        export.GenerateReport();
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
        protected override void OnSaveAction(InquiryActionResult<ADM_M038_C> result)
        {
            try
            {

                ADM_M038 aDM_M038 = new ADM_M038();
                ObjectSerializationService objSer = new ObjectSerializationService();
                aDM_M038.Index = SelectedTabIndex;
                if (blNew == true)
                {
                    SelectedADM_M038_C.add_by = AppSessionState.UserID;
                    SelectedADM_M038_D.add_by = AppSessionState.UserID;
                    SelectedADM_M038_E.add_by = AppSessionState.UserID;

                    SelectedADM_M038_C.client = AppSessionState.client;
                    SelectedADM_M038_D.client = AppSessionState.client;
                    SelectedADM_M038_E.client = AppSessionState.client;

                    if (aDM_M038.Index == 0)
                    {
                        aDM_M038.XmlDataDocument = objSer.ObjectToXML(SelectedADM_M038_C);
                        aDM_M038 = repository_ADM_M038.SaveWithReturnDomainObject<ADM_M038>(aDM_M038, "UOM_Conversion", "Administration");
                        SelectedADM_M038_C = (ADM_M038_C)new ObjectSerializationService().XMLToObject(aDM_M038.XmlDataDocument, SelectedADM_M038_C);

                        SelectedList.Add(SelectedADM_M038_C);
                        this.SelectedADM_M038_C.EndEdit();
                        _dataGridCollection.Refresh();
                    }
                    else if (aDM_M038.Index == 1)
                    {
                        aDM_M038.XmlDataDocument = objSer.ObjectToXML(SelectedADM_M038_D);
                        aDM_M038 = repository_ADM_M038.SaveWithReturnDomainObject<ADM_M038>(aDM_M038, "UOM_Conversion", "Administration");
                        SelectedADM_M038_D = (ADM_M038_D)new ObjectSerializationService().XMLToObject(aDM_M038.XmlDataDocument, SelectedADM_M038_D);


                        SelectedIntraList.Add(SelectedADM_M038_D);
                        this.SelectedADM_M038_D.EndEdit();
                        _IntraCollection.Refresh();
                    }
                    else if (aDM_M038.Index == 2)
                    {
                        aDM_M038.XmlDataDocument = objSer.ObjectToXML(SelectedADM_M038_E);
                        aDM_M038 = repository_ADM_M038.SaveWithReturnDomainObject<ADM_M038>(aDM_M038, "UOM_Conversion", "Administration");
                        SelectedADM_M038_E = (ADM_M038_E)new ObjectSerializationService().XMLToObject(aDM_M038.XmlDataDocument, SelectedADM_M038_E);

                        SelectedInterList.Add(SelectedADM_M038_E);
                        this.SelectedADM_M038_E.EndEdit();
                        _InterCollection.Refresh();
                    }
                    blNew = false;

                }
                else if (blNew == false)
                {
                    if (aDM_M038.Index == 0)
                    {
                        aDM_M038.XmlDataDocument = objSer.ObjectToXML(SelectedADM_M038_C);
                        aDM_M038 = repository_ADM_M038.UpdateWithReturnDomainObject<ADM_M038>(aDM_M038, "UOM_Conversion", "Administration");
                        SelectedADM_M038_C = (ADM_M038_C)new ObjectSerializationService().XMLToObject(aDM_M038.XmlDataDocument, SelectedADM_M038_C);
                        this.SelectedADM_M038_C.EndEdit();
                        _dataGridCollection.Refresh();
                    }
                    else if (aDM_M038.Index == 1)
                    {
                        aDM_M038.XmlDataDocument = objSer.ObjectToXML(SelectedADM_M038_D);
                        aDM_M038 = repository_ADM_M038.UpdateWithReturnDomainObject<ADM_M038>(aDM_M038, "UOM_Conversion", "Administration");
                        SelectedADM_M038_D = (ADM_M038_D)new ObjectSerializationService().XMLToObject(aDM_M038.XmlDataDocument, SelectedADM_M038_D);
                        this.SelectedADM_M038_D.EndEdit();
                        _IntraCollection.Refresh();
                    }
                    else if (aDM_M038.Index == 2)
                    {
                        aDM_M038.XmlDataDocument = objSer.ObjectToXML(SelectedADM_M038_E);
                        aDM_M038 = repository_ADM_M038.UpdateWithReturnDomainObject<ADM_M038>(aDM_M038, "UOM_Conversion", "Administration");
                        SelectedADM_M038_E = (ADM_M038_E)new ObjectSerializationService().XMLToObject(aDM_M038.XmlDataDocument, SelectedADM_M038_E);
                        this.SelectedADM_M038_E.EndEdit();
                        _InterCollection.Refresh();
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
        protected override void OnCreateAction(InquiryActionResult<ADM_M038_C> result)
        {
            blNew = true;
            SelectedADM_M038_C = new ADM_M038_C();
            SelectedADM_M038_D = new ADM_M038_D();
            SelectedADM_M038_E = new ADM_M038_E();
            ADM_M038 aDM_M_38 = new ADM_M038();
            SelectedADM_M038_C.ValidateAsync().Wait();
            SelectedUnitDtls = new ADM_M038_B_P();
            _dataGridCollection.Refresh();
            SelectedADM_M038_C.client = AppSessionState.client;
            SelectedADM_M038_D.client = AppSessionState.client;
            SelectedADM_M038_E.client = AppSessionState.client;

        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M038_C> result)
        {

            if (SelectedADM_M038_C.base_unit != null || SelectedADM_M038_D.conv_type != null || SelectedADM_M038_E.conv_type != null)
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
                    ADM_M038 aDM_M038 = new ADM_M038();
                    ADM_M038_Delete aDM_M038_Delete = new ADM_M038_Delete();
                    ObjectSerializationService objSer = new ObjectSerializationService();
                    aDM_M038_Delete.Index = SelectedTabIndex;
                    if (aDM_M038_Delete.Index == 0)
                    {
                        aDM_M038_Delete.id = SelectedADM_M038_C.id;
                        aDM_M038.XmlDataDocument = objSer.ObjectToXML(aDM_M038_Delete);
                        string response = repository.Delete(aDM_M038.XmlDataDocument, "UOM_Conversion", "Administration");
                        SelectedList.Remove(SelectedADM_M038_C);

                        this.SelectedADM_M038_C.EndEdit();
                        _dataGridCollection.Refresh();
                        SelectedADM_M038_C = new ADM_M038_C();

                    }
                    else if (aDM_M038_Delete.Index == 1)
                    {
                        aDM_M038_Delete.id = SelectedADM_M038_D.id;
                        aDM_M038.XmlDataDocument = objSer.ObjectToXML(aDM_M038_Delete);
                        string response = repository.Delete(aDM_M038.XmlDataDocument, "UOM_Conversion", "Administration");
                        SelectedIntraList.Remove(SelectedADM_M038_D);
                        this.SelectedADM_M038_D.EndEdit();
                        SelectedADM_M038_D = new ADM_M038_D();
                        _IntraCollection.Refresh();

                    }
                    else if (aDM_M038_Delete.Index == 2)
                    {
                        aDM_M038_Delete.id = SelectedADM_M038_E.id;
                        aDM_M038.XmlDataDocument = objSer.ObjectToXML(aDM_M038_Delete);
                        string response = repository.Delete(aDM_M038.XmlDataDocument, "UOM_Conversion", "Administration");
                        SelectedInterList.Remove(SelectedADM_M038_E);
                        this.SelectedADM_M038_E.EndEdit();
                        SelectedADM_M038_E = new ADM_M038_E();
                        _InterCollection.Refresh();
                    }
                }
                blNew = true;
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M038_C> result)
        {
            SelectedADM_M038_C.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M038_C> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M038_C> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M038_C = SelectedADM_M038_C;
        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M038_C> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M038_C = SelectedADM_M038_C;
        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M038_C> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M038_C = SelectedADM_M038_C;
        }
        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<ADM_M038_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M038_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M038_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M038_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M038_C> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Filters For Unit
        private void FilterCollectionUnit()
        {
            if (_UnitCollection != null)
            {
                _UnitCollection.Refresh();
            }
        }
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
                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterStringUnit.ToLower()) ||
                        data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterStringUnit.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For MeasurCls
        private void FilterCollectionMeasurCls()
        {
            if (_MeasurClsCollection != null)
            {
                _MeasurClsCollection.Refresh();
            }
        }
        public string FilterStringMeasurCls
        {
            get { return _filterStringMeasurCls; }
            set
            {
                _filterStringMeasurCls = value;
                RaisePropertyChanged("FilterStringMeasurCls");
                FilterCollectionMeasurCls();
            }
        }
        public bool MeasurClsFilter(object obj)
        {
            var data = obj as ADM_M038_A_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringMeasurCls))
                {
                    return (data.class_name != null && data.class_name.ToString().ToLower().Contains(_filterStringMeasurCls.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Item
        private void FilterCollectionItem()
        {
            if (_ItemCollection != null)
            {
                _ItemCollection.Refresh();
            }
        }
        public string FilterStringItem
        {
            get { return _filterStringItem; }
            set
            {
                _filterStringItem = value;
                RaisePropertyChanged("FilterStringItem");
                FilterCollectionItem();
            }
        }
        public bool ItemFilter(object obj)
        {
            var data = obj as ADM_M022_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringItem))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterStringItem.ToLower()));
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
            var data = obj as ADM_M038_C;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.unit_code != null && data.unit_code.ToLower().Contains(_filterString.ToLower())) ||
                    (data.base_unit != null && data.base_unit.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    (data.c_factor != null && data.c_factor.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    (data.conv_type != null && data.conv_type.ToString().ToLower().Contains(_filterString.ToLower()));

                }
                return true;
            }
            return false;
        }
        #region Filters Fro Intra
        public string FilterStringIntra
        {
            get { return _filterStringIntra; }
            set
            {
                _filterStringIntra = value;
                RaisePropertyChanged("FilterStringIntra");
                FilterCollectionIntra();
            }
        }
        private void FilterCollectionIntra()
        {
            if (_IntraCollection != null)
            {
                _IntraCollection.Refresh();
            }
        }
        public bool IntraFilter(object obj)
        {
            var data = obj as ADM_M038_D;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringIntra))
                {
                    return (data.ItemCode != null && data.ItemCode.ToLower().Contains(_filterStringIntra.ToLower())) ||
                    (data.source_unit_code != null && data.source_unit_code.ToString().ToLower().Contains(_filterStringIntra.ToLower())) ||
                    (data.dest_base_unit_code != null && data.dest_base_unit_code.ToString().ToLower().Contains(_filterStringIntra.ToLower())) ||
                    (data.c_factor != null && data.c_factor.ToString().ToLower().Contains(_filterStringIntra.ToLower())) ||
                    (data.conv_type != null && data.conv_type.ToString().ToLower().Contains(_filterStringIntra.ToLower()));

                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters Fro Inter
        public string FilterStringInter
        {
            get { return _filterStringInter; }
            set
            {
                _filterStringInter = value;
                RaisePropertyChanged("FilterStringInter");
                FilterCollectionInter();
            }
        }
        private void FilterCollectionInter()
        {
            if (_InterCollection != null)
            {
                _InterCollection.Refresh();
            }
        }
        public bool InterFilter(object obj)
        {
            var data = obj as ADM_M038_E;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringInter))
                {
                    return (data.ItemCode != null && data.ItemCode.ToLower().Contains(_filterStringInter.ToLower())) ||
                    (data.source_base_unit_code != null && data.source_base_unit_code.ToString().ToLower().Contains(_filterStringInter.ToLower())) ||
                    (data.dest_base_unit_code != null && data.dest_base_unit_code.ToString().ToLower().Contains(_filterStringInter.ToLower())) ||
                    (data.c_factor != null && data.c_factor.ToString().ToLower().Contains(_filterStringInter.ToLower())) ||
                    (data.conv_type != null && data.conv_type.ToString().ToLower().Contains(_filterStringInter.ToLower()));

                }
                return true;
            }
            return false;
        }


        #endregion
        #endregion
    }
}
