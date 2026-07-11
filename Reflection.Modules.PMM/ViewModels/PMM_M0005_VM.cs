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
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using Reflection.BusinessEntity;
using Reflection.Presentation.Services.Convertors;
using Reflection.Presentation.Services;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Reflection.BusinessEntity.ADM;
using System.Collections.Specialized;

namespace Reflection.Modules.PMM.ViewModels
{
    public class PMM_M0005_VM : WorkspaceViewModel<STD_BE_A>
    {
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string doc_cat_vm { get; set; }
        IShowMessageViewService sms;
        WebServiceRepository<List<STD_BE_A>> repository = new WebServiceRepository<List<STD_BE_A>>();
        WebServiceRepository<MC_GEN_BE> repository_MC = new WebServiceRepository<MC_GEN_BE>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region
        //public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(PMM_M0005_VM));
        //public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }
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
        
        private AutoSuggestTextViewModel<dynamic> _AS_OBJ_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_OBJ_TYPE
        {
            get { return _AS_OBJ_TYPE; }
            set { _AS_OBJ_TYPE = value; RaisePropertyChanged("AS_OBJ_TYPE"); }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_EQUIP_CAT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_EQUIP_CAT
        {
            get { return _AS_EQUIP_CAT; }
            set { _AS_EQUIP_CAT = value; RaisePropertyChanged("AS_EQUIP_CAT"); }
        }
       
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
                    if (SourceName == "obj_type")
                    { AS_DEFAULT = AS_OBJ_TYPE; }
                    else if (SourceName == "equip_cat")
                    { AS_DEFAULT = AS_EQUIP_CAT; }
                }
            }
        }

        #endregion

        #region Declarations       

        private MC_GEN_BE _MC;
        public MC_GEN_BE MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MC_GEN_BE _MC_TEMP;
        public MC_GEN_BE MC_TEMP
        {
            get { return _MC_TEMP; }
            set { _MC_TEMP = value; RaisePropertyChanged("MC_TEMP"); }
        }

        private STD_BE_A _StandardEntity;
        public STD_BE_A StandardEntity
        {
            get
            { return _StandardEntity; }
            set
            {
                _StandardEntity = value;
                RaisePropertyChanged("StandardEntity");
            }
        }
        private ObservableCollection<STD_BE_A> _StandardEntityList;
        public ObservableCollection<STD_BE_A> StandardEntityList
        {
            get
            {
                return _StandardEntityList;
            }
            set
            {
                if (_StandardEntityList != value)
                {
                    _StandardEntityList = value;
                    _StandardEntityList.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("StandardEntityList");
                }
            }
        }

        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> cmdSelectionChanged_ITEM { get; private set; }
        #endregion

        #region Constructor
        public PMM_M0005_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            StandardEntity = new STD_BE_A();
            StandardEntityList = new ObservableCollection<STD_BE_A>();
            MC = new MC_GEN_BE();
            MC_TEMP = new MC_GEN_BE();
            sms = this.GetViewService<IShowMessageViewService>();
            cmdSelectionChanged_ITEM = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_ITEM(items); });
            StandardEntityList.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            LoadInitialData();
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MC_GEN_BE>(MC, Request, "PMM_M0005_BL", "PMM", "LOAD_INI", 0, "");

                AS_DEFAULT = new AutoSuggestTextViewModel<dynamic>(MC.INCOTERM_LIST, TheFilter, SuggestedValue, "incoterms", "incoterm", true);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).obj_type);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).obj_type ?? "").ToString().ToLower().Contains(prefix) ||
                                           (((STD_LIST_BE)o).obj_name ?? "").ToString().ToLower().Contains(prefix);
                AS_OBJ_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.OBJECT_TYPE_LIST, TheFilter, SuggestedValue, "obj_type", "obj_type", true);
                AS_OBJ_TYPE.AutoSuggestVM.IsEmptyValueAllowed = true; AS_OBJ_TYPE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).cat_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).cat_code ?? "").ToString().ToLower().Contains(prefix) ||
                                           (((STD_LIST_BE)o).cat_name ?? "").ToString().ToLower().Contains(prefix);
                AS_EQUIP_CAT = new AutoSuggestTextViewModel<dynamic>(MC.CATEGORY_LIST, TheFilter, SuggestedValue, "equip_cat", "cat_code", true);
                AS_EQUIP_CAT.AutoSuggestVM.IsEmptyValueAllowed = true; AS_EQUIP_CAT.AutoSuggestVM.IsFreeTextAllowed = false;

                StandardEntityList = MC.STD_ENTITY_COL;
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private bool Validation()
        {
            foreach (var o in StandardEntityList)
            {
                int flag = 0;
                if (o.selected == true)
                {
                    foreach (var p in StandardEntityList)
                    {
                        if (o.obj_type == p.obj_type && o.equip_cat == p.equip_cat)
                        {
                            flag++;
                        }
                    }
                    if (flag > 1)
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Duplicate Record not allowed for the Country {0} and Product Group {1} and Company {2}", o.ctry_code, o.group_code, o.comp_code); sms.ShowMessage();
                        return false;
                    }
                    if (string.IsNullOrWhiteSpace(o.obj_type))
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Object Type required for the Equipment Category {0} ", o.equip_cat); sms.ShowMessage();
                        return false;
                    }
                    if (string.IsNullOrWhiteSpace(o.equip_cat))
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Equipment Category required for the object Type ", o.obj_type); sms.ShowMessage();
                        return false;
                    }

                }
            }
            return true;
        }
        private void SelectionChanged_ITEM(object InputValue)
        {
            try
            {
                StandardEntity = (STD_BE_A)InputValue;
            }
            catch (Exception ex) { }
        }
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (STD_BE_A item in e.NewItems)
                    {
                        item.client = AppSessionState.client;
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        item.selected = true;
                        item.userid = AppSessionState.UserID;
                        item.ts_code = ts_code_vm;
                        item.active = "1";
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Replace)
                { }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                { }
                if (e.Action == NotifyCollectionChangedAction.Move)
                { }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        #endregion

        #region Abstract Command Actions
        protected override void OnSaveAction(InquiryActionResult<STD_BE_A> result)
        {
            try
            {
                List<STD_BE_A> RequestList = new List<STD_BE_A>();
                foreach (STD_BE_A item in StandardEntityList)
                {
                    if (item.selected == true)
                    {
                        RequestList.Add(item);
                    }
                }
                if (Validation() == true)
                {
                    string strReturn = repository.Save<List<STD_BE_A>>(RequestList, "PMM_M0005_BL", "PMM");

                    if (RequestList != null)
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Record Saved Successfully!", this.Title); sms.ShowMessage();
                    }
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        protected override void OnDocumentAction()
        { }
        protected override void OnRefreshCommand(InquiryActionResult<STD_BE_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<STD_BE_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<STD_BE_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<STD_BE_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<STD_BE_A> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<STD_BE_A> result)
        {
            StandardEntity = new STD_BE_A();
        }
        protected override void OnRemoveAction(InquiryActionResult<STD_BE_A> result)
        {
            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Delete Changes"; sms.Text = String.Format("This record will be Deleted forever", this.Title);
            if (sms.ShowMessage() == DialogResult.Ok)
            {
                //string response = repository.Delete(MasterEntity.SrNo, "FormReceivedFrmCustomer", "CRM");  
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<STD_BE_A> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<STD_BE_A> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<STD_BE_A> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<STD_BE_A> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<STD_BE_A> result)
        {

        }

        #endregion

        #region Filters

        #region Filters For DataGrid   
        private ICollectionView _ITEMS_COLLECTION_VIVE;
        public ICollectionView ITEMS_COLLECTION_VIVE
        {
            get { return _ITEMS_COLLECTION_VIVE; }
            set { _ITEMS_COLLECTION_VIVE = value; RaisePropertyChanged("ITEMS_COLLECTION_VIVE"); }
        }

        private string _FLTR_STRING_VIEW;
        public string FLTR_STRING_VIEW
        {
            get { return _FLTR_STRING_VIEW; }
            set
            {
                if (_FLTR_STRING_VIEW != value)
                {
                    _FLTR_STRING_VIEW = value;
                    RaisePropertyChanged("FLTR_STRING_VIEW");
                    FilterCollection();
                }
            }
        }
        private void FilterCollection()
        {
            if (_ITEMS_COLLECTION_VIVE != null)
            {
                _ITEMS_COLLECTION_VIVE.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as STD_BE_A;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FLTR_STRING_VIEW))
                {
                    return (data.obj_type != null && (data.obj_type ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.obj_name != null && (data.obj_name ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.cat_name != null && (data.cat_name ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.equip_cat != null && (data.equip_cat ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.fun_loc != null && (data.fun_loc ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) 
                            );
                }
                return true;
            }
            return false;
        }



        #endregion

        #endregion
    }

}





