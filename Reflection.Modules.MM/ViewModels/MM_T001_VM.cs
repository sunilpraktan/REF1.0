using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.BusinessEntity;
using System.Windows.Controls;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Services.Convertors;
using Reflection.ReportingServices;
using Reflection.Presentation.Common;
using System.Collections.Specialized;
using Reflection.BusinessEntity.ADM;
using Reflection.BusinessEntity.MM;
using System.Threading.Tasks;
using Reflection.BusinessEntity.COM;

namespace Reflection.Modules.MM.ViewModels
{
    public class MM_T001_VM : WorkspaceViewModel<MM_T003>
    {
        #region AutoSuggest Initialization
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
                    if (SourceName == "batch_no")
                    { AS_DEFAULT = AS_BATCH; }
                    if (SourceName == "wc_code")
                    { AS_DEFAULT = AS_WC; }
                    if (SourceName == "item_code")
                    { AS_DEFAULT = AS_ITEM; }
                    if (SourceName == "store_code")
                    { AS_DEFAULT = AS_STORE; }
                    if (SourceName == "unit_code")
                    { AS_DEFAULT = AS_UOM; }
                    if (SourceName == "counter_unit")
                    { AS_DEFAULT = AS_UOM_COUNTER; }
                    if (SourceName == "order_no")
                    { AS_DEFAULT = AS_ORDERS; }
                    if (SourceName == "item_cat")
                    { AS_DEFAULT = AS_LINE_CATEGORY; }
                    else if (SourceName == "equip_no")
                    { AS_DEFAULT = AS_EQUIPMENT; }

                }
            }
        }
        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }
        private AutoSuggestTextViewModel<dynamic> _AS_DEFAULT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_DEFAULT
        {
            get { return _AS_DEFAULT; }
            set
            {
                if (_AS_DEFAULT != value)
                {
                    _AS_DEFAULT = value; RaisePropertyChanged("AS_DEFAULT");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_UOM { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_UOM
        {
            get { return _AS_UOM; }
            set
            {
                if (_AS_UOM != value)
                {
                    _AS_UOM = value; RaisePropertyChanged("AS_UOM");
                }
            }
        }
       
        private AutoSuggestTextViewModel<dynamic> _AS_UOM_COUNTER { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_UOM_COUNTER
        {
            get { return _AS_UOM_COUNTER; }
            set
            {
                if (_AS_UOM_COUNTER != value)
                {
                    _AS_UOM_COUNTER = value; RaisePropertyChanged("AS_UOM_COUNTER");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_EQUIPMENT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_EQUIPMENT
        {
            get { return _AS_EQUIPMENT; }
            set
            {
                if (_AS_EQUIPMENT != value)
                {
                    _AS_EQUIPMENT = value; RaisePropertyChanged("AS_EQUIPMENT");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_BATCH { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_BATCH
        {
            get { return _AS_BATCH; }
            set
            {
                if (_AS_BATCH != value)
                {
                    _AS_BATCH = value; RaisePropertyChanged("AS_BATCH");
                }
            }
        }
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
        private AutoSuggestTextViewModel<dynamic> _AS_STORE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_STORE
        {
            get { return _AS_STORE; }
            set
            {
                if (_AS_STORE != value)
                {
                    _AS_STORE = value; RaisePropertyChanged("AS_STORE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_DOC_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_DOC_TYPE
        {
            get { return _AS_DOC_TYPE; }
            set
            {
                if (_AS_DOC_TYPE != value)
                {
                    _AS_DOC_TYPE = value; RaisePropertyChanged("AS_DOC_TYPE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_PRIORITY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_PRIORITY
        {
            get { return _AS_PRIORITY; }
            set
            {
                if (_AS_PRIORITY != value)
                {
                    _AS_PRIORITY = value; RaisePropertyChanged("AS_PRIORITY");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_DEPARTMENT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_DEPARTMENT
        {
            get { return _AS_DEPARTMENT; }
            set
            {
                if (_AS_DEPARTMENT != value)
                {
                    _AS_DEPARTMENT = value; RaisePropertyChanged("AS_DEPARTMENT");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_EMPLOYEE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_EMPLOYEE
        {
            get { return _AS_EMPLOYEE; }
            set
            {
                if (_AS_EMPLOYEE != value)
                {
                    _AS_EMPLOYEE = value; RaisePropertyChanged("AS_EMPLOYEE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_BOM { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_BOM
        {
            get { return _AS_BOM; }
            set
            {
                if (_AS_BOM != value)
                {
                    _AS_BOM = value; RaisePropertyChanged("AS_BOM");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_ITEM { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ITEM
        {
            get { return _AS_ITEM; }
            set
            {
                if (_AS_ITEM != value)
                {
                    _AS_ITEM = value; RaisePropertyChanged("AS_ITEM");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_WC { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_WC
        {
            get { return _AS_WC; }
            set
            {
                if (_AS_WC != value)
                {
                    _AS_WC = value; RaisePropertyChanged("AS_WC");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _REF_DOC { get; set; }
        public AutoSuggestTextViewModel<dynamic> REF_DOC
        {
            get { return _REF_DOC; }
            set
            {
                if (_REF_DOC != value)
                {
                    _REF_DOC = value; RaisePropertyChanged("REF_DOC");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_ORDERS { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ORDERS
        {
            get { return _AS_ORDERS; }
            set
            {
                if (_AS_ORDERS != value)
                {
                    _AS_ORDERS = value; RaisePropertyChanged("AS_ORDERS");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_STATUS { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_STATUS
        {
            get { return _AS_STATUS; }
            set
            {
                if (_AS_STATUS != value)
                {
                    _AS_STATUS = value; RaisePropertyChanged("AS_STATUS");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_LINE_CATEGORY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_LINE_CATEGORY
        {
            get { return _AS_LINE_CATEGORY; }
            set
            {
                if (_AS_LINE_CATEGORY != value)
                {
                    _AS_LINE_CATEGORY = value; RaisePropertyChanged("AS_LINE_CATEGORY");
                }
            }
        }
        #endregion

        #region Variable Declaration
        bool isNewRecord = true;
        WebServiceRepository<MM_T003> REPO = new WebServiceRepository<MM_T003>();
        WebServiceRepository<MC_MM_T003> REPO_MC = new WebServiceRepository<MC_MM_T003>();
        WebServiceRepository<MC_MM_T003> REPO_MC_TEMP = new WebServiceRepository<MC_MM_T003>();
        ObjectSerializationService obj = new ObjectSerializationService();

        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string doc_cat_vm { get; set; }

        private MC_MM_T003 _MC = new MC_MM_T003();
        public MC_MM_T003 MC
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
        private MC_MM_T003 _MCTemp = new MC_MM_T003();
        public MC_MM_T003 MCTemp
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
        private STD_DOC_TYPE _DOC_TYPE_OBJ;
        public STD_DOC_TYPE DOC_TYPE_OBJ
        {
            get { return _DOC_TYPE_OBJ; }
            set
            {
                if (_DOC_TYPE_OBJ != value)
                {
                    _DOC_TYPE_OBJ = value;
                    RaisePropertyChanged(nameof(DOC_TYPE_OBJ));
                }
            }
        }
        private string _store_location;
        public string store_location
        {
            get { return _store_location; }
            set
            {
                if (_store_location != value)
                {
                    _store_location = value; RaisePropertyChanged("store_location");
                }
            }
        }
        private STD_LIST_BE _REF_OBJECT;
        public STD_LIST_BE REF_OBJECT
        {
            get { return _REF_OBJECT; }
            set
            {
                if (_REF_OBJECT != value)
                {
                    _REF_OBJECT = value; RaisePropertyChanged("REF_OBJECT");
                }
            }
        }
        private STD_REQ_PARA_BE _REQUEST_PARA;
        public STD_REQ_PARA_BE REQUEST_PARA
        {
            get { return _REQUEST_PARA; }
            set
            {
                if (_REQUEST_PARA != value)
                {
                    _REQUEST_PARA = value;

                    RaisePropertyChanged("REQUEST_PARA");
                }
            }
        }
        public List<ADM_M002> _ObjCompany = new List<ADM_M002>();
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
        public List<ADM_M003> _ObjLocation = new List<ADM_M003>();
        private List<ADM_M003> ObjLocation
        {
            get { return _ObjLocation; }
            set
            {
                if (_ObjLocation != value)
                {
                    _ObjLocation = value;
                }
            }
        }
       
        private MM_T003 _MasterEntity;
        public MM_T003 MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value; RaisePropertyChanged("MasterEntity");
                    //value.BeginEdit();
                }
            }
        }
       
        private ObservableCollection<MM_T003_A> _ItemsEntity;
        public ObservableCollection<MM_T003_A> ItemsEntity
        {
            get { return _ItemsEntity; }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value; RaisePropertyChanged("ItemsEntity");
                    ItemsEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItemsEntity);
                }
            }
        }
        private List<COM_T011> _ReleaseList;
        public List<COM_T011> ReleaseList
        {
            get
            {
                return _ReleaseList;
            }
            set
            {
                if (_ReleaseList != value)
                {
                    _ReleaseList = value;
                    RaisePropertyChanged("ReleaseList");
                }
            }
        }
        private MM_T003_A _MM_T003_A_OBJ;
        public MM_T003_A MM_T003_A_OBJ
        {
            get { return _MM_T003_A_OBJ; }
            set
            {
                _MM_T003_A_OBJ = value; RaisePropertyChanged("MM_T003_A_OBJ");
            }
        }

        private int _dgSelectedIndexItem;
        public int dgSelectedIndexItem
        {
            get
            {
                return _dgSelectedIndexItem;
            }
            set
            {
                if (_dgSelectedIndexItem != value)
                {
                    _dgSelectedIndexItem = value;
                    RaisePropertyChanged("dgSelectedIndexItem");
                    //if (TotalDocumentTaxesItem.Count > 0)
                    //{
                    //    TotalDocumentTaxesItem = new ObservableCollection<PUR_T005_C>(TotalDocumentTaxes.Where(tax => tax.ItemCode == ItemsEntity[dgSelectedIndexItem].ItemCode && tax.sku == ItemsEntity[dgSelectedIndexItem].sku && tax.item_line_id == ItemsEntity[dgSelectedIndexItem].id));
                    //}
                }
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

        #region Model Entity Update
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = MasterEntity.HasErrors;
            if (sender.ToString() == "ref_doc_no")
            {
                if (!string.IsNullOrWhiteSpace(MasterEntity.ref_doc_no) && MC.ORDER_LIST != null)
                {
                    if (MC.ORDER_LIST.Count > 0)
                    {
                        try
                        {
                            MasterEntity.bom_no = MC.ORDER_LIST.Where(b => b.order_no == MasterEntity.ref_doc_no).ToList()[0].bom_no;
                        }
                        catch (Exception ex)
                        { }

                    }
                }
            }
            else if (sender.ToString() == "emp_id")
            {
                if (!string.IsNullOrWhiteSpace(MasterEntity.emp_id) && MC.PERSONNEL_LIST != null)
                {
                    if (MC.PERSONNEL_LIST.Count > 0)
                    {
                        try
                        {
                            MasterEntity.dept_code = MC.PERSONNEL_LIST.Where(b => b.emp_id == MasterEntity.emp_id).ToList()[0].dept_code;
                            MasterEntity.dept_name = MC.PERSONNEL_LIST.Where(b => b.emp_id == MasterEntity.emp_id).ToList()[0].dept_name;
                        }
                        catch (Exception ex)
                        { }

                    }
                }
            }
        }
        void ModelUpdated_Item(object sender, EventArgs e)
        {
            this.ErrorExist = MasterEntity.HasErrors;

        }

        #endregion

        #region ICollection
        private ICollectionView _BACKFLIP_COLLECTION;
        public ICollectionView BACKFLIP_COLLECTION
        {
            get { return _BACKFLIP_COLLECTION; }
            set { _BACKFLIP_COLLECTION = value; RaisePropertyChanged("BACKFLIP_COLLECTION"); }
        }

        private ICollectionView _ITEM_COLLECTION;
        public ICollectionView ITEM_COLLECTION
        {
            get { return _ITEM_COLLECTION; }
            set
            {
                _ITEM_COLLECTION = value;

                RaisePropertyChanged("ITEM_COLLECTION");
            }
        }
        private IEnumerable _ITEM_BATCH_COLLECTION;
        public IEnumerable ITEM_BATCH_COLLECTION
        {
            get { return _ITEM_BATCH_COLLECTION; }
            set
            {
                _ITEM_BATCH_COLLECTION = value;

                RaisePropertyChanged("ITEM_BATCH_COLLECTION");
            }
        }
        //List<STD_ITEM> BATCH_LIST { get; set; }
        private void FLTR_COL_ITEM()
        {
            if (_ITEM_COLLECTION != null)
            {
                _ITEM_COLLECTION.Refresh();
            }
        }
        private string _FLTR_STR_ITEM;
        public string FLTR_STR_ITEM
        {
            get { return _FLTR_STR_ITEM; }
            set
            {
                _FLTR_STR_ITEM = value;
                RaisePropertyChanged("FLTR_STR_ITEM");
                FLTR_COL_ITEM();
            }
        }
        public bool ITEM_FILTER(object obj)
        {
            var data = obj as STD_ITEM;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FLTR_STR_ITEM))
                {
                    return ((data.item_code != null) && data.item_code.ToLower().Contains(_FLTR_STR_ITEM.ToLower())) ||
                           (data.item_name != null && data.item_name.ToString().ToLower().Contains(_FLTR_STR_ITEM.ToLower())) ||
                           (data.cat_code != null && data.cat_code.ToString().ToLower().Contains(_FLTR_STR_ITEM.ToLower())) ||
                           (data.sub_cat != null && data.sub_cat.ToString().ToLower().Contains(_FLTR_STR_ITEM.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Relay Command

        public RelayCommand<object> cmdInsertItemList { get; private set; }
        //public RelayCommand<object> cmdInsertCompany { get; private set; }
        //public RelayCommand<object> cmdInsertLocation { get; private set; }
        public RelayCommand<object> cmdSC_ITEM { get; private set; } // Selection CHange of item for object set and Batch Filter with store code & Plant

        public RelayCommand<object> cmdInsertItems { get; private set; }
        public RelayCommand<object> DataGridRowDeleteCommand { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdInsertOrder { get; private set; }
        public RelayCommand<object> CmdInsertDocType { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand cmdExecuteReference { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdLoadBackFlipData { get; private set; }
        public RelayCommand<object> cmdInsertEquipment { get; private set; }
        public RelayCommand<object> cmdAcknowledgment { get; private set; }
        public RelayCommand<object> cmdGetInfo { get; private set; }
        public RelayCommand<object> cmdInsertBatch { get; private set; }


        #endregion

        #region DefalutValue
        private void DefaultValues()
        {
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.location_id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.doc_cat = doc_cat_vm;
            MasterEntity.doc_type = doc_cat_vm;
            MasterEntity.dept_code = AppSessionState.dept_code;
            MasterEntity.active = "1";
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.deadline = DateTime.Now;
            MasterEntity.from_date = DateTime.Now;
            MasterEntity.to_date = DateTime.Now;
            MasterEntity.emp_id = AppSessionState.EmpId;
            MasterEntity.ref_doc_no = REF_OBJECT.ref_doc_no;
            MasterEntity.order_qty = 1;

            if (MC.STATUS_LIST != null)
            {
                if(MC.STATUS_LIST.Count > 0)
                {
                    MasterEntity.t_status = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_status).FirstOrDefault();
                    MasterEntity.t_display = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_display).FirstOrDefault();
                }
            }
            if (MC.PERSONNEL_LIST != null)
            {
                if (MC.PERSONNEL_LIST.Where(x => x.emp_id.Equals(MasterEntity.emp_id, StringComparison.OrdinalIgnoreCase)).Count() > 0)
                {
                    MasterEntity.dept_code = MC.PERSONNEL_LIST.Where(x => x.emp_id.Equals(MasterEntity.emp_id, StringComparison.OrdinalIgnoreCase) == true).ToList()[0].dept_code;
                    MasterEntity.dept_name = MC.PERSONNEL_LIST.Where(x => x.emp_id.Equals(MasterEntity.emp_id, StringComparison.OrdinalIgnoreCase) == true).ToList()[0].dept_name;
                }
            }
            if (MC.DOC_TYPE_LIST != null)
            {
                if (MC.DOC_TYPE_LIST.Count > 0)
                {
                    DOC_TYPE_OBJ = (from o in MC.DOC_TYPE_LIST where o.doc_cat == doc_cat_vm && o.default_doc == true select o).FirstOrDefault();
                }
            }
            if (DOC_TYPE_OBJ != null)
            {
                MasterEntity.doc_type = DOC_TYPE_OBJ.doc_type;
                MasterEntity.doc_type_name = DOC_TYPE_OBJ.doc_type_name;
            }
        }
        private void Logging()
        {
            MasterEntity.ts_code = this.ts_code_vm;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.session_id = AppSessionState.session_id;
            MasterEntity.client = AppSessionState.client;

            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
        }
        private bool Validation()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(MasterEntity.doc_cat))
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Please Select Document category........");
                    showMessageService.ShowMessage();

                    return false;
                }
                if (string.IsNullOrWhiteSpace(MasterEntity.doc_type))
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Please Select Document Type........");
                    showMessageService.ShowMessage();

                    return false;
                }
                if (MasterEntity.comp_code == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Please Select Company........");
                    showMessageService.ShowMessage();

                    return false;
                }
                if (MasterEntity.location_id == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Please Select Plant........");
                    showMessageService.ShowMessage();

                    return false;
                }

                if (MasterEntity.emp_id == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Please Select Requester Name........");
                    showMessageService.ShowMessage();

                    return false;
                }

                if (ItemsEntity.Count < 1)//when form is blank and we save the record
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
                    foreach (var o in ItemsEntity)
                    {
                        if (o.item_code != null && o.item_code != "" && o.item_name != null)
                        {
                            int flag = 0;
                            if (o.id == 0)
                            {
                                foreach (var p in ItemsEntity)
                                {
                                    if (o.item_code == p.item_code && o.sku == p.sku && o.line_id==p.line_id && o.id==p.id)
                                    {
                                        flag++;
                                    }
                                }
                                if (flag > 1)
                                {
                                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                    showMessageService.ButtonSetup = DialogButton.Ok;
                                    showMessageService.Caption = "Message";
                                    showMessageService.Text = String.Format("Cannot Save Duplicate Item {0} and Parameter {1}", o.item_code, o.sku_desc);
                                    showMessageService.ShowMessage();
                                    return false;
                                }
                            }


                            // Validation For All Parameter Values Selected or Not


                            if (o.qty == null || o.qty == 0)
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Quantity cannot be null or 0 for the item {0} and Parameter {1}", o.item_code, o.sku_desc);
                                showMessageService.ShowMessage();
                                return false;
                            }
                            if (string.IsNullOrWhiteSpace(o.store_code) && MC.MM_SETTING_LIST[0].ind_store_code == "Y")
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = "Store Code required";
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
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
            return true;
        }
        #endregion

        #region Constructor
        public MM_T001_VM(string ts_code, string doc_cat) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_cat_vm = doc_cat;

            MC = new MC_MM_T003();
            MCTemp = new MC_MM_T003();
            REF_OBJECT = new STD_LIST_BE();
            REQUEST_PARA = new STD_REQ_PARA_BE();
            MasterEntity = new MM_T003();
            ItemsEntity = new ObservableCollection<MM_T003_A>();
            ItemsEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItemsEntity);
            MasterEntity.ValidateAsync().Wait();
            MM_T003.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            MM_T003_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            // ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            DOC_TYPE_OBJ = new STD_DOC_TYPE();
            //LoadInitialData();
            CommandInitialisation();

        }
        public MM_T001_VM(string ts_code, string doc_cat, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            this.doc_cat_vm = doc_cat;

            MC = new MC_MM_T003();
            MCTemp = new MC_MM_T003();
            REF_OBJECT = new STD_LIST_BE();
            REQUEST_PARA = new STD_REQ_PARA_BE();
            MasterEntity = new MM_T003();
            ItemsEntity = new ObservableCollection<MM_T003_A>();
            ItemsEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItemsEntity);
            MasterEntity.ValidateAsync().Wait();
            MM_T003.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            MM_T003_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            // ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            DOC_TYPE_OBJ = new STD_DOC_TYPE();
            //LoadInitialData();
            CommandInitialisation();

        }
        public MM_T001_VM(string ts_code, string doc_cat, string doc_no,STD_LIST_BE REF_OBJ) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            this.doc_cat_vm = doc_cat;

            REF_OBJECT = new STD_LIST_BE();
            REF_OBJECT = REF_OBJ;
            REQUEST_PARA = new STD_REQ_PARA_BE();
            MC = new MC_MM_T003();
            MCTemp = new MC_MM_T003();
            MasterEntity = new MM_T003();
            ItemsEntity = new ObservableCollection<MM_T003_A>();
            ItemsEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItemsEntity);
            MasterEntity.ValidateAsync().Wait();
            MM_T003.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            MM_T003_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            // ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            DOC_TYPE_OBJ = new STD_DOC_TYPE();
            CommandInitialisation();

        }
        public MM_T001_VM(string ts_code, STD_LIST_BE REF_OBJ) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = REF_OBJ.doc_no;
            this.doc_cat_vm = REF_OBJ.doc_cat;

            REF_OBJECT = new STD_LIST_BE();
            REF_OBJECT = REF_OBJ;
            REQUEST_PARA = new STD_REQ_PARA_BE();
            MC = new MC_MM_T003();
            MCTemp = new MC_MM_T003();
            MasterEntity = new MM_T003();
            ItemsEntity = new ObservableCollection<MM_T003_A>();
            ItemsEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItemsEntity);
            MasterEntity.ValidateAsync().Wait();
            MM_T003.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            MM_T003_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            // ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            DOC_TYPE_OBJ = new STD_DOC_TYPE();
            CommandInitialisation();

        }
        #endregion

        #region Method Implementation
        private void LoadInitialData(string comp_code,string plant)
        {
            try
            {
                //MasterEntity = new MM_T003();
                //ItemsEntity = new ObservableCollection<MM_T003_A>();
                //ItemsEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItemsEntity);

                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + comp_code + "!@" + plant + "!@" + doc_cat_vm + "!@" + (MasterEntity.doc_type ?? doc_cat_vm);
                MC = REPO_MC.GetDataWithReturnDomainObject<MC_MM_T003>(MC, Request, "MM_T003_BL", "MM", "LoadAll", 0, "");

                
                #region AutoSuggest Region

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0002)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M0002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0002)o).comp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_COMPANY = new AutoSuggestTextViewModel<dynamic>(MC.COMPANY_LIST, TheFilter, SuggestedValue, "comp_code", true);
                AS_COMPANY.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
                TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_LOCATION = new AutoSuggestTextViewModel<dynamic>(MC.LOCATION_LIST, TheFilter, SuggestedValue, "location_id", true);
                AS_LOCATION.AutoSuggestVM.IsEmptyValueAllowed = false; AS_LOCATION.AutoSuggestVM.IsFreeTextAllowed = false;

                if (MC.LOCATION_LIST.Count == 1)
                {
                    MasterEntity.location_id = MC.LOCATION_LIST[0].location_id;
                }
                else
                {
                    if (REF_OBJECT != null)
                    {
                        MasterEntity.location_id = plant;
                    }
                    else
                    {
                        MasterEntity.location_id = null;
                    }
                }

                List<MM_M0001> STORE_LIST_OBJ = MC.STORE_LIST.Where(x => x.comp_code == comp_code && x.location_id == plant).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M0001)x).store_code);
                TheFilter = (o, prefix) => ((MM_M0001)o).store_code.ToLower().Contains(prefix.ToLower()) || ((MM_M0001)o).store_name.ToLower().Contains(prefix.ToLower());
                AS_STORE = new AutoSuggestTextViewModel<dynamic>(STORE_LIST_OBJ, TheFilter, SuggestedValue, "store_code", "store_code", true);
                AS_STORE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_STORE.AutoSuggestVM.IsFreeTextAllowed = false;

                if (STORE_LIST_OBJ.Count == 1)
                {
                    store_location = STORE_LIST_OBJ[0].store_code;
                }

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_DOC_TYPE)x).doc_type);
                TheFilter = (o, prefix) => ((STD_DOC_TYPE)o).doc_type.ToLower().Contains(prefix.ToLower()) || ((STD_DOC_TYPE)o).doc_type_name.ToLower().Contains(prefix.ToLower());
                AS_DOC_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.DOC_TYPE_LIST, TheFilter, SuggestedValue, "doc_type", true);
                AS_DOC_TYPE.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0040)x).pr_code.ToString());
                TheFilter = (o, prefix) => ((ADM_M0040)o).pr_code.ToString().ToLower().Contains(prefix.ToLower()) || ((ADM_M0040)o).text_name.ToLower().Contains(prefix.ToLower());
                AS_PRIORITY = new AutoSuggestTextViewModel<dynamic>(MC.PRIORITY_LIST, TheFilter, SuggestedValue, "pr_code", true);
                AS_PRIORITY.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).dept_code.ToString());
                TheFilter = (o, prefix) => ((STD_LIST_BE)o).dept_code.ToString().ToLower().Contains(prefix.ToLower()) || ((STD_LIST_BE)o).dept_name.ToString().ToLower().Contains(prefix.ToLower());
                AS_DEPARTMENT = new AutoSuggestTextViewModel<dynamic>(MC.DEPARTMENT_LIST, TheFilter, SuggestedValue, "dept_code", true);
                AS_DEPARTMENT.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PERSONNEL)x).emp_id.ToString());
                TheFilter = (o, prefix) => ((STD_PERSONNEL)o).emp_id.ToString().ToLower().Contains(prefix.ToLower()) || ((STD_PERSONNEL)o).emp_name.ToString().ToLower().Contains(prefix.ToLower());
                AS_EMPLOYEE = new AutoSuggestTextViewModel<dynamic>(MC.PERSONNEL_LIST, TheFilter, SuggestedValue, "emp_id", true);
                AS_EMPLOYEE.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).doc_no.ToString());
                TheFilter = (o, prefix) => ((STD_LIST_BE)o).doc_no.ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).short_text ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_BOM = new AutoSuggestTextViewModel<dynamic>(MC.BOM_LIST, TheFilter, SuggestedValue, "doc_no", true);
                AS_BOM.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).item_code.ToString());
                TheFilter = (o, prefix) => ((STD_ITEM)o).item_code.ToString().ToLower().Contains(prefix.ToLower()) || ((STD_ITEM)o).item_name.ToString().ToLower().Contains(prefix.ToLower());
                AS_ITEM = new AutoSuggestTextViewModel<dynamic>(MC.ITEM_LIST, TheFilter, SuggestedValue, "item_code", "item_name", true);
                AS_ITEM.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).wc_code.ToString());
                TheFilter = (o, prefix) => ((STD_LIST_BE)o).wc_code.ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).wc_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_WC = new AutoSuggestTextViewModel<dynamic>(MC.WC_LIST, TheFilter, SuggestedValue, "wc_code", "wc_code", true);
                AS_WC.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).ref_doc_no.ToString());
                TheFilter = (o, prefix) => ((STD_LIST_BE)o).ref_doc_no.ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).item_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).item_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).title ?? "").ToString().ToLower().Contains(prefix.ToLower());
                REF_DOC = new AutoSuggestTextViewModel<dynamic>(MC.ORDER_LIST, TheFilter, SuggestedValue, "ref_doc_no", "ref_doc_no", true);
                REF_DOC.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).order_no.ToString());
                TheFilter = (o, prefix) => ((STD_LIST_BE)o).order_no.ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).item_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).item_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).title ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_ORDERS = new AutoSuggestTextViewModel<dynamic>(MC.ORDER_LIST, TheFilter, SuggestedValue, "order_no", "order_no", true);
                AS_ORDERS.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code.ToString());
                TheFilter = (o, prefix) => ((UOMS)o).unit_code.ToString().ToLower().Contains(prefix.ToLower()) || ((UOMS)o).unit_name.ToString().ToLower().Contains(prefix.ToLower());
                AS_UOM_COUNTER = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST.Where(x => x.unit_code != null).ToList(), TheFilter, SuggestedValue, "counter_unit", "unit_code", true);
                AS_UOM_COUNTER.AutoSuggestVM.IsEmptyValueAllowed = true; AS_UOM_COUNTER.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code.ToString());
                TheFilter = (o, prefix) => ((UOMS)o).unit_code.ToString().ToLower().Contains(prefix.ToLower()) || ((UOMS)o).unit_name.ToString().ToLower().Contains(prefix.ToLower());
                AS_UOM = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST.Where(x => x.unit_code != null).ToList(), TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                AS_UOM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_UOM.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).equip_no.ToString());
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).equip_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).equip_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).emp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_EQUIPMENT = new AutoSuggestTextViewModel<dynamic>(MC.EQUIPMENT_LIST, TheFilter, SuggestedValue, "equip_no", "equip_no", true);
                AS_EQUIPMENT.AutoSuggestVM.IsEmptyValueAllowed = true; AS_EQUIPMENT.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).item_cat.ToString());
                TheFilter = (o, prefix) => ((STD_LIST_BE)o).item_cat.ToString().ToLower().Contains(prefix.ToLower()) || ((STD_LIST_BE)o).item_cat_name.ToString().ToLower().Contains(prefix.ToLower());
                AS_LINE_CATEGORY = new AutoSuggestTextViewModel<dynamic>(MC.LINE_CAT_LIST, TheFilter, SuggestedValue, "equip_no", "equip_no", true);
                AS_LINE_CATEGORY.AutoSuggestVM.IsEmptyValueAllowed = true; AS_LINE_CATEGORY.AutoSuggestVM.IsFreeTextAllowed = false;

                #endregion

                ITEM_COLLECTION = (ICollectionView)CollectionViewSource.GetDefaultView(MC.ITEM_LIST);
                ITEM_COLLECTION.Filter = new Predicate<object>(ITEM_FILTER);

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
        private void CommandInitialisation()
        {
            #region Command Initialisation
            cmdInsertItemList = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItemList(cmdPara); });
            //cmdInsertCompany = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCompany(cmdPara); });
            //cmdInsertLocation = new RelayCommand<object>(items => { if (items == null) { return; } InsertLocation(items); });
            cmdSC_ITEM = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } SelectionChangedItem(cmdPara); });
            cmdInsertItems = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_Item(cmdPara); });
            cmdInsertOrder = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertOrder(cmdPara, false, true, true); });
            CommandLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
            DataGridRowDeleteCommand = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });
            CmdInsertDocType = new RelayCommand<object>(items => { if (items == null) { return; } InsertDocType(items); });
            cmdExecuteReference = new GalaSoft.MvvmLight.Command.RelayCommand(() => { ExecuteReference(); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            cmdLoadBackFlipData = new RelayCommand<object>(items => { if (items == null) { return; } LoadBackFlipData(items); });
            cmdInsertEquipment = new RelayCommand<object>(items => { if (items == null) { return; } InsertEquipment(items); });
            cmdAcknowledgment = new RelayCommand<object>(items => { if (items == null) { return; } UpdateAcknowledgment(items); });
            cmdGetInfo = new RelayCommand<object>(items => { if (items == null) { return; } GetInformation(items); });
            cmdInsertBatch = new RelayCommand<object>(items => { if (items == null) { return; } InsertDataGridRow_Batch(items); });
            #endregion
        }
        private void LoadBackFlipData(object Parameter)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + (REQUEST_PARA.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@" + (REQUEST_PARA.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + MasterEntity.doc_cat + "!@" + (Utilities.NullIf(REQUEST_PARA.doc_type ?? MasterEntity.doc_type) ?? "") + "!@" + REQUEST_PARA.active_code + "!@" + (Utilities.NullIf(REQUEST_PARA.t_status) ?? "") + "!@" + Utilities.NullIf(REQUEST_PARA.emp_id) + "!@"  + Convert.ToDateTime(REQUEST_PARA.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQUEST_PARA.to_date).ToString("MM/dd/yyyy");
                MCTemp = REPO_MC_TEMP.GetDataWithReturnDomainObject<MC_MM_T003>(MCTemp, Request, "MM_T003_BL", "MM", "LoadAll", 0, "");

                BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(MCTemp.BACK_FLIP_LIST);
                BACKFLIP_COLLECTION.Filter = new Predicate<object>(FLTR_BACKFLIP);

                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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
        //private void InsertCompany(object InputValue)
        //{
        //    try
        //    {
        //        CursorControl.SetBusyState();
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
        //            if(!string.IsNullOrWhiteSpace(MasterEntity.comp_code) && !string.IsNullOrWhiteSpace(MasterEntity.location_id))
        //            {
        //                LoadInitialData(MasterEntity.comp_code, MasterEntity.location_id);
        //            }
        //            MasterEntity.comp_code = POPUPEntityObject.comp_code;

        //            if (MC.LOCATION_LIST.Count == 1)
        //            {
        //                MasterEntity.location_id = MC.LOCATION_LIST[0].location_id;

        //                List<MM_M0001> STORE_LIST_OBJ = MC.STORE_LIST.Where(x => x.comp_code == MasterEntity.comp_code && x.location_id == MasterEntity.location_id).ToList();
        //                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M0001)x).store_code);
        //                TheFilter = (o, prefix) => ((MM_M0001)o).store_code.ToLower().Contains(prefix.ToLower()) || ((MM_M0001)o).store_name.ToLower().Contains(prefix.ToLower());
        //                AS_STORE = new AutoSuggestTextViewModel<dynamic>(STORE_LIST_OBJ, TheFilter, SuggestedValue, "store_code", "store_code", true);
        //                AS_STORE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_STORE.AutoSuggestVM.IsFreeTextAllowed = false;

        //                if (STORE_LIST_OBJ.Count == 1)
        //                {
        //                    store_location = STORE_LIST_OBJ[0].store_code;
        //                }
        //            }
        //            else
        //            {
        //                MasterEntity.location_id = null;
        //            }
        //        }
        //        //}
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
        
        //private void InsertLocation(object InputValue)
        //{
        //    try
        //    {
        //        string Request = "";
        //        ADM_M0003 POPUP_ENTITY_OBJ = null;
        //        #region Command Parameter Read Section
        //        try
        //        {
        //            if (InputValue.GetType() == typeof(string) && InputValue != null)
        //            {
        //                Request = InputValue.ToString();
        //                if (Request.Length > 0)
        //                {
        //                    try
        //                    { POPUP_ENTITY_OBJ = MC.LOCATION_LIST.Where(x => x.location_id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.comp_code == MasterEntity.comp_code).ToList()[0]; }
        //                    catch (Exception ex) { }
        //                }
        //            }
        //            else if (InputValue != null)
        //            {
        //                POPUP_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<ADM_M0003>().ToList()[0];
        //            }
        //        }
        //        catch (Exception ex) { }
        //        #endregion
        //        if (POPUP_ENTITY_OBJ != null)
        //        {
        //            MasterEntity.location_id = POPUP_ENTITY_OBJ.location_id;
        //            MasterEntity.comp_code = POPUP_ENTITY_OBJ.comp_code;
        //            if (!string.IsNullOrWhiteSpace(MasterEntity.comp_code) && !string.IsNullOrWhiteSpace(MasterEntity.location_id))
        //            {
        //                LoadInitialData(MasterEntity.comp_code, MasterEntity.location_id);
        //            }
        //            MasterEntity.comp_code = POPUP_ENTITY_OBJ.comp_code;
        //            MasterEntity.location_id = POPUP_ENTITY_OBJ.location_id;

        //            List<MM_M0001> STORE_LIST_OBJ = MC.STORE_LIST.Where(x => x.comp_code == MasterEntity.comp_code && x.location_id == MasterEntity.location_id).ToList();
        //            SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M0001)x).store_code);
        //            TheFilter = (o, prefix) => ((MM_M0001)o).store_code.ToLower().Contains(prefix.ToLower()) || ((MM_M0001)o).store_name.ToLower().Contains(prefix.ToLower());
        //            AS_STORE = new AutoSuggestTextViewModel<dynamic>(STORE_LIST_OBJ, TheFilter, SuggestedValue, "store_code", "store_code", true);
        //            AS_STORE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_STORE.AutoSuggestVM.IsFreeTextAllowed = false;

        //            if (STORE_LIST_OBJ.Count == 1)
        //            {
        //                store_location = STORE_LIST_OBJ[0].store_code;
        //            }
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
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";
                string ParametersStringValue = "";
                STD_LIST_BE ParameterEntityObject = null;
                if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList()[0];
                        Request = "LOAD_DOC_BY_DOC_NO" + "!@" + AppSessionState.client + "!@" + ParameterEntityObject.comp_code + "!@" + ParameterEntityObject.location_id + "!@" + ParameterEntityObject.doc_cat + "!@" + ParameterEntityObject.doc_type + "!@" + ParameterEntityObject.doc_no;

                        isNewRecord = false;
                        MCTemp = REPO_MC_TEMP.GetDataWithReturnDomainObject<MC_MM_T003>(MCTemp, Request, "MM_T003_BL", "MM", "", 0, Request);
                        if (MCTemp.MASTER_ENTITY_LIST.Count > 0)
                        {
                            ReleaseList = MCTemp.WORKFLOW_LIST; // NOTE: if we put this code after item, it will not work because item entity change fire and take another servier trip and this data becode null in return MC object. need to fix this property change calling while just assigment.
                            MasterEntity = MCTemp.MASTER_ENTITY_LIST[0];
                            ItemsEntity = MCTemp.ITEMS_ENTITY_LIST;
                            MasterEntity.ts_code = ts_code_vm;
                            
                        }
                        SelectedTabControlIndex = 0;
                    }
                }
                SetBusinessEntitiesAfterLoad(ParametersStringValue, "");
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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
        private void ExecuteReference()
        {
            if (!string.IsNullOrWhiteSpace(MasterEntity.ref_doc_no) && !string.IsNullOrWhiteSpace(MasterEntity.bom_no) && MasterEntity.order_qty.HasValue)
            {
                //MC_MM_T001 MCTempGRN = new MC_MM_T001();
                //WebServiceRepository<MC_MM_T001> repositoryMG = new WebServiceRepository<MC_MM_T001>();
                string Request = "ExecuteReference" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + MasterEntity.ref_doc_no + "!@" + MasterEntity.bom_no + "!@" + MasterEntity.order_qty.ToString() + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId;
                //MCTempGRN = repositoryMG.GetDataWithReturnDomainObject<MC_MM_T001>(MCTempGRN, Request, "MM_T003_BL", "MM", "LoadAll", 0, "");
                MCTemp = REPO_MC.GetDataWithReturnDomainObject<MC_MM_T003>(MCTemp, Request, "MM_T003_BL", "MM", "LoadAll", 0, "");
                MasterEntity.ts_code = ts_code_vm;

                ItemsEntity.Clear();
                foreach (var obj in MCTemp.ITEMS_ENTITY_LIST)
                {
                    MM_T003_A item = new MM_T003_A();
                    item.doc_cat = "IO";
                    item.doc_type = "IO";
                    item.location_id = MasterEntity.location_id ?? AppSessionState.OBJ_LOCATION.location_id;
                    item.comp_code = MasterEntity.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code;
                    item.userid = AppSessionState.UserID;
                    item.active = "1";
                    item.order_no = MasterEntity.ref_doc_no;
                    item.t_status = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_status).FirstOrDefault();
                    item.t_display = (from o in MC.STATUS_LIST where o.t_status == item.t_status select o.t_display).FirstOrDefault();
                    item.active = "1";
                    item.appr_qty = 0;
                    item.item_code = obj.item_code;
                    item.item_name = obj.item_name;
                    item.item_cat = "A";
                    item.line_id = ItemsEntity.Count + 1;
                    item.order_no = obj.order_no;
                    item.qty = obj.qty;
                    item.sku = obj.sku;
                    item.sku_desc = obj.sku_desc;
                    item.store_code = obj.store_code;
                    item.ts_code = this.ts_code_vm;
                    item.unit_code = obj.unit_code;
                    item.userid = AppSessionState.UserID;

                    ItemsEntity.Add(item);

                }

                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
        }
        private void InsertDocType(object InputValue)
        {
            try
            {
                string Request = "";
                STD_DOC_TYPE POPUPEntityObject = null;
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        POPUPEntityObject = MC.DOC_TYPE_LIST.Where(x => x.doc_type_user.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_DOC_TYPE>().ToList()[0];
                }
                #endregion             
                if (POPUPEntityObject != null)
                {
                    MasterEntity.doc_type = POPUPEntityObject.doc_type;
                    MasterEntity.doc_type_name = POPUPEntityObject.doc_type_name;
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertEquipment(object InputValue)
        {
            try
            {
                string Request = "";
                STD_LIST_BE POPUPEntityObject = null;
                #region Command Parameter Read Section     
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        POPUPEntityObject = MC.EQUIPMENT_LIST.Where(x => x.equip_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    MM_T003_A_OBJ.equip_no = POPUPEntityObject.equip_no;
                    if (string.IsNullOrWhiteSpace(MM_T003_A_OBJ.note)) // NOTE: temp solution, remove is standard way found
                    {
                        MM_T003_A_OBJ.note = POPUPEntityObject.equip_name;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void UpdateAcknowledgment(object InputValue)
        {
            try
            {
                CursorControl.SetBusyState();
                if (Validation() == true)
                {
                    MasterEntity.XDOC_A = obj.ObjectToXML(ItemsEntity);
                    MasterEntity.user_source1 = AppSessionState.UserSource1;
                    MasterEntity.user_source2 = AppSessionState.UserSource2;
                    MasterEntity.userid = AppSessionState.UserID;

                    if(MC.STATUS_LIST != null)
                    {
                        MasterEntity.t_status =  (from o in MC.STATUS_LIST where o.ind_ack == "1" select o.t_status).FirstOrDefault();
                        MasterEntity.t_display = (from o in MC.STATUS_LIST where o.ind_ack == "1" select o.t_display).FirstOrDefault();
                    }

                    if (isNewRecord == false)
                    {
                        MasterEntity = REPO.UpdateWithReturnDomainObject<MM_T003>(MasterEntity, "MM_T003_BL", "MM");
                        if (MasterEntity.doc_no != " " || MasterEntity.doc_no != null)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Acknowledgement Update Successfully");
                            showMessageService.ShowMessage();
                        }
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    isNewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void CollectionChangedNotifyForItemsEntity(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (MM_T003_A item in e.NewItems)
                    {
                        item.id = 0;
                        item.active = "1";
                        item.client = AppSessionState.client;
                        item.comp_code = MasterEntity.comp_code;
                        item.location_id = MasterEntity.location_id;
                        item.t_status = MasterEntity.t_status;
                        item.line_id = ItemsEntity.Count;
                        item.doc_no = MasterEntity.doc_no;
                        item.doc_cat = MasterEntity.doc_cat;
                        item.doc_type = MasterEntity.doc_type;
                        item.t_status = MasterEntity.t_status;
                        item.t_display = MasterEntity.t_display;
                        item.store_code = store_location;
                        item.order_no = MasterEntity.ref_doc_no;
                        item.qty = item.qty ?? 1;

                        if (REF_OBJECT != null)
                        {
                            item.equip_no = REF_OBJECT.equip_no;
                            item.equip_counter = Convert.ToDecimal(REF_OBJECT.read_value);
                            item.counter_unit = REF_OBJECT.unit_code;
                            item.note = item.note ?? REF_OBJECT.equip_name;
                        }

                        MM_T003_A_OBJ = item; // New row created and added to object instance// when item get added without row adding but this function all like from InsertItemList(). other place instance of row created but from bulk adding it is not.
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Remove) //NOTE: use this section to remove dependant entries. like if Operation remove then all char data need to remove from Char Entity
                {
                    
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertDataGridRow_Item(object InputValue)
        {
            string Request = "";
            STD_ITEM POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ITEM_LIST.Where(x => x.item_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_ITEM>().ToList()[0];
                }
                if (POPUPEntityObject != null && MM_T003_A_OBJ != null)
                {
                    MM_T003_A_OBJ.item_code = POPUPEntityObject.item_code;
                    MM_T003_A_OBJ.item_name = POPUPEntityObject.item_name;
                    MM_T003_A_OBJ.unit_code = POPUPEntityObject.unit_code;
                    MM_T003_A_OBJ.sub_cat = POPUPEntityObject.item_subcat;
                    MM_T003_A_OBJ.ind_vc = POPUPEntityObject.ind_vc;
                    MM_T003_A_OBJ.location_id = MasterEntity.location_id;
                    MM_T003_A_OBJ.store_code = store_location;
                    MM_T003_A_OBJ.comp_code = MasterEntity.comp_code;
                    MM_T003_A_OBJ.active = "1"; 
                    MM_T003_A_OBJ.t_status = MasterEntity.t_status;
                    MM_T003_A_OBJ.t_display = MasterEntity.t_display;
                    MM_T003_A_OBJ.order_no = MasterEntity.ref_doc_no;
                    MM_T003_A_OBJ.doc_cat = MasterEntity.doc_cat;
                    MM_T003_A_OBJ.doc_type = MasterEntity.doc_type;
                    //MM_T003_A_OBJ.qty = POPUPEntityObject.qty;

                    //if(POPUPEntityObject.cat_code == "AS" && POPUPEntityObject.stock_total <= 0)
                    //{
                    //GetBatchData(MM_T003_A_OBJ);
                    //}
                }
            }
            catch (Exception ex) { }

        }
        private void InsertItemList(object InputValue)
        {
            try
            {
                STD_ITEM OBJ_STD = new STD_ITEM();
                OBJ_STD = (STD_ITEM)InputValue;

                if (MC.ITEM_LIST != null && OBJ_STD != null)
                {
                    MM_T003_A_OBJ = new MM_T003_A();
                    ItemsEntity.Add(MM_T003_A_OBJ);
                    InsertDataGridRow_Item(OBJ_STD.item_code);
                    OBJ_STD.selected = false;
                }

                //if (MC.ITEM_LIST != null)
                //{
                //    foreach (var item in MC.ITEM_LIST)
                //    {
                //        if(item.selected == true)
                //        {
                //            ItemsEntity.Add(new MM_T003_A()); // This will just add new row and assign MM_T003_A_OBJ to newly added row.
                //            InsertDataGridRow_Item(item.item_code);
                //            item.selected = false;
                //        }
                //    }
                //}
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex) { }
        }
        private void SelectionChangedItem(object InputValue)
        {
            try
            {
                if ((MM_T003_A)InputValue != null) //.NewItemPlaceholder
                {
                    MM_T003_A_OBJ = (MM_T003_A)InputValue;

                    if (!string.IsNullOrWhiteSpace(MM_T003_A_OBJ.item_code))
                    {
                        if (MC.BATCH_LIST.Exists(x => x.item_code == MM_T003_A_OBJ.item_code) == false)
                        {
                            GetBatchData(MM_T003_A_OBJ);
                        }
                    }

                    var temp = (from o in MC.BATCH_LIST
                                where o.item_code == MM_T003_A_OBJ.item_code && (o.sku ?? "") == (MM_T003_A_OBJ.sku ?? "") && o.comp_code == MasterEntity.comp_code && o.location_id == MasterEntity.location_id && o.store_code == MM_T003_A_OBJ.store_code
                                select o);

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).batch_no);
                    TheFilter = (o, prefix) => (((STD_ITEM)o).batch_no ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    AS_BATCH = new AutoSuggestTextViewModel<dynamic>(temp.ToList(), TheFilter, SuggestedValue, "batch_no", "batch_no", true);
                    AS_BATCH.AutoSuggestVM.IsEmptyValueAllowed = true; AS_BATCH.AutoSuggestVM.IsFreeTextAllowed = false;


                    //ITEM_BATCH_COLLECTION = (ICollectionView)CollectionViewSource.GetDefaultView(temp.ToList());
                    //var Emps = from emp in Employees where emp.FullName.Contains(txtInput.Text) || (emp.Contact ?? "").Contains(txtInput.Text) select emp;
                    ITEM_BATCH_COLLECTION = temp;
                    //var Emps = from temp in MC.BATCH_LIST where bat.FullName.Contains(txtInput.Text) select batch_no;
                    //ITEM_BATCH_COLLECTION.Filter = new Predicate<object>(ITEM_FILTER);

                }
                // commented because exist non exist must refresh popup loist other wise it will show previous item list if not clear. once confirm that working fine remove this code.
                //if (!string.IsNullOrWhiteSpace(MM_T003_A_OBJ.item_code))
                //{
                //    if (MC.BATCH_LIST.Exists(x => x.item_code == MM_T003_A_OBJ.item_code) == true)
                //    {
                //        var temp = (from o in MC.BATCH_LIST
                //                    where o.item_code == MM_T003_A_OBJ.item_code && (o.sku ?? "") == (MM_T003_A_OBJ.sku ?? "") && o.comp_code == MasterEntity.comp_code && o.location_id == MasterEntity.location_id && o.store_code == MM_T003_A_OBJ.store_code
                //                    select o);

                //        SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).batch_no);
                //        TheFilter = (o, prefix) => (((STD_ITEM)o).batch_no ?? "").ToString().ToLower().Contains(prefix.ToLower());
                //        AS_BATCH = new AutoSuggestTextViewModel<dynamic>(temp.ToList(), TheFilter, SuggestedValue, "batch_no", "batch_no", true);
                //        AS_BATCH.AutoSuggestVM.IsEmptyValueAllowed = true; AS_BATCH.AutoSuggestVM.IsFreeTextAllowed = false;
                //    }
                //}
            }
            catch (Exception ex)
            {
            }
        }
        private void GetBatchData(MM_T003_A para)
        {
            if (MM_T003_A_OBJ != null)
            {
                if (MM_T003_A_OBJ != null)
                {
                    CursorControl.SetBusyState();
                    string Request = "GET_BATCH_DATA" + "!@" + AppSessionState.client + "!@" + MM_T003_A_OBJ.comp_code + "!@" + MM_T003_A_OBJ.location_id + "!@" + doc_cat_vm + "!@" + (Utilities.NullIf(MM_T003_A_OBJ.doc_type ?? doc_cat_vm) ?? "") + "!@" + MM_T003_A_OBJ.item_code + "!@" + Utilities.NullIf(MasterEntity.emp_id) + "!@" + Utilities.NullIf(MasterEntity.t_status) + "!@" + Convert.ToDateTime(MasterEntity.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(MasterEntity.to_date).ToString("MM/dd/yyyy");
                    MCTemp = REPO_MC_TEMP.GetDataWithReturnDomainObject<MC_MM_T003>(MCTemp, Request, "MM_T003_BL", "MM", "LoadAll", 0, "");

                    if (MCTemp.BATCH_LIST != null)
                    {
                        if (MCTemp.BATCH_LIST.Count > 0)
                        {
                            foreach (var item in MCTemp.BATCH_LIST)
                            {
                                MC.BATCH_LIST.Add(item);
                            }
                        }
                    }
                    //if (MCTemp.STANDARD_LIST.Count > 0) // STANDARD_LIST was added to check asset stock data but it is already added in item list poup
                    //{
                    //    STD_LIST_BE OBJ_BE = new STD_LIST_BE();
                    //    OBJ_BE = MCTemp.STANDARD_LIST[0];
                    //    if (OBJ_BE.stock_total <= 0) // && OBJ_BE.item_cat == "AS"
                    //    {
                    //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    //        showMessageService.ButtonSetup = DialogButton.Ok;
                    //        showMessageService.Caption = "Message";
                    //        showMessageService.Text = String.Format("Out of Stock or is already issued to other user, for more detail, use info button in item grid", this.Title);
                    //        showMessageService.ShowMessage();
                    //    }
                    //}
                    //else
                    //{
                    //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    //    showMessageService.ButtonSetup = DialogButton.Ok;
                    //    showMessageService.Caption = "Message";
                    //    showMessageService.Text = String.Format("Out of Stock or is already issued to other user, for more detail, use info button in item grid", this.Title);
                    //    showMessageService.ShowMessage();
                    //}

                }
            }
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
        }
        private void GetInformation(object para)
        {
            if(MM_T003_A_OBJ != null)
            {
                if (MM_T003_A_OBJ != null)
                {
                    CursorControl.SetBusyState();
                    string Request = "GET_INFO" + "!@" + AppSessionState.client + "!@" + MM_T003_A_OBJ.comp_code + "!@" + MM_T003_A_OBJ.location_id + "!@" + doc_cat_vm + "!@" + (Utilities.NullIf(MM_T003_A_OBJ.doc_type ?? doc_cat_vm) ?? "") + "!@" + MM_T003_A_OBJ.item_code + "!@" + Utilities.NullIf(MasterEntity.emp_id) + "!@" + Utilities.NullIf(MasterEntity.t_status) + "!@" + Convert.ToDateTime(MasterEntity.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(MasterEntity.to_date).ToString("MM/dd/yyyy");
                    MCTemp = REPO_MC_TEMP.GetDataWithReturnDomainObject<MC_MM_T003>(MCTemp, Request, "MM_T003_BL", "MM", "LoadAll", 0, "");

                    if(MCTemp.STANDARD_LIST.Count > 0)
                    {
                        Views.WIN_001 WIN_OBJ = new Views.WIN_001(MCTemp.STANDARD_LIST);
                        WIN_OBJ.Show();
                    }
                }
            }
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
        }
        private void InsertOrder(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                STD_LIST_BE POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        POPUPEntityObject = MC.ORDER_LIST.Where(x => x.order_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<EPR_T001_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                    }
                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    MM_T003_A_OBJ.order_no = POPUPEntityObject.order_no;
                    MM_T003_A_OBJ.wc_code = POPUPEntityObject.wc_code;
                    if(string.IsNullOrWhiteSpace(MM_T003_A_OBJ.note)) // NOTE: temp solution, remove is standard way found
                    {
                        MM_T003_A_OBJ.note = POPUPEntityObject.title;
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
        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemsEntity.Count > i && ItemsEntity[dgSelectedIndexItem].id == 0)
                {
                    ItemsEntity.RemoveAt(i);
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
                if(REF_OBJECT != null && REF_OBJECT.req_code == "VIEW")
                {
                    List<STD_LIST_BE> STD_LIST_OBJ = new List<STD_LIST_BE>();
                    STD_LIST_OBJ.Add(REF_OBJECT);
                    LoadInitialData(REF_OBJECT.comp_code, REF_OBJECT.location_id);
                    LoadDocumentByDocumentNumber(STD_LIST_OBJ, "DocumentNo");
                }
                else if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");

                    AppSessionState.ViewOtherRecordAllowed = true;
                }
                else
                {
                    MasterEntity.location_id = AppSessionState.OBJ_LOCATION.location_id;
                    MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                    LoadInitialData(MasterEntity.comp_code, MasterEntity.location_id);
                    MasterEntity.location_id = AppSessionState.OBJ_LOCATION.location_id;
                    MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                    DefaultValues();
                    DateTime d = DateTime.UtcNow;
                    d = d.AddMonths(-1);
                    REQUEST_PARA.from_date = d;
                    REQUEST_PARA.to_date = DateTime.UtcNow;
                    REQUEST_PARA.active = true;
                    REQUEST_PARA.location_id = AppSessionState.OBJ_LOCATION.location_id;
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
        public string ConvertDataTableToHTML()
        {
            string html = "<table>";
            //add header row
            html += "<tr bgcolor=#e0e0eb>";
            html += "<td width=5%> <p><strong><span style=color:#000080;> Item Code </span></strong></p> </td>";
            html += "<td width=10%> <p><strong><span style=color:#000080;> Item Name </span></strong></p> </td>";
            html += "<td width=5%> <p><strong><span style=color:#000080;> Quantity </span></strong></p> </td>";
            html += "<td width=5%> <p><strong><span style=color:#000080;> Unit </span></strong></p> </td>";
            html += "<td width=5%> <p><strong><span style=color:#000080;> Unit Price </span></strong></p> </td>";
            html += "</tr>";

            foreach (var item in ItemsEntity)
            {
                html += "<tr bgcolor=#d9e6f2>";
                html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.item_code + "</p></span></strong></p> </td>";
                html += "<td width=10%> <p><strong><span style=color:#000080;> " + item.item_name + "</span></strong></p> </td>";
                html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.qty.ToString() + "</span></strong></p> </td>";
                html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.unit_code + "</span></strong></p> </td>";
                //html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.unit_price.ToString() + "</span></strong></p> </td>";
                html += "<td width=5%> <p><strong><span style=color:#000080;> " + (item.cost.HasValue ? decimal.Round(item.cost.Value, 2).ToString() : "") + "</span></strong></p> </td>";
                html += "</tr>";
            }
            html += "</table>";

            return html;
        }
        private void NotifyMessage(string AlertName, string operation)
        {
            try
            {
                List<NotificationData> objNotifyData = new List<NotificationData>();
                List<NotificationData> objNotifyDataTemp = new List<NotificationData>();
                NotificationData objNotifyDataObject = new NotificationData();
                string xx = ConvertDataTableToHTML();
                objNotifyDataTemp = MC.NOTIFICATION_LIST.Where(x => x.alert_name == AlertName).ToList();
                objNotifyDataTemp[0].CopyPropertiesTo<NotificationData>(objNotifyDataObject);
                objNotifyData.Add(objNotifyDataObject);
                foreach (NotificationData VarData in objNotifyData)
                {
                    List<KeyValuePair<string, string>> kvpList = new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("[EMP]",MasterEntity.emp_name),
                        new KeyValuePair<string, string>("[DOC]", MasterEntity.doc_type_name),
                        new KeyValuePair<string, string>("[OPR]", AppSessionState.EmpName),
                        new KeyValuePair<string, string>("[DOCNO]", MasterEntity.doc_no),
                        new KeyValuePair<string, string>("[Comp]","M/s: " + AppSessionState.CompanyName),
                        new KeyValuePair<string, string>("[TSTS]", MasterEntity.t_display),
                        new KeyValuePair<string, string>("[Attn]",VarData.EmpName),
                        new KeyValuePair<string, string>("[DOCDATE]", MasterEntity.doc_date.ToString()),
                        new KeyValuePair<string, string>("[MODDT]", DateTime.Now.ToString()),
                        new KeyValuePair<string, string>("[PREF]", (MasterEntity.ref_doc_no ?? "").ToString()), //MasterEntity.cust_ref_date.HasValue ? MasterEntity.cust_ref_date.Value.ToString() : string.Empty;
                        new KeyValuePair<string, string>("[ITEM_TABLE]", xx),
                    };

                    foreach (KeyValuePair<string, string> kvp in kvpList)
                    {
                        VarData.subject = VarData.subject.Replace(kvp.Key, kvp.Value);
                        VarData.msg_body = VarData.msg_body.Replace(kvp.Key, kvp.Value);
                    }
                    VarData.cc_mail_id = (VarData.cc_mail_id ?? "") + ";" + (AppSessionState.EmpEmailId ?? "");
                    Task t = MailMessenger.SendMailAsync(AppSessionState.MailAccount, VarData.to_mail_id, VarData.cc_mail_id, VarData.bcc_mail_id, VarData.subject, VarData.msg_body, null);
                }
            }
            catch (Exception ex)
            {
                //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }

        private void InsertDataGridRow_Batch(object InputValue)
        {
            try
            {

                string Request = "";
                STD_ITEM POPUPEntityObject = null;

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
                            POPUPEntityObject = MC.BATCH_LIST.Where(x => x.batch_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.item_code.Equals(MM_T003_A_OBJ.item_code) == true && x.comp_code.Equals(MM_T003_A_OBJ.comp_code ) == true && x.location_id.Equals(MM_T003_A_OBJ.location_id) == true).ToList()[0]; // && x.store_code.Equals(MM_T003_A_OBJ.store_code) == true
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<STD_ITEM>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_ITEM>().ToList()[0];
                    }
                }
                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    if (ItemsEntity.Count > 0 && !string.IsNullOrWhiteSpace(POPUPEntityObject.batch_no))
                    {
                        MM_T003_A_OBJ.batch_no = POPUPEntityObject.batch_no;
                        MM_T003_A_OBJ.store_code = POPUPEntityObject.store_code;
                        MM_T003_A_OBJ.location_id = POPUPEntityObject.location_id;
                        MM_T003_A_OBJ.comp_code = POPUPEntityObject.comp_code;
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

        #endregion

        #region Abstract Method
        protected override void OnCreateAction(InquiryActionResult<MM_T003> result)
        {
            isNewRecord = true;
            MasterEntity = new MM_T003();
            MasterEntity.ValidateAsync().Wait();
            ItemsEntity = new ObservableCollection<MM_T003_A>();
            ItemsEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItemsEntity);
            ItemsEntity.Clear();
            DefaultValues();

            var msg = new NotificationMessage("MM_T003_VM");
            Messenger.Default.Send<NotificationMessage>(msg);
        }
        protected override void OnDiscardAction(InquiryActionResult<MM_T003> result)
        { }
        protected override void OnFevoriteAction(InquiryActionResult<MM_T003> result)
        { }
        protected override void OnFlipAction(InquiryActionResult<MM_T003> result)
        { }
        protected override void OnHelpAction(InquiryActionResult<MM_T003> result)
        { }
        protected override void OnPrintAction(InquiryActionResult<MM_T003> result)
        {
            try
            {
                CursorControl.SetBusyState();
                ReportManager ReportManager = new ReportManager();
                string ReportName = "";

                object[] objDataSource = new object[5];
                string[] objDataSourceName = new string[5];

                var CmpResult = AppSessionState.COMPANY_LIST.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[0] = CmpResult;

                var Result = AppSessionState.LOCATION_LIST.Where(loc => loc.location_id == MasterEntity.location_id).ToList();
                objDataSource[1] = Result;

              
                if (MC.MASTER_ENTITY_LIST != null)
                {
                    if (MC.MASTER_ENTITY_LIST.Count > 0)
                    {
                        MC.MASTER_ENTITY_LIST.Clear();
                        MC.MASTER_ENTITY_LIST.Add(MasterEntity);
                    }
                    else
                    {
                        MC.MASTER_ENTITY_LIST.Add(_MasterEntity);
                    }
                }
                objDataSource[2] = MC.MASTER_ENTITY_LIST;
                objDataSource[3] = ItemsEntity;
                objDataSource[4] = ReleaseList;

                objDataSourceName[0] = "dsCompany";
                objDataSourceName[1] = "dsLocation";
                objDataSourceName[2] = "dsMaster";
                objDataSourceName[3] = "dsItems";
                objDataSourceName[4] = "dsRS";

                if (MC.DOC_TYPE_LIST != null)
                {
                    if (MC.DOC_TYPE_LIST.Count > 0)
                    {
                        DOC_TYPE_OBJ = (from o in MC.DOC_TYPE_LIST where o.doc_cat == doc_cat_vm && o.doc_type == MasterEntity.doc_type select o).FirstOrDefault();
                        if (DOC_TYPE_OBJ.ind_digital == "0")
                        {
                            ReportName = DOC_TYPE_OBJ.report_name.Split(',')[1];
                        }
                        else
                        {
                            ReportName = DOC_TYPE_OBJ.report_name.Split(',')[0];
                        }
                    }
                }

                string ReportDisplayName = (MasterEntity.emp_name ?? "") + "_" + MasterEntity.doc_no + "_" + MasterEntity.doc_date.Value.ToShortDateString();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\REPORTS_STD\\TXN\\" + ReportName, getParametersList(null), ReportDisplayName);
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private Dictionary<string, string> getParametersList(string paraValue)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("prepare_by", AppSessionState.Name);
                //result.Add("PrintOption", paraValue);
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
            return result;
        }
        protected override void OnRemoveAction(InquiryActionResult<MM_T003> result)
        {
            try
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Delete Changes";
                showMessageService.Text =
                    String.Format(
                        "This record will be Deleted forever '{0}'",
                            this.Title);
                if (showMessageService.ShowMessage() == DialogResult.Ok)
                {
                    this.MasterEntity.EndEdit();
                    string response = REPO.Delete(MasterEntity.doc_no, "MM_T003_BL", "MM");
                    MasterEntity = new MM_T003();
                    ItemsEntity = new ObservableCollection<MM_T003_A>();
                    BACKFLIP_COLLECTION.Refresh();
                    isNewRecord = true;
                }
            }
            catch (Exception ex)
            {
            }
        }
        protected override void OnSaveAction(InquiryActionResult<MM_T003> result)
        {
            try
            {
                CursorControl.SetBusyState();
                if (Validation() == true)
                {
                    MasterEntity.XDOC_A = obj.ObjectToXML(ItemsEntity);
                    Logging();
                    this.MasterEntity.EndEdit();
                    if (isNewRecord == true)
                    {
                        MasterEntity = REPO.SaveWithReturnDomainObject<MM_T003>(MasterEntity, "MM_T003_BL", "MM");
                        if (MasterEntity.doc_no != " " || MasterEntity.doc_no != null)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Data Saved Successfully");
                            showMessageService.ShowMessage();
                        }
                        if (MasterEntity.doc_no != null && MC.NOTIFICATION_LIST.FindIndex(f => f.alert_name == "OnInsert") >= 0)
                        {
                            NotifyMessage("OnInsert", "Created");
                        }
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = REPO.UpdateWithReturnDomainObject<MM_T003>(MasterEntity, "MM_T003_BL", "MM");
                        if (MasterEntity.doc_no != " " || MasterEntity.doc_no != null)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Data Update Successfully");
                            showMessageService.ShowMessage();
                        }
                    }
                    
                    SetBusinessEntitiesAfterLoad("Save", "");
                    isNewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 
                }
            }
            catch (Exception ex)
            {
            }
        }
        
        protected override void OnDocumentAction()
        { }
        protected override void OnRefreshCommand(InquiryActionResult<MM_T003> result)
        {
            
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MM_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MM_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MM_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MM_T003> result)
        {
            throw new NotImplementedException();
        }

        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                MasterEntity.ts_code = ts_code_vm;
                if (MasterEntity.XDOC_A != null)
                {
                    ItemsEntity.Clear();
                    ItemsEntity = (ObservableCollection<MM_T003_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_A, MC.ITEMS_ENTITY_LIST);
                    MasterEntity = MasterEntity;
                    ReleaseList = MCTemp.WORKFLOW_LIST;
                }
                else
                {
                    MC.ITEMS_ENTITY_LIST = new ObservableCollection<MM_T003_A>();
                }
               
            }
            catch (Exception ex)
            {
            }
        }
        #endregion
        #region Filter
        private string _FLTR_STR_BACKFLIP;
        public string FLTR_STR_BACKFLIP
        {
            get { return _FLTR_STR_BACKFLIP; }
            set
            {
                _FLTR_STR_BACKFLIP = value;
                RaisePropertyChanged("FLTR_STR_BACKFLIP");
                FLTR_COLL_BACKFLIP();
            }
        }
        private void FLTR_COLL_BACKFLIP()
        {
            if (BACKFLIP_COLLECTION != null)
            {
                BACKFLIP_COLLECTION.Refresh();
            }
        }
        public bool FLTR_BACKFLIP(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FLTR_STR_BACKFLIP))
                {
                    return (data.doc_no != null && (data.doc_no ?? "").ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.doc_date != null && data.doc_date.ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.party_code != null && (data.party_code ?? "").ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.party_name != null && (data.party_name ?? "").ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.doc_cat != null && (data.ref_doc_cat ?? "").ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.mov_tp != null && (data.mov_tp ?? "").ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.mov_tp_name != null && (data.mov_tp_name ?? "").ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.location_id != null && (data.location_id ?? "").ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.comp_code != null && (data.comp_code ?? "").ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.post_date != null && data.post_date.ToString().ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.emp_name != null && (data.emp_name ?? "").ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower())
                       );
                }
                return true;
            }
            return false;
        }


        
        #endregion

    }
}
