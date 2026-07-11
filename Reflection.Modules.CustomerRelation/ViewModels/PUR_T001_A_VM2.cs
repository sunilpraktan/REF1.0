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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using Reflection.ReportingServices;
using System.Windows.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using System.Windows;
using Reflection.Presentation.Services.Convertors;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    class PUR_T001_A_VM2 : WorkspaceViewModel<PUR_T001_A>
    {

        #region Variable Declaration
        bool NewRecord = true;
        WebServiceRepository<PUR_T001_A> repository = new WebServiceRepository<PUR_T001_A>();
        WebServiceRepository<MultipleContext_PUR_T001_A> repositoryM = new WebServiceRepository<MultipleContext_PUR_T001_A>();
        ObjectSerializationService objSer = new ObjectSerializationService();


        private ICollectionView _dataGridCollection;

        private int _dgSelectedIndex;
        private bool _parameter;
        public bool parameter
        {
            get { return _parameter; }
            set
            {
                if (_parameter != value)
                {
                    _parameter = value;
                    RaisePropertyChanged("parameter");
                }
            }
        }


        private List<PUR_T001_A> _SelectedList;
        public List<PUR_T001_A> SelectedList
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
        private PUR_T001_A _MasterEntity;
        public PUR_T001_A MasterEntity
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
                    RaisePropertyChanged("MasterEntity");
                    value.BeginEdit();
                }
            }
        }
        private List<ADM_M002> _CompanyList = new List<ADM_M002>();
        public List<ADM_M002> CompanyList
        {
            get { return _CompanyList; }
            set
            {
                if (_CompanyList != value)
                {
                    _CompanyList = value;
                }
            }
        }

        string CompanyName;

        private PUR_T001_AFlip _FilpEntity;
        public PUR_T001_AFlip FilpEntity
        {
            get
            {

                return _FilpEntity;
            }
            set
            {
                if (_FilpEntity != value)
                {
                    _FilpEntity = value;
                    RaisePropertyChanged("FilpEntity");

                }
            }
        }


        private List<PUR_T001_AFlip> _FlipGridData;
        public List<PUR_T001_AFlip> FlipGridData
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
        private ICollectionView _doc_typeCollection;
        public ICollectionView doc_typeCollection
        {
            get { return _doc_typeCollection; }
            set
            {
                _doc_typeCollection = value;
                RaisePropertyChanged("doc_typeCollection");
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
        #endregion
        #region Auto Suggest Initalization Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(PUR_T001_A_VM2));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }
        private DataGridCellInfo _cellInfo;
        public DataGridCellInfo CellInfo
        {
            get { return _cellInfo; }
            set
            {
                _cellInfo = value;
                SetAutoTextSource(_cellInfo);
                RaisePropertyChanged("CellInfo");
            }
        }
        private void SetAutoTextSource(DataGridCellInfo dgCellInfo)
        {
            if (dgCellInfo != null)
            {
                var column = dgCellInfo.Column as DataGridColumn;
                if (column != null)
                {
                    string headerName = column.Header.ToString();
                    string SourceName = column.SortMemberPath.ToString();
                    //if (SourceName == "ItemCode")
                    //{ ASDefault = ASItem; }
                    //else if (SourceName == "unit_code")
                    //{ ASDefault = ASUnit; }
                    //else if (SourceName == "sono")
                    //{ ASDefault = ASOrder; }
                    //else if (SourceName == "item_cat")
                    //{ ASDefault = ASItemCat; }
                    //else 
                    if (SourceName == "bom_no")
                    { ASDefault = ASBOMRef; }
                }
            }
        }
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
        private AutoSuggestTextViewModel<dynamic> _ASt_status { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASt_status
        {
            get { return _ASt_status; }
            set
            {
                if (_ASt_status != value)
                {
                    _ASt_status = value; RaisePropertyChanged("ASt_status");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASRequester { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASRequester
        {
            get { return _ASRequester; }
            set
            {
                if (_ASRequester != value)
                {
                    _ASRequester = value; RaisePropertyChanged("ASRequester");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASPriority { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPriority
        {
            get { return _ASPriority; }
            set
            {
                if (_ASPriority != value)
                {
                    _ASPriority = value; RaisePropertyChanged("ASPriority");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASItem { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASItem
        {
            get { return _ASItem; }
            set
            {
                if (_ASItem != value)
                {
                    _ASItem = value; RaisePropertyChanged("ASItem");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASUnit
        {
            get { return _ASUnit; }
            set
            {
                if (_ASUnit != value)
                {
                    _ASUnit = value; RaisePropertyChanged("ASUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASOrder { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASOrder
        {
            get { return _ASOrder; }
            set
            {
                if (_ASOrder != value)
                {
                    _ASOrder = value; RaisePropertyChanged("ASOrder");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASItemCat { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASItemCat
        {
            get { return _ASItemCat; }
            set
            {
                if (_ASItemCat != value)
                {
                    _ASItemCat = value; RaisePropertyChanged("ASItemCat");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASPurOrg { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPurOrg
        {
            get { return _ASPurOrg; }
            set
            {
                if (_ASPurOrg != value)
                {
                    _ASPurOrg = value; RaisePropertyChanged("ASPurOrg");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASPurGrp { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPurGrp
        {
            get { return _ASPurGrp; }
            set
            {
                if (_ASPurGrp != value)
                {
                    _ASPurGrp = value; RaisePropertyChanged("ASPurGrp");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASBOMRef { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBOMRef
        {
            get { return _ASBOMRef; }
            set
            {
                if (_ASBOMRef != value)
                {
                    _ASBOMRef = value; RaisePropertyChanged("ASBOMRef");
                }
            }
        }
        #endregion


        #region Validation Region
        void Model_ItemUpdated(object sender, EventArgs e)
        {
            this.ErrorExist = MasterEntity.HasErrors;

        }

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        #endregion


        #region ICollection
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }
        private ICollectionView _PriorityCollection;
        public ICollectionView PriorityCollection
        {
            get { return _PriorityCollection; }
            set
            {
                _PriorityCollection = value;

                RaisePropertyChanged("PriorityCollection");
            }
        }


        private ICollectionView _EmpCollection;
        public ICollectionView EmpCollection
        {
            get { return _EmpCollection; }
            set
            {
                _EmpCollection = value;

                RaisePropertyChanged("EmpCollection");
            }
        }

        private ICollectionView _ItemsCollection;
        public ICollectionView ItemsCollection
        {
            get { return _ItemsCollection; }
            set
            {
                _ItemsCollection = value;

                RaisePropertyChanged("ItemsCollection");
            }
        }

        private ICollectionView _uomCollection;
        public ICollectionView uomCollection
        {
            get { return _uomCollection; }
            set
            {
                _uomCollection = value;

                RaisePropertyChanged("uomCollection");
            }
        }

        private ICollectionView _itemcategoryCollection;
        public ICollectionView itemcategoryCollection
        {
            get { return _itemcategoryCollection; }
            set
            {
                _itemcategoryCollection = value;
                RaisePropertyChanged("itemcategoryCollection");
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

        private ICollectionView _ParameterCollection;
        public ICollectionView ParameterCollection
        {
            get { return _ParameterCollection; }
            set
            {
                _ParameterCollection = value;
                RaisePropertyChanged("ParameterCollection")
                ;
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

        private ICollectionView _MakeCollection;
        public ICollectionView MakeCollection
        {
            get { return _MakeCollection; }
            set { _MakeCollection = value; RaisePropertyChanged("MakeCollection"); }
        }

        #endregion

        #region StringList Variables
        List<string> _strListPriority;
        public List<string> StringListPriority
        {
            get { return _strListPriority; }
            set
            {
                if (_strListPriority != value)
                {
                    _strListPriority = value;
                }
            }
        }


        List<string> _strListEmployee;
        public List<string> StringListEmployee
        {
            get { return _strListEmployee; }
            set
            {
                if (_strListEmployee != value)
                {
                    _strListEmployee = value;
                }
            }
        }


        List<string> _strListDept;
        public List<string> StringListDept
        {
            get { return _strListDept; }
            set
            {
                if (_strListDept != value)
                {
                    _strListDept = value;
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

        List<string> _stringListUOM;
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


        List<string> _stringListPlant;
        public List<string> stringListPlant
        {
            get { return _stringListPlant; }
            set
            {
                if (_stringListPlant != value)
                {
                    _stringListPlant = value;
                }
            }
        }

        List<string> _stringListStoreLoc;
        public List<string> stringListStoreLoc
        {
            get { return _stringListStoreLoc; }
            set
            {
                if (_stringListStoreLoc != value)
                {
                    _stringListStoreLoc = value;
                }
            }
        }

        List<string> _stringListBatch;
        public List<string> stringListBatch
        {
            get { return _stringListBatch; }
            set
            {
                if (_stringListBatch != value)
                {
                    _stringListBatch = value;
                }
            }
        }
        List<string> _stringListItemCategory;
        public List<string> StringListItemCategory
        {
            get { return _stringListItemCategory; }
            set
            {
                if (_stringListItemCategory != value)
                {
                    _stringListItemCategory = value;
                }
            }
        }
        List<string> _strListIndent;
        public List<string> StringListIndent
        {
            get { return _strListIndent; }
            set
            {
                if (_strListIndent != value)
                {
                    _strListIndent = value;
                }
            }
        }

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

        #endregion

        #region RelayCommand

        public RelayCommand<object> SelectionChangedCommandPriority
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandEmp
        {
            get;
            private set;
        }

        public RelayCommand<object> SelectionChangedCommandItems
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommanduom
        {
            get;
            private set;
        }



        public RelayCommand<object> DataGridRowDeleteCommand
        {
            get;
            private set;
        }

        public RelayCommand<object> ParameterPopupCommand
        {
            get;
            private set;
        }
        public RelayCommand<object> CollectionChangedMethod
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectedCommand_itemcategory { get; private set; }

        public RelayCommand<IList> CollectionChangedCommand
        {
            get;
            private set;
        }

        public RelayCommand<IList> SelectionChangedParaValCommand
        {
            get;
            private set;
        }
        public RelayCommand<object> CommandAddItemCategory { get; private set; }
        public RelayCommand<IList> SelectionChangeCommandItemDetails { get; private set; }
        public RelayCommand<IList> CommandLoadDataFromBackFlip { get; private set; }
        public RelayCommand<IList> cmdMake { get; private set; }
        public RelayCommand<object> CmdAddBOM { get; private set; }
        public RelayCommand<object> CmdInsert_t_status { get; private set; }
        #endregion



        #region PUR_T001_B

        private ObservableCollection<PUR_T001_B> _Pur_Req_Details = new ObservableCollection<PUR_T001_B>();
        public ObservableCollection<PUR_T001_B> Pur_Req_Details
        {
            get { return _Pur_Req_Details; }
            set
            {
                if (_Pur_Req_Details != value)
                {
                    _Pur_Req_Details = value;

                    RaisePropertyChanged("Pur_Req_Details");
                }
            }
        }
        public PUR_T001_B _SelectedPUR_T001_B { get; private set; }
        public PUR_T001_B SelectedPUR_T001_B
        {
            get { return _SelectedPUR_T001_B; }
            set
            {
                if (_SelectedPUR_T001_B != value)
                {
                    _SelectedPUR_T001_B = value;
                    RaisePropertyChanged("SelectedPUR_T001_B");
                    // value.BeginEdit();
                }
            }
        }
        private List<PUR_T001_B> _SelectedPUR_T001_B_List;
        public List<PUR_T001_B> SelectedPUR_T001_B_List
        {
            get
            {
                return _SelectedPUR_T001_B_List;
            }
            set
            {
                _SelectedPUR_T001_B_List = value;
                RaisePropertyChanged("SelectedPUR_T001_B_List");
            }
        }

        #endregion


        List<ADM_M022_P> _ItemList = new List<ADM_M022_P>();
        public List<ADM_M022_P> ItemList
        {
            get { return _ItemList; }
            set
            {
                if (_ItemList != value)
                {
                    _ItemList = value;

                    RaisePropertyChanged("ItemList");
                }
            }
        }
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
        private bool _isTabChangeAllowed = true;
        public bool isTabChangeAllowed
        {
            get { return _isTabChangeAllowed; }
            set
            {
                if (_isTabChangeAllowed != value)
                {
                    _isTabChangeAllowed = value;
                    RaisePropertyChanged("isTabChangeAllowed");
                }
            }
        }
        MultipleContext_PUR_T001_A _MC = new MultipleContext_PUR_T001_A();
        public MultipleContext_PUR_T001_A MC
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
        MultipleContext_PUR_T001_A MCTemp = new MultipleContext_PUR_T001_A();
        public PUR_T001_A_VM2()
            : base()
        {
            CursorControl.SetBusyState();
            parameter = false;
            MasterEntity = new PUR_T001_A();
            Pur_Req_Details = new ObservableCollection<PUR_T001_B>();//detail table observable collection
            FlipGridData = new List<PUR_T001_AFlip>();
            MC = new MultipleContext_PUR_T001_A();
            MCTemp = new MultipleContext_PUR_T001_A();
            MasterEntity.ValidateAsync().Wait();
            NotificationDataCollection = new List<NotificationData>();

            PUR_T001_A.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            PUR_T001_B.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);

            SelectionChangedCommandPriority = new RelayCommand<object>(
            items =>
            {
                if (items == null) { return; }
                InsertPriority(items);
            });

            SelectionChangedCommandEmp = new RelayCommand<object>(
            items =>
            {
                if (items == null) { return; }

                InsertEmployee(items);
            });

            SelectionChangedCommandItems = new RelayCommand<object>(
            cmdPara =>
            {
                if (cmdPara == null) { return; }
                InsertDataGridRow_Item(cmdPara, true, true, true);
            });

            SelectionChangedCommanduom = new RelayCommand<object>
                 (cmdPara =>
                 {
                     if (cmdPara == null) { return; }
                     InsertDataGridRow_Uom(cmdPara, false, true, true);
                 });


            CommandAddItemCategory = new RelayCommand<object>
            (cmdPara =>
            {
                if (cmdPara == null) { return; }
                InsertDataGridRow_ItemCategory(cmdPara, false, true, true);
            });

            CollectionChangedCommand = new RelayCommand<IList>(
             items => { if (items == null) { return; } CollectionChanged(items); });

            SelectionChangedParaValCommand = new RelayCommand<IList>(
            items => { if (items == null) { return; } GetSelectedParaValue(items); });

            DataGridRowDeleteCommand = new RelayCommand<object>(
            items => { if (items == null) { return; } DeleteDataGridRow_Item(items); });

            CommandLoadDataFromBackFlip = new RelayCommand<IList>
            (cmdPara => { if (cmdPara == null) { return; } LoadBackFilpDetailstemp(cmdPara); });

            SelectionChangeCommandItemDetails = new RelayCommand<IList>(items => { if (items == null) { return; } ItemDetailsSelectionChangedMethod(items); });

            cmdMake = new RelayCommand<IList>
           (cmdPara => { if (cmdPara == null) { return; } InsertMake(cmdPara, false, true, true); });

            CmdAddBOM = new RelayCommand<object>
                (cmdPara =>
                {
                    if (cmdPara == null) { return; }
                    InsertBOM(cmdPara, false, true, true);
                });
            CmdInsert_t_status = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Insert_t_status(cmdPara); });
            //DefaultValues();
            LoadInitialData();
            if (MC.doc_typeList != null && MC.doc_typeList.Count > 0)
            {
                if (AppSessionState.TransValue != null && AppSessionState.TransactionCode == MC.doc_typeList[0].TranCode)
                {
                    LoadBackFilpDetailstemp(AppSessionState.TransValue);
                    isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
                    AppSessionState.TransValue = null;
                    AppSessionState.TransParameter = null;
                    AppSessionState.ViewOtherRecordAllowed = true;
                }
            }


        }



        //private void LoadBackFilpDetailstemp(IList ParameterObject)
        //{
        //    string Request = "";
        //    IList list = ParameterObject as IList;
        //    List<PUR_T001_AFlip> GetSelectedChangedTemp = list.Cast<PUR_T001_AFlip>().ToList();

        //    try
        //    {
        //        if (GetSelectedChangedTemp.Count > 0)
        //        {
        //            FilpEntity = (PUR_T001_AFlip)GetSelectedChangedTemp[0];
        //            Request = "LoadDocumentFromBackFilp" + "!@" + FilpEntity.req_no;
        //            MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_PUR_T001_A>(MCTemp, Request, "PurchaseRequisition", "Procurement", "LoadDocumentFromBackFilp", 0, "");
        //            MasterEntity = MCTemp.Pur_Req[0];
        //            Pur_Req_Details = MCTemp.Pur_Req_Details;

        //            AttachmentCollection = MC.Attachment;
        //            SelectedTabControlIndex = 0;
        //            NewRecord = false;
        //            parameter = false;
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
        private void LoadBackFilpDetailstemp(Object ParameterObject)
        {
            try
            {
                string Request = "";
                if (ParameterObject.GetType() == typeof(string))
                {
                    Request = "LoadDocumentFromBackFilp" + "!@" + ParameterObject.ToString();
                }
                else
                {
                    IList list = ParameterObject as IList;
                    List<PUR_T001_AFlip> GetSelectedChangedTemp = list.Cast<PUR_T001_AFlip>().ToList();

                    FilpEntity = (PUR_T001_AFlip)GetSelectedChangedTemp[0];
                    Request = "LoadDocumentFromBackFilp" + "!@" + FilpEntity.req_no;
                }

                MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_PUR_T001_A>(MC, Request, "PurchaseRequisition", "Procurement", "LoadDocumentFromBackFilp", 0, "");
                MasterEntity = MCTemp.Pur_Req[0];
                Pur_Req_Details = MCTemp.Pur_Req_Details;

                AttachmentCollection = MC.Attachment;
                SelectedTabControlIndex = 0;
                NewRecord = false;
                parameter = false;
                var msg = new NotificationMessage("PUR_T001_A_VM2");
                Messenger.Default.Send<NotificationMessage>(msg);
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

        private void InsertPriority(object InputValue)
        {

            string Request = "";
            ADM_M040_P POPUPEntityObject = null;

            try
            {
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.Priorities.Where(x => x.priority.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M040_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                //if (POPUPEntityObject != null && MasterEntity.EmpId != POPUPEntityObject.EmpId) //Application:New/Update.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                if (POPUPEntityObject != null)
                {
                    MasterEntity.priority = POPUPEntityObject.pr_code;
                    MasterEntity.priorityNm = POPUPEntityObject.priority;

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
        private void InsertEmployee(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M024_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.Employees.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                    }
                }

                catch (Exception ex) { }
                #endregion
                //if (POPUPEntityObject != null && MasterEntity.EmpId != POPUPEntityObject.EmpId) //Application:New/Update.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                if (POPUPEntityObject != null)
                {
                    MasterEntity.EmpId = POPUPEntityObject.EmpId;
                    MasterEntity.EmpNm = POPUPEntityObject.EmpName;


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
        private void InsertDataGridRow_Item(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M022_P POPUPEntityObject = null;
            dgSelectedIndex = dgSelectedIndex;
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
                        POPUPEntityObject = MC.ItemList.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];

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
            }
            else if (InputValue != null)
            {
                if (((IEnumerable)InputValue).Cast<ADM_M022_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_P>().ToList()[0];
                }
            }

            #endregion

            if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
            {
                var InputValueIfExists = Pur_Req_Details.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                int IndexOfExistValue = Pur_Req_Details.IndexOf(Pur_Req_Details.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && Pur_Req_Details.Count == dgSelectedIndex)
                {
                    Pur_Req_Details.Add(new PUR_T001_B()
                    {

                        ItemCode = POPUPEntityObject.ItemCode,
                        description = POPUPEntityObject.ItemName,
                        unit_code = POPUPEntityObject.unit_code,
                        SubCatCode = POPUPEntityObject.SubCatCode,
                        StockUnt = POPUPEntityObject.StockUnt,
                        line_id = 0,
                        location_Id = AppSessionState.location_Id,
                        comp_code = AppSessionState.comp_code,
                        add_by = AppSessionState.UserID,
                        po_code = AppSessionState.po_code,
                        pg_code = AppSessionState.pg_code,
                        active = true,
                        t_status = MasterEntity.t_status,
                        t_display = MasterEntity.t_display

                    });
                }
                else if (dgSelectedIndex >= 0 && Pur_Req_Details.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                {
                    if (Pur_Req_Details[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                    {
                        Pur_Req_Details[dgSelectedIndex].ItemCode = POPUPEntityObject.ItemCode;
                        Pur_Req_Details[dgSelectedIndex].description = POPUPEntityObject.ItemName;
                        Pur_Req_Details[dgSelectedIndex].StockUnt = Convert.ToBoolean(POPUPEntityObject.StockUnt);
                        Pur_Req_Details[dgSelectedIndex].active = true;
                        Pur_Req_Details[dgSelectedIndex].SubCatCode = POPUPEntityObject.SubCatCode;
                        Pur_Req_Details[dgSelectedIndex].line_id = 0;
                        Pur_Req_Details[dgSelectedIndex].location_Id = AppSessionState.location_Id;
                        Pur_Req_Details[dgSelectedIndex].comp_code = AppSessionState.comp_code;
                        Pur_Req_Details[dgSelectedIndex].add_by = AppSessionState.UserID;
                        Pur_Req_Details[dgSelectedIndex].po_code = AppSessionState.po_code;
                        Pur_Req_Details[dgSelectedIndex].pg_code = AppSessionState.pg_code;
                        Pur_Req_Details[dgSelectedIndex].t_status = MasterEntity.t_status;
                        Pur_Req_Details[dgSelectedIndex].t_display = MasterEntity.t_display;

                    }
                    else if (Pur_Req_Details[dgSelectedIndex].ItemCode != POPUPEntityObject.ItemCode)
                    {
                        Pur_Req_Details[dgSelectedIndex].ItemCode = "";
                        Pur_Req_Details[dgSelectedIndex].description = "";
                    }
                }
            }
            #region Clear Empty Row
            PUR_T001_B newObj = new PUR_T001_B();
            for (int i = Pur_Req_Details.Count - 1; i >= 0; i--)
            {
                bool xx = Pur_Req_Details[i].ComparePropertiesTo(newObj);
                if (Pur_Req_Details[i].ComparePropertiesTo(newObj) == true && Pur_Req_Details.Count > 1)
                {
                    Pur_Req_Details.RemoveAt(i);
                    //if (Pur_Req_Details.Count == 0)
                    //{
                    //    Pur_Req_Details.Add(newObj);
                    //}
                }
            }
            #endregion

        }
        private void InsertDataGridRow_Uom(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {

            string Request = "";
            ADM_M038_B_P POPUPEntityObject = null;

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
                        POPUPEntityObject = MC.uoms.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                    }
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

            if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
            {
                var InputValueIfExists = Pur_Req_Details.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                int IndexOfExistValue = Pur_Req_Details.IndexOf(Pur_Req_Details.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                if (dgSelectedIndex >= 0 && Pur_Req_Details.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                {
                    if (Pur_Req_Details[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    {
                        Pur_Req_Details[dgSelectedIndex].unit_code = POPUPEntityObject.unit_code;
                    }
                    else if (Pur_Req_Details[dgSelectedIndex].unit_code != POPUPEntityObject.unit_code)
                    {
                        Pur_Req_Details[dgSelectedIndex].unit_code = "";
                    }
                }
            }
            #region Clear Empty Row
            PUR_T001_B newObj = new PUR_T001_B();
            for (int i = Pur_Req_Details.Count - 1; i >= 0; i--)
            {
                bool xx = Pur_Req_Details[i].ComparePropertiesTo(newObj);
                if (Pur_Req_Details[i].ComparePropertiesTo(newObj) == true && Pur_Req_Details.Count > 1)
                {
                    Pur_Req_Details.RemoveAt(i);
                    if (Pur_Req_Details.Count == 0)
                    {
                        Pur_Req_Details.Add(newObj);
                    }
                }
            }

            #endregion

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
                    var InputValueIfExists = Pur_Req_Details.Where(X => X.user_source1 == POPUPEntityObject.parametervalue).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = Pur_Req_Details.IndexOf(Pur_Req_Details.Where(X => X.user_source1 == POPUPEntityObject.parametervalue).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && Pur_Req_Details.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (Pur_Req_Details[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            Pur_Req_Details[dgSelectedIndex].user_source1 = POPUPEntityObject.parametervalue;
                        }
                        else if (Pur_Req_Details[dgSelectedIndex].user_source1 != POPUPEntityObject.parametervalue)
                        {
                            Pur_Req_Details[dgSelectedIndex].user_source1 = "";
                        }
                    }
                    #region Clear Empty Row
                    PUR_T001_B newObj = new PUR_T001_B();
                    for (int i = Pur_Req_Details.Count - 1; i >= 0; i--)
                    {
                        bool xx = Pur_Req_Details[i].ComparePropertiesTo(newObj);
                        if (Pur_Req_Details[i].ComparePropertiesTo(newObj) == true && Pur_Req_Details.Count > 1)
                        {
                            Pur_Req_Details.RemoveAt(i);
                            if (Pur_Req_Details.Count == 0)
                            {
                                Pur_Req_Details.Add(newObj);
                            }
                        }
                    }

                    #endregion
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
        private void Insert_t_status(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M0013 POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.STATUS_LIST.Where(x => x.t_status.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.t_display.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = NewMethod(InputValue).ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.t_status = POPUPEntityObject.t_status;
                    MasterEntity.t_display = POPUPEntityObject.t_display;
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

        private static IEnumerable<ADM_M0013> NewMethod(object InputValue)
        {
            return ((IEnumerable)InputValue).Cast<ADM_M0013>();
        }

        private void InsertBOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ENG_T001_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.BOM_List.Where(x => x.doc_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ENG_T001_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion


                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {

                    Pur_Req_Details[dgSelectedIndex].bom_no = POPUPEntityObject.doc_no;

                }
                #region Clear Empty Row
                PUR_T001_B newObj = new PUR_T001_B();
                for (int i = Pur_Req_Details.Count - 1; i >= 0; i--)
                {
                    bool xx = Pur_Req_Details[i].ComparePropertiesTo(newObj);
                    if (Pur_Req_Details[i].ComparePropertiesTo(newObj) == true && Pur_Req_Details.Count > 1)
                    {
                        Pur_Req_Details.RemoveAt(i);
                        if (Pur_Req_Details.Count == 0)
                        {
                            Pur_Req_Details.Add(newObj);
                        }
                    }
                }

                #endregion
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
        private void InsertDataGridRow_ItemCategory(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            SYS_M008_P POPUPEntityObject = null;
            dgSelectedIndex = dgSelectedIndex;
            #region Command Parameter Read Section
            // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
            if (InputValue.GetType() == typeof(string) && InputValue != null)
            {
                //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                Request = InputValue.ToString();
                if (Request.Length > 0)
                {
                    try
                    { POPUPEntityObject = MC.ItemCategoryList.Where(x => x.item_cat.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                    catch (Exception ex) { }
                }
            }
            else if (InputValue != null)
            {
                if (((IEnumerable)InputValue).Cast<SYS_M008_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M008_P>().ToList()[0];
                }
            }

            #endregion

            if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
            {
                var InputValueIfExists = Pur_Req_Details.Where(X => X.item_cat == POPUPEntityObject.item_cat).FirstOrDefault(); // Prefer Primary Key for this instruction.
                int IndexOfExistValue = Pur_Req_Details.IndexOf(Pur_Req_Details.Where(X => X.item_cat == POPUPEntityObject.item_cat).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                if (dgSelectedIndex >= 0 && Pur_Req_Details.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                {
                    if (Pur_Req_Details[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    {
                        Pur_Req_Details[dgSelectedIndex].item_cat = POPUPEntityObject.item_cat;
                    }
                    else if (Pur_Req_Details[dgSelectedIndex].item_cat != POPUPEntityObject.item_cat)
                    {
                        Pur_Req_Details[dgSelectedIndex].item_cat = "";
                    }
                }
            }
            #region Clear Empty Row
            PUR_T001_B newObj = new PUR_T001_B();
            for (int i = Pur_Req_Details.Count - 1; i >= 0; i--)
            {
                bool xx = Pur_Req_Details[i].ComparePropertiesTo(newObj);
                if (Pur_Req_Details[i].ComparePropertiesTo(newObj) == true && Pur_Req_Details.Count > 1)
                {
                    Pur_Req_Details.RemoveAt(i);
                    if (Pur_Req_Details.Count == 0)
                    {
                        Pur_Req_Details.Add(newObj);
                    }
                }
            }
            #endregion
        }
        private void ItemDetailsSelectionChangedMethod(IList InputList)
        {
            IList list = InputList as IList;
            try
            {
                if (dgSelectedIndex != -1 && Pur_Req_Details.Count > 0 && Pur_Req_Details.Count > dgSelectedIndex)
                {
                    List<PUR_T001_B> selectedlist = list.Cast<PUR_T001_B>().ToList();

                    if (selectedlist.Count > 0)
                    {

                        if (Pur_Req_Details[dgSelectedIndex].id == 0 && Pur_Req_Details[dgSelectedIndex].StockUnt == true)
                        {
                            parameter = true;
                        }
                        else
                        {
                            parameter = false;
                        }
                    }
                }
                if (Pur_Req_Details.Count > 0 && dgSelectedIndex != -1 && Pur_Req_Details.Count > dgSelectedIndex)
                {
                    if (MC.BOM_List.Count() > 0)
                    {

                        var BOMItems = (from data in MC.BOM_List where data.ItemCode == Pur_Req_Details[dgSelectedIndex].ItemCode select data);

                        //New PopUP - BOM Reference
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ENG_T001_P)x).doc_no);
                        TheFilter = (o, prefix) => (((ENG_T001_P)o).doc_no ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASBOMRef = new AutoSuggestTextViewModel<dynamic>(BOMItems, TheFilter, SuggestedValue, "bom_no", "doc_no", true);
                        ASBOMRef.AutoSuggestVM.IsEmptyValueAllowed = true;
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
        private void CollectionChanged(IList DataList)
        {
            IList list = DataList as IList;
            int a = dgSelectedIndex;
            string[] TempSkuList = new string[100];
            List<string> TempParaValueList = new List<string>();
            try
            {
                if (Pur_Req_Details[dgSelectedIndex].id == 0 && Pur_Req_Details.Count > 0 && dgSelectedIndex < Pur_Req_Details.Count)
                {
                    List<PUR_T001_B> SelectedRowlist = list.Cast<PUR_T001_B>().ToList();

                    if (SelectedRowlist[0].StockUnt == true)
                    {
                        var paramlist = (from o in MC.ParameterList where o.SubCatCode == SelectedRowlist[0].SubCatCode select o).ToList();
                        ParameterTemp = paramlist.ToList();

                        if (paramlist.Count > 0 && Pur_Req_Details[dgSelectedIndex].sku != "" && Pur_Req_Details[dgSelectedIndex].sku != null)
                        {
                            TempSkuList = Pur_Req_Details[dgSelectedIndex].sku.Split('/');

                            for (int i = 0; i < paramlist.Count; i++)
                            {
                                TempParaValueList = (from o in MC.ParamValueList where o.value_code == TempSkuList[i] select o.parametervalue).ToList();
                                if (TempParaValueList.Count > 0)
                                {
                                    paramlist[i].parametervalue = TempParaValueList[0];
                                }
                            }

                            ParameterCollection = CollectionViewSource.GetDefaultView(paramlist.ToList());
                        }
                        else
                        {
                            foreach (var o in ParameterTemp)
                            {
                                o.parametervalue = null; o.value_code = null;
                            }
                            ParameterCollection = CollectionViewSource.GetDefaultView(paramlist.ToList());
                        }

                        if (paramlist.Count > 0) //&& SelectedParaValueCollection.Count != paramlist.Count)
                        {
                            SelectedParaValueCollection = new List<ADM_M031_P>();

                            for (int i = 0; i < paramlist.Count; i++)
                            {
                                SelectedParaValueCollection.Add(new ADM_M031_P()
                                {
                                    // ItemCode = SelectedRowlist[0].ItemCode,
                                    dgselectedindex = dgSelectedIndex,
                                    //  value_code = SelectedParaValueList[0].value_code,
                                    para_code = paramlist[i].para_code,
                                    para_name = paramlist[i].para_name
                                });
                            }
                        }
                        if (Pur_Req_Details[dgSelectedIndex].sku_desc != null)
                        {
                            SelectedParaValueCollection = ParameterCollection.Cast<ADM_M031_P>().ToList();

                            foreach (var o in SelectedParaValueCollection)
                            {
                                o.dgselectedindex = dgSelectedIndex;
                                foreach (var p in MC.ParamValueList)
                                {
                                    if (o.para_code == p.para_code && o.parametervalue == p.parametervalue)
                                    {
                                        o.value_code = p.value_code;
                                    }
                                }
                            }
                        }

                    }

                }
                else if (Pur_Req_Details[dgSelectedIndex].id != 0 && Pur_Req_Details.Count > 0 && dgSelectedIndex < Pur_Req_Details.Count)
                {
                    //List<PUR_T001_B> SelectedRowlist = list.Cast<PUR_T001_B>().ToList();
                    //string[] TempSkuList = new string[100];
                    //List<string> TempParaValueList = new List<string>();

                    //if (SelectedRowlist[0].StockUnt == true)
                    //{
                    //    var paramlist = (from o in MC.ParameterList where o.SubCatCode == SelectedRowlist[0].SubCatCode select o).ToList();
                    //    if (paramlist.Count > 0 && Pur_Req_Details[dgSelectedIndex].sku != "" && Pur_Req_Details[dgSelectedIndex].sku != null)
                    //    {
                    //        TempSkuList = Pur_Req_Details[dgSelectedIndex].sku.Split('/');

                    //        for (int i = 0; i < paramlist.Count; i++)
                    //        {
                    //            TempParaValueList = (from o in MC.ParamValueList where o.value_code == TempSkuList[i] select o.parametervalue).ToList();
                    //            paramlist[i].parametervalue = TempParaValueList[0];
                    //        }

                    //        ParameterCollection = CollectionViewSource.GetDefaultView(paramlist.ToList());
                    //    }
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
        private void GetSelectedParaValue(IList parameter)
        {
            IList list = parameter as IList;
            List<ADM_M031_P> SelectedParaValueList = list.Cast<ADM_M031_P>().ToList();
            int a = ParadgSelectedIndex;
            int b = dgSelectedIndex;

            try
            {
                if (dgSelectedIndex != -1 && SelectedParaValueList.Count > 0 && Pur_Req_Details[dgSelectedIndex].StockUnt == true)
                {
                    if (Pur_Req_Details[dgSelectedIndex].id == 0)
                    {
                        #region 
                        if (SelectedParaValueList.Count > 0 && SelectedParaValueList[0].parametervalue != null && SelectedParaValueList[0].parametervalue != "")// && SelectedParaValueCollection.dgselectedindex.contains)
                        {
                            for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                            {
                                if (SelectedParaValueCollection[i].para_code == SelectedParaValueList[0].para_code && SelectedParaValueCollection[i].dgselectedindex == dgSelectedIndex)
                                {
                                    SelectedParaValueCollection[i].parametervalue = SelectedParaValueList[0].parametervalue;

                                    var paravaluetemp = (from o in MC.ParamValueList where o.para_code == SelectedParaValueCollection[i].para_code && o.parametervalue == SelectedParaValueCollection[i].parametervalue select o).ToList();

                                    if (paravaluetemp.Count > 0)
                                    {
                                        SelectedParaValueCollection[i].value_code = paravaluetemp[0].value_code;
                                    }
                                }
                            }

                            // SKU Description
                            GetSkuDescription();

                            //Function for calculating SKU
                            CalculateSku();


                        }
                        #endregion
                    }
                    else if (Pur_Req_Details[dgSelectedIndex].id != 0)
                    {

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
        private void GetSkuDescription()
        {
            if (Pur_Req_Details[dgSelectedIndex].sku_desc == null || Pur_Req_Details[dgSelectedIndex].sku_desc == "")
            {
                for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                {
                    if (Pur_Req_Details[dgSelectedIndex].sku_desc == "" || Pur_Req_Details[dgSelectedIndex].sku_desc == null && (String.IsNullOrEmpty(SelectedParaValueCollection[i].parametervalue) || SelectedParaValueCollection[i].parametervalue.Trim() != "NA"))
                    {
                        Pur_Req_Details[dgSelectedIndex].sku_desc = SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                    }
                    else if (String.IsNullOrEmpty(SelectedParaValueCollection[i].parametervalue) || SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
                    {
                        Pur_Req_Details[dgSelectedIndex].sku_desc = Pur_Req_Details[dgSelectedIndex].sku_desc + SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                    }
                }
            }
            else
            {
                Pur_Req_Details[dgSelectedIndex].sku_desc = "";

                for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                {
                    if (Pur_Req_Details[dgSelectedIndex].sku_desc == "" || Pur_Req_Details[dgSelectedIndex].sku_desc == null && (String.IsNullOrEmpty(SelectedParaValueCollection[i].parametervalue) || SelectedParaValueCollection[i].parametervalue.Trim() != "NA"))
                    {
                        Pur_Req_Details[dgSelectedIndex].sku_desc = SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                    }
                    else if (String.IsNullOrEmpty(SelectedParaValueCollection[i].parametervalue) || SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
                    {
                        Pur_Req_Details[dgSelectedIndex].sku_desc = Pur_Req_Details[dgSelectedIndex].sku_desc + SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                    }
                }
            }
        }
        private void CalculateSku()
        {
            if (Pur_Req_Details[dgSelectedIndex].sku == null &&(Pur_Req_Details[dgSelectedIndex].sku == null || Pur_Req_Details[dgSelectedIndex].sku == ""))
            {
                for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                {
                    if (Pur_Req_Details[dgSelectedIndex].sku == "" || Pur_Req_Details[dgSelectedIndex].sku == null)
                    {
                        Pur_Req_Details[dgSelectedIndex].sku = SelectedParaValueCollection[i].value_code;
                    }
                    else
                    {
                        Pur_Req_Details[dgSelectedIndex].sku = Pur_Req_Details[dgSelectedIndex].sku + "/" + SelectedParaValueCollection[i].value_code;
                    }
                }
            }
            else if (Pur_Req_Details[dgSelectedIndex].sku == null)
            {
                Pur_Req_Details[dgSelectedIndex].sku = "";

                for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                {
                    if (Pur_Req_Details[dgSelectedIndex].sku == "" || Pur_Req_Details[dgSelectedIndex].sku == null)
                    {
                        Pur_Req_Details[dgSelectedIndex].sku = SelectedParaValueCollection[i].value_code;
                    }
                    else
                    {
                        Pur_Req_Details[dgSelectedIndex].sku = Pur_Req_Details[dgSelectedIndex].sku + "/" + SelectedParaValueCollection[i].value_code;
                    }
                }
            }
        }

        private void DeleteDataGridRow_Item(object InputValue)
        {
            int i = (int)InputValue;
            if (Pur_Req_Details.Count > i && Pur_Req_Details[dgSelectedIndex].id == 0)
            {
                Pur_Req_Details.RemoveAt(i);
            }
        }
        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {
                MasterEntity.doc_cat = "RQ";
                MasterEntity.doc_type = "RQ";
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + AppSessionState.po_code + "!@" + AppSessionState.pg_code + "!@" + AppSessionState.EmpId;

                MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_PUR_T001_A>(MC, Request, "PurchaseRequisition", "Procurement", "LoadAll", 0, "");
                #region Auto Suggest Initialization Region


                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_P)x).ItemCode);
                TheFilter = (o, prefix) => (((ADM_M022_P)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M022_P)o).ItemName.ToString().ToLower() ?? "").Contains(prefix.ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.ItemList, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_display);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASt_status = new AutoSuggestTextViewModel<dynamic>(MC.STATUS_LIST, TheFilter, SuggestedValue, "t_display", true);
                ASt_status.AutoSuggestVM.IsEmptyValueAllowed = true;

                #endregion
                FlipGridData = MC.DocumentDataFlipGrid;
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                PriorityCollection = CollectionViewSource.GetDefaultView(MC.Priorities);
                PriorityCollection.Filter = new Predicate<object>(PriorityFilter);
                StringListPriority = MC.Priorities.Select(x => x.priority).ToList();

                EmpCollection = CollectionViewSource.GetDefaultView(MC.Employees);
                EmpCollection.Filter = new Predicate<object>(EmpFilter);
                StringListEmployee = MC.Employees.Select(x => x.EmpId).ToList();

                List<ADM_M030_P> makelist = (from o in MC.ParamValueList where o.para_code == "1002" select o).ToList();
                MakeCollection = CollectionViewSource.GetDefaultView(makelist);
                MakeCollection.Filter = new Predicate<object>(FilterMake);
                StringListMake = makelist.Select(x => x.parametervalue).ToList();

                uomCollection = CollectionViewSource.GetDefaultView(MC.uoms);
                uomCollection.Filter = new Predicate<object>(uomFilter);
                StringListUOM = MC.uoms.Select(x => x.unit_code).ToList();

                ItemsCollection = (ICollectionView)CollectionViewSource.GetDefaultView(MC.ItemList.ToList());
                ItemsCollection.Filter = new Predicate<object>(ItemsFilter);
                StringListItems = MC.ItemList.Select(x => x.ItemCode).ToList();

                itemcategoryCollection = CollectionViewSource.GetDefaultView(MC.ItemCategoryList);
                itemcategoryCollection.Filter = new Predicate<object>(Filteritemcategory);
                StringListItemCategory = MC.ItemCategoryList.Select(x => x.item_cat).ToList();

                NotificationDataCollection = MC.NotificationData;

                DefaultValues();

                MasterEntity.deadline = DateTime.Now;
                MasterEntity.date_start = DateTime.Now;

                //doc_typeCollection = CollectionViewSource.GetDefaultView(MC.doc_typeList);




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
        private void GenerateSku()
        {
            string makecode = "";
            try
            {
                foreach (var o in Pur_Req_Details)
                {
                    if (o.id == 0)
                    {
                        makecode = "";

                        if (o.user_source1 != null && o.user_source1 != "")
                        {
                            makecode = MC.ParamValueList.Where(X => X.parametervalue.Trim() == o.user_source1.Trim() && X.para_code == "1002").Select(x => x.value_code).FirstOrDefault();

                            o.sku = makecode;
                            o.sku_desc = "Make:" + o.user_source1;

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
        private void DefaultValues()
        {
            MasterEntity.doc_cat = "RQ";
            MasterEntity.doc_type = "RQ";
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.po_code = AppSessionState.po_code;
            MasterEntity.pg_code = AppSessionState.pg_code;
            MasterEntity.t_status = "001";
            var tempt_display = (from o in MC.STATUS_LIST
                                 where o.t_status == MasterEntity.t_status
                                 select o).ToList();
            MasterEntity.t_display = tempt_display[0].t_display;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;
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
                        new KeyValuePair<string, string>("[DOC]",MC.doc_typeList[0].doc_desc_user),
                        new KeyValuePair<string, string>("[DOCNO]", MasterEntity.req_no),
                        new KeyValuePair<string, string>("[DOCDATE]", MasterEntity.date_start.ToString()),
                        new KeyValuePair<string, string>("[EMP]", MC.Employees[0].EmpName),
                        new KeyValuePair<string, string>("[Comp]","M/s: " + AppSessionState.CompanyName),
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
        #region · Command Actions ·
        protected override void OnSaveAction(InquiryActionResult<PUR_T001_A> result)
        {
            CursorControl.SetBusyState();
            try
            {
                //DefaultValues();

                this.MasterEntity.EndEdit();
                if (validation() == true)
                {
                    MasterEntity.XmlDataDocument_PUR_T001_B = objSer.ObjectToXML(Pur_Req_Details);
                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<PUR_T001_A>(MasterEntity, "PurchaseRequisition", "Procurement");
                        if (MasterEntity.req_no != null && NotificationDataCollection.FindIndex(f => f.alert_name == "OnInsert") >= 0)
                        {
                            NotifyMessage("OnInsert");
                        }
                        if (MasterEntity.req_no != null && NotificationDataCollection.FindIndex(f => f.alert_name == "OnApproval") >= 0)
                        {
                            NotifyMessage("OnApproval");
                        }

                    }
                    else if (NewRecord == false)
                    {

                        MasterEntity = repository.UpdateWithReturnDomainObject<PUR_T001_A>(MasterEntity, "PurchaseRequisition", "Procurement");

                    }
                    SetBusinessEntitiesAfterLoad("Save", "");

                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Data Saved Successfully");
                    showMessageService.ShowMessage();

                    NewRecord = false;
                    _dataGridCollection.SortDescriptions.Add(new SortDescription("req_no", ListSortDirection.Descending));
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Data Saved Successfully");
                showMessageService.ShowMessage();
            }
            var msg = new NotificationMessage("PUR_T001_A_VM2");
            Messenger.Default.Send<NotificationMessage>(msg);
        }

        private bool validation()
        {
            try
            {
                // Validation for record modification depends on workflow and status
                foreach (var o in MC.doc_typeList)
                {

                    if (o.doc_cat == MasterEntity.doc_cat && o.Workflow_id_temp != null)
                    {
                        if (MasterEntity.t_status == "007" || MasterEntity.t_status == "002")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("You cannot edit record once it is Approved");
                            showMessageService.ShowMessage();
                            return false;
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

            if (Pur_Req_Details.Count < 1)//when form is blank and we save the record
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("At Least Insert One Item........");
                showMessageService.ShowMessage();

                return false;
            }
            else
            {
                GenerateSku();

                foreach (var o in Pur_Req_Details)
                {
                    if (o.ItemCode != null && o.ItemCode != "" && o.description != null)
                    {
                        int flag = 0;
                        if (o.id == 0)
                        {
                            foreach (var p in Pur_Req_Details)
                            {
                                if (o.ItemCode == p.ItemCode && o.sku == p.sku)
                                {
                                    flag++;
                                }
                            }
                            if (flag > 1)
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Cannot Save Duplicate Item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                                showMessageService.ShowMessage();
                                return false;
                            }
                        }


                        // Validation For All Parameter Values Selected or Not

                        if (o.StockUnt == true && o.id == 0)
                        {
                            var paralist = (from p in MC.ParameterList where p.SubCatCode == o.SubCatCode select p).ToList();

                            if (paralist.Count > 0)
                            {
                                string[] SkuList = new string[100];           //string array
                                List<string> SkuListt = new List<string>();    // stringlist

                                if (o.sku != null && o.sku != "")
                                {
                                    SkuList = o.sku.Split('/');
                                    SkuListt = SkuList.ToList();

                                    foreach (var item in SkuList)
                                    {
                                        if (item == "")
                                        {
                                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                            showMessageService.ButtonSetup = DialogButton.Ok;
                                            showMessageService.Caption = "Parameter Validation";
                                            showMessageService.Text = String.Format("All Parameters of item {0} of index {1} are not selected..!!! \n Check Parameter at index {2} is selected or not. \n ", o.ItemCode, Pur_Req_Details.IndexOf(o), SkuList.ToList().IndexOf(item));
                                            showMessageService.ShowMessage();
                                            return false;
                                        }
                                    }
                                }
                                else
                                {
                                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                    showMessageService.ButtonSetup = DialogButton.Ok;
                                    showMessageService.Caption = "Parameter Validation";
                                    showMessageService.Text = String.Format("All Parameters of item {0} of index {1} are not selected\n If you can see All Parameter Value Selected Please Select the Same Values Again ", o.ItemCode, Pur_Req_Details.IndexOf(o));
                                    showMessageService.ShowMessage();
                                    return false;
                                }
                            }

                        }


                        if (o.qty == null || o.qty == 0)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Quantity cannot be null or 0 for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.user_source1 == null || o.user_source1 == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Make Cannot be Blank {0}", o.ItemCode);
                            showMessageService.ShowMessage();
                            return false;
                        }
                    }
                    else
                    {

                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("please select Item ........");
                        showMessageService.ShowMessage();
                        return false;
                    }

                }

            }
            return true;

        }

        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            if (MasterEntity.XmlDataDocument_PUR_T001_B != null)
            {
                MC.Pur_Req_Details = (ObservableCollection<PUR_T001_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_PUR_T001_B, MC.Pur_Req_Details);
                Pur_Req_Details.Clear();
                Pur_Req_Details = MC.Pur_Req_Details;
            }
            else
            {
                MC.Pur_Req_Details = new ObservableCollection<PUR_T001_B>();
            }


            if (MasterEntity.XmlDataDocument_FlipGrid != null && NewRecord == true && ParameterOption1 == "Save")
            {
                MC.DocumentDataFlipGrid = (List<PUR_T001_AFlip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.DocumentDataFlipGrid);
                FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
            }
        }

        protected override void OnCreateAction(InquiryActionResult<PUR_T001_A> result)
        {

            NewRecord = true;

            MasterEntity = new PUR_T001_A();
            MasterEntity.ValidateAsync().Wait();
            Pur_Req_Details = new ObservableCollection<PUR_T001_B>();
            Pur_Req_Details.Clear();
            DefaultValues();
            MasterEntity.date_start = DateTime.Now;
            MasterEntity.deadline = DateTime.Now;
            _dataGridCollection.Refresh();
            var msg = new NotificationMessage("PUR_T001_A_VM2");
            Messenger.Default.Send<NotificationMessage>(msg);

        }
        protected override void OnRemoveAction(InquiryActionResult<PUR_T001_A> result)
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
                this.MasterEntity.CancelEdit();
                string response = repository.Delete(MasterEntity.req_no, "PurchaseRequisition", "Procurement");
                //SelectedList.Remove(MasterEntity);
                _dataGridCollection.Refresh();
                MasterEntity = new PUR_T001_A();
                Pur_Req_Details = new ObservableCollection<PUR_T001_B>();
                NewRecord = true;
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<PUR_T001_A> result)
        {
            MasterEntity.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<PUR_T001_A> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<PUR_T001_A> result)
        {
            SelectedList = SelectedList;
            MasterEntity = MasterEntity;
        }
        protected override void OnHelpAction(InquiryActionResult<PUR_T001_A> result)
        {
            SelectedList = SelectedList;
            MasterEntity = MasterEntity;
        }
        protected override void OnPrintAction(InquiryActionResult<PUR_T001_A> result)
        {
            CursorControl.SetBusyState();
            try
            {

                string Request = "LoadDocumentFromBackFilp" + "!@" + MasterEntity.req_no;

                MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_PUR_T001_A>(MCTemp, Request, "PurchaseRequisition", "Procurement", "LoadDocumentFromBackFilp", 0, "");

                object[] objDataSource = new object[4];
                string[] objDataSourceName = new string[4];

                //MCTemp.MasterEntity.Clear();
                //MCTemp.MasterEntity.Add(MasterEntity);

                objDataSource[0] = MCTemp.Pur_Req;
                objDataSource[1] = MCTemp.Pur_Req_Details;

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[2] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[3] = Result;



                objDataSourceName[0] = "dsPurchaseRequisition";
                objDataSourceName[1] = "dsPurchaseRequisitionItem";
                objDataSourceName[2] = "dsCompany";
                objDataSourceName[3] = "dsLocation";


                ReportManager ReportManager = new ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Procurment\\PurchaseRequisition.rdlc", getParametersList(), "");
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

        //protected override void OnExportAction(InquiryActionResult<PUR_T001_A> result)
        //{
        //    try
        //    {
        //        List<PUR_T001_A> Export_List = new List<PUR_T001_A>();
        //        foreach (var o in DataGridCollection)
        //        {
        //            PUR_T001_A Data = o as PUR_T001_A;
        //            Export_List.Add(Data);
        //        }

        //        //--------------------------------------

        //        ExportToExcel<PUR_T001_A, List<PUR_T001_A>> export = new ExportToExcel<PUR_T001_A, List<PUR_T001_A>>();
        //        ICollectionView view = CollectionViewSource.GetDefaultView(Export_List);
        //        export.dataToPrint = (List<PUR_T001_A>)view.SourceCollection;

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


        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }
        protected override void OnRefreshCommand(InquiryActionResult<PUR_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<PUR_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<PUR_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<PUR_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<PUR_T001_A> result)
        {
            throw new NotImplementedException();
        }
        #endregion

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
        #region filters

        private string _filterString;
        private string _filterStringPriority;
        private string _filterStringEmp;
        private string _filterStringItems;
        private string _filterStringuom;
        #region Filters For Priority
        private void FilterCollectionPriority()
        {
            if (_PriorityCollection != null)
            {
                _PriorityCollection.Refresh();
            }
        }
        public string FilterStringPriority
        {
            get { return _filterStringPriority; }
            set
            {
                _filterStringPriority = value;
                RaisePropertyChanged("FilterStringPriority");
                FilterCollectionPriority();
            }
        }
        public bool PriorityFilter(object obj)
        {
            var data = obj as ADM_M040_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringPriority))
                {
                    return (data.priority != null && data.priority.ToString().ToLower().Contains(_filterStringPriority.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Emp
        private void FilterCollectionEmp()
        {
            if (_EmpCollection != null)
            {
                _EmpCollection.Refresh();
            }
        }
        public string FilterStringEmp
        {
            get { return _filterStringEmp; }
            set
            {
                _filterStringEmp = value;
                RaisePropertyChanged("FilterStringEmp");
                FilterCollectionEmp();
            }
        }
        public bool EmpFilter(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringEmp))
                {
                    return (data.EmpName != null && data.EmpName.ToLower().Contains(_filterStringEmp.ToLower())) ||
                            (data.EmpFName != null && data.EmpFName.ToLower().Contains(_filterStringEmp.ToLower())) ||
                             (data.EmpId != null && data.EmpId.ToLower().Contains(_filterStringEmp.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Items
        private void FilterCollectionItems()
        {
            if (_ItemsCollection != null)
            {
                _ItemsCollection.Refresh();
            }
        }
        public string FilterStringItems
        {
            get { return _filterStringItems; }
            set
            {
                _filterStringItems = value;
                RaisePropertyChanged("FilterStringItems");
                FilterCollectionItems();
            }
        }
        public bool ItemsFilter(object obj)
        {
            var data = obj as ADM_M022_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringItems))
                {
                    return ((data.ItemCode != null) && data.ItemCode.ToLower().Contains(_filterStringItems.ToLower())) ||
                           (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterStringItems.ToLower())) ||
                           (data.SubCatName != null && data.SubCatName.ToString().ToLower().Contains(_filterStringItems.ToLower())) ||
                           (data.CatCode != null && data.CatCode.ToString().ToLower().Contains(_filterStringItems.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For uom
        private void FilterCollectionuom()
        {
            if (_uomCollection != null)
            {
                _uomCollection.Refresh();
            }
        }
        public string FilterStringuom
        {
            get { return _filterStringuom; }
            set
            {
                _filterStringuom = value;
                RaisePropertyChanged("FilterStringuom");
                FilterCollectionuom();
            }
        }
        public bool uomFilter(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringuom))
                {
                    return (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterStringuom.ToLower())) ||
                        (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterStringuom.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion


        #region itemcategory
        //itemcategory
        private string _filterString_itemcategory;
        public string FilterString_itemcategory
        {
            get { return _filterString_itemcategory; }
            set
            {
                _filterString_itemcategory = value;
                RaisePropertyChanged("FilterString_itemcategory");
                FilterCollectionitemcategory();
            }
        }
        private void FilterCollectionitemcategory()
        {
            if (_itemcategoryCollection != null)
            {
                _itemcategoryCollection.Refresh();
            }
        }
        public bool Filteritemcategory(object obj)
        {
            var data = obj as SYS_M008_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_itemcategory))
                {
                    return (data.item_cat != null && data.item_cat.ToString().ToLower().Contains(_filterString_itemcategory.ToLower()) ||
                        data.cat_desc != null && data.cat_desc.ToString().ToLower().Contains(_filterString_itemcategory.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For Make
        private string _filterStringMake;
        private void FilterCollectionMake()
        {
            if (_MakeCollection != null)
            {
                _MakeCollection.Refresh();
            }
        }
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
            var data = obj as PUR_T001_AFlip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.req_no != null && data.req_no.ToString().ToLower().Contains(_filterString.ToLower())) ||
                           (data.date_start != null && data.date_start.ToString().ToLower().Contains(_filterString.ToLower())) ||
                           (data.deadline != null && data.deadline.ToString().ToLower().Contains(_filterString.ToLower())) ||
                           (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_filterString.ToLower())) ||
                           (data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterString.ToLower())) ||
                           (data.t_display != null && data.t_display.ToString().ToLower().Contains(_filterString.ToLower()));
                }
                return true;
            }
            return false;
        }

        
        #endregion
        #endregion
    }
}
